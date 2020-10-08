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

            //整数の例
            var numbers = new List<int>
            {
                19,17,15,24,12,25,14,20,12,28,19,30,24
            };
            
            var strings = numbers.Distinct().ToArray();
            foreach (var str in strings)
            {
                Console.Write(str + " ");
            }

            var sortedNumbers = numbers.OrderBy(n => n).Distinct();
            foreach (var sort in sortedNumbers)
            {
                Console.WriteLine(sort + " ");
            }

            //文字列の例
            Console.WriteLine("\n\n---------------");
            var words = new List<string>
            {
                "Microsoft",
                "Apple",
                "Google",
                "Oracle",
                "Facebook",
            };
            var lower = words.Select(name => name.ToLower()).ToArray();

            //オブジェクトの例
            Console.WriteLine("\n\n-----------------");
            var books = Books.GetBooks();
            //タイトルリスト
            var titles = books.Select(name => name.Title);

            foreach (var title in titles)
            {
                Console.WriteLine(title + "　");
            }

            //ページ数の多い順に並べ替えベスト3
            var sortedBooks = books.OrderByDescending(book => book.Pages).Take(3);
            Console.WriteLine("ページ数の多い順に並べ替えベスト3");
            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book.Title + " " + book.Pages);
            }
        }
    }
}
