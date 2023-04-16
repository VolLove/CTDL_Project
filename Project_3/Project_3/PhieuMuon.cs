using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    internal class PhieuMuon
    {
        private string maPhieuMuon;
        private string maDG;
        private string maSach;
        private DateTime ngayMuon;
        private DateTime ngayTra;
        private int tinhTrang;

        public PhieuMuon() {
        
            tinhTrang = 0;
            ngayMuon = DateTime.Now;
            ngayTra = ngayMuon.AddDays(7);
        }
        public PhieuMuon( string maDG, string maSach)
        {
            this.maDG = maDG;
            this.maSach = maSach;
            tinhTrang = 0;
            ngayMuon = DateTime.Now;
            ngayTra = ngayMuon.AddDays(7);
        }
        public PhieuMuon(string maPhieuMuon, string maDG, string maSach, string ngayMuon, string ngayTra, int tinhTrang)
        {
            this.maPhieuMuon = maPhieuMuon;
            this.maDG = maDG;
            this.maSach = maSach;
            string[] s = ngayMuon.Split('/');
            this.ngayMuon = new DateTime(int.Parse(s[2]),int.Parse(s[0]), int.Parse(s[1]));
            s = ngayTra.Split('/');
            this.ngayTra = new DateTime(int.Parse(s[2]), int.Parse(s[0]), int.Parse(s[1]));
            this.tinhTrang = tinhTrang;
        }

        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public string MaDG { get => maDG; set => maDG = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public string Print()
        {
            return $"|{MaPhieuMuon,-10}|{maDG,-10}|{maSach,-10}|{ngayMuon.ToString("MM/dd/yyyy"),-12}|{ngayTra.ToString("MM/dd/yyyy"),-12}|";
        }
        public string PrintFile()
        {
            return $"{maPhieuMuon}_{maDG}_{MaSach}_{ngayMuon.ToString("MM/dd/yyyy")}_{ngayTra.ToString("MM/dd/yyyy")}_{tinhTrang}";
        }
    }
}
