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
        public QuanLy()
        {
            sachs = new LinkedList<Sach>();
            banDocs = new LinkedList<BanDoc>();
            phieuMuons = new LinkedList<PhieuMuon>();
            users = new LinkedList<User>();
            SelectUser();
            SelectSach();
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
                return false;
            }
          
        }
        public bool AddSach(Sach sach)
        {
            try
            {
                sachs.AddLast(sach);
                return true;
            }
            catch (Exception)
            {
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
                return false;
            }
        }
        public bool updateSach()
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
                return false;
            }

        }
        
    }
}
