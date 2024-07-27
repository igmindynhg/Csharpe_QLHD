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
    public partial class TaoHoaDon : Form
    {
        public TaoHoaDon()
        {
            InitializeComponent();
        }
        DataBaseDataContext data = new DataBaseDataContext();

        private void TaoHoaDon_Load(object sender, EventArgs e)
        {
            data = new DataBaseDataContext();

            var query = from a in data.HoaDons
                        join b in data.KhachHangs on a.MaKhachHang equals b.MaKhachHang
                        select new
                        {
                            Mã_hóa_đơn = a.MaHoaDon,
                            Mã_khách_hàng = a.MaKhachHang,
                            Tên_khách_hàng = b.TenKhachHang,
                            Ngày_tạo = a.NgayLap,
                            Tổng_tiền = a.TongTien,
                            Trạng_thái = a.TrangThai
                        };

            var query1 = from a in data.ChiTietHoaDons
                         join b in data.SanPhams on a.MaSanPham equals b.MaSanPham
                         select new
                         {
                             Mã_CTHD = a.MaCthd,
                             Mã_hóa_đơn = a.MaHoaDon,
                             Mã_sản_phẩm = b.MaSanPham,
                             Tên_sản_phẩm = b.TenSanPham,
                             Số_lượng = a.SoLuongSp,
                             Tổng_tiền = a.ThanhTien
                         };
            data_hdCreate.DataSource = query.ToList();
            data_hdCreate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            data_cthd.DataSource = query1.ToList();
            data_cthd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        

        private void btn_createHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon kh = new HoaDon();

                kh.NgayLap = DateTime.Now;

                kh.TongTien = 0;
                kh.TrangThai = "Chưa thanh toán";
                kh.MaKhachHang = Convert.ToInt32(txt_maKH.Text);

                data.HoaDons.InsertOnSubmit(kh);
                data.SubmitChanges();

                MessageBox.Show("Tạo hóa đơn thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Tạo hóa đơn Thất Bại");
            }
            finally
            {
                var qlpb = data.HoaDons;
                data_hdCreate.DataSource = qlpb;
                TaoHoaDon_Load(sender, e);
            }
        }

        private void data_hdCreate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow row = new DataGridViewRow();
            row = data_hdCreate.Rows[e.RowIndex];
            txt_mahd2.Text = row.Cells["Mã_Hóa_Đơn"].Value.ToString();

            txtStatus.Text = row.Cells["Trạng_thái"].Value.ToString();*/
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = data_hdCreate.Rows[e.RowIndex];
                int selectedInvoiceId = Convert.ToInt32(row.Cells["Mã_hóa_đơn"].Value);

                txt_mahd2.Text = row.Cells["Mã_hóa_đơn"].Value.ToString();
                txtStatus.Text = row.Cells["Trạng_thái"].Value.ToString();

               
                var query = from a in data.ChiTietHoaDons
                            join b in data.SanPhams on a.MaSanPham equals b.MaSanPham
                            where a.MaHoaDon == selectedInvoiceId
                            select new
                            {
                                Mã_CTHD = a.MaCthd,
                                Mã_hóa_đơn = a.MaHoaDon,
                                Mã_sản_phẩm = b.MaSanPham,
                                Tên_sản_phẩm = b.TenSanPham,
                                Số_lượng = a.SoLuongSp,
                                Tổng_tiền = a.ThanhTien
                            };

                data_cthd.DataSource = query.ToList();
                data_cthd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                SanPham sp = (from ass in data.SanPhams
                              where ass.MaSanPham == Convert.ToInt32(txt_masp.Text)
                              select ass).FirstOrDefault();
                if (sp != null)
                {
                    cthd.SoLuongSp = Convert.ToInt32(txt_sl.Text);
                    cthd.MaSanPham = sp.MaSanPham;
                    String TenSanPham = (from ass in data.SanPhams
                                         where ass.MaSanPham == Convert.ToInt32(txt_masp.Text)
                                         select ass.TenSanPham).FirstOrDefault();
                    cthd.MaHoaDon = Convert.ToInt32(txt_mahd2.Text);

                    if (sp.DonGia > 0f) // Kiểm tra giá trị của giaBan
                    {
                        cthd.ThanhTien = cthd.SoLuongSp * sp.DonGia;
                    }
                    else
                    {
                        cthd.ThanhTien = 0f;
                    }
                    data.ChiTietHoaDons.InsertOnSubmit(cthd);
                    data.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mặt hàng trong cơ sở dữ liệu.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ.");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            finally
            {
                var qlpb = from cthd in data.ChiTietHoaDons
                           join sp in data.SanPhams on cthd.MaSanPham equals sp.MaSanPham
                           select new
                           {
                               Mã_CTHD = cthd.MaCthd,
                               Mã_hóa_đơn = cthd.MaHoaDon,
                               Mã_sản_phẩm = cthd.MaSanPham,
                               Tên_sản_phẩm = sp.TenSanPham,
                               Số_lượng = cthd.SoLuongSp,
                               Tổng_tiền = cthd.ThanhTien
                           };
                data_cthd.DataSource = qlpb;
                TaoHoaDon_Load(sender, e);
            }

        }

        private void data_cthd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_cthd.Rows[e.RowIndex];

            txt_macthd.Text = row.Cells["Mã_CTHD"].Value.ToString();
            txt_mahd2.Text = row.Cells["Mã_Hóa_Đơn"].Value.ToString();
            txt_sl.Text = row.Cells["Số_Lượng"].Value.ToString();

            txt_masp.Text = row.Cells["Mã_sản_phẩm"].Value.ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var macthd = txt_macthd.Text;
                ChiTietHoaDon del_pb = data.ChiTietHoaDons.Where(o => o.MaCthd.Equals(macthd)).FirstOrDefault();
                data.ChiTietHoaDons.DeleteOnSubmit(del_pb);
                data.SubmitChanges();


            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất Bại !");
            }
            finally
            {
                var pb3 = data.ChiTietHoaDons;
                data_cthd.DataSource = pb3;

                TaoHoaDon_Load(sender, e);

            }
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Convert.ToInt32(txt_mahd2.Text);
                var hoaDon = data.HoaDons.FirstOrDefault(h => h.MaHoaDon == a);

                if (hoaDon != null)
                {
                    if (hoaDon.TrangThai == "Đã thanh toán")
                    {
                        MessageBox.Show("Hóa đơn đã thanh toán.");
                    }
                    else if (hoaDon.TrangThai == "Chưa thanh toán")
                    {
                        var chiTietHoaDons = data.ChiTietHoaDons.Where(cthd => cthd.MaHoaDon == a).ToList();
                        double tongTien = 0;

                        foreach (var cthd in chiTietHoaDons)
                        {
                            tongTien += Convert.ToDouble(cthd.ThanhTien);
                            // Trừ số lượng đã bán từ số lượng tồn của mặt hàng tương ứng
                            var matHang = data.SanPhams.FirstOrDefault(mh => mh.MaSanPham == cthd.MaSanPham);
                            if (matHang != null)
                            {
                                matHang.SoLuong -= cthd.SoLuongSp;
                            }
                        }

                        hoaDon.TongTien = tongTien;
                        hoaDon.TrangThai = "Đã thanh toán";

                        data.SubmitChanges();
                        MessageBox.Show("Hóa đơn đã được thanh toán.");
                    }
                    else
                    {
                        MessageBox.Show("Trạng thái hóa đơn không hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi kiểm tra trạng thái hóa đơn.");
            }
            finally
            {
                TaoHoaDon_Load(sender, e);
            }



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void data_cthd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
