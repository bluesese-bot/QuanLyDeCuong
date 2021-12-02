using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyDeCuong.Business.EntitiesClass
{
    class EC_tb_Decuong
    {
        private string MaDeCuong, TenDeCuong, TenHocPhan, TomTat, NoiDung, SoTinChi, TaiLieuThamKhao, MaGiaoVien, MaKhoa;

        public EC_tb_Decuong()
        {
        }

        public EC_tb_Decuong(DataRow row)
        {
            this.MaDeCuong1 = row[0].ToString();
            this.TenDeCuong1 = row[1].ToString();
            this.TenHocPhan1 = row[2].ToString();
            this.TomTat1 = row[3].ToString();
            this.NoiDung1 = row[4].ToString();
            this.SoTinChi1 = row[5].ToString();
            this.TaiLieuThamKhao1 = row[6].ToString();
            this.MaGiaoVien1 = row[7].ToString();
            this.MaKhoa1 = row[8].ToString();
        }
        public string MaDeCuong1 { get => MaDeCuong; set => MaDeCuong = value; }
        public string TenDeCuong1 { get => TenDeCuong; set => TenDeCuong = value; }
        public string TenHocPhan1 { get => TenHocPhan; set => TenHocPhan = value; }
        public string TomTat1 { get => TomTat; set => TomTat = value; }
        public string NoiDung1 { get => NoiDung; set => NoiDung = value; }
        public string SoTinChi1 { get => SoTinChi; set => SoTinChi = value; }
        public string TaiLieuThamKhao1 { get => TaiLieuThamKhao; set => TaiLieuThamKhao = value; }
        public string MaGiaoVien1 { get => MaGiaoVien; set => MaGiaoVien = value; }
        public string MaKhoa1 { get => MaKhoa; set => MaKhoa = value; }
    }
}
