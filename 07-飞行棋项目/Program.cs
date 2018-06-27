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
        // 玩家姓名
        public static string[] playerNames = new string[2];
        

        static void Main(string[] args)
        {
            GameShow();

            #region 输入玩家姓名
            Console.WriteLine("请输入玩家A的姓名");
            playerNames[0] = Console.ReadLine();
            while (playerNames[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空，请重新输入");
                playerNames[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家B的姓名");
            playerNames[1] = Console.ReadLine();
            while (playerNames[1] == "" || playerNames[1] == playerNames[0])
            {
                if (playerNames[1] == "")
                {
                    Console.WriteLine("玩家B的姓名不能为空，请重新输入");
                    playerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家B的姓名不能与玩家A相同，请重新输入");
                    playerNames[1] = Console.ReadLine();
                }
                
            }
            #endregion
            // 清屏
            Console.Clear();
            GameShow();
            Console.WriteLine("{0}的士兵用A表示", playerNames[0]);
            Console.WriteLine("{0}的士兵用B表示", playerNames[1]);
            InitialMaps();
            DrawMap();
            while (playerPos[0] < 100 && playerPos[1] < 100)
            {
                Console.Clear();
                DrawMap();

                GoStep(0, playerPos[0]);
                Console.Clear();
                DrawMap();
                GoStep(1, playerPos[1]);

                Console.Clear();
                DrawMap();
            }

        }

        

        /// <summary>
        /// 计算走的步数
        /// </summary>
        /// <param name="play">行动玩家的姓名</param>
        /// <param name="pos">行动玩家的坐标</param>
        public static void GoStep(int play, int pos)
        {

            Console.WriteLine("玩家{0}按任意键掷骰子", playerNames[play]);
            Console.ReadKey();
            Random r = new Random();
            int step = r.Next(1, 7);
            Console.WriteLine("玩家{0}掷出了{1}", playerNames[play], step);
            Console.ReadKey();
            Console.WriteLine("玩家{0}按任意键开始行动", playerNames[play]);
            Console.ReadKey();
            Console.WriteLine("玩家{0}行动完了", playerNames[play]);
            Console.ReadKey();
            pos += step;

            Action(pos, play);
        }

        /// <summary>
        /// 根据步数计算发生时间
        /// </summary>
        /// <param name="pos">行动玩家坐标</param>
        /// <param name="play">行动玩家的姓名</param>
        public static void Action(int pos, int play)
        {
            playerPos[play] = pos;
            if (playerPos[play]  == playerPos[1 - play])
            {
                
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}后退6格", playerNames[play], playerNames[1 - play], playerNames[1 - play]);
                Console.ReadKey();
                playerPos[1 - play] -= 6;
                if (playerPos[1 - play] < 0)
                {
                    playerPos[1 - play] = 0;
                    Console.WriteLine("玩家{0}后退了{1}步", playerNames[1 - play], playerPos[play] - playerPos[1 - play]);
                }
                else
                {
                    Console.WriteLine("玩家{0}后退了6步", playerNames[1 - play]);
                }
                
            }
            else
            {
                switch (maps[playerPos[play]])
                {
                    case 0:

                        Console.WriteLine("{0}士兵踩到了方块，什么也没发生", playerNames[play]);
                        Console.ReadKey();
                        

                        break;
                    case 1:
                        Console.WriteLine("{0}士兵踩到了幸运轮盘，请选择 1--交换位置 2--轰炸对方", playerNames[play]);
                        string choose = Console.ReadLine();
                        while (choose.Equals("1") == false && choose.Equals("2") == false)
                        {
                            Console.WriteLine("您的选择有误，请您重新输入 1--交换位置 2--轰炸对方");
                            choose = Console.ReadLine();
                        }
                        // 调用幸运轮盘方法
                        LuckyTurn(choose, play, pos);
                        break;

                    case 2:
                        Console.WriteLine("{0}士兵踩到了地雷，倒退6格", playerNames[play]);

                        // 调用地雷方法
                        LandMine(play, pos);
                        break;

                    case 3:
                        Console.WriteLine("{0}士兵踩到了暂停，将暂停一回合", playerNames[play]);
                        Console.ReadKey();
                        // 调用暂停方法
                        Paurse(play, pos);
                        break;

                    case 4:
                        Console.WriteLine("{0}士兵踩到了时空隧道，将前进10格", playerNames[play]);
                        Console.ReadKey();
                        // 调用时空隧道方法
                        TimeTunnel(play, pos);
                        break;
                    
                }
            }

            
        }

        /// <summary>
        /// 时空隧道方法
        /// </summary>
        /// <param name="play"></param>
        /// <param name="pos"></param>
        public static void TimeTunnel(int play, int pos)
        {
            playerPos[play] += 10;
            if (playerPos[play] >= 100)
            {
                playerPos[play] = 99;
                Console.WriteLine("玩家{0}前进了{1}格", playerNames[play], playerPos[play] - 99);
            }
            else
            {
                Console.WriteLine("玩家{0}前进了10格", playerNames[play]);
                Console.ReadKey();
            }
            
        }



        /// <summary>
        /// 暂停方法
        /// </summary>
        /// <param name="play"></param>
        /// <param name="pos"></param>
        public static void Paurse(int play, int pos)
        {
            DrawMap();
            GoStep(1 - play, playerPos[1 - play]);
        }

        /// <summary>
        /// 地雷方法
        /// </summary>
        /// <param name="play"></param>
        /// <param name="pos"></param>
        public static void LandMine(int play, int pos)
        {
            playerPos[play] = pos - 6;
            if (playerPos[play] < 0)
            {
                playerPos[play] = 0;
                Console.WriteLine("玩家{0}倒退了{1}格", playerNames[play], pos);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("玩家{0}倒退了6格", playerNames[play]);
                Console.ReadKey();
            }
            
        }

        /// <summary>
        /// 幸运轮盘方法
        /// </summary>
        /// <param name="choose">玩家的选择</param>
        public static void LuckyTurn(string choose, int play, int pos) {
            int temp = pos;
            if (choose.Equals("1")) // 交换位置
            {
                playerPos[play] = playerPos[1 - play];
                playerPos[1 - play] = temp;
                Console.WriteLine("玩家{0}选择了跟玩家{1}交换位置", playerNames[play], playerNames[1 - play]);
            }
            else // 轰炸对方
            {
                playerPos[1 - play] -= 6;
                if (playerPos [1 - play] < 0)
                {
                    playerPos[1 - play] = 0;
                    Console.WriteLine("玩家{0}选择了轰炸对方，玩家{1}倒退了{2}格", playerNames[play], playerNames[1 - play], playerPos[1 - play]);
                }
                else
                {
                    Console.WriteLine("玩家{0}选择了轰炸对方，玩家{1}倒退了6格", playerNames[play], playerNames[1 - play]);
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 绘制游戏头
        /// </summary>
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
            Console.WriteLine("*********************************");InitialMaps();
            
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
            // 显示图例
            Console.WriteLine("图例:幸运轮盘:◎   地雷:☆   暂停:▲   时空隧道:卐");

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
            for (int i = 64; i > 34; i--)
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
            for (int i = 70; i < 100; i++)
            {
                Console.Write(DrawStringMaps(i));
            }
            #endregion

            // 换行
            Console.WriteLine();
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
