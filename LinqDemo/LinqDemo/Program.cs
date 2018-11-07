using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var listStudent = new List<Student>()
            {
                new Student {ID=1,NAME = "Trung",AGE =20 },
                new Student {ID=2,NAME = "Huy",AGE =21 },
                new Student {ID=3,NAME = "Thang",AGE =22 },
                new Student {ID=4,NAME = "Tung",AGE =23 },
            };
            var list = from e in listStudent
                        where e.AGE > 21
                        select new { e.NAME,e.ID};

            foreach (var em in list)
            {
                Console.WriteLine(em.NAME);
            }

            listStudent.Add(new Student { ID = 1, NAME = "Cao", AGE = 26 });

            //var list = (from e in listStudent
            //            where e.AGE > 21
            //            select e).ToList();


            //int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var lowNumbers =
            //    from n in numbers
            //    where n <= 3
            //    select n;

            //Console.WriteLine("First run numbers <= 3:");
            //foreach (int n in lowNumbers)
            //{
            //    Console.WriteLine(n);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    numbers[i] = -numbers[i];
            //}


            //Console.WriteLine("Second run numbers <= 3:");
            //foreach (int n in lowNumbers)
            //{
            //    Console.WriteLine(n);
            //}
            Console.ReadLine();
        }
    }
}
