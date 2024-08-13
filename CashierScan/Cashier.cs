using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QRCoder;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;

namespace CashierScan
{
    public partial class Cashier : Form
    {
        string connectionString = "server=localhost;database=cashier_scan;uid=root;pwd=;";
        private HttpListener listener;
        private Thread listenerThread;

        public Cashier()
        {
            InitializeComponent();
            LoadData();
            StartHttpServer();

            gridScan.Columns.Add("Name", "Name");
            gridScan.Columns.Add("Code", "Code");

            gridScan.Columns.Add("Timestamp", "Timestamp"); // Contoh kolom baru
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM goods";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    gridGoods.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void GenerateQRCode(string name, string code)
        {
            var item = new
            {
                Name = name,
                Code = code,
            };

            string qrText = JsonConvert.SerializeObject(item);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            qrBox.SizeMode = PictureBoxSizeMode.StretchImage;
            qrBox.Image = qrCodeImage;
        }

        public class ScannedItem
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }

        private void StartHttpServer()
        {
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add("http://192.168.1.150:8000/");
                listener.Start();
                Console.WriteLine("Server started, listening on http://192.168.1.150:8000/");
                listenerThread = new Thread(Listen);
                listenerThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting HTTP server: " + ex.Message);
            }
        }

        private void Listen()
        {
            try
            {
                while (listener.IsListening)
                {
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;

                    // Add CORS headers
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
                    response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

                    if (request.HttpMethod == "OPTIONS")
                    {
                        response.StatusCode = 204;
                        response.Close();
                        continue;
                    }

                    if (request.HttpMethod == "POST" && request.HasEntityBody)
                    {
                        using (var body = request.InputStream)
                        using (var reader = new StreamReader(body, request.ContentEncoding))
                        {
                            var json = reader.ReadToEnd();
                            var item = JsonConvert.DeserializeObject<ScannedItem>(json);

                            // Tambahkan timestamp
                            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            Invoke(new Action(() =>
                            {
                                gridScan.Rows.Add(item.Name, item.Code, timestamp); // Tambahkan timestamp
                            }));
                        }
                    }

                    response.StatusCode = 200;
                    response.Close();
                }
            }
            catch (HttpListenerException hle)
            {
                Console.WriteLine("HttpListenerException: " + hle.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }


        private void Cashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null && listener.IsListening)
            {
                listener.Stop();
            }

            if (listenerThread != null && listenerThread.IsAlive)
            {
                listenerThread.Abort();
            }
        }

        // Implementasi event handler untuk tombol-tombol lainnya...
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textName.Text;
                string code = textCode.Text;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO goods (name, code) VALUES (@name, @code)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@code", code);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data successfully inserted!");
                            LoadData();

                            // Generate QR Code after successful data insertion
                            GenerateQRCode(name, code);
                        }
                        else
                        {
                            MessageBox.Show("Data insertion failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridGoods.SelectedRows.Count > 0)
                {
                    string selectedCode = gridGoods.SelectedRows[0].Cells["code"].Value.ToString();
                    string name = textName.Text;
                    string code = textCode.Text;

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE goods SET name = @name, code = @code WHERE code = @selectedCode";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@code", code);
                            cmd.Parameters.AddWithValue("@selectedCode", selectedCode);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data successfully updated!");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Data update failed.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a record to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridGoods.SelectedRows.Count > 0)
                {
                    string selectedCode = gridGoods.SelectedRows[0].Cells["code"].Value.ToString();

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM goods WHERE code = @selectedCode";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@selectedCode", selectedCode);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data successfully deleted!");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Data deletion failed.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a record to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void gridGoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = gridGoods.Rows[e.RowIndex];

                string name = row.Cells["name"].Value?.ToString();
                string code = row.Cells["code"].Value?.ToString();

                textName.Text = name;
                textCode.Text = code;

                GenerateQRCode(name, code);
            }
        }
    }
}
