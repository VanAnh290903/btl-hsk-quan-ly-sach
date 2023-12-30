using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_QLS.DAO;
using BTL_HSK_QLS.Entities;

namespace BTL_HSK_QLS.Table
{
    public partial class QLHoaDonChiTiet : Form
    {
        List<Sach> sachlistDaChon = new List<Sach>();
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();
        private HoaDon hoaDon = new HoaDon();
        decimal total = 0;

        public QLHoaDonChiTiet()
        {
            InitializeComponent();

        }
        private void QLHoaDonChiTiet_Load(object sender, EventArgs e)
        {
            hoaDon.sMaHD = "HD" + GenerateRandomString(8);
            hoaDon.sMaNV = Properties.Settings.Default.MaNV;
            hoaDon.dNgayLap = DateTime.Now;
            txtMaHD.Text = hoaDon.sMaHD;
            txtNhanVien.Text = Properties.Settings.Default.TenNV;
            loadKhachHang();
        }
        private void btnThemKHHoaDon_Click(object sender, EventArgs e)
        {
            // Hiển thị form nhập thông tin khách hàng
            QLKhachHang formKhachHang = new QLKhachHang();
            formKhachHang.ShowDialog();

            MessageBox.Show("Thêm khách hàng thành công.");
            loadKhachHang();
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            //cbbKhachHang.Enabled = false;
            tablePanel.RowCount++;
            tablePanel.AutoSize = true;
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));



            // Tạo 1 TextBox và 1 ComboBox mới.
            var comboBox = new ComboBox();

            comboBox.DisplayMember = "sTenSach";
            comboBox.ValueMember = "sMaSach";

            List<Sach> saches = hoaDonDAO.getSach();
            saches.Insert(0, new Sach() { sMaSach = "", sTenSach = "" });
            comboBox.DataSource = saches;

            var textBox = new TextBox();
            var textBox2 = new TextBox();


            var laber = new Label();
            laber.Text = "0 đ";
            //var slSach = new Label();
            //slSach.Text = "0";
            int soLuongSachHienTai = 0;
            comboBox.SelectedIndexChanged += (sender2, e2) => // chọn một dòng nào đó trên combobox
            {
                Sach sach = (Sach)comboBox.SelectedItem; // quyển sách chọn

                if (sach.sMaSach.Equals("")) return;

                Sach sachDaChon = sachlistDaChon.FirstOrDefault(x => x.sMaSach == sach.sMaSach); //nếu lấy đc dữ liệu nghĩa là quyển sách đó đã đc chọn 

                if (sachDaChon != null)
                {
                    MessageBox.Show("Quyển sách đã được chọn, vui lòng chọn lại");
                    comboBox.SelectedIndex = 0;
                    return;
                }
                sachDaChon = (Sach)comboBox.SelectedItem; // đưa
                sachlistDaChon.Remove(sachDaChon);
                sachlistDaChon.Add(sachDaChon);

                // Lấy số lượng sách hiện tại từ giá trị đã chọn trong ComboBox
                Sach selectedSach = (Sach)comboBox.SelectedItem;
                soLuongSachHienTai = selectedSach.iSoLuongTrongKho;

                // Kiểm tra nếu số lượng nhập vào lớn hơn số lượng sách hiện tại thì cảnh báo
                if (decimal.TryParse(textBox.Text, out decimal result) && result > soLuongSachHienTai)
                {
                    MessageBox.Show("Số lượng sách nhập vào không được vượt quá số lượng sách hiện tại. Sô lượng sách còn lại là " + soLuongSachHienTai);
                    textBox.Text = "";
                    textBox.Focus();
                }
            };
            // Khai báo các biến để lưu giá trị của hai TextBox trên hàng
            decimal soLuong = 0;
            decimal donGia = 0;

            // Tạo sự kiện TextChanged cho TextBox số lượng
            textBox.TextChanged += (sender2, e2) =>
            {
                // Kiểm tra xem giá trị của TextBox có phải là số hay không
                if (decimal.TryParse(textBox.Text, out decimal result))
                {
                    soLuong = result;
                    if (soLuong > soLuongSachHienTai)
                    {
                        MessageBox.Show("Số lượng sách nhập vào không được vượt quá số lượng sách hiện tại. Sô lượng sách còn lại là " + soLuongSachHienTai);
                        textBox.Text = "";

                    }
                    // Tính toán và hiển thị giá trị trên Label
                    decimal thanhTien = soLuong * donGia;
                    laber.Text = string.Format("{0:#,##0} đ", thanhTien);
                    tongtien();
                }
               
            };

            // Tạo sự kiện TextChanged cho TextBox đơn giá
            textBox2.TextChanged += (sender2, e2) =>
            {
                // Kiểm tra xem giá trị của TextBox có phải là số hay không
                if (decimal.TryParse(textBox2.Text, out decimal result))
                {
                    donGia = result;

                    // Tính toán và hiển thị giá trị trên Label
                    decimal thanhTien = soLuong * donGia;
                    laber.Text = string.Format("{0:#,##0} đ", thanhTien);
                    tongtien();
                }
            };
            
            textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);// chỉ cho nhập số
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);

            // Đặt thuộc tính Dock cho TextBox và ComboBox.
            comboBox.Dock = DockStyle.Fill;
            textBox.Dock = DockStyle.Fill;
            textBox2.Dock = DockStyle.Fill;
            laber.Dock = DockStyle.Fill;

            // Thêm TextBox và ComboBox vào bảng.
            tablePanel.Controls.Add(comboBox, 0, tablePanel.RowCount - 1);
            tablePanel.Controls.Add(textBox, 1, tablePanel.RowCount - 1);
            tablePanel.Controls.Add(textBox2, 2, tablePanel.RowCount - 1);
            tablePanel.Controls.Add(laber, 3, tablePanel.RowCount - 1);
            //tablePanel.Controls.Add(slSach, 4, tablePanel.RowCount - 1);

        }
        private void tongtien()
        {
            // Duyệt qua tất cả các hàng trên TableLayoutPanel
            total = 0;
            for (int row = 0; row < tablePanel.RowCount; row++)
            {
                // Tìm các TextBox chứa giá trị số của giá tiền và số lượng
                //var control = tablePanel.GetControlFromPosition(2, row);//0123
                //var priceBox = control as TextBox;// gán kiểu
                if (row!=0)
                {
                    var quantityBox = (TextBox)tablePanel.GetControlFromPosition(1, row);
                    var priceBox = (TextBox)tablePanel.GetControlFromPosition(2, row);

                    // Kiểm tra nếu TextBox chứa giá trị số của giá tiền và số lượng không rỗng
                    if (!string.IsNullOrWhiteSpace(priceBox.Text) && !string.IsNullOrWhiteSpace(quantityBox.Text))
                    {
                        // Chuyển đổi giá trị của giá tiền và số lượng thành decimal
                        decimal price = decimal.Parse(priceBox.Text);
                        int quantity = int.Parse(quantityBox.Text);

                        // Tính toán tổng tiền của mỗi hàng
                        decimal subtotal = price * quantity;

                        // Hiển thị giá trị của thành tiền trên Label tương ứng
                        var subtotalLabel = (Label)tablePanel.GetControlFromPosition(3, row);
                        subtotalLabel.Text = string.Format("{0:#,##0} đ", subtotal);

                        // Cộng tổng tiền của hàng đó vào tổng tiền của tất cả các hàng
                        total += subtotal;
                    }
                }
                

            }

            // Hiển thị tổng tiền của tất cả các hàng
            lblTongTienHD.Text = string.Format("{0:#,##0} đ", total);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu ký tự không phải là số và không phải là ký tự backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // hủy sự kiện
            }
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void loadKhachHang()
        {
            cbbKhachHang.DisplayMember = "stenkh";
            cbbKhachHang.ValueMember = "smakh";

            List<KhachHang> khachHangs = hoaDonDAO.getKhachHang();
            cbbKhachHang.DataSource = khachHangs;

        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            hoaDon.iTongTien = Convert.ToInt32(total);
            if (hoaDon.sMaKH == null)
            {
                MessageBox.Show("Phải chọn khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
            //if(rdbChuaThanhToan.Checked==false && rdbDaThanhToan.Checked==false)
            //{
            //    MessageBox.Show("Bạn chưa chọn trạng thái thanh toán hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (hoaDon.iTongTien <= 0)
            {
                MessageBox.Show("Tổng tiền phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdbChuaThanhToan.Checked == false&& rdbDaThanhToan.Checked==false)
            {
                MessageBox.Show("Chưa chọn trạng thái thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
                if (rdbChuaThanhToan.Checked==true)
            {
                hoaDon.iTrangThai = 0;
            }    
            else
            {
                hoaDon.iTrangThai = 1;
            }    
                bool res = hoaDonDAO.insertHoaDon(hoaDon);
            if (res)
            {
                List<HoaDonChiTiet> hoaDonChiTiets = new List<HoaDonChiTiet>();
                for (int row = 0; row < tablePanel.RowCount; row++)
                {
                    // Tìm các TextBox chứa giá trị số của giá tiền và số lượng
                    var control = tablePanel.GetControlFromPosition(2, row);
                    var txtDonGia = control as TextBox;
                    if (txtDonGia != null)
                    {
                        var txtSoLuong = (TextBox)tablePanel.GetControlFromPosition(1, row);
                        var cbbSach = (ComboBox)tablePanel.GetControlFromPosition(0, row);

                        // Kiểm tra nếu TextBox chứa giá trị số của giá tiền và số lượng không rỗng
                        if (!string.IsNullOrWhiteSpace(txtDonGia.Text) && !string.IsNullOrWhiteSpace(txtSoLuong.Text))
                        {
                            // Chuyển đổi giá trị của giá tiền và số lượng thành decimal
                            decimal price = decimal.Parse(txtDonGia.Text);
                            int quantity = int.Parse(txtSoLuong.Text);

                            // Tính toán tổng tiền của mỗi hàng
                            decimal subtotal = price * quantity;

                            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet();
                            hoaDonChiTiet.sMaHD = hoaDon.sMaHD;
                            hoaDonChiTiet.sMaSach = cbbSach.SelectedValue?.ToString();
                            hoaDonChiTiet.iSoLuong = int.Parse(txtSoLuong.Text);
                            hoaDonChiTiet.fDonGia = Convert.ToInt32(price);
                            hoaDonChiTiet.fThanhTien = Convert.ToInt32(subtotal);

                            hoaDonChiTiets.Add(hoaDonChiTiet);
                        }
                    }
                }
                bool res2 = hoaDonDAO.InsertListHoaDonChiTiet(hoaDonChiTiets);
                if (res2)
                {
                    foreach (HoaDonChiTiet hoaDonChiTiet in hoaDonChiTiets)
                    {

                        bool res3 = hoaDonDAO.updateSoLuongSach(hoaDonChiTiet.sMaSach, hoaDonChiTiet.iSoLuong);
                    }
                    loadDetail();
                    MessageBox.Show("Tạo hóa đơn thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi tạo hóa đơn, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Đã có lỗi sảy ra khi tạo hóa đơn, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoaDon.sMaKH = cbbKhachHang.SelectedValue?.ToString();
        }
        private void loadDetail()
        {
            
            ((QuyenNV)this.ParentForm).loadHoaDon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ((QuyenNV)this.ParentForm).loadDSHD();
        }

        private void tablePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
