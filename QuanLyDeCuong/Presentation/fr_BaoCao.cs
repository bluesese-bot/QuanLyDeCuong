using QuanLyDeCuong.Business.EntitiesClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyDeCuong.Business.Component;
using QuanLyDeCuong.DataAccess;
using QuanLyDeCuong.Report;
using System.Data;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_BaoCao : Form
    {
        string mdc;

        E_tb_Decuong thucthi = new E_tb_Decuong();
        ConnectDB cn = new ConnectDB();
        public fr_BaoCao(string madc)
        {
            InitializeComponent();
            this.mdc = madc;
        }
           

        private void fr_BaoCao_Load(object sender, EventArgs e)
        {
            CrystalReport2 baocao = new CrystalReport2();
            baocao.SetDataSource(cn.taobang(@"SELECT * FROM dbo.DeCuong WHERE MaDeCuong= N'" + mdc + "'"));
            crystalReportViewer1.ReportSource = baocao;
        }
    }
}
