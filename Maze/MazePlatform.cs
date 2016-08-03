using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class MazePlatform   // This class contains functions that create the maze platform, initialize the status of the pixels on the platfor, and create the maze borders
    {
        public static int[] mazeX = new int[200];
        public static int[] mazeY = new int[200];
        public static int[,] status = new int[200, 200];

        public const int CLOSED = 1;
        public const int OPEN = 2;

        public const int UP = 1;
        public const int DOWN = 2;
        public const int RIGHT = 3;
        public const int LEFT = 4;

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
                    status[x, y] = OPEN;
                }
            }
        }

        public static void CreateMazeBorders()
        {
            for (int x = 0; x < 200; x++)
            {
                status[x, 0] = CLOSED;    //closes bottom border
                status[x, 199] = CLOSED;  //closes top border
            }
            for (int y = 0; y < 200; y++)
            {
                status[0, y] = CLOSED;    //closes left border
                status[199, y] = CLOSED;  //closes right border
            }
        }
    }
}
