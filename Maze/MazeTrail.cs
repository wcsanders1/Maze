using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeTrail  //These are trails in the maze that all have dead ends, i.e., they're not solutions, though a solution is a Trail
    {                   // This has methods for creating and erasing trails

        public const int OPEN = MazePlatform.OPEN;
        public const int TRAIL = MazePlatform.TRAIL;
        public const int BORDER = MazePlatform.BORDER;

        public const int NO_TRAIL_IN_WAY = MazePlatform.NO_TRAIL_IN_WAY;

        public const int SOLUTION = MazePlatform.SOLUTION;

        public const int UP = MazePlatform.UP;
        public const int DOWN = MazePlatform.DOWN;
        public const int RIGHT = MazePlatform.RIGHT;
        public const int LEFT = MazePlatform.LEFT;

        List<int> xPosition = null;
        List<int> yPosition = null;

        public MazeTrail()
        {
            xPosition = new List<int>();
            yPosition = new List<int>();
        }

        public int[,] createTrail(int x, int y, int direction, int distance, MazePlatform mazePlatform)
        {
            for (int i = 0; i < distance; i++)
            {
                mazePlatform.status[x, y] = TRAIL;

                xPosition.Add(x);
                yPosition.Add(y);

                if (direction == RIGHT && (mazePlatform.status[x++, y] == OPEN)) { x++; }
                if (direction == LEFT && (mazePlatform.status[x--, y] == OPEN)) { x--; }
                if (direction == DOWN && (mazePlatform.status[x, y++] == OPEN)) { y++; }
                if (direction == UP && (mazePlatform.status[x, y--] == OPEN)) { y--; }
            }

            return mazePlatform.status;
        }

        public static int distanceToBorder(int x, int y, int direction, MazePlatform mazePlatform)
        {
            int intialX = x;
            int initialY = y;
            int distance = 0;

            //catch error of entering direction that isn't left, right, up or down

            while (mazePlatform.status[x, y] != BORDER)
            {
                if (direction == RIGHT) { x++; }
                if (direction == LEFT) { x--; }
                if (direction == DOWN) { y++; }
                if (direction == UP) { y--; }
                distance++;
            }

            return distance;  
        }

        public static int distanceToTrail(int x, int y, int direction, MazePlatform mazePlatform)
        {
            int distance = 0;

            //catch error of entering direction that isn't left, right, up or down

            while (mazePlatform.status[x, y] != TRAIL)
            {
                if (mazePlatform.status[x, y] == BORDER) { return NO_TRAIL_IN_WAY; }

                if (direction == RIGHT) { x++; }
                if (direction == LEFT) { x--; }
                if (direction == DOWN) { y++; }
                if (direction == UP) { y--; }

                distance++;
            }

            return distance;
        }
    }
}
