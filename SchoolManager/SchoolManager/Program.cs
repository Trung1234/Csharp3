using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolContext())
            {
                // Nhập tên 1 student mới cần tạo
                Console.Write("Ten cua 1 Student moi: ");
                var name = Console.ReadLine();

                // Thêm 1 student mới  
                var blog = new Student{ StudentName = name };
                db.Students.Add(blog);
                db.SaveChanges();

                // Hiển thị các student trong database, sắp xếp theo Name
                var query = from b in db.Students
                            orderby b.StudentName
                            select b;

                Console.WriteLine("Tat ca student trong database :");
                foreach (var item in query)
                {
                    Console.WriteLine(item.StudentName);
                }

                Console.WriteLine("Go bat ky phim nao de thoat...");
                Console.ReadKey();
            }
        }
    }
}
