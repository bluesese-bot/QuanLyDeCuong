

using QuanLyDeCuong.Business.EntitiesClass;

namespace QuanLyDeCuong.DataAccess
{
    class SQL_tb_Khoa
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string manv)
        {
            return cn.kiemtra("select count(*) from [Khoa] where MaKhoa=N'" + manv + "'");
        }
        public void themmoinv(EC_tb_Khoa nv)
        {
            string sql = @"INSERT INTO Khoa
                      (MaKhoa, TenKhoa, DienThoai)
                        VALUES   (N'" + nv.MaKhoa1 + "',N'" + nv.TenKhoa1 + "',N'" + nv.DienThoai1 + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_Khoa nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [Khoa] WHERE MaKhoa=N'" + nv.MaKhoa1 + "'");
        }

        public void suanv(EC_tb_Khoa nv)
        {
            string sql = (@"UPDATE    Khoa
                    SET TenKhoa =N'" + nv.TenKhoa1 + "', SDT =N'" + nv.DienThoai1 + "' where MaKhoa=N'" + nv.MaKhoa1 + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
