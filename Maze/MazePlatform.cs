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
    }
}
