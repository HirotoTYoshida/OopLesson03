using System;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5.1
            var a1 = Console.ReadLine();
            var a2 = Console.ReadLine();
            if(string.Compare(a1,a2,ignoreCase:true) == 0)
            {
                Console.WriteLine("等しい");
            }
            else
            {
                Console.WriteLine("等しくない");
            }

            //5.2
            var line = Console.ReadLine();
            int num;
            if(int.TryParse(line, out num))
            {
                Console.WriteLine("#,#");
            }
            else
            {
                Console.WriteLine("数値文字列でありません");
            }
        }


    }
}
