using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_Trangchu : Form
    {
        public string username = "", pass = "", loaitk = "", magv = "";
        private Form activeForm;
        
        private void fr_Trangchu_Load(object sender, EventArgs e)
        {
            OpenChildForm(new fr_Quanlydecuong(magv,loaitk), sender);
            Loadview();
        }
        private void Loadview()
        {
            if (loaitk == "Giao Viên")
            {
                quảnLýToolStripMenuItem.Visible = false;
            }
            if (loaitk == "Trưởng Khoa")
            {
                quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                quảnLýKhoaToolStripMenuItem.Visible = false;
            }
        }

        private void quảnLýGiáoViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_QLGiaovien(), sender);
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_QLTaikhoan(), sender);
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_QLKhoa(), sender);
        }
        public void ThreadProc()
        {
            fr_DangNhap fr = new fr_DangNhap();
            Application.Run(fr);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            this.Close();
        }

        private void tìmKiếmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_TimKiem(magv,loaitk),sender);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_DoiMk fr = new fr_DoiMk(username);
            fr.ShowDialog();
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_Quanlydecuong(magv,loaitk), sender);
        }

        public fr_Trangchu()
        {
            InitializeComponent();
        }

    }
}
