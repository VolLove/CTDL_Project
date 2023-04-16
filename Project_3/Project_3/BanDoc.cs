using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    internal class BanDoc
    {
        private string maBD;
        private string name;
        private DateTime ngayDK;

        private BanDoc() { }    
        public BanDoc(string maBD, string name, DateTime ngayDK)
        {
            this.maBD = maBD;
            this.name = name;
            this.ngayDK = ngayDK;
        }

        public string MaBD { get => maBD; set => maBD = value; }
        public string Name { get => name; set => name = value; }
        public DateTime NgayDK { get => ngayDK; set => ngayDK = value; }
    }
}
