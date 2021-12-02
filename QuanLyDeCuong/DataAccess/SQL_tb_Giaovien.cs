

using QuanLyDeCuong.Business.EntitiesClass;

namespace QuanLyDeCuong.DataAccess
{
    class SQL_tb_Giaovien
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string manv)
        {
            return cn.kiemtra("select count(*) from [GiaoVien] where MaGiaoVien=N'" + manv + "'");
        }
        public void themmoinv(EC_tb_GiaoVien nv)
        {
            string sql = @"INSERT INTO GiaoVien
                      (MaGiaoVien, HoTen, SDT, MaKhoa)
                        VALUES   (N'" + nv.MaGiaoVien1 + "',N'" + nv.HoTen1 + "',N'" + nv.SDT1 + "',N'" + nv.MaKhoa1 + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_GiaoVien nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [GiaoVien] WHERE MaGiaoVien=N'" + nv.MaGiaoVien1 + "'");
        }

        public void suanv(EC_tb_GiaoVien nv)
        {
            string sql = (@"UPDATE    GiaoVien
                    SET HoTen =N'" + nv.HoTen1 + "', SDT =N'" + nv.SDT1 + "', MaKhoa =N'" + nv.MaKhoa1 + "'  where MaGiaoVien=N'" + nv.MaGiaoVien1 + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
