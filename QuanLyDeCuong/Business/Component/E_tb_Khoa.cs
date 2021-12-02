using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System.Windows.Forms;

namespace QuanLyDeCuong.Business.Component
{
    class E_tb_Khoa
    {
        SQL_tb_Khoa spsql = new SQL_tb_Khoa();
        public void themoi(EC_tb_Khoa lg)
        {
            if (!spsql.kiemtra(lg.MaKhoa1))
            {
                spsql.themmoinv(lg);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sua(EC_tb_Khoa lg)
        {
            spsql.suanv(lg);
        }
        public void xoa(EC_tb_Khoa lg)
        {
            spsql.xoanv(lg);
        }
    }
}
