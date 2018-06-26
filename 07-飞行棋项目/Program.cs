using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_飞行棋项目
{
    class Program
    {
        // 地图关卡
        public static int[] maps = new int[100];
        // 玩家坐标
        public static int[] playerPos = new int[2];

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
            InitialMaps();
            DrawMap();
        }
        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitialMaps()
        {
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 }; // 幸运轮盘下标
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 }; // 地雷下标
            int[] pause = { 9, 27, 60, 93 }; // 暂停下标
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 }; // 时空隧道下标

            foreach (int index in luckyturn)
            {
                maps[index] = 1;
            }

            foreach (int index in landMine)
            {
                maps[index] = 2;
            }

            foreach (int index in pause)
            {
                maps[index] = 3;
            }

            foreach (int index in timeTunnel)
            {
                maps[index] = 4;
            }
        }
        /// <summary>
        /// 画地图
        /// </summary>
        public static void DrawMap()
        {
            // 画第一条横线
            for (int i = 0; i < 30; i++)
            {
                if (playerPos[0] == playerPos[1] && playerPos[0] == i)
                {
                    Console.Write("<>");
                }
                else if (playerPos[0] == i)
                {
                    Console.Write("Ａ");
                }
                else if (playerPos[1] == i)
                {
                    Console.Write("Ｂ");
                }
                else
                {
                    switch (maps[i])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("□");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("◎");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("☆");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("▲");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("卐");
                            break;
                    }
                }
            }
        }
    }
}
