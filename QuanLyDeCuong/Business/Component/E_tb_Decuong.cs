using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyDeCuong.Business.Component
{
    class E_tb_Decuong
    {
        SQL_tb_Decuong spsql = new SQL_tb_Decuong();
        public List<EC_tb_Decuong> GetTb_Menus(string madc)
        {
            return spsql.GetTb_Menus(madc);

        }
        public void themoi(EC_tb_Decuong lg)
        {
            if (!spsql.kiemtra(lg.MaDeCuong1))
            {
                spsql.themmoinv(lg);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sua(EC_tb_Decuong lg)
        {
            spsql.suanv(lg);
        }
        public void xoa(EC_tb_Decuong lg)
        {
            spsql.xoanv(lg);
        }
        public void loadprofileDC(TextBox madc, TextBox tendc, TextBox tenhocphan, TextBox tomtat, TextBox noidung, TextBox sotinchi, TextBox tailieuthamkhao, TextBox magv, TextBox makhoa, string maDC)
        {
            spsql.loadprofileDC( madc,  tendc,  tenhocphan,  tomtat,  noidung,  sotinchi,  tailieuthamkhao,  magv,  makhoa,  maDC);
        }
    }
}
