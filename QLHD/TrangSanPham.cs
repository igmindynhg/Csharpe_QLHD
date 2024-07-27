using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHD
{
    public partial class TrangSanPham : Form
    {
        public TrangSanPham()
        {
            InitializeComponent();
            LoadData();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {

        }

       DataBaseDataContext db = new DataBaseDataContext();
        private void LoadData()
        {
            var qr = db.SanPhams;
            if (qr.Any())
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = qr.ToList();
            }
        }
        private bool CheckMaSanPhamExists(int maSanPham)
        {
            return db.SanPhams.Any(sp => sp.MaSanPham == maSanPham);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var maStr = txtMa.Text.Trim();
                var tenSp = txtTen.Text.Trim();
                var donGiaStr  = txtGia.Text.Trim();
                var soLuongStr = txtSoluong.Text.Trim();
         
                if (/*string.IsNullOrEmpty(maStr) ||*/ string.IsNullOrEmpty(tenSp) || string.IsNullOrEmpty(donGiaStr) || string.IsNullOrEmpty(soLuongStr))
                {
                    MessageBox.Show("Trống.");
                }
                /*if (!int.TryParse(maStr, out int ma))
                {
                    MessageBox.Show("Mã sản phẩm phải là số nguyên.");
                    return;
                }*/
                int.TryParse(maStr, out int ma);
                if (CheckMaSanPhamExists(ma))
                {
                    var existingProduct = db.SanPhams.FirstOrDefault(sp => sp.TenSanPham == tenSp && sp.DonGia == float.Parse(donGiaStr));
                    if (existingProduct != null)
                    {
                        existingProduct.SoLuong += float.Parse(soLuongStr);
                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật số lượng sản phẩm thành công.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại trong cơ sở dữ liệu.");
                        return;
                    }
                }
                else
                {
                    var existingProduct = db.SanPhams.FirstOrDefault(sp => sp.TenSanPham == tenSp && sp.DonGia == float.Parse(donGiaStr));
                    if (existingProduct != null)
                    {
                        existingProduct.SoLuong += float.Parse(soLuongStr);
                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật số lượng sản phẩm thành công.");
                        LoadData();
                    }
                    else
                    {
                        SanPham obj = new SanPham();
                        obj.MaSanPham = ma;
                        obj.TenSanPham = tenSp;
                        obj.DonGia = float.Parse(donGiaStr);
                        obj.SoLuong = float.Parse(soLuongStr);
                        db.SanPhams.InsertOnSubmit(obj);
                        db.SubmitChanges();


                        MessageBox.Show("Thêm thành công sản phẩm.");
                        button4_Click(sender, e);
                        txtTen.Focus();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sever:" + ex);
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            if(!float.TryParse(txtGia.Text.Trim(), out float donGia) || donGia <= 0)
            {
                lbdongia.Visible = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
            }
            else
            {
                lbdongia.Visible=false;
                btnThem.Enabled=true;
                btnSua.Enabled=true;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var r = dataGridView1.Rows[e.RowIndex];
                if (r != null)
                {
                    var maSP = r.Cells[0].Value.ToString();
                    var tenSP = r.Cells[1].Value.ToString();
                    var donGia = r.Cells[2].Value.ToString();
                    var soLuong = r.Cells[3].Value.ToString();

                    txtMa.Text = maSP;
                    txtTen.Text = tenSP;
                    txtGia.Text = donGia;
                    txtSoluong.Text = soLuong;
                   txtMa.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("chi tiết: " + ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                
                var maStr = txtMa.Text.Trim();
                var tenSp = txtTen.Text.Trim();
                var donGiaStr = txtGia.Text.Trim();
                var soLuongStr = txtSoluong.Text.Trim();
                if (string.IsNullOrEmpty(maStr) || string.IsNullOrEmpty(tenSp) || string.IsNullOrEmpty(donGiaStr) || string.IsNullOrEmpty(soLuongStr))
                {
                    MessageBox.Show("Trống.");
                }
                else if (!int.TryParse(maStr, out int ma))
                {
                    MessageBox.Show("Mã sản phẩm phải là số nguyên.");
                    return;
                }
                else
                {
                    var qr = db.SanPhams.Where(o => o.MaSanPham == ma);
                    if (qr.Any())
                    {
                        var obj = qr.SingleOrDefault();
                        obj.TenSanPham = tenSp;
                        obj.DonGia = float.Parse(donGiaStr);
                        obj.SoLuong = float.Parse(soLuongStr);
                        db.SubmitChanges();

                        MessageBox.Show("Cập nhật sản phẩm thành công.");
                        txtTim.Focus();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm không tốn tại.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var maStr = txtMa.Text.Trim();
            int.TryParse(maStr, out int ma);
            if (string.IsNullOrEmpty(maStr))
            {
                
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có muỗn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                                var qr = db.SanPhams.Where(o => o.MaSanPham == ma);
                                if (qr.Any())
                                {
                                    var obj = qr.SingleOrDefault();
                                    obj.MaSanPham = ma;
                                    db.SanPhams.DeleteOnSubmit(obj);
                                    db.SubmitChanges();
                                    MessageBox.Show("Đã xóa sản phẩm.");
                                    LoadData();
                                    txtTim.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Mã xóa sản phẩm không tồn tại.");
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTim.Text = string.Empty;
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtMa.Enabled = false;
            btnSua.Enabled = true;
            lbma.Visible = false;
            lbten.Visible = false;
            lbdongia.Visible = false;
            txtSoluong.Text = string.Empty;
            lbsluonng.Visible = false;
            btnThem.Enabled = true;
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var tim = txtTim.Text;
                if (string.IsNullOrEmpty(tim))
                {
                    LoadData();
                }
                else
                {
                    var qr = db.SanPhams.Where(o => o.TenSanPham.Contains(tim));
                    if (qr.Any())
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = qr.ToList();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi" + ex);
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(txtSoluong.Text.Trim(), out float soLuong) || soLuong <= 0)
            {
                lbsluonng.Visible = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
            }
            else
            {
                lbsluonng.Visible = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            /*string pattern = @"^SP\d+$";

            if (string.IsNullOrEmpty(txtMa.Text))
            {
                lbma.Visible = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
            }
            else if (Regex.IsMatch(txtMa.Text.Trim(), pattern))
            {
                lbma.Visible = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
            }
            else
            {
                lbma.Visible = true; 
                btnThem.Enabled = false;
                btnSua.Enabled = false;
            }*/
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                lbten.Visible = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
            }
            else
            {
                lbten.Visible = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
            }
        }
    }
}
