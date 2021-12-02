using System;
using System.Data.SqlClient;
using QuanLyDeCuong.DataAccess;
using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_TimKiem : Form
    {
        private string loaitk,magv,madc;
        ConnectDB cn = new ConnectDB();
        private int dong;

        public fr_TimKiem(string magv,string loaitk)
        {
            InitializeComponent();
            this.loaitk = loaitk;
            this.magv = magv;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Đề Cương";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Tên Đề Cương";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Tên Học Phần";
            msds.Columns[2].Width = 100;
            msds.Columns[3].HeaderText = "Số Tín Chỉ";
            msds.Columns[3].Width = 100;
            msds.Columns[4].HeaderText = "Mã Giáo Viên";
            msds.Columns[4].Width = 100;
            msds.Columns[5].HeaderText = "Mã Khoa";
            msds.Columns[5].Width = 100;
            msds.Columns[6].HeaderText = "Tóm Tắt";
            msds.Columns[6].Width = 100;
        }
        public void hienthi(string sql)
        {
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

        private void txtthongtin_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (op1.Checked)
            {
                if (loaitk=="Trưởng Khoa")
                {
                    sql = @"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaKhoa = N'" + cn.returnscalarnumberString(@"SELECT GiaoVien.MaKhoa FROM dbo.GiaoVien WHERE MaGiaoVien=N'" + magv + "'") + "' and dc.TenDeCuong=N'"+txtthongtin.Text+"'";
                    msds.DataSource = cn.taobang(sql);

                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (loaitk == "Admin")
                {
                    sql = @"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.TenDeCuong=N'"+txtthongtin.Text+"'";
                    msds.DataSource = cn.taobang(sql);

                    SqlConnection con = cn.getcon();
                    con.Open();
                }

            }
            if (op2.Checked)
            {
                sql = @"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaKhoa=N'" + txtthongtin.Text + "'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op4.Checked)
            {
                if (loaitk == "Trưởng Khoa")
                {
                    sql = @"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaKhoa = N'" + cn.returnscalarnumberString(@"SELECT GiaoVien.MaKhoa FROM dbo.GiaoVien WHERE MaGiaoVien=N'" + magv + "'") + "' and dc.MaGiaoVien=N'" + txtthongtin.Text + "'";
                    msds.DataSource = cn.taobang(sql);

                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (loaitk == "Admin")
                {
                    sql = @"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaGiaoVien=N'" + txtthongtin.Text + "'";
                    msds.DataSource = cn.taobang(sql);

                    SqlConnection con = cn.getcon();
                    con.Open();
                }

            }
        }
        public void ThreadProc()
        {
            fr_Decuong fr = new fr_Decuong();
            fr.loaitk = loaitk;
            fr.makhoa = cn.returnscalarnumberString(@"SELECT GiaoVien.MaKhoa FROM dbo.GiaoVien WHERE MaGiaoVien=N'" + magv + "'");
            fr.mgv = magv;
            fr.xem = true;
            fr.mdc = madc;
            Application.Run(fr);
        }

        private void msds_DoubleClick(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
        }

        private void fr_TimKiem_Load(object sender, EventArgs e)
        {
            loadview();
            khoitaoluoi();
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            madc = msds.Rows[dong].Cells[0].Value.ToString();
        }

        private void loadview()
        {
            if (loaitk == "Giáo Viên")
            {
                hienthi(@"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaGiaoVien =N'" + magv + "'");
                op1.Visible = false;
                op2.Visible = false;
                op4.Visible = false;
            }
            if (loaitk == "Trưởng Khoa")
            {
                hienthi(@"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaKhoa =N'" + cn.returnscalarnumberString(@"SELECT GiaoVien.MaKhoa FROM dbo.GiaoVien WHERE MaGiaoVien=N'" + magv + "'") + "'");
                op1.Visible = true;
                op2.Visible = false;
                op4.Visible = true;
            }
            if (loaitk == "Admin")
            {
                hienthi(@"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc");
            }
        }
    }
}
