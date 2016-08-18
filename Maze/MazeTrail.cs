using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeTrail
    {                   
        public const int OPEN = MazePlatform.OPEN;
        public const int TRAIL = MazePlatform.TRAIL;
        public const int BORDER = MazePlatform.BORDER;
        public const int TRAILBORDER = MazePlatform.TRAILBORDER;

        public const int NO_TRAIL_IN_WAY = MazePlatform.NO_TRAIL_IN_WAY;

        public const int UP = MazePlatform.UP;
        public const int DOWN = MazePlatform.DOWN;
        public const int RIGHT = MazePlatform.RIGHT;
        public const int LEFT = MazePlatform.LEFT;
        public const int OPENS_UP = MazePlatform.OPENS_UP;
        public const int OPENS_DOWN = MazePlatform.OPENS_DOWN;
        public const int OPENS_RIGHT = MazePlatform.OPENS_RIGHT;
        public const int OPENS_LEFT = MazePlatform.OPENS_LEFT;

        public int trailWidth = 6;            // These four variables are used to draw the borders around the trails
        public int halfTrailWidth = 0;
        public int trailBuffer = 0;
        public int trailBorderWidth = 0;

        public bool solution = false;           // This is true only when the trail is the solution

        public bool recurse = false;

        public List<int> xPosition = null;    //These lists contain maze trails and allow the trails to detect each other so they don't collide
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
            trailBuffer = trailWidth + 2;
            trailBorderWidth = halfTrailWidth + 1;
        }

        // GetTrailLength returns a random number of pixels so that a new trail section can be a random length 

        public int GetTrailLength()
        {
            Random rnd = new Random();

            //if (rnd.Next(1, 10) <= 6)
            //{
                return rnd.Next(28, 33);
            //}
            //else
            //{
            //    return rnd.Next(20, 30);
            //}
        }

        // CreateTrail adds trail to a list that is a trail; the list allows trails to see each other so they don't run into each other and so the method CreateDeadEnd, below,
        // can follow the trails and branch new trails off of them

        public void CreateTrail(int x, int y, int direction, int distance, MazeTrail mazeTrail, MazePlatform mazePlatform)
        {
            for (int i = 0; i < distance; i++)
            {
                mazeTrail.xPosition.Add(x);
                mazeTrail.yPosition.Add(y);
                mazeTrail.trailDirection.Add(direction);
                mazeTrail.positionStatus.Add(TRAIL);

                if (direction == RIGHT ) { x++; }
                if (direction == LEFT ) { x--; }
                if (direction == DOWN ) { y++; }
                if (direction == UP ) { y--; }
            }
        }

        // DistanceToBorder returns an int that's equal to the number of pixels separating one point from a border of the maze in a given direction

        public int DistanceToBorder(int x, int y, int direction, MazePlatform mazePlatform)
        {
            int intialX = x;
            int initialY = y;
            int distance = 0;

            while (mazePlatform.status[x, y] != BORDER && x < (mazePlatform.mazeWidth - 1) && x > 1)
            {
                if (direction == RIGHT) { x++; }
                if (direction == LEFT) { x--; }
                if (direction == DOWN) { y++; }
                if (direction == UP) { y--; }
                distance++;
            }

            return distance;  
        }

        //DistanceToTrail returns an int that's equal to the number of pixels separating one point from another trail in a given direction

        public int DistanceToTrail(int x, int y, int direction, MazePlatform mazePlatform)
        {
            int distance = 0;
            bool keepGoing = true;

            if (direction == RIGHT || direction == LEFT || direction == UP || direction == DOWN)
            {
                while (keepGoing)
                {
                    if (mazePlatform.status[x, y] == BORDER)
                    {
                        return NO_TRAIL_IN_WAY;
                    }

                    for (int a = 0; a < trailWidth; a++)
                    {
                        if (x < trailBuffer || y < trailBuffer || x >= (mazePlatform.mazeWidth - trailBuffer) || (y >= mazePlatform.mazeHeight - trailBuffer))
                        {
                            keepGoing = false;
                            break;
                        }

                        if (direction == RIGHT)
                        {
                            if (mazePlatform.status[x + trailBorderWidth, (y - a)] == TRAIL || mazePlatform.status[x + trailBorderWidth, (y - a)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                            else if (mazePlatform.status[x + trailBorderWidth, (y + a)] == TRAIL || mazePlatform.status[x + trailBorderWidth, (y + a)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                        }
                        else if (direction == LEFT)
                        {
                            if (mazePlatform.status[x - trailBorderWidth, (y - a)] == TRAIL || mazePlatform.status[x - trailBorderWidth, (y - a)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                            if (mazePlatform.status[x - trailBorderWidth, (y + a)] == TRAIL || mazePlatform.status[x - trailBorderWidth, (y + a)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                        }
                        else if (direction == UP)
                        {
                            if (mazePlatform.status[(x - a), (y - trailBorderWidth)] == TRAIL || mazePlatform.status[(x - a), (y - trailBorderWidth)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                            else if (mazePlatform.status[(x + a), (y - trailBorderWidth)] == TRAIL || mazePlatform.status[(x + a), (y - trailBorderWidth)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                        }
                        else if (direction == DOWN)
                        {
                            if (mazePlatform.status[(x - a), (y + trailBorderWidth)] == TRAIL || mazePlatform.status[(x - a), (y + trailBorderWidth)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                            else if (mazePlatform.status[(x + a), (y + trailBorderWidth)] == TRAIL || mazePlatform.status[(x + a), (y + trailBorderWidth)] == TRAILBORDER)
                            {
                                keepGoing = false;
                            }
                        }
                    }

                    if (direction == RIGHT) { x++; }
                    else if (direction == LEFT) { x--; }
                    else if (direction == UP) { y--; }
                    else if (direction == DOWN) { y++; }
                    distance++;                  
                }
            }

            return distance;
        }

        // CloseDeadEnd closes the dead ends of trails when then can't extend any farther

        public void CloseDeadEnd(int xPosition, int yPosition, int directionGoing, MazePlatform mazePlatform)
        {
            if (directionGoing == DOWN  || directionGoing == UP)
            {
                for (int i = 0; i < trailBorderWidth; i++)
                {
                    mazePlatform.status[(xPosition + i), yPosition] = TRAILBORDER;
                    mazePlatform.status[(xPosition - i), yPosition] = TRAILBORDER;
                }
            }
            else if (directionGoing == RIGHT || directionGoing == LEFT)
            {
                for (int i = 0; i < trailBorderWidth; i++)
                {
                    mazePlatform.status[(xPosition), yPosition + i] = TRAILBORDER;
                    mazePlatform.status[(xPosition), yPosition - i] = TRAILBORDER;
                }
            }
        }

        // DrawTrails draws trails on the maze platform

        public void DrawTrails(MazeTrail mazeTrail, MazePlatform mazePlatform)
        {
            for (int i = 0; i < mazeTrail.xPosition.Count; i++)
            {
                if (i != 0)
                {
                    if (mazeTrail.trailDirection[i] != mazeTrail.trailDirection[i - 1])
                    {
                        i += halfTrailWidth;
                    }
                }
                if (mazeTrail.trailDirection[i] == RIGHT)
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - (halfTrailWidth - a))] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == RIGHT)
                    {
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - (halfTrailWidth - a))] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == UP)
                    {
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - ii), (mazeTrail.yPosition[i] - halfTrailWidth)] = OPEN;
                        }
                        for (int ii = 0; ii <= (halfTrailWidth + 1); ii++)
                        { 
                            mazePlatform.status[(mazeTrail.xPosition[i] + ii), (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i] + (halfTrailWidth + 1), ((mazeTrail.yPosition[i] + halfTrailWidth) - ii)] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[(mazeTrail.xPosition[i] + a), ((mazeTrail.yPosition[i] + halfTrailWidth) - b)] = TRAIL;
                            }
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == DOWN)
                    {
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - ii), (mazeTrail.yPosition[i] + halfTrailWidth)] = OPEN;
                        }
                        for (int ii = 0; ii <= (halfTrailWidth + 1); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] + ii), (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i] + (halfTrailWidth + 1), ((mazeTrail.yPosition[i] - halfTrailWidth) + ii)] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[(mazeTrail.xPosition[i] + a), ((mazeTrail.yPosition[i] + halfTrailWidth) - b)] = TRAIL;
                            }
                        }
                    }
                }
                else if (mazeTrail.trailDirection[i] == LEFT)    
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - (halfTrailWidth - a))] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == LEFT)
                    {
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - (halfTrailWidth - a))] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == UP)
                    {
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - ii), (mazeTrail.yPosition[i] - halfTrailWidth)] = OPEN;
                        }
                        for (int ii = 0; ii <= (halfTrailWidth + 1); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - ii), (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i] - (halfTrailWidth + 1), ((mazeTrail.yPosition[i] + halfTrailWidth) - ii)] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[(mazeTrail.xPosition[i] - a), ((mazeTrail.yPosition[i] - halfTrailWidth) + b)] = TRAIL;
                            }
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == DOWN)
                    {
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - ii), (mazeTrail.yPosition[i] + halfTrailWidth)] = OPEN;
                        }
                        for (int ii = 0; ii <= (halfTrailWidth + 1); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - ii), (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[mazeTrail.xPosition[i] - (halfTrailWidth + 1), ((mazeTrail.yPosition[i] - halfTrailWidth) + ii)] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[(mazeTrail.xPosition[i] - a), ((mazeTrail.yPosition[i] + halfTrailWidth) - b)] = TRAIL;
                            }
                        }
                    }
                }
                else if (mazeTrail.trailDirection[i] == UP)
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + a), mazeTrail.yPosition[i]] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == UP)
                    {
                        mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + a), mazeTrail.yPosition[i]] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == RIGHT)
                    {
                        for (int ii = 0; ii < (halfTrailWidth + 2); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), (mazeTrail.yPosition[i] - ii)] = TRAILBORDER;
                        }
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), (mazeTrail.yPosition[i] + ii)] = OPEN;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth) + ii, (mazeTrail.yPosition[i] - (halfTrailWidth + 1))] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + b), ((mazeTrail.yPosition[i] - (halfTrailWidth - 1)) + a)] = TRAIL;
                            }
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == LEFT)
                    {
                        for (int ii = 0; ii < (halfTrailWidth + 2); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), ((mazeTrail.yPosition[i]) - ii)] = TRAILBORDER;
                        }
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), (mazeTrail.yPosition[i] + ii)] = OPEN;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth) + ii, (mazeTrail.yPosition[i] - (halfTrailWidth + 1))] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + b), ((mazeTrail.yPosition[i] - (halfTrailWidth - 1)) + a)] = TRAIL;
                            }
                        }
                    }
                }
                else if (mazeTrail.trailDirection[i] == DOWN)
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + a), mazeTrail.yPosition[i]] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == DOWN)
                    {
                        mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER; 

                        for (int a = 1; a < trailWidth; a++)
                        {
                            mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + a), mazeTrail.yPosition[i]] = TRAIL;
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == RIGHT)
                    {
                        for (int ii = 0; ii < (halfTrailWidth + 2); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), (mazeTrail.yPosition[i] + ii)] = TRAILBORDER;
                        }
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), (mazeTrail.yPosition[i] - ii)] = OPEN;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth) + ii, (mazeTrail.yPosition[i] + (halfTrailWidth + 1))] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + b), ((mazeTrail.yPosition[i]) + a)] = TRAIL;
                            }
                        }
                    }
                    else if (mazeTrail.trailDirection[i + 1] == LEFT)
                    {
                        for (int ii = 0; ii < (halfTrailWidth + 2); ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), ((mazeTrail.yPosition[i]) + ii)] = TRAILBORDER;
                        }
                        for (int ii = 0; ii < halfTrailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), (mazeTrail.yPosition[i] + ii)] = OPEN;
                        }
                        for (int ii = 1; ii < trailWidth; ii++)
                        {
                            mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth) + ii, (mazeTrail.yPosition[i] + (halfTrailWidth + 1))] = TRAILBORDER;
                        }
                        for (int a = 0; a < halfTrailWidth; a++)
                        {
                            for (int b = 1; b < trailWidth; b++)
                            {
                                mazePlatform.status[((mazeTrail.xPosition[i] - halfTrailWidth) + b), (mazeTrail.yPosition[i] + a)] = TRAIL;
                            }
                        }
                    }
                }
            }
        }

        public void CreateMazeDeadEnd(List<MazeTrail> mazeTrail, MazePlatform mazePlatform)
        {
            int priorDirection = 0;
            int stepsInSameDirection = 0;
            Random rnd = new Random();
            recurse = false;

            mazeTrailList = new List<MazeTrail>();

            foreach (MazeTrail trail in mazeTrail)
            {
                stepsInSameDirection = 0;
                priorDirection = trail.trailDirection[1];

                for (int i = 0; i < trail.xPosition.Count; i++)
                {
                    if (priorDirection == trail.trailDirection[i])
                    {
                        stepsInSameDirection++;

                        if (stepsInSameDirection == 15)
                        {
                            if (true)  //rnd.Next(10) < 5: This makes a trail opening on a curve 50% of the time
                            {
                                if (trail.trailDirection[i] == LEFT || trail.trailDirection[i] == RIGHT)
                                {
                                    for (int x = 0; x < halfTrailWidth; x++)
                                    {
                                        mazePlatform.status[((trail.xPosition[i] - x)), (trail.yPosition[i])] = OPENS_UP;
                                        trail.positionStatus[(i - x)] = OPENS_UP;
                                    }

                                    for (int x = 0; x < trailWidth; x++)
                                    {
                                        mazePlatform.status[((trail.xPosition[i] - trailWidth)), (trail.yPosition[i])] = OPENS_DOWN;
                                        trail.positionStatus[(i - x) - halfTrailWidth] = OPENS_DOWN;
                                    }


                                }
                                else if (trail.trailDirection[i] == DOWN)
                                {
                                    for (int y = 0; y < trailWidth; y++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i]), (trail.yPosition[i] - y) - trailWidth] = OPENS_LEFT;
                                        trail.positionStatus[(i - y) - halfTrailWidth] = OPENS_LEFT;
                                    }

                                    for (int y = 0; y < trailWidth; y++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i]), (trail.yPosition[i] - y)] = OPENS_RIGHT;
                                        trail.positionStatus[(i - y)] = OPENS_RIGHT;
                                    }
                                }
                                else if (trail.trailDirection[i] == UP)
                                {
                                    for (int y = 0; y < trailWidth; y++)
                                    {
                                        if (trail.yPosition[i] > 22)
                                        {
                                            mazePlatform.status[(trail.xPosition[i]), (trail.yPosition[i] - y) - trailWidth] = OPENS_LEFT;
                                            trail.positionStatus[(i - y) - halfTrailWidth] = OPENS_LEFT;
                                        }
                                    }

                                    for (int y = 0; y < trailWidth; y++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i]), (trail.yPosition[i] - y)] = OPENS_RIGHT;
                                        trail.positionStatus[(i - y)] = OPENS_RIGHT;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (priorDirection == RIGHT)
                        {
                            trail.positionStatus[i] = OPENS_RIGHT;
                        }
                        else if (priorDirection == LEFT)
                        {
                            trail.positionStatus[i] = OPENS_LEFT;
                        }
                        stepsInSameDirection = 0;
                        priorDirection = trail.trailDirection[i];
                    }
                }
            }

            //**********************************************************************************************************

            foreach (MazeTrail trail in mazeTrail)
            {
                int xPoint = 0;
                int yPoint = 0;
                int direction = 0;
                int _distanceToBorder = 0;
                int _distanceToTrail = 0;
                int curveLength = 0;
                bool goUp = false;
                bool goDown = false;
                bool goLeft = false;
                bool goRight = false;
                bool keepGoing = true;
                MazeTrail newMazeTrail = null;

                for (int i = 0; i < trail.xPosition.Count; i++)
                {

                    if (trail.positionStatus[i] == OPENS_UP)
                    {
                        xPoint = trail.xPosition[i] + halfTrailWidth;
                        yPoint = trail.yPosition[i] - halfTrailWidth;
                        newMazeTrail = new MazeTrail();
                        recurse = true;

                        curveLength = GetTrailLength();

                        goUp = true;
                        keepGoing = true;

                        _distanceToBorder = DistanceToBorder(xPoint, yPoint, UP, mazePlatform);
                        _distanceToTrail = DistanceToTrail(xPoint, yPoint, UP, mazePlatform);

                        if (_distanceToBorder < curveLength + 1 || _distanceToTrail < curveLength + 1)
                        {
                            goUp = false;
                            keepGoing = false;
                        }

                        if (goUp)
                        {
                            CreateTrail(xPoint, yPoint, UP, curveLength, newMazeTrail, mazePlatform);
                            DrawTrails(newMazeTrail, mazePlatform);
                            mazeTrailList.Add(newMazeTrail);
                            yPoint -= curveLength;
                            goUp = false;
                        }

                        priorDirection = UP;
                        i += trailWidth + 1;
                    }
                    else if (trail.positionStatus[i] == OPENS_DOWN)
                    {
                        
                        xPoint = trail.xPosition[i] + (halfTrailWidth);
                        yPoint = trail.yPosition[i] + (halfTrailWidth);
                        newMazeTrail = new MazeTrail();
                        recurse = true;
                        
                        curveLength = GetTrailLength();

                        goDown = true;
                        keepGoing = true;

                        _distanceToBorder = DistanceToBorder(xPoint, yPoint, DOWN, mazePlatform);
                        _distanceToTrail = DistanceToTrail(xPoint, yPoint, DOWN, mazePlatform);

                        if (_distanceToBorder < curveLength + 1 || _distanceToTrail < curveLength + 1)
                        {
                            goDown = false;
                            keepGoing = false;
                        }

                        if (goDown)
                        {
                            CreateTrail(xPoint, yPoint, DOWN, curveLength, newMazeTrail, mazePlatform);
                            DrawTrails(newMazeTrail, mazePlatform);
                            mazeTrailList.Add(newMazeTrail);
                            yPoint += curveLength;
                            goDown = false;
                        }

                        priorDirection = DOWN;
                        i += trailWidth + 1;
                    }
                    else if (trail.positionStatus[i] == OPENS_RIGHT)
                    {
                        xPoint = trail.xPosition[i] + halfTrailWidth;

                        if (trail.trailDirection[i] == DOWN)
                        {
                            yPoint = trail.yPosition[i] + halfTrailWidth;
                        }
                        else if (trail.trailDirection[i] == UP)
                        {
                            yPoint = trail.yPosition[i] - halfTrailWidth;
                        }

                        newMazeTrail = new MazeTrail();
                        recurse = true;
                        curveLength = GetTrailLength();

                        goRight = true;
                        keepGoing = true;

                        _distanceToBorder = DistanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);
                        _distanceToTrail = DistanceToTrail(xPoint, yPoint, RIGHT, mazePlatform);

                        if (_distanceToBorder < curveLength + 1 || _distanceToTrail < curveLength + 1)
                        {
                            goRight = false;
                            keepGoing = false;
                        }

                        if (goRight)
                        {
                            CreateTrail(xPoint, yPoint, RIGHT, curveLength, newMazeTrail, mazePlatform);
                            DrawTrails(newMazeTrail, mazePlatform);
                            mazeTrailList.Add(newMazeTrail);
                            xPoint += curveLength;
                            goRight = false;
                        }

                        priorDirection = RIGHT;
                        i += trailWidth + 1;
                    }
                    else if (trail.positionStatus[i] == OPENS_LEFT)
                    {
                        xPoint = trail.xPosition[i] - (halfTrailWidth);

                        if (trail.trailDirection[i] == DOWN)
                        {
                            yPoint = trail.yPosition[i] + halfTrailWidth;
                        }
                        else if (trail.trailDirection[i] == UP)
                        {
                            yPoint = trail.yPosition[i] - halfTrailWidth;
                        }

                        newMazeTrail = new MazeTrail();
                        recurse = true;
                        curveLength = GetTrailLength();

                        goLeft = true;
                        keepGoing = true;

                        _distanceToBorder = DistanceToBorder(xPoint, yPoint, LEFT, mazePlatform);
                        _distanceToTrail = DistanceToTrail(xPoint, yPoint, LEFT, mazePlatform);

                        if (_distanceToBorder < curveLength + 1 || _distanceToTrail < curveLength + 1)
                        {
                            goLeft = false;
                            keepGoing = false;
                        }

                        if (goLeft)
                        {
                            CreateTrail(xPoint, yPoint, LEFT, curveLength, newMazeTrail, mazePlatform);
                            DrawTrails(newMazeTrail, mazePlatform);
                            mazeTrailList.Add(newMazeTrail);
                            xPoint -= curveLength;
                            goLeft = false;
                        }

                        priorDirection = LEFT;
                        i += trailWidth + 1;
                    }
                    else
                    {
                        keepGoing = false;
                    }

                    while (keepGoing)
                    {
                        if (priorDirection == DOWN || priorDirection == UP)
                        {
                            curveLength = GetTrailLength();
                            direction = rnd.Next(3, 5);

                            if (direction == RIGHT)
                            {
                                _distanceToBorder = DistanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);
                                _distanceToTrail = DistanceToTrail(xPoint, yPoint, RIGHT, mazePlatform);

                                if (_distanceToBorder <= curveLength + 1 || _distanceToTrail <= curveLength + 1)
                                {
                                    keepGoing = false;
                                    CloseDeadEnd(xPoint, yPoint, priorDirection, mazePlatform);
                                }
                                else
                                {
                                    CreateTrail(xPoint, yPoint, RIGHT, curveLength, newMazeTrail, mazePlatform);
                                    DrawTrails(newMazeTrail, mazePlatform);
                                    xPoint += curveLength;
                                }
                                priorDirection = RIGHT;
                            }
                            if (direction == LEFT)
                            {
                                _distanceToBorder = DistanceToBorder(xPoint, yPoint, LEFT, mazePlatform);
                                _distanceToTrail = DistanceToTrail(xPoint, yPoint, LEFT, mazePlatform);

                                if (_distanceToBorder <= curveLength + 1 || _distanceToTrail <= curveLength + 1)
                                {
                                    keepGoing = false;
                                    CloseDeadEnd(xPoint, yPoint, priorDirection, mazePlatform);
                                }
                                else
                                {
                                    CreateTrail(xPoint, yPoint, LEFT, curveLength, newMazeTrail, mazePlatform);
                                    DrawTrails(newMazeTrail, mazePlatform);
                                    xPoint -= curveLength;
                                }
                                priorDirection = LEFT;
                            }
                        }

                        else if (priorDirection == RIGHT || priorDirection == LEFT)
                        {
                            curveLength = GetTrailLength();
                            direction = rnd.Next(1, 3);

                            if (direction == DOWN)
                            {
                                goDown = true;
                                _distanceToBorder = DistanceToBorder((xPoint - halfTrailWidth), yPoint, DOWN, mazePlatform);
                                _distanceToTrail = DistanceToTrail(xPoint, yPoint, DOWN, mazePlatform);

                                if (_distanceToBorder < curveLength + 1 || _distanceToTrail <= curveLength + 1)
                                {
                                    keepGoing = false;
                                    goDown = false;
                                    CloseDeadEnd(xPoint, yPoint, priorDirection, mazePlatform);
                                }

                                if (goDown)
                                {
                                    CreateTrail(xPoint, yPoint, DOWN, curveLength, newMazeTrail, mazePlatform);
                                    DrawTrails(newMazeTrail, mazePlatform);
                                    yPoint += curveLength;
                                }

                                priorDirection = DOWN;
                            }
                            else if (direction == UP)
                            {
                                goUp = true;
                                _distanceToBorder = DistanceToBorder(xPoint, yPoint, UP, mazePlatform);
                                _distanceToTrail = DistanceToTrail(xPoint, yPoint, UP, mazePlatform);

                                if (_distanceToBorder < curveLength + 1 || _distanceToTrail <= curveLength + 1)
                                {
                                    keepGoing = false;
                                    goUp = false;
                                    CloseDeadEnd(xPoint, yPoint, priorDirection, mazePlatform);
                                }

                                if (goUp)
                                {
                                    CreateTrail(xPoint, yPoint, UP, curveLength, newMazeTrail, mazePlatform);
                                    DrawTrails(newMazeTrail, mazePlatform);
                                    yPoint -= curveLength;
                                }

                                priorDirection = UP;
                            }
                        }

                    }
                    
                }
            }
       
            if (recurse)
            {
                CreateMazeDeadEnd(mazeTrailList, mazePlatform);
            }
        }
    }
}