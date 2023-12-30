using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL_HSK_QLS.Table
{
    public partial class QLSach : Form
    {
        public QLSach()
        {
            InitializeComponent();
        }

        private void QLSach_Load(object sender, EventArgs e)
        {
            layCbbMaloaisach();
            hiendgvKhoSach();
            txtmaloaisach.DataBindings.Clear();
            txtmaloaisach.DataBindings.Add("Text", cbbmaloaisach.DataSource, "smaloaisach");
        }
        public void hiendgvKhoSach()
        {
            string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[tblSach]", cnn))
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        da.Fill(tb);
                        dgvKhoSach.DataSource = tb;

                    }
                }
            }
        }
        /// <summary>
        /// Đổ dữ liệu lên cbbmaloaisach
        /// </summary>
        /// <returns></returns>
        public DataTable layDSSach()
        {
            string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[tblTypes]", cnn))
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        da.Fill(tb);
                        return tb;

                    }
                }
            }
        }
        private void layCbbMaloaisach()
        {
            DataTable t = layDSSach();
            DataView v = new DataView(t);
            v.Sort = "stenloaisach";
            cbbmaloaisach.DataSource = v;
            cbbmaloaisach.DisplayMember = "stenloaisach";
            cbbmaloaisach.ValueMember = "smaloaisach";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //txtmasach.Text = null;
            //txttensach.Text = null;
            //txttacgia.Text = null;
            //txtnxb.Text = null;
            //txtsoluong.Text = null;
            txtmasach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult isAdd = MessageBox.Show("Bạn có chắc chắn muốn lưu bản ghi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isAdd == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_insert_sach";
                        cmd.Parameters.AddWithValue("@smasach", txtmasach.Text);
                        cmd.Parameters.AddWithValue("@stensach", txttensach.Text);
                        cmd.Parameters.AddWithValue("@stentacgia", txttacgia.Text);
                        cmd.Parameters.AddWithValue("@sNXB", txtnxb.Text);
                        cmd.Parameters.AddWithValue("@smaloaisach", txtmaloaisach.Text);
                        cmd.Parameters.AddWithValue("@isoluongtrongkho", txtsoluong.Text);
                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                QLSach_Load(sender, e);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult isAdd = MessageBox.Show("Bạn có chắc chắn muốn sửa bản ghi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isAdd == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_update_sach_byID";
                        cmd.Parameters.AddWithValue("@smasach", txtmasach.Text);
                        cmd.Parameters.AddWithValue("@stensach", txttensach.Text);
                        cmd.Parameters.AddWithValue("@stentacgia", txttacgia.Text);
                        cmd.Parameters.AddWithValue("@sNXB", txtnxb.Text);
                        cmd.Parameters.AddWithValue("@smaloaisach", txtmaloaisach.Text);
                        cmd.Parameters.AddWithValue("@isoluongtrongkho", txtsoluong.Text);

                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                QLSach_Load(sender, e);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult isAdd = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isAdd == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_delete_sach_byID";
                        cmd.Parameters.AddWithValue("@smasach", txtmasach.Text);

                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                QLSach_Load(sender, e);

            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            //string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
            //using (SqlConnection cnn = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = cnn.CreateCommand())
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.CommandText = "sp_find_sach_byID";
            //        cmd.Parameters.AddWithValue("@smasach", txtmasach.Text);

            //        cnn.Open();
            //        int i = cmd.ExecuteNonQuery();
            //        cnn.Close();
            //    }
            //}
            //QLSach_Load(sender, e);



        }

        private void QLSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult isLogout = MessageBox.Show("Bạn có chắc chắn muốn thoát hệ thống?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isLogout == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
