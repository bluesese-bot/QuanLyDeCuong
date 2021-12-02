using System;
using System.Drawing;
using QuanLyDeCuong.Business.Component;
using QuanLyDeCuong.Business.EntitiesClass;
using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_DoiMk : Form
    {
        private string tk;
        public fr_DoiMk(string tk)
        {
            InitializeComponent();
            this.tk = tk;
        }
        E_tb_User thucthi = new E_tb_User();
        EC_tb_User ck = new EC_tb_User();

        private void fr_DoiMk_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(txtPass1.Text, txtPass2.Text, true) == 0)
                {
                    ck.Username = tk;
                    ck.Password = txtPass1.Text;
                    thucthi.doimk(ck);
                    MessageBox.Show("Đổi Mật Khẩu Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hai Mật Khẩu Không Trùng Khớp", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass1.Text = null;
                    txtPass2.Text = null;
                    txtPass1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
