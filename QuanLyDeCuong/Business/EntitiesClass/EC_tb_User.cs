using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyDeCuong.Business.EntitiesClass
{
    class EC_tb_User
    {
        private string username, password, magv, loaitk;
        public EC_tb_User() { }
        public EC_tb_User(DataRow row)
        {
            this.username = row[0].ToString();
            this.password = row[1].ToString();
            this.loaitk = row[3].ToString();
            this.magv = row[2].ToString();
        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Magv { get => magv; set => magv = value; }
        public string Loaitk { get => loaitk; set => loaitk = value; }
    }
}
