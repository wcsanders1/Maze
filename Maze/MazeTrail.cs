﻿using System;
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

        public int[,] createTrail(int x, int y, int direction, int distance, MazeTrail mazeTrail, MazePlatform mazePlatform)
        {
            for (int i = 0; i < distance; i++)
            {
                mazePlatform.status[x, y] = TRAIL;

                mazeTrail.xPosition.Add(x);
                mazeTrail.yPosition.Add(y);
                mazeTrail.trailDirection.Add(direction);
                mazeTrail.positionStatus.Add(TRAIL);

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

        public void DrawTrails(MazeTrail mazeTrail, MazePlatform mazePlatform)
        {
            for (int i = 0; i < mazeTrail.xPosition.Count; i++)
            {
                if (i != 0)
                {
                    if (mazeTrail.trailDirection[i] != mazeTrail.trailDirection[i - 1])
                    {
                        i = i + halfTrailWidth;
                    }
                }
                if (mazeTrail.trailDirection[i] == RIGHT)
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER;
                        mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER;
                    }
                    else if (mazeTrail.trailDirection[i + 1] == RIGHT)
                    {
                        if (mazeTrail.positionStatus[i] != OPENS_UP) { mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] + halfTrailWidth)] = TRAILBORDER; }
                        if (mazeTrail.positionStatus[i] != OPENS_DOWN) { mazePlatform.status[mazeTrail.xPosition[i], (mazeTrail.yPosition[i] - halfTrailWidth)] = TRAILBORDER; }
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
                    }
                }
                else if (mazeTrail.trailDirection[i] == UP)
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                    }
                    else if (mazeTrail.trailDirection[i + 1] == UP)
                    {
                        if (mazeTrail.positionStatus[i] != OPENS_LEFT) { mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER; }
                        if (mazeTrail.positionStatus[i] != OPENS_RIGHT) { mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER; }
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
                    }
                }
                else if (mazeTrail.trailDirection[i] == DOWN)
                {
                    if ((i + 1) == mazeTrail.xPosition.Count)
                    {
                        mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                        mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER;
                    }
                    else if (mazeTrail.trailDirection[i + 1] == DOWN)
                    {
                        if (mazeTrail.positionStatus[i] != OPENS_RIGHT) { mazePlatform.status[(mazeTrail.xPosition[i] - halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER; }
                        if (mazeTrail.positionStatus[i] != OPENS_LEFT) { mazePlatform.status[(mazeTrail.xPosition[i] + halfTrailWidth), mazeTrail.yPosition[i]] = TRAILBORDER; }
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
                    }
                }
            }
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
                                else if (trail.trailDirection[i] == DOWN || trail.trailDirection[i] == UP)
                                {
                                    openingLocation = rnd.Next(1, 5);
                                    openingDirection = rnd.Next(7, 9);

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
                        priorDirection = trail.trailDirection[i];
                    }
                }
            }

            //**********************************************************************************************************

            foreach (MazeTrail trail in mazeTrail)
            {
                int xPoint = 0;
                int yPoint = 0;
                bool keepGoing = true;
                MazeTrail newMazeTrail = null;

                for (int i = 0; i < trail.xPosition.Count; i++)
                {

                    if (trail.positionStatus[i] == OPENS_DOWN)  // This is upside down for some reason, but works otherwise
                    {
                        xPoint = trail.xPosition[i] + halfTrailWidth;
                        yPoint = trail.yPosition[i] - halfTrailWidth;
                        newMazeTrail = new MazeTrail();

                        int curveLength = rnd.Next(15, 60);

                        bool goDown = true;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, UP, mazePlatform);

                        if (_distanceToBorder < curveLength + 20)
                        {
                            goDown = false;
                            keepGoing = false;
                        }

                        if (goDown)
                        {
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, curveLength, newMazeTrail, mazePlatform);
                            yPoint += curveLength;
                        }

                        priorDirection = DOWN;

                        i += trailWidth +1;
                    }
                }

                DrawTrails(newMazeTrail, mazePlatform);
            }

                        //while (keepGoing)
                        //{
                        //    if (priorDirection == DOWN || priorDirection == UP)
                        //    {
                        //        curveLength = rnd.Next(15, 60);
                        //        _distanceToBorder = distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);

                        //        if (_distanceToBorder <= curveLength + 20)
                        //        {
                        //            keepGoing = false;
                        //        }
                        //        else
                        //        {
                        //            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                        //            xPoint += curveLength;
                        //            priorDirection = RIGHT;
                        //        }
                        //    }
                        //    else if (priorDirection == RIGHT || priorDirection == LEFT)
                        //    {
                        //        curveLength = rnd.Next(15, 60);
                        //        direction = rnd.Next(1, 3);

                        //        if (direction == DOWN)
                        //        {
                        //            goDown = true;
                        //            _distanceToBorder = distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);

                        //            if (_distanceToBorder < curveLength + 20)
                        //            {
                        //                keepGoing = false;
                        //                goDown = false;
                        //            }

                        //            if (goDown)
                        //            {
                        //                mazePlatform.status = createTrail(xPoint, yPoint, DOWN, curveLength, mazePlatform);
                        //                yPoint += curveLength;
                        //            }

                        //            priorDirection = DOWN;
                        //        }
                        //        else if (direction == UP)
                        //        {
                        //            bool goUp = true;
                        //            _distanceToBorder = distanceToBorder(xPoint, yPoint, UP, mazePlatform);

                        //            if (_distanceToBorder < curveLength + 20)
                        //            {
                        //                keepGoing = false;
                        //                goUp = false;
                        //            }

                        //            if (goUp)
                        //            {
                        //                mazePlatform.status = createTrail(xPoint, yPoint, UP, curveLength, mazePlatform);
                        //                yPoint -= curveLength;
                        //            }

                        //            priorDirection = UP;
                        //        }
                        //    }
                        //}
                    }
                }
                   




                //    while (keepGoing)
                //    {
                //        if (initialCurve)
                //        {
                //            int curveLength = rnd.Next(15, 60);

                //            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                //            xPoint += curveLength;
                //            initialCurve = false;
                //        }
                //        else if (priorDirection == RIGHT || priorDirection == LEFT)
                //        {
                //            int curveLength = rnd.Next(15, 60);
                //            int direction = rnd.Next(1, 3);

                //            if (direction == DOWN)
                //            {
                //                bool goDown = true;
                //                int _distanceToBorder = distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);

                //                if (_distanceToBorder < curveLength + 20)
                //                {
                //                    goDown = false;
                //                }

                //                if (goDown)
                //                {
                //                    mazePlatform.status = createTrail(xPoint, yPoint, DOWN, curveLength, mazePlatform);
                //                    yPoint += curveLength;
                //                }

                //                priorDirection = DOWN;
                //            }
                //            else if (direction == UP)
                //            {
                //                bool goUp = true;
                //                int _distanceToBorder = distanceToBorder(xPoint, yPoint, UP, mazePlatform);

                //                if (_distanceToBorder < curveLength + 20)
                //                {
                //                    goUp = false;
                //                }

                //                if (goUp)
                //                {
                //                    mazePlatform.status = createTrail(xPoint, yPoint, UP, curveLength, mazePlatform);
                //                    yPoint -= curveLength;
                //                }

                //                priorDirection = UP;
                //            }
                //        }
                //        else if (priorDirection == DOWN || priorDirection == UP)
                //        {
                //            int curveLength = rnd.Next(15, 60);
                //            int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);

                //            if (distanceToBorder <= curveLength + 20)
                //            {
                //                mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazePlatform);
                //                keepGoing = false;
                //            }
                //            else
                //            {
                //                mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                //                xPoint += curveLength;
                //                priorDirection = RIGHT;
                //            }
                //        }
                //    }
                //}

                //**********************************************************************************************************
            }
//        }
//    }
//}
