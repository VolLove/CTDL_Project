using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            SelectBanDoc();
            SelectPhieuMuon();
            SelectUser();
            SelectSach();
        }

        //////////////////////////

        /// <summary>
        /// Lấy danh sách user trong file Admin.txt
        /// Dữ liệu lưu vào Linkedlist users
        /// </summary>
        /// <returns>Lấy thành công return true</returns>
        public bool SelectUser()
        {
            users = new LinkedList<User>();
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
            catch (Exception)
            {
                Console.WriteLine("User error: Lỗi dữ liệu !");
                return false;
            }

        }
        /// <summary>
        /// Lấy danh sách sách trong file Sach.txt
        /// Dữ liệu lưu vào Linkedlist sachs
        /// </summary>
        /// <returns>Lấy thành công return true</returns>
        public bool SelectSach()
        {
            sachs = new LinkedList<Sach>();
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
        /// <summary>
        /// Lấy sanh sách phiếu mượn trong file PhieuMuon.txt
        /// Dữ liệu lưu vào Linkedlist phieuMuons
        /// </summary>
        /// <returns>Lấy thành công return true</returns>
        public bool SelectPhieuMuon()
        {
            phieuMuons = new LinkedList<PhieuMuon>();
            try
            {
                using (StreamReader reader = new StreamReader(phieuMuonFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] strings = line.Split("_");
                        PhieuMuon phieuMuon = new PhieuMuon(strings[0], strings[1], strings[2], strings[3], strings[4], int.Parse(strings[5]));
                        phieuMuons.AddLast(phieuMuon);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Phieu muon error: loi du lieu!");
                return false;
            }
        }
        /// <summary>
        /// Lấy danh sách bạn đọc trong file Bandoc.txt
        /// Dữ liệu lưu vào Linkedlist banDocs
        /// </summary>
        /// <returns>Lấy thành công return true</returns>
        public bool SelectBanDoc()
        {
            banDocs = new LinkedList<BanDoc>();
            try
            {
                using (StreamReader reader = new StreamReader(banDocFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] s = line.Split("_");
                        BanDoc banDoc = new BanDoc(s[0], s[1], s[2]);
                        banDocs.AddLast(banDoc);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ban doc erro: Loi du lieu");
                return false;
            }
        }

        ////////////////

        /// <summary>
        /// Lưu danh sách sách vào file Sach.txt.
        /// Ghi đè dữ liệu cũ trong file.
        /// </summary>
        /// <returns>Khi update thành công return true</returns>
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
        /// <summary>
        /// Lưu danh sách vào file PhieuMuon.txt.
        /// Ghi đè dữ liệu cũ trong file.
        /// </summary>
        /// <returns>Khi update thành công return true</returns>
        public bool UpdatePhieuMuon()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(phieuMuonFile))
                {
                    LinkedListNode<PhieuMuon> phieuMuonNode = phieuMuons.First;
                    while (phieuMuonNode != null)
                    {
                        writer.WriteLine(phieuMuonNode.Value.PrintFile());
                        phieuMuonNode = phieuMuonNode.Next;
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
        /// <summary>
        /// Lưu dữ liệu bạn đọc vào file BanDoc.txt.
        /// Ghi đè dữ liệu cũ trong file.
        /// </summary>
        /// <returns></returns>
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
                        node = node.Next;
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

        ////////////////////////

        /// <summary>
        /// Thêm sách mới vào danh sách.
        /// Nếu MaSach tồn tại kết thúc hàm, return false.
        /// Update danh sách và lấy lại dữ liệu.
        /// </summary>
        /// <param name="sach">Sách muốn thêm</param>
        /// <returns></returns>
        public bool AddSach(Sach sach)
        {
            if (ExistSach(sach.MaSach) == true)
            {
                Console.WriteLine("Sach error: Ma sach ton tai!");
                return false;
            }
            try
            {
                sachs.AddLast(sach);
                if (UpdateSach() == false)
                {
                    return false;
                }
                if (SelectSach() == false)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Sach error: Khong the them sach!");
                return false;
            }
            return true;

        }
        /// <summary>
        /// Thêm phiếu mượn.
        /// Update và lấy lại danh sách nếu thêm thành công.
        /// </summary>
        /// <param name="phieuMuon"></param>
        /// <returns></returns>
        public bool AddPhieuMuon(PhieuMuon phieuMuon)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                int x = dateTime.Hour * 1800 + dateTime.Minute * 60 + dateTime.Second;
                phieuMuon.MaPhieuMuon = $"{dateTime.Year}TDCTV{dateTime.DayOfYear}D{x}";
                phieuMuons.AddLast(phieuMuon);
                if (UpdatePhieuMuon() == false)
                {
                    return false;
                }
                if (SelectPhieuMuon() == false)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Phieu muon error:Khong the them phieu muon!");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Thêm bạn đọc mới.
        /// MaBD tồn tại kết thúc hàm, return false.
        /// Update và lấy lại danh sách nếu thêm thành công.
        /// </summary>
        /// <param name="banDoc"></param>
        /// <returns></returns>
        public bool AddBanDoc(BanDoc banDoc)
        {
            if (ExistBanDoc(banDoc.MaBD))
            {
                Console.WriteLine("Ban doc error: Ma ban doc ton tai!");
                return false;
            }
            try
            {
                DateTime dateTime = DateTime.Now;
                banDoc.MaBD = $"{dateTime.Year}TDC{dateTime.Month}{banDocs.Count + 1}";
                banDocs.AddLast(banDoc);
                if (UpdateBanDoc() == false)
                {
                    return false;
                }
                if (SelectBanDoc() == false)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ban doc error: Khong the them!");
                return false;
            }
            return true;
        }

        ////////////////////////

        /// <summary>
        /// Kiểm tra đăng nhập.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool LoginUser(User user)
        {
            LinkedListNode<User> node = users.First;

            while (node != null)
            {
                if (node.Value.UserName.Equals(user.UserName) && node.Value.Password.Equals(user.Password))
                {
                    return true;
                }
                node = node.Next;

            }
            return false;
        }

        ///////////////////////

        /// <summary>
        /// Kiểm tra tồn tại của sách.
        /// Mã sách tồn tại return true.
        /// </summary>
        /// <param name="maSach"></param>
        /// <returns></returns>
        public bool ExistSach(string maSach)
        {
            LinkedListNode<Sach> node = sachs.First;
            while (node != null)
            {
                if (node.Value.MaSach.Equals(maSach))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        /// <summary>
        /// Kiểm tra tồn tại phiếu mượn.
        /// Mã phiếu mượn tồn tại return true.
        /// </summary>
        /// <param name="maPhieuMuon"></param>
        /// <returns></returns>
        public bool ExistPhieu(string maPhieuMuon)
        {
            LinkedListNode<PhieuMuon> node = phieuMuons.First;
            while (node != null)
            {
                if (node.Value.Equals(maPhieuMuon))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        /// <summary>
        /// Kiểm tra tồn tại bạn đọc.
        /// Mã bạn đọc tồn tại return true.
        /// </summary>
        /// <param name="maBanDoc"></param>
        /// <returns></returns>
        public bool ExistBanDoc(string maBanDoc)
        {
            LinkedListNode<BanDoc> node = banDocs.First;
            while (node != null)
            {
                if (node.Value.MaBD.Equals(maBanDoc))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        private bool MuonChua(string maSach)
        {
            LinkedListNode<Sach> node = sachs.First;
            while (node != null)
            {
                if (node.Value.MaSach.Equals(maSach))
                {
                    if (node.Value.TinhTrang == 1)
                    {
                        return true;
                    }
                }
                node = node.Next;
            }
            return false;
        }
        private void TMuon(string maSach)
        {
            LinkedListNode<Sach> node = sachs.First;
            LinkedList<Sach> values = new LinkedList<Sach>();
            while (node != null)
            {
                if (node.Value.MaSach.Equals(maSach))
                {
                    node.Value.TinhTrang = 1;
                }
                    values.AddLast(node.Value);
                node = node.Next;

            }
            test(values);
        }
        private bool TTra(string maSach)
        {
            LinkedListNode<BanDoc> node = banDocs.First;
            while (node != null)
            {
                if (node.Value.MaBD.Equals(maSach))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        /////////////////////////

        /// <summary>
        /// Xoá sách khỏi danh sách.
        /// Nếu sách đang được mượn sẽ dừng quá trình và thông báo.
        /// </summary>
        /// <param name="maSach"></param>
        /// <returns></returns>
        public bool RemoveSach(string maSach)
        {
            try
            {
                LinkedListNode<Sach> node = sachs.First;
                while (node != null)
                {
                    if (node.Value.MaSach.Equals(maSach))
                    {
                        if (node.Value.TinhTrang != 0)
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

        ////////////////////////


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sach"></param>
        /// <param name="banDoc"></param>
        /// <returns></returns>
        public void MuonSach()
        {
            string maBD; string maSach="";
            int count = 0;
            do
            {
                Console.Write("Nhap ma ban doc: ");
                maBD = Console.ReadLine();
                if (ExistBanDoc(maBD) == false)
                {
                    Console.WriteLine("Ma ban doc sai! Nhap lai");
                    count++;
                }
            } while (ExistBanDoc(maBD)==false && count<3);
            if (count >=3)
            {
                return;
            }
            count = 0;
            do
            {
                Console.Write("Nhap ma sach: ");
                maSach = Console.ReadLine();
                if (ExistSach(maSach) == false)
                {
                    Console.WriteLine("Ma sach sai! Nhap lai!");
                    count++;
                }
            } while (ExistSach(maSach)==false && count<3);
            if (count >= 3)
            {
                return;
            }
            if (MuonChua(maSach) == true)
            {
                return;
            }
            PhieuMuon phieuMuon = new PhieuMuon(maBD, maSach);
            TMuon(maSach);
            if (AddPhieuMuon(phieuMuon) == false)
            {
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maPhieu"></param>
        /// <returns></returns>
        public void TraSach(string maPhieu)
        {
            
        }



        /////////////////////////
        public void test(LinkedList<Sach> saches)
        {
            LinkedListNode<Sach> node = saches.First;
            while (node != null)
            {
                Console.WriteLine(node.Value.sachPrin());
                node = node.Next;
            }
        }

    }
}
