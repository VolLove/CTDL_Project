using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    internal class PhieuMuon
    {
        private string maDG;
        private DateTime ngayMuon;
        private int tinhTrang;
        private int sTT;

        public string MaDG { get => maDG; set => maDG = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int STT { get => sTT; set => sTT = value; }

        public PhieuMuon(string maDG, DateTime ngayMuon, int tinhTrang, int sTT)
        {
            this.maDG = maDG;
            this.ngayMuon = ngayMuon;
            this.tinhTrang = tinhTrang;
            this.sTT = sTT;
        }
    }
}
