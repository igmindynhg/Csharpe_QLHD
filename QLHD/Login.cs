using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = !checkBox1.Checked;
                checkBox1_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        DataBaseDataContext db = new DataBaseDataContext();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            try 
            {
                string tk = txtTaiKhoan.Text.Trim();
                string mk = txtMatKhau.Text.Trim();
                if(string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Không để rỗng thông tin đăng nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaiKhoan.Focus();
                }
                else
                {
                    var qr = db.TaiKhoans.Where(o => o.TenDangNhap == tk && o.MatKhau == mk);
                    if (qr.Any())
                    {
                        var tk_obj = qr.SingleOrDefault();
                        this.Hide();
                        Home home = new Home();
                        home.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTaiKhoan.Focus();
                    }
                }
            }catch(Exception ex) 
            {
                MessageBox.Show("Lỗi sever" + ex);
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                lb_tk.Visible = true;
            }
            else
            {
                lb_tk.Visible=false;
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                lb_mk.Visible = true;
                checkBox1.Visible = false;

            }
            else
            {
                lb_mk.Visible=false;
                checkBox1.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
