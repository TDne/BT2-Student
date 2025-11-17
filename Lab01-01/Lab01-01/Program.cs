using System;
using System.Collections.Generic;

namespace Lab01_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<string> maSo = new List<string>();
            List<string> hoTen = new List<string>();
            List<string> khoa = new List<string>();
            List<double> diem = new List<double>();

            int luaChon = -1;

            while (luaChon != 0)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1 - Thêm sinh viên");
                Console.WriteLine("2 - Xem danh sách");
                Console.WriteLine("0 - Thoát");
                Console.Write("Chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                if (luaChon == 1)
                {
                    Console.Write("Mã số: ");
                    maSo.Add(Console.ReadLine());

                    Console.Write("Họ tên: ");
                    hoTen.Add(Console.ReadLine());

                    Console.Write("Khoa: ");
                    khoa.Add(Console.ReadLine());

                    Console.Write("Điểm: ");
                    diem.Add(double.Parse(Console.ReadLine()));

                    Console.WriteLine("Thêm thành công!");
                }
                else if (luaChon == 2)
                {
                    Console.WriteLine("\n===== DANH SÁCH =====");
                    if (maSo.Count == 0)
                    {
                        Console.WriteLine("Chưa có sinh viên nào!");
                    }
                    else
                    {
                        for (int i = 0; i < maSo.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {maSo[i]} - {hoTen[i]} - {khoa[i]} - {diem[i]}");
                        }
                    }
                }
            }

            Console.WriteLine("END!");
        }
    }
}
