using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHD
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private int loguser;
        private int ma;

        public Home(int ma)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loguser = ma;
            
        }
        
        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form1 = new Login();
            form1.ShowDialog();
            this.Close();
        }

        private async void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(300);
            });
            this.Cursor = Cursors.Default;
            pnHienThi.Controls.Clear();
            TrangTaiKhoan tk = new TrangTaiKhoan();
            tk.TopLevel = false;
            tk.FormBorderStyle = FormBorderStyle.None;
            tk.Dock = DockStyle.Fill;
            pnHienThi.Controls.Add(tk);
            tk.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnHienThi.Controls.Clear();
            TrangSanPham sp = new TrangSanPham();
            sp.TopLevel = false;
            sp.FormBorderStyle = FormBorderStyle.None;
            sp.Dock = DockStyle.Fill;
            pnHienThi.Controls.Add(sp);
            sp.Show();
        }

        private void tạoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnHienThi.Controls.Clear();
            TaoHoaDon sp = new TaoHoaDon();
            sp.TopLevel = false;
            sp.FormBorderStyle = FormBorderStyle.None;
            sp.Dock = DockStyle.None; 
            sp.AutoScroll = true;
            sp.Size = new Size(pnHienThi.ClientSize.Width, sp.Height);
            pnHienThi.Controls.Add(sp);
            sp.Show();
        }

        private void xemHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnHienThi.Controls.Clear();
            XemHD sp = new XemHD();
            sp.TopLevel = false;
            sp.FormBorderStyle = FormBorderStyle.None;
            sp.Dock = DockStyle.Fill;
            pnHienThi.Controls.Add(sp);
            sp.Show();
        }
    }
}
