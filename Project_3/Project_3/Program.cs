using System;
using System.Text;

namespace Project_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 200;
            ScreeenMain();
        }
        static void ScreeenMain()
        {
            QuanLy quanLy = new QuanLy();

            if (Login(quanLy) == true)
            {
                ConsoleKey k;
                do
                {
                    Console.Clear();
                    Logo();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\tNhan phim chon chuc nang: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\t1. Quan ly sach.");
                    Console.WriteLine("\t2. Quan ly phieu muon.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tESC. Thoat.");
                    Console.Write("\t");
                    k = Console.ReadKey().Key;
                    if (k == ConsoleKey.Escape)
                    {
                        Console.WriteLine("\n\t\\Ban co muon thoat?");
                        Console.Write("\tY. Thoat");
                        k = Console.ReadKey().Key;
                        if (k == ConsoleKey.Y)
                        {
                            return;
                        }
                    }
                    Console.WriteLine();
                    switch (k)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            ConsoleKey h;
                            do
                            {
                                Logo();
                                quanLy.TableSach();
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("\tNhan phim chon chuc nang: ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t1. Them sach.");
                                Console.WriteLine("\t2. Xoa sach.");
                                Console.WriteLine("\t3. Quay lai menu.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\tESC. Thoat.");
                                Console.Write("\t");
                                h = Console.ReadKey().Key;
                                if (h == ConsoleKey.Escape)
                                {
                                    Console.WriteLine("\\Ban co muon thoat?");
                                    Console.Write("\tY.Thoat");
                                    Console.Write("\tKhac. No");
                                    h = Console.ReadKey().Key;
                                    if (h == ConsoleKey.Y)
                                    {
                                        return;
                                    }

                                }
                                switch (h)
                                {
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        ConsoleKey j;
                                        Logo();
                                        quanLy.TableSach();
                                        Console.WriteLine();
                                        Sach sach = ThemSach();
                                        if (quanLy.AddSach(sach))
                                        {
                                            Console.WriteLine("Them sach thanh cong!");
                                        }
                                        Console.WriteLine("\t1. Quay lai menu.");
                                        Console.WriteLine("\tESC. Thoat.");
                                        do
                                        {
                                            ConsoleKeyInfo info = Console.ReadKey(true);
                                            j = info.Key;
                                            if (j == ConsoleKey.Escape)
                                            {
                                                Console.WriteLine("Ban co muon thoat?");
                                                Console.Write("\tY.Thoat");
                                                Console.Write("\t");
                                                info = Console.ReadKey(true);
                                                j = info.Key;
                                                if (j == ConsoleKey.Y)
                                                {
                                                    return;
                                                }
                                                Console.WriteLine();
                                                Console.Write("\t");
                                            }
                                        } while (j != ConsoleKey.D1);
                                        break;
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Logo();
                                        quanLy.TableSach();
                                        Console.WriteLine();
                                        Console.Write("\tNhap ma sach muon xoa: ");
                                        string maSach = Console.ReadLine();
                                        if (quanLy.FindSach(maSach) != null)
                                        {
                                            Console.WriteLine("\tBan co muon xoa thong tin sach?");
                                            Console.WriteLine("\tY. Yes");
                                            Console.WriteLine("\tKhac. No");
                                            Console.Write("\t");
                                            j = Console.ReadKey().Key;
                                            if (j == ConsoleKey.Y)
                                            {
                                                if (quanLy.RemoveSach(maSach))
                                                {
                                                    Console.WriteLine("\tSach xoa thanh cong!");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong tim thay!");
                                        }
                                        Console.WriteLine("\t1. Quay lai menu.");
                                        Console.WriteLine("\tESC. Thoat.");
                                        Console.Write("\t");
                                        do
                                        {
                                            ConsoleKeyInfo info = Console.ReadKey(true);
                                            j = info.Key;
                                            if (j == ConsoleKey.Escape)
                                            {
                                                Console.WriteLine("Ban co muon thoat?");
                                                Console.WriteLine("\tY.Thoat");
                                                Console.WriteLine("\tKhac. No");
                                                Console.Write("\t");
                                                info = Console.ReadKey(true);
                                                j = info.Key;
                                                if (j == ConsoleKey.Y)
                                                {
                                                    return;
                                                }
                                                Console.WriteLine();
                                                Console.Write("\t");
                                            }
                                        } while (j != ConsoleKey.D1);
                                        break;
                                    default:
                                        break;
                                }
                                Console.Clear();
                            } while (h != ConsoleKey.D3);
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            do
                            {
                                Console.Clear();
                                Logo();
                                quanLy.TablePhieu();
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("\tNhan phim chon chuc nang: ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t1. Muon sach.");
                                Console.WriteLine("\t2. Tra sach.");
                                Console.WriteLine("\t3. Quay lai menu.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\tESC. Thoat.");
                                Console.Write("\t");
                                h = Console.ReadKey(true).Key;

                                if (h == ConsoleKey.Escape)
                                {
                                    Console.WriteLine("\n\t\\Ban co muon thoat?");
                                    Console.Write("\tY. Thoat");
                                    h = Console.ReadKey().Key;
                                    if (h == ConsoleKey.Y)
                                    {
                                        return;
                                    }
                                }
                                switch (h)
                                {
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        ConsoleKey j;
                                        Logo();
                                        quanLy.TablePhieu();
                                        quanLy.MuonSach();
                                        Console.WriteLine("\t1. Quay lai menu.");
                                        Console.WriteLine("\tESC. Thoat.");
                                        Console.Write("\t");
                                        do
                                        {
                                            ConsoleKeyInfo info = Console.ReadKey(true);
                                            j = info.Key;
                                            if (j == ConsoleKey.Escape)
                                            {
                                                Console.WriteLine("Ban co muon thoat?");
                                                Console.Write("\tY.Thoat");
                                                Console.Write("\t");
                                                info = Console.ReadKey(true);
                                                j = info.Key;
                                                if (j == ConsoleKey.Y)
                                                {
                                                    return;
                                                }
                                                Console.WriteLine();
                                                Console.Write("\t");
                                            }
                                        } while (j != ConsoleKey.D1);
                                        break;
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Logo();
                                        quanLy.TablePhieu();
                                        quanLy.TraSach();
                                        Console.WriteLine("\t1. Quay lai menu.");
                                        Console.WriteLine("\tESC. Thoat.");
                                        Console.Write("\t");
                                        do
                                        {
                                            ConsoleKeyInfo info = Console.ReadKey(true);
                                            j = info.Key;
                                            if (j == ConsoleKey.Escape)
                                            {
                                                Console.WriteLine("Ban co muon thoat?");
                                                Console.Write("\tY.Thoat");
                                                Console.Write("\t");
                                                info = Console.ReadKey(true);
                                                j = info.Key;
                                                if (j == ConsoleKey.Y)
                                                {
                                                    return;
                                                }
                                                Console.WriteLine();
                                                Console.Write("\t");
                                            }
                                        } while (j != ConsoleKey.D1);
                                        break;
                                    default:
                                        break;
                                }
                            } while (h != ConsoleKey.D3);

                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                    Console.Clear();
                } while (k != ConsoleKey.Escape);
            }
        }

        static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\t* *                                                                             * *");
            Console.Write("\t* *                               ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Thu Vien");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                      * *\"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t* *                                                                             * *");
            Console.WriteLine("\t* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static bool Login(QuanLy quanLy)
        {
            int x = 0;
            User user = new User();
            do
            {
                string name = "", password = "";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                Console.Write("\t*                                ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("DANG NHAP HE THONG");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                               *");
                Console.WriteLine("\t* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tUser");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(":  ");
                ConsoleKeyInfo info = Console.ReadKey(true);
                while (info.Key != ConsoleKey.Enter)
                {
                    if (info.Key == ConsoleKey.Escape)
                    {
                        return false;
                    }
                    //Kiểm tra có phải là phím Backspace hay không
                    if (info.Key != ConsoleKey.Backspace)
                    {
                        name += info.KeyChar;
                        Console.Write(info.KeyChar);

                    }
                    else if (name.Length > 0)
                    {
                        //Bỏ ký tự cuối cùng
                        name = name.Substring(0, name.Length - 1);
                        Console.Write("\b \b");
                    }
                    info = Console.ReadKey(true);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tPassword");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": ");
                info = Console.ReadKey(true);
                while (info.Key != ConsoleKey.Enter)
                {
                    if (info.Key == ConsoleKey.Escape)
                    {
                        return false;
                    }
                    //Kiểm tra có phải là phím Backspace hay không
                    if (info.Key != ConsoleKey.Backspace)
                    {
                        password += info.KeyChar;
                        //Ẩn password
                        Console.Write('*');
                    }
                    else if (password.Length > 0)
                    {
                        //Bỏ ký tự cuối cùng
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                    info = Console.ReadKey(true);
                }
                Console.WriteLine();
                user = new(name, password);
                x++;
                if (quanLy.LoginUser(user) == true)
                {
                    Console.WriteLine("\tDang nhap thanh cong!");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("\tDang nhap sai! vui long nhap lai!");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (x < 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tDang nhap that bai! Ket thuc chuong trinh!");
            Console.ReadKey();
            return false;

        }
        static Sach ThemSach()
        {
            string maSach = "", tacGia = "", tenSach = "", nhaSX = "";
            int giaban = -1, nam = -1, sotrang = -1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\tMa sach: ");
                Console.ForegroundColor = ConsoleColor.White;
                maSach = Console.ReadLine();
                if (maSach == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tKhong nhap chuoi rong!");
                }
            } while (maSach == "");
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\tTen sach : ");
                Console.ForegroundColor = ConsoleColor.White;
                tenSach = Console.ReadLine();
                if (tenSach == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tKhong nhap chuoi rong!");
                }
            } while (tenSach == "");
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\tTac gia: ");
                Console.ForegroundColor = ConsoleColor.White;
                tacGia = Console.ReadLine();
                if (tacGia == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tKhong nhap chuoi rong!");
                }
            } while (tacGia == "");
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\tNha san xuat: ");
                Console.ForegroundColor = ConsoleColor.White;
                nhaSX = Console.ReadLine();
                if (nhaSX == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tKhong nhap chuoi rong!");
                }
            } while (nhaSX == "");
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\tGia ban: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    giaban = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    giaban = -1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tVui long nhap so lon hon hoac bang 0!");
                }
            } while (giaban < 0);

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\tNam phat hanh: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    nam = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    nam = -1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tVui long nhap dung nam");
                }
            } while (nam < 0);
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\tSo trang: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    sotrang = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    sotrang = -1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tVui long nhap dung nam");
                }
            } while (sotrang < 0);
            Sach sach = new Sach(maSach, tenSach, tacGia, nhaSX, giaban, nam, sotrang);
            return sach;
        }
    }
}
