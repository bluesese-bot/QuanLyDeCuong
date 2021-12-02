using QuanLyDeCuong.Business.EntitiesClass;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyDeCuong.DataAccess
{
    class SQL_tb_Decuong
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string ma)
        {
            return cn.kiemtra("select count(*) from [DeCuong] where MaDeCuong=N'" + ma + "'");
        }
        public void themmoinv(EC_tb_Decuong nv)
        {
            string sql = @"INSERT INTO DeCuong
                      (MaDeCuong, TenDeCuong, TenHocPhan, TomTat,NoiDung,SoTinChi,TaiLieuThamKhao,MaGiaoVien,MaKhoa)
                        VALUES   (N'" + nv.MaDeCuong1 + "',N'" + nv.TenDeCuong1 + "',N'" + nv.TenHocPhan1 + "',N'" + nv.TomTat1 + "',N'" + nv.NoiDung1 + "',N'" + nv.SoTinChi1 + "',N'" + nv.TaiLieuThamKhao1 + "',N'" + nv.MaGiaoVien1 + "',N'" + nv.MaKhoa1 + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_Decuong nv)
        {
            cn.ExcuteNonQuery(@"DELETE FROM [DeCuong] WHERE MaDeCuong=N'" + nv.MaDeCuong1 + "'");
        }

        public void suanv(EC_tb_Decuong nv)
        {
            string sql = (@"UPDATE    DeCuong
                    SET TenDeCuong =N'" + nv.TenDeCuong1 + "', TenHocPhan =N'" + nv.TenHocPhan1 + "', TomTat =N'" + nv.TomTat1 + "', NoiDung =N'" + nv.NoiDung1 + "', SoTinChi =N'" + nv.SoTinChi1 + "', TaiLieuThamKhao =N'" + nv.TaiLieuThamKhao1 + "', MaGiaoVien =N'" + nv.MaGiaoVien1 + "', MaKhoa =N'" + nv.MaKhoa1 + "'  where MaDeCuong=N'" + nv.MaDeCuong1 + "'");
            cn.ExcuteNonQuery(sql);
        }
        public void loadprofileDC(TextBox madc, TextBox tendc, TextBox tenhocphan, TextBox tomtat, TextBox noidung, TextBox sotinchi, TextBox tailieuthamkhao, TextBox magv, TextBox makhoa,string maDC)
        {
            cn.LoadTextBox(tendc, "SELECT TenDeCuong FROM dbo.DeCuong WHERE MaDeCuong=N'"+maDC+"'");
            cn.LoadTextBox(tenhocphan, "SELECT TenHocPhan FROM dbo.DeCuong WHERE MaDeCuong=N'"+maDC+"'");
            cn.LoadTextBox(tomtat, "SELECT TomTat FROM dbo.DeCuong WHERE MaDeCuong=N'" + maDC + "'");
            cn.LoadTextBox(noidung, "SELECT NoiDung FROM dbo.DeCuong WHERE MaDeCuong=N'" + maDC + "'");
            cn.LoadTextBox(sotinchi, "SELECT SoTinChi FROM dbo.DeCuong WHERE MaDeCuong=N'" + maDC + "'");
            cn.LoadTextBox(tailieuthamkhao, "SELECT TaiLieuThamKhao FROM dbo.DeCuong WHERE MaDeCuong=N'" + maDC + "'");
            cn.LoadTextBox(magv, "SELECT MaGiaoVien FROM dbo.DeCuong WHERE MaDeCuong=N'" + maDC + "'");
            cn.LoadTextBox(makhoa, "SELECT MaKhoa FROM dbo.DeCuong WHERE MaDeCuong=N'" + maDC + "'");
            madc.Text = maDC;
        }
        public List<EC_tb_Decuong> GetTb_Menus(string madc)
        {
            List<EC_tb_Decuong> listmenu = new List<EC_tb_Decuong>();
            DataTable data = cn.taobang(@"SELECT * FROM dbo.DeCuong WHERE MaDeCuong= N'"+madc+"'");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_Decuong menu = new EC_tb_Decuong(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
