
namespace BTL_HSK_QLS.Table
{
    partial class QLDSHoaDon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnNhapDL = new System.Windows.Forms.Button();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnXoaHD = new System.Windows.Forms.Button();
            this.btnAddHD = new System.Windows.Forms.Button();
            this.rbdChuaThanhToan = new System.Windows.Forms.RadioButton();
            this.rdbThanhToan = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSuaHD = new System.Windows.Forms.Button();
            this.btnTimKiemHD = new System.Windows.Forms.Button();
            this.btnXemHDCT = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSHoaDon = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTaiLai);
            this.groupBox1.Controls.Add(this.btnNhapDL);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnInHD);
            this.groupBox1.Controls.Add(this.btnXoaHD);
            this.groupBox1.Controls.Add(this.btnAddHD);
            this.groupBox1.Controls.Add(this.rbdChuaThanhToan);
            this.groupBox1.Controls.Add(this.rdbThanhToan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSuaHD);
            this.groupBox1.Controls.Add(this.btnTimKiemHD);
            this.groupBox1.Controls.Add(this.btnXemHDCT);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 639);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(55, 555);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(157, 40);
            this.btnTaiLai.TabIndex = 12;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnNhapDL
            // 
            this.btnNhapDL.Location = new System.Drawing.Point(15, 247);
            this.btnNhapDL.Name = "btnNhapDL";
            this.btnNhapDL.Size = new System.Drawing.Size(105, 40);
            this.btnNhapDL.TabIndex = 11;
            this.btnNhapDL.Text = "Nhập";
            this.btnNhapDL.UseVisualStyleBackColor = true;
            this.btnNhapDL.Click += new System.EventHandler(this.btnNhapDL_Click);
            // 
            // txtMaHD
            // 
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(16, 63);
            this.txtMaHD.Multiline = true;
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(145, 29);
            this.txtMaHD.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã hóa đơn";
            // 
            // btnInHD
            // 
            this.btnInHD.Location = new System.Drawing.Point(53, 491);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(157, 40);
            this.btnInHD.TabIndex = 8;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = true;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // btnXoaHD
            // 
            this.btnXoaHD.Location = new System.Drawing.Point(146, 247);
            this.btnXoaHD.Name = "btnXoaHD";
            this.btnXoaHD.Size = new System.Drawing.Size(105, 40);
            this.btnXoaHD.TabIndex = 7;
            this.btnXoaHD.Text = "Xóa ";
            this.btnXoaHD.UseVisualStyleBackColor = true;
            this.btnXoaHD.Click += new System.EventHandler(this.btnXoaHD_Click);
            // 
            // btnAddHD
            // 
            this.btnAddHD.Location = new System.Drawing.Point(53, 436);
            this.btnAddHD.Name = "btnAddHD";
            this.btnAddHD.Size = new System.Drawing.Size(157, 40);
            this.btnAddHD.TabIndex = 6;
            this.btnAddHD.Text = "Thêm hóa đơn";
            this.btnAddHD.UseVisualStyleBackColor = true;
            this.btnAddHD.Click += new System.EventHandler(this.btnAddHD_Click);
            // 
            // rbdChuaThanhToan
            // 
            this.rbdChuaThanhToan.AutoSize = true;
            this.rbdChuaThanhToan.Location = new System.Drawing.Point(16, 189);
            this.rbdChuaThanhToan.Name = "rbdChuaThanhToan";
            this.rbdChuaThanhToan.Size = new System.Drawing.Size(134, 21);
            this.rbdChuaThanhToan.TabIndex = 5;
            this.rbdChuaThanhToan.TabStop = true;
            this.rbdChuaThanhToan.Text = "Chưa thanh toán";
            this.rbdChuaThanhToan.UseVisualStyleBackColor = true;
            // 
            // rdbThanhToan
            // 
            this.rdbThanhToan.AutoSize = true;
            this.rdbThanhToan.Location = new System.Drawing.Point(18, 150);
            this.rdbThanhToan.Name = "rdbThanhToan";
            this.rdbThanhToan.Size = new System.Drawing.Size(119, 21);
            this.rdbThanhToan.TabIndex = 4;
            this.rdbThanhToan.TabStop = true;
            this.rdbThanhToan.Text = "Đã thanh toán";
            this.rdbThanhToan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trạng thái";
            // 
            // btnSuaHD
            // 
            this.btnSuaHD.Location = new System.Drawing.Point(146, 314);
            this.btnSuaHD.Name = "btnSuaHD";
            this.btnSuaHD.Size = new System.Drawing.Size(105, 40);
            this.btnSuaHD.TabIndex = 2;
            this.btnSuaHD.Text = "Sửa";
            this.btnSuaHD.UseVisualStyleBackColor = true;
            this.btnSuaHD.Click += new System.EventHandler(this.btnSuaHD_Click);
            // 
            // btnTimKiemHD
            // 
            this.btnTimKiemHD.Location = new System.Drawing.Point(15, 314);
            this.btnTimKiemHD.Name = "btnTimKiemHD";
            this.btnTimKiemHD.Size = new System.Drawing.Size(105, 40);
            this.btnTimKiemHD.TabIndex = 1;
            this.btnTimKiemHD.Text = "Tìm kiếm";
            this.btnTimKiemHD.UseVisualStyleBackColor = true;
            this.btnTimKiemHD.Click += new System.EventHandler(this.btnTimKiemHD_Click);
            // 
            // btnXemHDCT
            // 
            this.btnXemHDCT.Location = new System.Drawing.Point(55, 380);
            this.btnXemHDCT.Name = "btnXemHDCT";
            this.btnXemHDCT.Size = new System.Drawing.Size(155, 40);
            this.btnXemHDCT.TabIndex = 0;
            this.btnXemHDCT.Text = "Xem chi tiết";
            this.btnXemHDCT.UseVisualStyleBackColor = true;
            this.btnXemHDCT.Click += new System.EventHandler(this.btnXemHDCT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSHoaDon);
            this.groupBox2.Location = new System.Drawing.Point(281, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1057, 598);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hóa đơn";
            // 
            // dgvDSHoaDon
            // 
            this.dgvDSHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSHoaDon.Location = new System.Drawing.Point(3, 18);
            this.dgvDSHoaDon.Name = "dgvDSHoaDon";
            this.dgvDSHoaDon.RowHeadersWidth = 51;
            this.dgvDSHoaDon.RowTemplate.Height = 24;
            this.dgvDSHoaDon.Size = new System.Drawing.Size(1051, 577);
            this.dgvDSHoaDon.TabIndex = 0;
            this.dgvDSHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHoaDon_CellClick);
            this.dgvDSHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHoaDon_CellContentClick);
            // 
            // QLDSHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 663);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QLDSHoaDon";
            this.Text = "QLDSHoaDon";
            this.Load += new System.EventHandler(this.QLDSHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnTimKiemHD;
        private System.Windows.Forms.Button btnXemHDCT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDSHoaDon;
        private System.Windows.Forms.Button btnSuaHD;
        private System.Windows.Forms.RadioButton rbdChuaThanhToan;
        private System.Windows.Forms.RadioButton rdbThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaHD;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNhapDL;
        private System.Windows.Forms.Button btnAddHD;
        private System.Windows.Forms.Button btnTaiLai;
    }
}