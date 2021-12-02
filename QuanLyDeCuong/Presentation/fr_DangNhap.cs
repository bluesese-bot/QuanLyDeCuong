using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QuanLyDeCuong.DataAccess;
using QuanLyDeCuong.Business.EntitiesClass;
using QuanLyDeCuong.Business.Component;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_DangNhap : Form
    {
        public fr_DangNhap()
        {
            InitializeComponent();
        }

        ConnectDB cn = new ConnectDB();
        E_tb_User thucthi = new E_tb_User();
        EC_tb_User ck = new EC_tb_User();
        public void ThreadProc()
        {
            fr_Trangchu fr = new fr_Trangchu();
            fr.loaitk = ck.Loaitk;
            fr.username = ck.Username;
            fr.pass = ck.Password;
            fr.magv = ck.Magv;
            Application.Run(fr);
        }
        private void cmddn_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = txtpass.Text;
            string loaitk = "";
            string magv = "";
            try
            {


                if (!thucthi.kiemtrauser(user, pass))
                {
                    List<EC_tb_User> listBillinfr = thucthi.GetTb_Menus(user, pass);
                    foreach (EC_tb_User item in listBillinfr)
                    {
                        user = item.Username;
                        pass = item.Password;
                        loaitk = item.Loaitk;
                        magv = item.Magv;
                    }
                    MessageBox.Show("Đăng Nhập Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ck.Loaitk = loaitk;
                    ck.Magv = magv;
                    ck.Username = user;
                    ck.Password = pass;
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                    t.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập chưa đúng. Vui lòng kiểm tra lại.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtuser.Text = "";
                    txtpass.Text = "";
                    txtuser.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cmddn.Enabled = false;
                cmddn_Click(sender, e);
            }
        }

        private void btnAN_Click(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
            btnAN.Visible = false;
            btnHien.Visible = true;
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = false;
            btnHien.Visible = false;
            btnAN.Visible = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void fr_DangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
