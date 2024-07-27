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
    public partial class ChangePassword : Form
    {
        public TrangTaiKhoan TaiKhoanV { get; set; }
        public ChangePassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private int userId; 

       
        public ChangePassword(int userId, TrangTaiKhoan taiKhoanV) : this()
        {
            this.userId = userId;
            this.TaiKhoanV = taiKhoanV; 
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var matk = 1;
            using (DataBaseDataContext db = new DataBaseDataContext())
                {
                    var taiKhoan = db.TaiKhoans.FirstOrDefault(o => o.MaTaiKhoan == (matk));
                    if (taiKhoan != null)
                    {
                        string matKhauTrongDatabase = taiKhoan.MatKhau;
                        if (textBox1.Text == matKhauTrongDatabase)
                        {
                        Change change = new Change();
                        change.Visible = true;
                        this.Visible = false;
                    }
                    else {
                        textBox1.Text = string.Empty;
                        textBox1.Focus();
                        label2.Visible = true;
                    }
                    }
                }
            }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }
    }
}
