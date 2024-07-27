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
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Change_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mk = textBox1.Text.Trim();
            var mk2 = textBox2.Text.Trim();
            if(string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(mk2) )
            {
                MessageBox.Show("Trống");
                textBox1.Focus();
            }else
            if (mk != mk2)
            {
                MessageBox.Show("Mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataBaseDataContext db = new DataBaseDataContext();
                var qr = db.TaiKhoans.FirstOrDefault(o => o.MaTaiKhoan == 1);
                string mk3 = qr.MatKhau;
                if (mk3 != null)
                {
                    if(mk == mk3)
                    {
                        MessageBox.Show("Trùng mật khẩu cũ.");
                    }
                    else if (mk.Length <6 )
                    {
                        MessageBox.Show("Trùng mật khẩu phải đủ 6 ký tự.");
                    }
                    else
                    {
                        var qr1 = db.TaiKhoans.Where(o => o.MaTaiKhoan == 1);
                        if (qr1.Any())
                        {
                            var obj = qr1.SingleOrDefault();
                            obj.MatKhau = mk;
                            db.SubmitChanges();
                            MessageBox.Show("Cập nhật mật khẩu thành công.");
                            this.Visible = false;


                        }
                        else
                        {

                        }
                    }
                }
              
            }
        }
    }
}
