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
            #region 画第一条横线
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMaps(i));
            }
            #endregion

            #region 画第一条竖线
            for (int i = 30; i < 35; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 30; j++)
                {
                    if (j == 29)
                    {
                        Console.Write(DrawStringMaps(i));
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
            #endregion

            #region 画第二条横线
            Console.WriteLine();
            for (int i = 35; i < 65; i++)
            {
                Console.Write(DrawStringMaps(i));
            }
            #endregion

            #region 画第二条竖线
            for (int i = 65; i < 70; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 30; j++)
                {
                    if (j == 0)
                    {
                        
                        Console.Write(DrawStringMaps(i));
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
            #endregion

            #region 画第三条横线
            Console.WriteLine();
            for (int i = 65; i < 95; i++)
            {
                Console.Write(DrawStringMaps(i));
            }
            #endregion

            #region 画第三条竖线
            for (int i = 95; i < 100; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 30; j++)
                {
                    if (j == 29)
                    {

                        Console.Write(DrawStringMaps(i));
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 绘制地图关卡
        /// </summary>
        /// <param name="i">当前的坐标</param>
        /// <returns>关卡的符号坐标</returns>
        public static string DrawStringMaps(int i)
        {
            string str = "";
            if (playerPos[0] == playerPos[1] && playerPos[0] == i)
            {
                str = "<>";
            }
            else if (playerPos[0] == i)
            {
                str = "Ａ";
            }
            else if (playerPos[1] == i)
            {
                str = "Ｂ";
            }
            else
            {
                switch (maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        str = "卐";
                        break;
                }
            }
            return str;
        }
    }
}
