using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    internal class QuanLy
    {

        private LinkedList<Sach> sachs;
        private LinkedList<BanDoc> banDocs;
        private LinkedList<PhieuMuon> phieuMuons;
        private LinkedList<User> users;
        private string userFile = "Admin.txt";
        private string bookFile = "Sach.txt";
        private string phieuMuonFile = "PhieuMuon.txt";
        private string banDocFile = "BanDoc.txt";
        public QuanLy()
        {
            sachs = new LinkedList<Sach>();
            banDocs = new LinkedList<BanDoc>();
            phieuMuons = new LinkedList<PhieuMuon>();
            users = new LinkedList<User>();
        }

        public bool SelectUser()
        {
            try
            {
                using (StreamReader reader = new StreamReader(userFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] strings = line.Split("_");
                        User u = new User(strings[0], strings[1]);
                        users.AddLast(u);
                    }
                }
                return true;
            }
            catch (Exception )
            {
                Console.WriteLine("User error: Lỗi dữ liệu !" );
                return false;
            }
          
        }
        public bool SelectSach()
        {
            try
            {
                using (StreamReader reader = new StreamReader(bookFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] strings = line.Split("_");
                        Sach sach = new Sach(strings[0], strings[1], strings[2], strings[3], double.Parse(strings[4]), int.Parse(strings[5]), int.Parse(strings[6]), strings[7], int.Parse(strings[8]));
                        sachs.AddLast(sach);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Sach error: Loi du lieu!");

                return false;
            }
        }
        public bool SelectPhieuMuon()
        {
            try
            {

                using (StreamReader reader = new StreamReader(phieuMuonFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) !=null)
                    {
                        string[] strings = line.Split("_");
                        PhieuMuon phieuMuon = new PhieuMuon(strings[0], strings[1], strings[2], strings[3], strings[4],int.Parse(strings[5]));
                        phieuMuons.AddLast(phieuMuon);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Phieu muon error: loi du lieu!");
                return false;
            }
        }
        public bool SelectBanDoc()
        {
            try
            {
                using (StreamReader reader = new StreamReader(banDocFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) !=null)
                    {
                        string[] s = line.Split("_");
                        BanDoc banDoc = new BanDoc(s[0], s[1], s[2]);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Ban doc erro: Loi du lieu");
                return false;
            }
        }


        public bool UpdateSach()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(bookFile))
                {
                    LinkedListNode<Sach> sachNode = sachs.First;
                    while (sachNode != null)
                    {
                        writer.WriteLine(sachNode.Value.sachPrinFile());
                        sachNode = sachNode.Next;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Sach error: Loi ghi file!");
                return false;
            }

        }
        public bool UpdatePhieuMuon()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(phieuMuonFile))
                {
                    LinkedListNode<PhieuMuon> phieuMuonNode = phieuMuons.First;
                    while(phieuMuonNode != null)
                    {
                        writer.WriteLine(phieuMuonNode.Value.PrintFile());
                        phieuMuonNode=phieuMuonNode.Next;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Phieu muon erro: Loi ghi file!");
                return false;
            }
        }
        public bool UpdateBanDoc()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(banDocFile))
                {
                    LinkedListNode<BanDoc> node = banDocs.First;
                    while (node != null)
                    {

                        node.Value.PrintFile();
                        node=node.Next;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Ban doc error: Loi ghi file!");
                return false;
            }
        }



        public bool AddSach(Sach sach)
        {
            if(ExistSach(sach.MaSach) == true)
            {
                Console.WriteLine("Sach error: Ma sach ton tai!");
                return false;
            }
            bool b = false;
            try
            {
                
                sachs.AddLast(sach);
                b = true;
                b =  UpdateSach();
                b =  SelectSach();
            }
            catch (Exception)
            {
                b = false;
            }
            return b;

        }
        public bool AddPhieuMuon(PhieuMuon phieuMuon)
        {
            bool b = false;
            try
            {
                DateTime dateTime = DateTime.Now;
                phieuMuon.MaPhieuMuon = $"{dateTime.Year}TDC{dateTime.DayOfYear}_{phieuMuons.Count+1}";
                phieuMuons.AddLast(phieuMuon);
                b = true;
                b = UpdatePhieuMuon();
                b = SelectPhieuMuon();
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        public bool AddBanDoc(BanDoc banDoc)
        {
            bool b = false;
            try
            {
                DateTime dateTime = DateTime.Now;
                banDoc.MaBD = $"{dateTime.Year}TDC{dateTime.Month}{banDocs.Count+1}";
                banDocs.AddLast(banDoc);
                b = true;
                b = UpdateBanDoc();
                b = SelectBanDoc();
            }
            catch (Exception)
            {
                Console.WriteLine("Ban doc error: Khong the them!");
                return false;
            }
            return b;
        }


        public bool LoginUser(User user)
        {
            LinkedListNode<User> node = users.First;

            while (node != null)
            {
                if (node.Value.UserName.Equals(user.UserName) && node.Value.Password.Equals(user.Password))
                {
                    return true;
                }
            }
            return false;   
        }



        public bool ExistSach(string maSach)
        {
            LinkedListNode<Sach> node = sachs.First;
            while (node != null)
            {
                if (node.Value.MaSach.Equals(maSach))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExistPhieu(string maPhieuMuon)
        {
            LinkedListNode<PhieuMuon> node = phieuMuons.First;
            while (node != null)
            {
                if (node.Value.Equals(maPhieuMuon))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExistBanDDoc(string maBanDoc)
        {
            LinkedListNode<BanDoc> node = banDocs.First;
            while(node != null)
            {
                if (node.Value.MaBD.Equals(maBanDoc))
                {
                    return true;
                }
            }
            return false;
        }


        public bool RemoveSach(string maSach)
        {
            try
            {
                LinkedListNode<Sach> node = sachs.First;
                while (node != null)
                {
                    if (node.Value.MaSach.Equals(maSach))
                    {
                        if (node.Value.TinhTrang!=0)
                        {
                            node = node.Next;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
        

        public bool TraSach(string maPhieu)
        {
            if (ExistPhieu(maPhieu) == false)
            {
                return false;
            }
            LinkedListNode<PhieuMuon> node = phieuMuons.First;
            while (node != null) {
               
            }
            return true;
        }
    }
}
