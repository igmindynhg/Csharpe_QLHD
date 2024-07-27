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
    public partial class TrangTaiKhoan : Form
    {
        public TrangTaiKhoan()
        {
            InitializeComponent();
            LoadData();
        }
        private int loguser;
        private int ma;

        public TrangTaiKhoan(int ma)
        {
            InitializeComponent();
            loguser = ma;
            LoadData();
            
        }

        public string TaiKhoanText
        {
            get { return  txtMa.Text.Trim(); }
        }


        private void TaiKhoan_Load(object sender, EventArgs e)
        {

        }

        DataBaseDataContext db = new DataBaseDataContext();
        private void LoadData()
        {
            var qr = db.TaiKhoans.Select(t => new { t.MaTaiKhoan, t.TenDangNhap });
            if (qr.Any())
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = qr.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var ma = txtMa.Text.Trim();
                var tk = txttk.Text.Trim();
                var mk = txtmk.Text.Trim();
                /*var mk2 = textBox4.Text.Trim();*/
                if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Trống.");
                }
                else if (mk.Length <6)
                {
                    MessageBox.Show("Mật khẩu đủ 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bool maExists = db.TaiKhoans.Any(t => t.MaTaiKhoan == int.Parse(ma));
                    if (maExists)
                    {
                        MessageBox.Show("Mã tài khoản đã tồn tại.");
                    }
                    else
                    {
                        TaiKhoan obj = new TaiKhoan();
                        obj.MaTaiKhoan = int.Parse(ma);
                        obj.TenDangNhap = tk;
                        obj.MatKhau = mk;

                        db.TaiKhoans.InsertOnSubmit(obj);
                        db.SubmitChanges();

                        txtMa.Focus();
                        btn_huy_Click(sender, e);   
                        MessageBox.Show("Thêm tài khoản thành công.");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var r = dataGridView1.Rows[e.RowIndex];
                if (r != null)
                {
                    var ma = r.Cells[0].Value.ToString();
                    var tk = r.Cells[1].Value.ToString();
                    if (int.TryParse(ma, out int maInt) && maInt == 1)
                    {
                        txtMa.Text = ma;
                        txttk.Text = tk;
                        txtMa.ReadOnly = true;
                        btnSua.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("You can only select your own account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Visible = true;
            LoadData();
           
            

            /*try
            {
                var ma = txtMa.Text.Trim();
                var tk = txttk.Text.Trim();
                var mk = txtmk.Text.Trim();
                *//*var mk2 = textBox4.Text.Trim();*//*
                if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Rong");
                }
                *//*else if (mk != mk2)
                {
                    MessageBox.Show("Mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*//*
                else if (!int.TryParse(ma, out int ma2))
                {
                    MessageBox.Show("Invalid Account ID.");
                    return;
                }
                else
                {

                    var qr = db.tbl_TaiKhoans.Where(o => o.maTaiKhoan == ma2);
                    if (qr.Any())
                    {
                        var obj = qr.SingleOrDefault();
                        obj.tenTaiKhoan = tk;
                        obj.matKhau = mk;


                        db.SubmitChanges();

                        MessageBox.Show("sua");
                        LoadData();
                    }

                }
            }
            catch (Exception ex)
            {

            }*/
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa tài khoản: "+ txttk +" ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var ma = txtMa.Text.Trim();
                        if (string.IsNullOrEmpty(ma))
                        { 
                            MessageBox.Show("Trống.");
                        }
                        else if (!int.TryParse(ma, out int ma2))
                        {
                            MessageBox.Show("Invalid Account ID.");
                            return;
                        }
                        else
                        {
                            var qr = db.TaiKhoans.Where(o => o.MaTaiKhoan == ma2);
                            if (qr.Any())
                            {
                                var obj = qr.SingleOrDefault();
                                obj.MaTaiKhoan = ma2;

                                db.TaiKhoans.DeleteOnSubmit(obj);
                                db.SubmitChanges();

                                MessageBox.Show("Đã xóa thành công.");
                                txttk.Focus();
                                LoadData();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txtMa.Text = string.Empty;
            txttk.Text = string.Empty;
            txtmk.Text  = string.Empty;               
            txtMa.ReadOnly = false;
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            if(txtMa.Text == string.Empty)
            {
                label6.Visible = true;
                button2.Enabled = false;
            }
            else
            {
                label6.Visible = false;
                button2.Enabled = true;
            }
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            if (txttk.Text == string.Empty)
            {
                label7.Visible = true;
                button2.Enabled = false;
            }
            else
            {
                label7.Visible = false;
                button2.Enabled = true;
            }
        }

        private void txtmk_TextChanged(object sender, EventArgs e)
        {
            if (txtmk.Text == string.Empty && txtmk.Text.Length >=6)
            {
                label9.Visible = true;
                button2.Enabled = false;
            }
            else
            {
                label9.Visible = false;
                button2.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
