using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.DataAccess;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyDeCuong.Business.Component
{
    class E_tb_User
    {
        ConnectDB cn = new ConnectDB();
        EC_tb_User ck = new EC_tb_User();
        SQL_tb_DangNhap sql = new SQL_tb_DangNhap();
        public bool kiemtrauser(string user, string pass)
        {
            ck.Username = user;
            ck.Password = pass;
            return sql.Kiemtrauser(ck);
        }
        public List<EC_tb_User> GetTb_Menus(string Username, string pass)
        {
               return sql.GetTb_Menus(Username,pass);

        }
        SQL_tb_DangNhap nvsql = new SQL_tb_DangNhap();
        public void themoinv(EC_tb_User nv)
        {
            if (kiemtrauser(nv.Username, nv.Password) == true)
            {
                sql.themmoinv(nv);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void suanv(EC_tb_User nv)
        {
            sql.suanv(nv);
        }
        public void xoanv(EC_tb_User nv)
        {
            sql.xoanv(nv);
        }
        public void doimk(EC_tb_User nv)
        {
            sql.suaMK(nv);
        }
    }
}
