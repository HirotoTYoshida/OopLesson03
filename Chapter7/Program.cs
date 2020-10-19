using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text); //問題7.1.1
            Console.WriteLine();
            Exercise1_2(text);
            Console.WriteLine();
            Exercise2_1(text);

        }
        static void Exercise1_1(string text)
        {
            var dict = new Dictionary<char, int>();
            foreach (var item in text)
            {
                var ch = char.ToUpper(item);
                if ('A' <= ch && ch <= 'Z')
                {
                    if (dict.ContainsKey(ch))
                    {
                        dict[ch]++;
                    }
                    else
                    {
                        dict[ch] = 1;
                    }
                }
            }
            foreach (var item in dict.OrderBy(s => s.Key))
            {
                Console.WriteLine("'{0}' : {1}" ,item.Key,item.Value);
            }
        }
        static void Exercise1_2(string text)
        {
            var dict = new SortedDictionary<char, int>();
            foreach (var item in text)
            {
                var ch = char.ToUpper(item);
                if ('A' <= ch && ch <= 'Z')
                {
                    if (dict.ContainsKey(ch))
                    {
                        //既に登録済み
                        dict[ch]++;
                    }
                    else
                    {
                        //未登録
                        dict[ch] = 1;
                    }
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine("'{0}' : {1}", item.Key, item.Value);
            }
        }

        //foreachで一文字ずつ取り出す
        //（半角アルファベットか調べる処理）
        //if(!A! <= && ch <= 'Z'){
                //Keyに存在するか？
                //    ・存在する
                //    　　対応するValueの値をインクリメント
                //    ・存在しない
                    　　
        
        static void Exercise2_1(string text)
        {
            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");


            //問題7.2.3
            //Countプロパティを呼び出して数を出力させ
            Console.WriteLine(abbrs.Count);
            //Removeメソッドを呼び出して要素を削除する
            if (abbrs.Remove("NPT"))
            {
                Console.WriteLine("削除成功");
            }
            else
            {
                Console.WriteLine("削除失敗");
            }


            // インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names)
            {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}は見つかりません", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0} は見つかりません", japanese);
            else
                Console.WriteLine("「{0}」の略語は {1} です", japanese, abbreviation);
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach (var item in abbrs.FindAll("国際"))
            {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();

            foreach (var item in abbrs.Where(s => s.Key.Length == 3))
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}

               
