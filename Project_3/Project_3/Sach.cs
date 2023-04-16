using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    internal class Sach
    {
        private string maSach;
        private string tenSach;
        private string tacGia;
        private string nhaXB;
        private double giaBan;
        private int namPH;
        private int soTrang;
        private DateTime ngayNK;
        private int tinhTrang;

        private Sach() { }
        public Sach(string maSach, string tenSach, string tacGia, string nhaXB, double giaBan, int namPH, int soTrang)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.nhaXB = nhaXB;
            this.giaBan = giaBan;
            this.namPH = namPH;
            this.soTrang = soTrang;
            this.ngayNK = DateTime.Now;
            this.tinhTrang = 0;
        }
        public Sach(string maSach, string tenSach, string tacGia, string nhaXB, double giaBan, int namPH, int soTrang, string ngayNK, int tinhTrang)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.nhaXB = nhaXB;
            this.giaBan = giaBan;
            this.namPH = namPH;
            this.soTrang = soTrang;
            string[] strings = ngayNK.Split("/");
            this.ngayNK = new DateTime(int.Parse(strings[2]), int.Parse(strings[0]), int.Parse(strings[1]));
            this.tinhTrang = tinhTrang;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public string NhaXB { get => nhaXB; set => nhaXB = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public int NamPH { get => namPH; set => namPH = value; }
        public int SoTrang { get => soTrang; set => soTrang = value; }
        public DateTime NgayNK { get => ngayNK; set => ngayNK = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }


        public string sachPrinFile()
        {
            return $"{maSach}_{tenSach}_{tacGia}_{nhaXB}_{giaBan}_{namPH}_{soTrang}_{ngayNK.ToString("MM/dd/yyyy")}_{tinhTrang}";
        }
    }
}
