using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class MazePlatform
    {
        public static int[] mazeX = new int[200];
        public static int[] mazeY = new int[200];
        public static string[,] status = new string[200, 200];

        private const int RIGHT = 1;
        private const int LEFT = 2;
        private const int UP = 1;
        private const int DOWN = 2;

        public static void CreateMazePlatform()
        {
            for (int i = 0; i < 200; i++)
            {
                mazeX[i] = i + 20;
            }
            for (int i = 0; i < 200; i++)
            {
                mazeY[i] = i + 20;
            }

            InitializeMazeStatus();

            CreateMazeBorders();
        }

        public static void InitializeMazeStatus()
        {
            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    status[x, y] = "open";
                }
            }
        }

        public static void CreateMazeBorders()
        {
            for (int x = 0; x < 200; x++)
            {
                status[x, 0] = "closed";    //closes bottom border
                status[x, 199] = "closed";  //closes top border
            }
            for (int y = 0; y < 200; y++)
            {
                status[0, y] = "closed";    //closes left border
                status[199, y] = "closed";  //closes right border
            }
        }

        public static void CreateMazeSolution()
        {
            Random rnd = new Random();
            int yStartPoint = rnd.Next(0, 200);
            int yPoint = yStartPoint;
            int xPoint = 0;
            int curveBreaks = 25;

            for (int curves = 1; curves <= curveBreaks; curves++)
            {
                if (curves == 1)
                {
                    int thisCurve = rnd.Next(1, (200 / 5));

                    for (int i = 0; i < thisCurve; i++)
                    {
                        xPoint++;
                        status[xPoint, yStartPoint] = "closed";
                    }
                }
                else if (curves % 2 == 0 && curves != curveBreaks)
                {
                    int thisCurve = rnd.Next(1, (200 / 5));
                    int direction = rnd.Next(1, 3);

                    if (direction == DOWN)
                    {
                        for (int y = 0; y < thisCurve; y++)
                        {
                            if (yPoint < 199)
                            {
                                yPoint++;

                                if (status[xPoint, yPoint] == "open")
                                {
                                    status[xPoint, yPoint] = "closed";
                                }
                                else if (status[xPoint, yPoint] == "closed")
                                {
                                    for (int i = 0; i < y; i++)
                                    {
                                        yPoint--;
                                        status[xPoint, yPoint] = "open";  
                                    }
                                    for (int i = 0; i < thisCurve; i++)
                                    {
                                        if (yPoint > 0)
                                        {
                                            yPoint--;
                                            status[xPoint, yPoint] = "closed";
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == UP)
                    {
                        for (int y = 0; y < thisCurve; y++)
                        {
                            if (yPoint > 0)
                            {
                                yPoint--;
                                status[xPoint, yPoint] = "closed";
                            }
                        }
                    }                    
                }
                else if (curves % 2 != 0 && curves != curveBreaks)
                {
                    int thisCurve = rnd.Next(1, (200 / 5));
                    int direction = rnd.Next(1, 3);

                    if (direction == RIGHT)
                    {
                        for (int x = 0; x < thisCurve; x++)
                        {
                            if (xPoint < 199)
                            {
                                xPoint++;
                                status[xPoint, yPoint] = "closed";
                            }
                        }
                    }
                    else if (direction == LEFT)
                    {
                        for (int x = 0; x < thisCurve; x++)
                        {
                            if (xPoint > 0)
                            {
                                xPoint--;
                                status[xPoint, yPoint] = "closed";
                            }
                        }
                    }                   
                }
                else if (curves % 2 == 0 && curves == curveBreaks)
                {
                    int direction = rnd.Next(1, 3);

                    if (direction == DOWN)
                    {
                        while (yPoint < 200)
                        {
                           yPoint++;
                           status[xPoint, yPoint] = "closed";
                        }
                    }
                    else if (direction == UP)
                    {
                        while (yPoint > 0)
                        { 
                           yPoint--;
                           status[xPoint, yPoint] = "closed";
                        }
                    }
                }
                else if (curves % 2 != 0 && curves == curveBreaks)
                {
                    int direction = rnd.Next(1, 3);

                    if (direction == RIGHT)
                    {
                        while (xPoint < 199)
                        {
                            xPoint++;
                            status[xPoint, yPoint] = "closed";
                        }
                    }
                    else if (direction == LEFT)
                    {
                        while (xPoint > 0)
                        {
                            xPoint--;
                            status[xPoint, yPoint] = "closed";
                        }
                    }
                }
            }
        }
    }
}
