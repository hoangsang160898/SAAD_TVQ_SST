using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace DTO
{
    public class SachDTO
    {
        private int maSach;
        private string tenSach;
        private string tacGia;
        private double donGiaNhap;
        private double donGiaBan;
        private int soLuong;
        private int maLoai;
        private string tenLoai;
        private string ngaySX;
        private string ngayNhap;
        private BitmapImage hinhAnh;
        private BitmapImage hinhAnhCover;



        public int MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public double DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        public double DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string NgaySX { get => ngaySX; set => ngaySX = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public BitmapImage HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public BitmapImage HinhAnhCover { get => hinhAnhCover; set => hinhAnhCover = value; }

        //public SachDTO(int maSach, string tenSach, string tacGia, double donGiaNhap, double donGiaBan, int soLuong, int maLoai, string ngaySX, string ngayNhap, BitmapImage hinhAnh, BitmapImage hinhAnhCover)
        public SachDTO(int maSach, string tenSach, string tacGia, double donGiaNhap, double donGiaBan, int soLuong, int maLoai,string tenLoai, string ngaySX, string ngayNhap)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.donGiaNhap = donGiaNhap;
            this.donGiaBan = donGiaBan;
            this.soLuong = soLuong;
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
            this.ngaySX = ngaySX;
            this.ngayNhap = ngayNhap;
          
        }
        public SachDTO()
        {
     
        }
        public SachDTO(SachDTO src)
        {
            maSach = src.maSach;
            tenSach = src.tenSach;
            tacGia = src.tacGia;
            donGiaNhap = src.donGiaNhap;
            donGiaBan = src.donGiaBan;
            soLuong = src.soLuong;
            maLoai = src.maLoai;
            tenLoai = src.tenLoai;
            ngaySX = src.ngaySX;
            ngaySX = src.ngayNhap;
            HinhAnh = src.hinhAnh;
            HinhAnhCover = src.HinhAnhCover;
        }

       

        public static BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri("pack://application:,,,/" + filename));
        }

        public static BitmapImage BitmapImageFromBytes(byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
    }
}
