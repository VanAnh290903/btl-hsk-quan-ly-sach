
namespace BTL_HSK_QLS.Table
{
    partial class QLNhanVien
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
            this.components = new System.ComponentModel.Container();
            this.grBoxNhapLieu = new System.Windows.Forms.GroupBox();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.txtSDTNV = new System.Windows.Forms.TextBox();
            this.txtTuoiNV = new System.Windows.Forms.DateTimePicker();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnNhap = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgrwNhanVien = new System.Windows.Forms.DataGridView();
            this.errorloiQLNV = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.grBoxNhapLieu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrwNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorloiQLNV)).BeginInit();
            this.SuspendLayout();
            // 
            // grBoxNhapLieu
            // 
            this.grBoxNhapLieu.Controls.Add(this.rdbNu);
            this.grBoxNhapLieu.Controls.Add(this.rdbNam);
            this.grBoxNhapLieu.Controls.Add(this.txtSDTNV);
            this.grBoxNhapLieu.Controls.Add(this.txtTuoiNV);
            this.grBoxNhapLieu.Controls.Add(this.txtTenNV);
            this.grBoxNhapLieu.Controls.Add(this.label4);
            this.grBoxNhapLieu.Controls.Add(this.label3);
            this.grBoxNhapLieu.Controls.Add(this.lblSex);
            this.grBoxNhapLieu.Controls.Add(this.lblName);
            this.grBoxNhapLieu.Controls.Add(this.txtMaNV);
            this.grBoxNhapLieu.Controls.Add(this.lblMaNV);
            this.grBoxNhapLieu.Location = new System.Drawing.Point(21, 17);
            this.grBoxNhapLieu.Name = "grBoxNhapLieu";
            this.grBoxNhapLieu.Size = new System.Drawing.Size(332, 440);
            this.grBoxNhapLieu.TabIndex = 0;
            this.grBoxNhapLieu.TabStop = false;
            this.grBoxNhapLieu.Text = "Nhập liệu";
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(176, 207);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(47, 21);
            this.rdbNu.TabIndex = 10;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;
            this.rdbNu.CheckedChanged += new System.EventHandler(this.rdbNu_CheckedChanged);
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(92, 207);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(58, 21);
            this.rdbNam.TabIndex = 9;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // txtSDTNV
            // 
            this.txtSDTNV.Location = new System.Drawing.Point(38, 344);
            this.txtSDTNV.Name = "txtSDTNV";
            this.txtSDTNV.Size = new System.Drawing.Size(250, 22);
            this.txtSDTNV.TabIndex = 8;
            // 
            // txtTuoiNV
            // 
            this.txtTuoiNV.Location = new System.Drawing.Point(105, 252);
            this.txtTuoiNV.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.txtTuoiNV.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtTuoiNV.Name = "txtTuoiNV";
            this.txtTuoiNV.Size = new System.Drawing.Size(200, 22);
            this.txtTuoiNV.TabIndex = 7;
            this.txtTuoiNV.Value = new System.DateTime(2023, 4, 17, 16, 36, 1, 0);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(29, 168);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(259, 22);
            this.txtTenNV.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số điện thoại: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày Sinh";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(26, 206);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(60, 17);
            this.lblSex.TabIndex = 3;
            this.lblSex.Text = "Giới tính";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 136);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Tên nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(29, 69);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(259, 22);
            this.txtMaNV.TabIndex = 1;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(26, 37);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(93, 17);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnTaiLai);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnNhap);
            this.groupBox1.Location = new System.Drawing.Point(21, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(213, 159);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 31);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(213, 107);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 31);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(213, 58);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 31);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(50, 159);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 31);
            this.btnTaiLai.TabIndex = 2;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(50, 107);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 31);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(50, 58);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 31);
            this.btnNhap.TabIndex = 0;
            this.btnNhap.Text = "Xử lý";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgrwNhanVien);
            this.groupBox2.Location = new System.Drawing.Point(379, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1303, 693);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Nhân Viên";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dtgrwNhanVien
            // 
            this.dtgrwNhanVien.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgrwNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrwNhanVien.Location = new System.Drawing.Point(23, 40);
            this.dtgrwNhanVien.Name = "dtgrwNhanVien";
            this.dtgrwNhanVien.RowHeadersWidth = 51;
            this.dtgrwNhanVien.RowTemplate.Height = 24;
            this.dtgrwNhanVien.Size = new System.Drawing.Size(1280, 653);
            this.dtgrwNhanVien.TabIndex = 0;
            this.dtgrwNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrwNhanVien_CellClick);
            this.dtgrwNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrwNhanVien_CellContentClick_1);
            // 
            // errorloiQLNV
            // 
            this.errorloiQLNV.ContainerControl = this;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(797, 755);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(345, 37);
            this.btnBaoCao.TabIndex = 3;
            this.btnBaoCao.Text = "Báo cáo danh sách nhân viên";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // QLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1791, 824);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grBoxNhapLieu);
            this.MinimumSize = new System.Drawing.Size(1511, 731);
            this.Name = "QLNhanVien";
            this.Text = "QLNhanVien";
            this.Load += new System.EventHandler(this.QLNhanVien_Load);
            this.grBoxNhapLieu.ResumeLayout(false);
            this.grBoxNhapLieu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrwNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorloiQLNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxNhapLieu;
        private System.Windows.Forms.DateTimePicker txtTuoiNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtSDTNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgrwNhanVien;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.ErrorProvider errorloiQLNV;
        private System.Windows.Forms.Button btnBaoCao;
    }
}