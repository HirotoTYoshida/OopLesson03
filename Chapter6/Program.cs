using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            //6.1.1
            Console.WriteLine("▲▲問題6.1▲▲");
            Console.WriteLine(numbers.Max());

            //6.1.2
            Console.WriteLine("\n-------------");
            var sk = numbers.Length - 2;
            foreach (var item in numbers.Skip(sk))
            {
                Console.WriteLine(item);
            }

            //6.1.3
            Console.WriteLine("\n-------------");
            var strs = numbers.Select(n => n.ToString());
            foreach (var s in strs)
            {
                Console.WriteLine(s);
            }

            //6.1.4
            Console.WriteLine("\n-------------");
            foreach (var n in numbers.OrderBy(n => n).Take(3))
            {
                Console.WriteLine(n);
            }

            //6.1.5
            Console.WriteLine("\n-------------");
            var count = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(count);
           
            
            
            var books = new List<Book>
            {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };


            //6.2.1
            Console.WriteLine("▲▲問題6.2▲▲");
            Console.WriteLine("\n-------------");
            var book = books.FirstOrDefault(b => b.Title == "ワンダフル・C#ライフ");
            if (book != null)
            {
                Console.WriteLine("{0} {1}", book.Price, book.Pages);
            }

            //6.2.2
            Console.WriteLine("\n-------------");
            int a = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(a);

            //6.2.3
            Console.WriteLine("\n-------------");
            var average = books.Where(b => b.Title.Contains("C#"))
                               .Average(b => b.Pages);
            Console.WriteLine(average);

            //6.2.4
            Console.WriteLine("\n-------------");
            var booka = books.FirstOrDefault(b => b.Price >= 4000);
            if (book != null)
                Console.WriteLine(book.Title);

            //6.2.5
            Console.WriteLine("\n-------------");
            var pages = books.Where(b => b.Price < 4000)
                             .Max(b => b.Pages);
            Console.WriteLine(pages);

            //6.2.6
            Console.WriteLine("\n-------------");
            var selected = books.Where(b => b.Pages >= 400)
                                .OrderByDescending(b => b.Price);
            foreach (var d in selected)
            {
                Console.WriteLine("{0} {1}", d.Title, d.Price);
            }

            //6.2.7
            Console.WriteLine("\n-------------");
            var ab = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);
            foreach (var c in ab)
            {
                Console.WriteLine(c.Title);
            }
                
        }
    }
}