using System;
using QuanLyDeCuong.DataAccess;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.Business.Component;
using System.Collections.Generic;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_Quanlydecuong : Form
    {
        public string magv;
        public string loaitk;
        int dem;
        string madc;
        public fr_Quanlydecuong()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        EC_tb_Decuong ck = new EC_tb_Decuong();
        E_tb_Decuong thucthi = new E_tb_Decuong();
        private int dong;

        public void ThreadProc()
        {
            fr_Decuong fr = new fr_Decuong();
            fr.loaitk = loaitk;
            fr.makhoa = cn.returnscalarnumberString(@"SELECT GiaoVien.MaKhoa FROM dbo.GiaoVien WHERE MaGiaoVien=N'"+magv+"'");
            fr.mgv = magv;
            switch (dem)
            {
                case 0:
                    fr.themmoi = true;
                    break;
                case 1:
                    fr.sua = true;
                    fr.mdc = madc;
                    break;
                case 2:
                    fr.xem = true;
                    fr.mdc = madc;
                    break;
            }
            Application.Run(fr);
        }
        public fr_Quanlydecuong(string Magv,string Loaitk)
        {
            InitializeComponent();
            this.magv = Magv;
            this.loaitk = Loaitk;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dem = 0;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dem = 1;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MaDeCuong1 = madc;
                    thucthi.xoa(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }

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

        private void fr_Quanlydecuong_Load(object sender, EventArgs e)
        {
            loadview();
            khoitaoluoi();
        }
        private void loadview()
        {
            if (loaitk == "Giáo Viên")
            {
                hienthi(@"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaGiaoVien =N'"+magv+"'");
            }
            if (loaitk == "Trưởng Khoa")
            {
                hienthi(@"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc WHERE dc.MaKhoa =N'"+ cn.returnscalarnumberString(@"SELECT GiaoVien.MaKhoa FROM dbo.GiaoVien WHERE MaGiaoVien=N'" + magv + "'")+ "'");
            }
            if (loaitk == "Admin")
            {
                hienthi(@"SELECT dc.MaDeCuong,dc.TenDeCuong,dc.TenHocPhan,dc.SoTinChi,dc.MaGiaoVien,dc.MaKhoa,dc.TomTat FROM dbo.DeCuong AS dc");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dem = 2;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            madc = msds.Rows[dong].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fr_BaoCao f = new fr_BaoCao(madc);
            f.ShowDialog();
        }
    }
}
