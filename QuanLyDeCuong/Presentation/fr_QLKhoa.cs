using QuanLyDeCuong.Business.Component;
using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_QLKhoa : Form
    {
        public fr_QLKhoa()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_Khoa thucthi = new E_tb_Khoa();
        EC_tb_Khoa ck = new EC_tb_Khoa();
        int dong = 0;
        bool themmoi;
        public void setnull()
        {
            txtMakhoa.Text = "";
            txtTenKhoa.Text = "";
            txtSDT.Text = "";
        }
        public void locktext()
        {
            txtTenKhoa.Enabled = false;
            txtTenKhoa.Enabled = false;
            txtSDT.Enabled = false;


            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMakhoa.Enabled = true;
            txtTenKhoa.Enabled = true;
            txtSDT.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Khoa";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Tên Khoa";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Số Điện Thoại";
            msds.Columns[2].Width = 100;

        }
        public void hienthi()
        {
            string sql = "SELECT * FROM dbo.Khoa";
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
            themmoi = true;
            un_locktext();
            setnull();
            txtMakhoa.Enabled = true;
            txtMakhoa.Focus();
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtMakhoa.Text != "")
            {
                if (txtTenKhoa.Text != "")
                {
                    if (txtSDT.Text != "")
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MaKhoa1 = txtMakhoa.Text;
                                ck.TenKhoa1 = txtTenKhoa.Text;
                                ck.DienThoai1 = txtSDT.Text;

                                thucthi.themoi(ck);
                                locktext();
                                hienthi();
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                                ck.MaKhoa1 = txtMakhoa.Text;
                                ck.TenKhoa1 = txtTenKhoa.Text;
                                ck.DienThoai1 = txtSDT.Text;

                                thucthi.sua(ck);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txtMakhoa.Enabled = true;
                        locktext();
                        hienthi();

                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtSDT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenKhoa.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMakhoa.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMakhoa.Enabled = false;
            txtTenKhoa.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MaKhoa1 = txtMakhoa.Text;
                    thucthi.xoa(ck);
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

        private void msds_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMakhoa.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtTenKhoa.Text = msds.Rows[dong].Cells[1].Value.ToString();
            txtSDT.Text = msds.Rows[dong].Cells[2].Value.ToString();
            locktext();
        }
        private void fr_QLKhoa_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
            khoitaoluoi();
        }
    }
}
