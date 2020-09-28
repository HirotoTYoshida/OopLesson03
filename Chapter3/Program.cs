using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {


        static void Main(string[] args)
        {
            var names = new List<string>
            {
                "Tokyo","New Delhi","Bangkok","London","Paris","Canberra","Hong Kong"
            };

            var query = names.Where(s => s.Length <= 5).ToList();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");

            names[0] = "Osaka";
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            var numbers = new List<int>
            {
                12,87,94,14,53,20,40,35,76,91,31,17,48
            };

            //3.1.1
            Console.WriteLine("\n-----3.1.2------");
            var exists = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);

            if (exists)
                Console.WriteLine("存在しています。");
            else
                Console.WriteLine("存在していません。");

            //3.1.2
            Console.WriteLine("\n-----3.1.2------");
            numbers.ForEach(s => Console.WriteLine(s / 2.0));

            //3.1.3
            Console.WriteLine("\n-----3.1.3-----");
            var num = numbers.Where(s => s >= 50);
            foreach (var item in num)
            {
                Console.WriteLine(item);
            }

            //3.1.4
            Console.WriteLine("\n-----3.1.4-----");
            numbers.Select(s => s * 2).ToList().ForEach(Console.WriteLine);
            //foreach (var item in lists)
            //{
            //    Console.WriteLine(item);
            //}

            var sts = new List<string>
            {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong kong",
            };

            //3.2.1
            Console.WriteLine("\n-----3.2.1-----");
            Console.WriteLine("都市名を入力。");
            //var line = Console.ReadLine();
            //int index = names.FindIndex(s => s == line);
            //Console.WriteLine(index);
            do
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                var index = sts.FindIndex(s => s == line);
                Console.WriteLine(index);
            } while (true);


            //3.2.2
            Console.WriteLine("\n-----3.2.2-----");
            var count = sts.Count(s => s.Contains('o'));
            Console.WriteLine(count);


            //3.2.3
            Console.WriteLine("\n-----3.2.3-----");
            var selected = sts.Where(s => s.Contains('o')).ToArray();
            foreach (var item in selected)
            {
                Console.WriteLine(item);
            }

            //3.2.4
            Console.WriteLine("\n-----3.2.4-----");
            var nameCounts = sts.Where(s => s.StartsWith("B")).Select(s => s.Length);
            foreach (var length in nameCounts)
            {
                Console.WriteLine(length);

            }
        }
    }
}
