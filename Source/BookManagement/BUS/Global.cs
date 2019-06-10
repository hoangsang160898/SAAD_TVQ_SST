using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class Global
    {
        public static List<SachDTO> Books;
        public static List<TheLoaiDTO> Categories;
        public static List<TheLoaiDTO> BookCategories;
        public static List<ChiTietHoaDonBanSachDTO> BookBoughtBills;
        public static List<ChiTietHoaDonBanSachDTO> BookBoughtBillsPreview;
        public static List<PhieuThuTienDTO> Bills;
        public static List<KhachHangDTO> Customers;
        public static List<int> ControlRules;
        public static List<double> Rules;
        public static List<BaoCaoTonSachDTO> BookReport;
             public static List<BaoCaoCongNoDTO> CustomerReport;
    }
}
