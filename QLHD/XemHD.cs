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
    public partial class XemHD : Form
    {
        public XemHD()
        {
            InitializeComponent();
        }

        DataBaseDataContext data = new DataBaseDataContext();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void XemHD_Load(object sender, EventArgs e)
        {
            data = new DataBaseDataContext();
            var query = from hd in data.HoaDons
                        join kh in data.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        select new
                        {
                            Mã_hóa_đơn = hd.MaHoaDon,
                            Mã_KH = hd.MaKhachHang,
                            Tên_KH = kh.TenKhachHang,
                            Ngày_lập = hd.NgayLap,
                            Tổng_tiền = hd.TongTien
                        };
            data_hd.DataSource = query.ToList();
            data_hd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void data_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = data_hd.Rows[e.RowIndex];
            txt_mahd.Text = row.Cells["Mã_hóa_đơn"].Value.ToString();
            txt_date.Text = row.Cells["Ngày_lập"].Value.ToString();

            txt_totalMoney.Text = row.Cells["Tổng_tiền"].Value.ToString();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var delete_cthd = data.ChiTietHoaDons.Where(ct => ct.MaHoaDon == Convert.ToInt32(txt_mahd.Text));
                data.ChiTietHoaDons.DeleteAllOnSubmit(delete_cthd);
                var delete_hd = data.HoaDons.Where(s => s.MaHoaDon == Convert.ToInt32(txt_mahd.Text)).SingleOrDefault();

                if (delete_hd != null)
                {
                    data.HoaDons.DeleteOnSubmit(delete_hd);
                    data.SubmitChanges();
                    XemHD_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại: " + ex.Message);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_Search.Text))
            {
                XemHD_Load(sender, e);
            }
            else
            {
                string searchText = txt_Search.Text;

                var query = from hd in data.HoaDons
                            join kh in data.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                            where hd.MaHoaDon.ToString().Contains(searchText) || kh.TenKhachHang.Contains(searchText)
                            select new
                            {
                                Mã_hóa_đơn = hd.MaHoaDon,
                                Mã_KH = hd.MaKhachHang,
                                Tên_KH = kh.TenKhachHang,
                                Ngày_lập = hd.NgayLap,
                                Tổng_tiền = hd.TongTien
                            };
                data_hd.DataSource = query.ToList();
                data_hd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
