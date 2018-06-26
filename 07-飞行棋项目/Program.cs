using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_飞行棋项目
{
    class Program
    {
        static void Main(string[] args)
        {
            GameShow();
            Console.ReadKey();
        }

        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("*********************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*********************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*********************************");
            Console.WriteLine("**********飞 行 棋 V 1.0*********");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*********************************");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("*********************************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*********************************");
            
        }
    }
}
