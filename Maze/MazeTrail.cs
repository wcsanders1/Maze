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
        public const int OPENS_UP = MazePlatform.OPENS_UP;
        public const int OPENS_DOWN = MazePlatform.OPENS_DOWN;
        public const int OPENS_RIGHT = MazePlatform.OPENS_RIGHT;
        public const int OPENS_LEFT = MazePlatform.OPENS_LEFT;

        public int trailWidth = 10;
        public int halfTrailWidth = 0;

        public List<int> xPosition = null;  //This array is used to determine the length of the mazeTrail as well as its xPosition
        public List<int> yPosition = null;
        public List<int> trailDirection = null;
        public List<int> positionStatus = null;

        public List<MazeTrail> mazeTrailList = null;

        public MazeTrail()
        {
            xPosition = new List<int>();
            yPosition = new List<int>();
            trailDirection = new List<int>();
            positionStatus = new List<int>();

            halfTrailWidth = trailWidth / 2;
        }

        public int[,] createTrail(int x, int y, int direction, int distance, MazePlatform mazePlatform)
        {
            for (int i = 0; i < distance; i++)
            {
                mazePlatform.status[x, y] = TRAIL;

                xPosition.Add(x);
                yPosition.Add(y);
                trailDirection.Add(direction);
                positionStatus.Add(TRAIL);

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
            for (int i = 0; i < xPosition.Count; i++)
            {
                if (i != 0)
                {
                    if (trailDirection[i] != trailDirection[i - 1])
                    {
                        i = i + halfTrailWidth;
                    }
                }
                if (trailDirection[i] == RIGHT)
                {
                    if ((i + 1) == xPosition.Count)
                    {
                        mazePlatform.status[xPosition[i], (yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[xPosition[i], (yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                    }
                    else if (trailDirection[i + 1] == RIGHT)
                    {
                        if (positionStatus[i] != OPENS_UP) { mazePlatform.status[xPosition[i], (yPosition[i] + halfTrailWidth)] = TRAILBORDER; }
                        if (positionStatus[i] != OPENS_DOWN) { mazePlatform.status[xPosition[i], (yPosition[i] - halfTrailWidth)] = TRAILBORDER; }
                    }
                    else if (trailDirection[i + 1] == UP)
                    {
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(xPosition[i] - ii), (yPosition[i] - halfTrailWidth)] = OPEN;
                        }
                        for (int ii = 0; ii <= (halfTrailWidth + 1); ii++)
                        { 
                            mazePlatform.status[(xPosition[i] + ii), (yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[xPosition[i] + (halfTrailWidth + 1), ((yPosition[i] + halfTrailWidth) - ii)] = TRAILBORDER;
                        }
                    }
                    else if (trailDirection[i + 1] == DOWN)
                    {
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(xPosition[i] - ii), (yPosition[i] + halfTrailWidth)] = OPEN;
                        }
                        for (int ii = 0; ii <= (halfTrailWidth + 1); ii++)
                        {
                            mazePlatform.status[(xPosition[i] + ii), (yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[xPosition[i] + (halfTrailWidth + 1), ((yPosition[i] - halfTrailWidth) + ii)] = TRAILBORDER;
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
                        if (positionStatus[i] != OPENS_LEFT) { mazePlatform.status[(xPosition[i] - halfTrailWidth), yPosition[i]] = TRAILBORDER; }
                        if (positionStatus[i] != OPENS_RIGHT) { mazePlatform.status[(xPosition[i] + halfTrailWidth), yPosition[i]] = TRAILBORDER; }
                    }
                    else if (trailDirection[i + 1] == RIGHT)
                    {
                        for (int ii = 0; ii < (halfTrailWidth + 2); ii++)
                        {
                            mazePlatform.status[(xPosition[i] - halfTrailWidth), (yPosition[i] - ii)] = TRAILBORDER;
                        }
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(xPosition[i] + halfTrailWidth), (yPosition[i] + ii)] = OPEN;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[(xPosition[i] - halfTrailWidth) + ii, (yPosition[i] - (halfTrailWidth + 1))] = TRAILBORDER;
                        }
                    }
                }
                else if (trailDirection[i] == DOWN)
                {
                    if ((i + 1) == xPosition.Count)
                    {
                        mazePlatform.status[(xPosition[i] - halfTrailWidth), yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(xPosition[i] + halfTrailWidth), yPosition[i]] = TRAILBORDER;
                    }
                    else if (trailDirection[i + 1] == DOWN)
                    {
                        if (positionStatus[i] != OPENS_RIGHT) { mazePlatform.status[(xPosition[i] - halfTrailWidth), yPosition[i]] = TRAILBORDER; }
                        if (positionStatus[i] != OPENS_LEFT) { mazePlatform.status[(xPosition[i] + halfTrailWidth), yPosition[i]] = TRAILBORDER; }
                    }
                    else if (trailDirection[i + 1] == RIGHT)
                    {
                        for (int ii = 0; ii < (halfTrailWidth + 2); ii++)
                        {
                            mazePlatform.status[(xPosition[i] - halfTrailWidth), (yPosition[i] + ii)] = TRAILBORDER;
                        }
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(xPosition[i] + halfTrailWidth), (yPosition[i] - ii)] = OPEN;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[(xPosition[i] - halfTrailWidth) + ii, (yPosition[i] + (halfTrailWidth + 1))] = TRAILBORDER;
                        }
                    }
                }
            }

            return mazePlatform.status;
        }

        public void CreateMazeDeadEnd(List<MazeTrail> mazeTrail, MazePlatform mazePlatform)
        {
            int priorDirection = 0;
            int stepsInSameDirection = 0;
            Random rnd = new Random();
            int openingLocation = 0;
            int openingDirection = 0;

            mazeTrailList = new List<MazeTrail>();

            foreach (MazeTrail trail in mazeTrail)
            {
                stepsInSameDirection = 0;
                priorDirection = trail.trailDirection[0];

                for (int i = 0; i < trail.xPosition.Count; i++)
                {
                    if (priorDirection == trail.trailDirection[i])    //   FIX THIS; THIS IS WHY IT NEVER MAKES OPENINGS LEFT OR RIGHT
                    {
                        stepsInSameDirection++;

                        if (stepsInSameDirection == 20)
                        {
                            if (rnd.Next(10) < 5)  //This makes a trail opening on a curve 50% of the time
                            {
                                if (trail.trailDirection[i] == LEFT || trail.trailDirection[i] == RIGHT)
                                {
                                    openingLocation = rnd.Next(1, 5);
                                    openingDirection = rnd.Next(5, 7);


                                    for (int x = 0; x < trailWidth; x++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i] - x) - openingLocation, (trail.yPosition[i])] = openingDirection;
                                        trail.positionStatus[i - x] = openingDirection;
                                    }
                                }
                                else
                                {
                                    openingLocation = rnd.Next(1, 5);
                                    openingDirection = rnd.Next(7, 9);
                                    priorDirection = trail.trailDirection[i];

                                    for (int y = 0; y < trailWidth; y++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i]), (trail.yPosition[i] - y) - openingLocation] = openingDirection;
                                        trail.positionStatus[i - y] = openingDirection;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        stepsInSameDirection = 0;
                    }
                }
            }
        }
    }
}
