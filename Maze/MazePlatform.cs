using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class MazePlatform   // This class contains functions that create the maze platform, initialize the status of the pixels on the platfor, and create the maze borders
    {
        public int mazeWidth = 0;
        public int mazeHeight = 0;

        public int[] mazeX = null;
        public int[] mazeY = null;
        public int[,] status = null;

        public const int OPEN = 1;
        public const int TRAIL = 2;
        public const int BORDER = 3;
        public const int TRAILBORDER = 4;
        public const int OPENS_UP = 5;
        public const int OPENS_DOWN = 6;
        public const int OPENS_RIGHT = 7;
        public const int OPENS_LEFT = 8;

        public const int NO_TRAIL_IN_WAY = 999999;

        public const int SOLUTION = 111;

        public const int UP = 1;
        public const int DOWN = 2;
        public const int RIGHT = 3;
        public const int LEFT = 4;

        public MazePlatform()
        {

        }

        public void CreateMazePlatform(int canvasWidth, int canvasHeight)
        {
            mazeWidth = Maze.difficultyLevel * 100;
            mazeHeight = Maze.difficultyLevel * 100;

            mazeX = new int[mazeWidth];
            mazeY = new int[mazeHeight];
            status = new int[mazeWidth, mazeHeight];

            int initialX = (canvasWidth / 2) - (mazeWidth / 2);
            int initialY = (canvasHeight / 2) - (mazeHeight / 2);

            for (int i = 0; i < mazeWidth; i++)
            {
                mazeX[i] = i + initialX;
            }
            for (int i = 0; i < mazeHeight; i++)
            {
                mazeY[i] = i + initialY;
            }

            InitializeMazeStatus();
            CreateMazeBorders();
        }

        public void InitializeMazeStatus()
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                for (int y = 0; y < mazeHeight; y++)
                {
                    status[x, y] = OPEN;
                }
            }
        }

        public void CreateMazeBorders()
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                status[x, 0] = BORDER;    //closes bottom border
                status[x, (mazeHeight - 1)] = BORDER;  //closes top border
            }
            for (int y = 0; y < mazeHeight; y++)
            {
                status[0, y] = BORDER;    //closes left border
                status[(mazeWidth - 1), y] = BORDER;  //closes right border
            }
        }
    }
}
