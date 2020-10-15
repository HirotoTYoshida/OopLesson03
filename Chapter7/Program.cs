using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("********************");
            Console.WriteLine("*辞書登録プログラム*");
            Console.WriteLine("********************");
            Console.WriteLine();

            // ディクショナリの初期化
            var dict = new Dictionary<string, List<string>>() { };


            while (true)
            {
                Console.WriteLine("1.登録 2.内容を表示 3.終了");
                Console.Write(">");
                var choice = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (choice)
                {
                    case 1:
                        // ディクショナリに追加
                        Console.Write("KEYを入力: ");
                        var key = Console.ReadLine();
                        Console.Write("VALUEを入力: ");
                        var value = Console.ReadLine();
                        if (dict.ContainsKey(key))
                        {
                            dict[key].Add(value);
                        }
                        else
                        {
                            dict[key] = new List<string> { value };
                        }
                        Console.WriteLine("登録しました!");
                        Console.WriteLine("");
                        break;

                    case 2:
                        // ディクショナリの内容を列挙
                        foreach (var item in dict)
                        {
                            foreach (var term in item.Value)
                            {
                                Console.WriteLine("{0} : {1}", item.Key, term);
                            }
                        }
                        break;

                    case 3:
                        break;

                    default:
                        Console.WriteLine("1or2or3を選択してください。");
                        Console.WriteLine();
                        break;
                }
                if (choice == 3)
                {
                    break;
                }
            }
        }
    }
}

//public static void DuplicateKeySample()
//{
//    var dict = Console.ReadLine();
//}

//public static void DuplicateKeySample()
//{
//    // ディクショナリの初期化
//    var dict = new Dictionary<string, List<string>>() {
//       { "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
//       { "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
//    };

//    // ディクショナリに追加
//    var key = "EC";
//    var value = "電子商取引";
//    

//    // ディクショナリの内容を列挙
//    foreach (var item in dict)
//    {
//        foreach (var term in item.Value)
//        {
//            Console.WriteLine("{0} : {1}", item.Key, term);
//        }
//    }
//}


