using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System.Windows.Forms;

namespace QuanLyDeCuong.Business.Component
{
    class E_tb_GiaoVien
    {
        SQL_tb_Giaovien spsql = new SQL_tb_Giaovien();
        public void themoi(EC_tb_GiaoVien lg)
        {
            if (!spsql.kiemtra(lg.MaGiaoVien1))
            {
                spsql.themmoinv(lg);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sua(EC_tb_GiaoVien lg)
        {
            spsql.suanv(lg);
        }
        public void xoa(EC_tb_GiaoVien lg)
        {
            spsql.xoanv(lg);
        }
    }
}
