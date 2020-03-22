using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // DammioDatabaseFirstEntities kế thừa từ DbContext
            using (var db = new DammioDatabaseFirstEntities())
            {
                // Tạo và lưu 1 blog mới vào database
                Console.Write("Dien ten cua 1 blog moi: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Hiển thị tất cả các blog trong database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("Tat ca cac blog trong database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Nhan bat ky phim nao de thoat ... -- dammio.com");
                Console.ReadKey();
            }
        }
    }
}
