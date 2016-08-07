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
        public const int TRAILBORDER = MazePlatform.TRAILBORDER;

        public const int NO_TRAIL_IN_WAY = MazePlatform.NO_TRAIL_IN_WAY;

        public const int SOLUTION = MazePlatform.SOLUTION;

        public const int UP = MazePlatform.UP;
        public const int DOWN = MazePlatform.DOWN;
        public const int RIGHT = MazePlatform.RIGHT;
        public const int LEFT = MazePlatform.LEFT;

        List<int> xPosition = null;
        List<int> yPosition = null;
        List<int> trailDirection = null;

        public MazeTrail()
        {
            xPosition = new List<int>();
            yPosition = new List<int>();
            trailDirection = new List<int>();
        }

        public int[,] createTrail(int x, int y, int direction, int distance, MazePlatform mazePlatform)
        {
            for (int i = 0; i < distance; i++)
            {
                mazePlatform.status[x, y] = TRAIL;

                xPosition.Add(x);
                yPosition.Add(y);
                trailDirection.Add(direction);


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

        public int[,] DrawTrails(MazePlatform mazePlatform)
        {
            int trailWidth = 6;
            int halfTrailWidth = trailWidth / 2;

            for (int i = 0; i < xPosition.Count; i++)
            {
                if (trailDirection[i] == RIGHT)
                {
                    if ((i + 1) == xPosition.Count)
                    {
                        mazePlatform.status[xPosition[i], (yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[xPosition[i], (yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                    }
                    else if (trailDirection[i + 1] == RIGHT)
                    {
                        mazePlatform.status[xPosition[i], (yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[xPosition[i], (yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                    }
                    else if (trailDirection[i + 1] == UP)
                    {
                        for (int ii = 1; ii <= (trailWidth / 2); ii++)
                        {
                            mazePlatform.status[(xPosition[i] - ii), (yPosition[i] - halfTrailWidth)] = OPEN;
                            mazePlatform.status[(xPosition[i] + ii), (yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                            mazePlatform.status[xPosition[i] + halfTrailWidth, (yPosition[i] - ii)] = TRAILBORDER;
                        }
                    }
                    else if (trailDirection[i + 1] == DOWN)
                    {
                        for (int ii = 1; ii <= (trailWidth / 2); ii++)
                        {
                            mazePlatform.status[(xPosition[i] - ii), (yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                            mazePlatform.status[(xPosition[i] + ii), (yPosition[i] + halfTrailWidth)] = OPEN;
                            mazePlatform.status[xPosition[i] + halfTrailWidth, (yPosition[i] + ii)] = TRAILBORDER;
                        }
                    }
                }
                else if (trailDirection[i] == UP)
                {
                    if ((i + 1) == xPosition.Count)
                    {
                        mazePlatform.status[(xPosition[i] - halfTrailWidth), yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(xPosition[i] + halfTrailWidth), yPosition[i]] = TRAILBORDER;
                    }
                    else if (trailDirection[i + 1] == UP)
                    {
                        mazePlatform.status[(xPosition[i] - halfTrailWidth), yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(xPosition[i] + halfTrailWidth), yPosition[i]] = TRAILBORDER;
                    }
                    else if (trailDirection[i + 1] == RIGHT)
                    {
                        for (int ii = 1; ii <= (trailWidth / 2); ii++)
                        {
                            mazePlatform.status[(xPosition[i] - halfTrailWidth), (yPosition[i] + ii)] = TRAILBORDER;
                            mazePlatform.status[(xPosition[i] + halfTrailWidth), (yPosition[i] - ii)] = OPEN;
                            mazePlatform.status[xPosition[i] + ii, (yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        }
                    }
                }
                else if (trailDirection[i + 1] == DOWN)   // FIX THIS PART
                {
                    for (int ii = 1; ii <= (trailWidth / 2); ii++)
                    {
                        mazePlatform.status[(xPosition[i] - ii), (yPosition[i] - trailWidth)] = TRAILBORDER;
                        mazePlatform.status[(xPosition[i] + ii), (yPosition[i] + trailWidth)] = OPEN;
                        mazePlatform.status[(xPosition[i] + (trailWidth / 2)), (yPosition[i] + ii)] = TRAILBORDER;
                    }
                }
            }

            return mazePlatform.status;
        }
    }
}
