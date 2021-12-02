using QuanLyDeCuong.Business.Component;
using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_QLTaikhoan : Form
    {
        public fr_QLTaikhoan()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_User thucthi = new E_tb_User();
        EC_tb_User ck = new EC_tb_User();
        int dong = 0;
        public void setnull()
        {
            txtTk.Text = "";
            txtMk.Text = "";
            cbLoaiTk.Text = "";
            txtMgv.Text = "";
        }
        public void locktext()
        {
            txtTk.Enabled = false;
            txtMk.Enabled = false;
            cbLoaiTk.Enabled = false;
            txtMgv.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtTk.Enabled = true;
            txtMk.Enabled = true;
            cbLoaiTk.Enabled = true;
            txtMgv.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Tên Đăng Nhập";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Mã Giáo Viên";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Loại Tài Khoản";
            msds.Columns[2].Width = 100;

        }
        public void hienthi()
        {
            string sql = "SELECT username,magv,loaitk FROM dbo.TaiKhoan";
            msds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            un_locktext();
            setnull();
            txtTk.Enabled = true;
            txtTk.Focus();
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtTk.Text != "")
            {
                if (txtMk.Text != "")
                {
                    if (cbLoaiTk.Text != "")
                    {
                        if (txtMgv.Text != "")
                        {
                            
                           try
                            {
                                ck.Username = txtTk.Text;
                                ck.Password = txtMk.Text;
                                ck.Loaitk = cbLoaiTk.Text;
                                ck.Magv = txtMgv.Text;

                                thucthi.themoinv(ck);
                                locktext();
                                hienthi();
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           }
                            catch (Exception ex)
                           {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           }

                            txtTk.Enabled = true;
                            locktext();
                            hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            txtMgv.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbLoaiTk.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMk.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtTk.Focus();
            }
        }



        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.Username = txtTk.Text;
                    thucthi.xoanv(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }
        private void fr_TaiKhoan_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void msds_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtTk.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtMgv.Text = msds.Rows[dong].Cells[1].Value.ToString();
            cbLoaiTk.Text = msds.Rows[dong].Cells[2].Value.ToString();
            locktext();
        }
    }
}
