using QuanLyDeCuong.Business.EntitiesClass;
using System.Collections.Generic;
using System.Data;

namespace QuanLyDeCuong.DataAccess
{
    class SQL_tb_DangNhap
    {
        ConnectDB cn = new ConnectDB();
        public List<EC_tb_User> GetTb_Menus(string Username, string pass)
        {
            List<EC_tb_User> listmenu = new List<EC_tb_User>();
            DataTable data = cn.taobang("select * from TaiKhoan where username = N'"+Username+"' and password = N'"+pass+"'");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_User menu = new EC_tb_User(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
        public bool Kiemtrauser(EC_tb_User user)
        {
            string sql = "select count(*) from TaiKhoan where username ='" + user.Username + "' and password = '" + user.Password + "'";
            return cn.KiemtraUsername(sql);
        }

        public void themmoinv(EC_tb_User nv)
        {
            string sql = @"INSERT INTO dbo.TaiKhoan (username,password,magv,loaitk) VALUES   (N'" + nv.Username + "',N'" + nv.Password + "',N'" + nv.Magv + "',N'" + nv.Loaitk + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_User nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [TaiKhoan] WHERE username=N'" + nv.Username + "'");
        }

        public void suanv(EC_tb_User nv)
        {
            string sql = (@"UPDATE    TaiKhoan
                    SET  password =N'" + nv.Password + "', loaitk =N'" + nv.Loaitk + "', magv =N'" + nv.Magv + "' where username =N'" + nv.Username + "'");
            cn.ExcuteNonQuery(sql);
        }
        public void suaMK(EC_tb_User mk)
        {
            string sql = (@"UPDATE dbo.TaiKhoan SET password = N'" + mk.Password + "'WHERE username = N'" + mk.Username + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
