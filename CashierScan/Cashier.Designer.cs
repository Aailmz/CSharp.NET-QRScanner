namespace CashierScan
{
    partial class Cashier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.qrBox = new System.Windows.Forms.PictureBox();
            this.textCode = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.gridGoods = new System.Windows.Forms.DataGridView();
            this.gridScan = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Name);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.qrBox);
            this.panel1.Controls.Add(this.textCode);
            this.panel1.Controls.Add(this.textName);
            this.panel1.Controls.Add(this.gridGoods);
            this.panel1.Controls.Add(this.gridScan);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 425);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Code";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(3, 5);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(42, 13);
            this.Name.TabIndex = 8;
            this.Name.Text = "Cashier";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(4, 223);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(185, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gold;
            this.btnEdit.Location = new System.Drawing.Point(4, 167);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(185, 34);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAdd.Location = new System.Drawing.Point(4, 105);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(185, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // qrBox
            // 
            this.qrBox.Location = new System.Drawing.Point(195, 105);
            this.qrBox.Name = "qrBox";
            this.qrBox.Size = new System.Drawing.Size(151, 152);
            this.qrBox.TabIndex = 4;
            this.qrBox.TabStop = false;
            // 
            // textCode
            // 
            this.textCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textCode.Location = new System.Drawing.Point(-1, 66);
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(346, 20);
            this.textCode.TabIndex = 3;
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textName.Location = new System.Drawing.Point(0, 21);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(346, 20);
            this.textName.TabIndex = 2;
            // 
            // gridGoods
            // 
            this.gridGoods.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGoods.Location = new System.Drawing.Point(0, 263);
            this.gridGoods.Name = "gridGoods";
            this.gridGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGoods.Size = new System.Drawing.Size(346, 162);
            this.gridGoods.TabIndex = 1;
            this.gridGoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGoods_CellClick);
            // 
            // gridScan
            // 
            this.gridScan.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridScan.Location = new System.Drawing.Point(362, -1);
            this.gridScan.Name = "gridScan";
            this.gridScan.Size = new System.Drawing.Size(413, 426);
            this.gridScan.TabIndex = 0;
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name.Text = "Cashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridGoods;
        private System.Windows.Forms.DataGridView gridScan;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox qrBox;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Name;
    }
}