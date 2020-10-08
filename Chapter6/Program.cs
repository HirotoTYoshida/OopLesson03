using System;
using System.Collections.Generic;
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
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4 };
            Console.WriteLine($"平均値:{numbers.Average()}");
            Console.WriteLine($"合計値:{numbers.Sum()}");
            Console.WriteLine($"最小値:{numbers.Where(n => n > 0).Min()}");
            Console.WriteLine($"最大値:{numbers.Max()}");

            bool exists = numbers.Any(n => n % 7 == 0);

            var results = numbers.Where(n => n > 0).Take(3);
            foreach (var result in results)
            {
                Console.Write(result + " ");
            }

            Console.WriteLine("\n------------------------");

            var books = Books.GetBooks();
            Console.WriteLine($"本の平均価格:{books.Average(x => x.Price)}");
            Console.WriteLine($"本の合計価格:{books.Sum(x => x.Price)}");
            Console.WriteLine($"本のページが最大:{books.Max(x => x.Pages)}");
            Console.WriteLine($"高価な本:{books.Max(x => x.Price)}");
            Console.WriteLine($"タイトルに「物語」がある冊数:{books.Count(x => x.Title.Contains("物語"))}");

            //600ページを超える書籍があるか？ (Anyメソッド)
            Console.WriteLine(books.Any(x => x.Pages >= 600) ? "600ページを超える書籍はある" : "600ページを超える書籍はない");

            //すべてが200ページ以上の書籍か？　(Allメソッド)
            Console.WriteLine(books.All(x => x.Pages >= 200) ? "すべて200ページ以上である" : "200ページ以下の書籍もある");

            //400ページを超える本は何冊目か？（FirstOrDefaultメソッド）
            var book = books.FirstOrDefault(x => x.Pages > 400);
            int i;
            for ( i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Contains(book.Title))
                {
                    break;
                }
            }
            Console.WriteLine($"400ページを超える本は{i + 1}冊目です。");

            //本の値段が400円以上のものを抽出
            var counts = books.Where(n => n.Price >= 400).Take(3);
            foreach (var count in counts)
            {
                Console.WriteLine(count.Title + " ");
            }
        }
    }
}
