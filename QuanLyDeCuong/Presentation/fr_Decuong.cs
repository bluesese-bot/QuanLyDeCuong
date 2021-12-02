using QuanLyDeCuong.Business.Component;
using QuanLyDeCuong.Business.EntitiesClass;
using System;
using System.Windows.Forms;

namespace QuanLyDeCuong.Presentation
{
    public partial class fr_Decuong : Form
    {
        public bool xem,sua,themmoi;
        public string mgv,makhoa,loaitk,mdc;

        EC_tb_Decuong ck = new EC_tb_Decuong();
        E_tb_Decuong thucthi = new E_tb_Decuong();
        public fr_Decuong()
        {
            InitializeComponent();
        }
        private void LoadView()
        {
            if (xem==true)
            {
                locktext();
                thucthi.loadprofileDC(txtMDC, txtTdc, txtThp, txtTomTat, txtNoidung, txtStc, txtTltk, txtMgv, txtMkhoa, mdc);
                txtMDC.Focus();
            }
            else
            {
                if (sua == true)
                {
                    unlocktext();
                    thucthi.loadprofileDC(txtMDC, txtTdc, txtThp, txtTomTat, txtNoidung, txtStc, txtTltk, txtMgv, txtMkhoa, mdc);
                    txtMDC.Focus();
                }
                else
                {
                    if (themmoi == true)
                    {
                        unlocktext();
                        txtMDC.Enabled = true;
                        txtMDC.Focus();
                    }
                }
            }
        }
        private void locktext()
        {
            txtMDC.Enabled = false;
            txtMgv.Enabled = false;
            txtMkhoa.Enabled = false;
            txtNoidung.Enabled = false;
            txtStc.Enabled = false;
            txtTdc.Enabled = false;
            txtThp.Enabled = false;
            txtTltk.Enabled = false;
            txtTomTat.Enabled = false;

            btnLuu.Visible = false;
        }
        private void unlocktext()
        {
            txtMDC.Enabled = false;
            txtMgv.Enabled = false;
            txtMkhoa.Enabled = false;
            txtNoidung.Enabled = true;
            txtStc.Enabled = true;
            txtTdc.Enabled = true;
            txtThp.Enabled = true;
            txtTltk.Enabled = true;
            txtTomTat.Enabled = true;

            btnLuu.Visible = true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMDC.Text != "")
            {
                if (txtMgv.Text != "")
                {
                    if (txtMkhoa.Text != "")
                    {
                        if (txtStc.Text != "")
                        {
                            if (txtTdc.Text != "")
                            {
                                if (txtThp.Text != "")
                                {
                                    if (themmoi == true)
                                    {
                                        try
                                        {
                                            ck.MaDeCuong1 = txtMDC.Text;
                                            ck.MaGiaoVien1 = txtMgv.Text;
                                            ck.MaKhoa1 = txtMkhoa.Text;
                                            ck.NoiDung1 = txtNoidung.Text;
                                            ck.SoTinChi1 = txtStc.Text;
                                            ck.TaiLieuThamKhao1 = txtTltk.Text;
                                            ck.TenDeCuong1 = txtTdc.Text;
                                            ck.TenHocPhan1 = txtThp.Text;
                                            ck.TomTat1 = txtTomTat.Text;

                                            thucthi.themoi(ck);
                                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        this.Close();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            ck.MaDeCuong1 = txtMDC.Text;
                                            ck.MaGiaoVien1 = txtMgv.Text;
                                            ck.MaKhoa1 = txtMkhoa.Text;
                                            ck.NoiDung1 = txtNoidung.Text;
                                            ck.SoTinChi1 = txtStc.Text;
                                            ck.TaiLieuThamKhao1 = txtTltk.Text;
                                            ck.TenDeCuong1 = txtTdc.Text;
                                            ck.TenHocPhan1 = txtThp.Text;
                                            ck.TomTat1 = txtTomTat.Text;

                                            thucthi.sua(ck);
                                            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                    txtThp.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                txtTdc.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            txtStc.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtMkhoa.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMgv.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMDC.Focus();
            }
        }


        private void fr_Decuong_Load(object sender, EventArgs e)
        {
            LoadView();
            txtMgv.Text = mgv;
            txtMkhoa.Text = makhoa;
        }
    }
}
