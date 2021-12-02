using QuanLyDeCuong.Business.Component;
using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_QLGiaovien : Form
    {
        public fr_QLGiaovien()
        {
            InitializeComponent();
        }

        ConnectDB cn = new ConnectDB();
        E_tb_GiaoVien thucthi = new E_tb_GiaoVien();
        EC_tb_GiaoVien ck = new EC_tb_GiaoVien();
        int dong = 0;
        bool themmoi;
        public void setnull()
        {
            txtMgv.Text = "";
            txtHoTen.Text = "";
            txtSdt.Text = "";
            txtMgv.Text = "";
        }
        public void locktext()
        {
            txtMgv.Enabled = false;
            txtHoTen.Enabled = false;
            txtSdt.Enabled = false;
            txtMgv.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMgv.Enabled = true;
            txtHoTen.Enabled = true;
            txtSdt.Enabled = true;
            txtMgv.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Giáo Viên";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Họ và Tên";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Số Điện Thoại";
            msds.Columns[2].Width = 100;
            msds.Columns[3].HeaderText = "Mã Khoa";
            msds.Columns[3].Width = 100;

        }
        public void hienthi()
        {
            string sql = "SELECT * FROM dbo.GiaoVien";
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
            txtMgv.Enabled = true;
            txtMgv.Focus();
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtMgv.Text != "")
            {
                if (txtHoTen.Text != "")
                {
                    if (txtSdt.Text != "")
                    {
                        if (txtMakhoa.Text != "")
                        {
                            if (themmoi == true)
                            {
                                try
                                {
                                    ck.MaGiaoVien1 = txtMgv.Text;
                                    ck.HoTen1 = txtHoTen.Text;
                                    ck.SDT1 = txtSdt.Text;
                                    ck.MaKhoa1 = txtMakhoa.Text;

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
                                    ck.MaGiaoVien1 = txtMgv.Text;
                                    ck.HoTen1 = txtHoTen.Text;
                                    ck.SDT1 = txtSdt.Text;
                                    ck.MaKhoa1 = txtMakhoa.Text;

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
                            txtMgv.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtSdt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtHoTen.Focus();
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
            txtMgv.Enabled = false;
            txtHoTen.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MaGiaoVien1 = txtMgv.Text;
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
            txtMgv.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtMgv.Text = msds.Rows[dong].Cells[1].Value.ToString();
            txtSdt.Text = msds.Rows[dong].Cells[2].Value.ToString();
            txtMakhoa.Text = msds.Rows[dong].Cells[3].Value.ToString();
            locktext();
        }

        private void fr_QLGiaovien_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
            khoitaoluoi();
        }
    }
}
