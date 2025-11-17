using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Xuất DS sinh viên thuộc khoa CNTT");
                Console.WriteLine("4. Xuất DS sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Xuất DS sinh viên sắp xếp theo điểm TB tăng dần");
                Console.WriteLine("6. Xuất DS sinh viên có điểm TB >= 5 và khoa CNTT");
                Console.WriteLine("7. Xuất sinh viên có điểm TB cao nhất khoa CNTT");
                Console.WriteLine("8. Thống kê số lượng theo xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        ClassificationStatistics(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống!");
            }
            else
            {
                foreach (Student student in studentList)
                {
                    student.Show();
                }
            }
        }

        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0} ===", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            
            if (students.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa {0}!", faculty);
            }
            else
            {
                foreach (Student student in students)
                {
                    student.Show();
                }
            }
        }

        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} ===", minDTB);
            var students = studentList.Where(s => s.AverageScore >= minDTB).ToList();
            
            if (students.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào có điểm TB >= {0}!", minDTB);
            }
            else
            {
                foreach (Student student in students)
                {
                    student.Show();
                }
            }
        }

        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần ===");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            
            if (sortedStudents.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống!");
            }
            else
            {
                foreach (Student student in sortedStudents)
                {
                    student.Show();
                }
            }
        }

        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1} ===", minDTB, faculty);
            var students = studentList.Where(s => s.AverageScore >= minDTB 
                && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            
            if (students.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào có điểm TB >= {0} và thuộc khoa {1}!", minDTB, faculty);
            }
            else
            {
                foreach (Student student in students)
                {
                    student.Show();
                }
            }
        }

        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Sinh viên có điểm TB cao nhất thuộc khoa {0} ===", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            
            if (students.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa {0}!", faculty);
            }
            else
            {
                var topStudent = students.OrderByDescending(s => s.AverageScore).First();
                topStudent.Show();
            }
        }

        static void ClassificationStatistics(List<Student> studentList)
        {
            Console.WriteLine("=== Thống kê xếp loại sinh viên ===");
            
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống!");
                return;
            }

            int xuatSac = 0;
            int gioi = 0;
            int kha = 0;
            int trungBinh = 0;
            int yeu = 0;
            int kem = 0;

            foreach (Student student in studentList)
            {
                if (student.AverageScore >= 9.0f)
                    xuatSac++;
                else if (student.AverageScore >= 8.0f)
                    gioi++;
                else if (student.AverageScore >= 7.0f)
                    kha++;
                else if (student.AverageScore >= 5.0f)
                    trungBinh++;
                else if (student.AverageScore >= 4.0f)
                    yeu++;
                else
                    kem++;
            }

            Console.WriteLine("Xuất sắc (9.0 - 10.0): {0}", xuatSac);
            Console.WriteLine("Giỏi (8.0 - 8.99): {0}", gioi);
            Console.WriteLine("Khá (7.0 - 7.99): {0}", kha);
            Console.WriteLine("Trung bình (5.0 - 6.99): {0}", trungBinh);
            Console.WriteLine("Yếu (4.0 - 4.99): {0}", yeu);
            Console.WriteLine("Kém (< 4.0): {0}", kem);
            Console.WriteLine("Tổng cộng: {0}", studentList.Count);
        }
    }
}
