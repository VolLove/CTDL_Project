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
        private int sTT;

        public PhieuMuon() { }
        public PhieuMuon(string maPhieuMuon, string maDG, string maSach, DateTime ngayMuon, DateTime ngayTra, int tinhTrang, int sTT)
        {
            this.maPhieuMuon = maPhieuMuon;
            this.maDG = maDG;
            this.maSach = maSach;
            this.ngayMuon = ngayMuon;
            this.ngayTra = ngayTra;
            this.tinhTrang = tinhTrang;
            this.sTT = sTT;
        }

        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public string MaDG { get => maDG; set => maDG = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int STT { get => sTT; set => sTT = value; }
    }
}
