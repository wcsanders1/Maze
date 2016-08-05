using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeSolution : MazeTrail             //This class should create the maze solution and do other things, like display it on demand
    {                                           //This class can inherit from the MazeTrails class because it's a trail, except it's the lone solution
        //public MazeSolution() : base()
        //{

        //}        
        
        public void CreateMazeSolution()
        {
            Random rnd = new Random();
            int yPoint = rnd.Next(10, 190);
            int xPoint = 1;
            int curveBreaks = 25;
            int priorDirection = MazePlatform.RIGHT;

            for (int curves = 1; curves <= curveBreaks; curves++)
            {
                if (curves == 1)                     //first direction of solution is always to the right
                {
                    int curveLength = rnd.Next(20, 50);

                    createTrail(xPoint, yPoint, MazePlatform.RIGHT, curveLength);
                    xPoint += curveLength;
                }
                else if ((priorDirection == MazePlatform.RIGHT || priorDirection == MazePlatform.LEFT) && curves != curveBreaks)
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(1, 3);

                    if (direction == MazePlatform.DOWN)
                    {
                        bool goDown = false;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, MazePlatform.DOWN);

                        if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.DOWN) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            goDown = true;
                        }

                        if (_distanceToBorder < curveLength)
                        {
                            curveLength = _distanceToBorder - 20;
                            if (curveLength < 10) { goDown = false; }
                        }

                        if (goDown)
                        {
                            createTrail(xPoint, yPoint, MazePlatform.DOWN, curveLength);
                            yPoint += curveLength;
                            priorDirection = MazePlatform.DOWN;
                        }
                    }
                    else if (direction == MazePlatform.UP)
                    {
                        bool goUp = false;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, MazePlatform.UP);

                        if (distanceToTrail(xPoint, yPoint, MazePlatform.UP) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            goUp = true;
                        }

                        if (_distanceToBorder < curveLength)
                        {
                            curveLength = _distanceToBorder - 20;
                            if (curveLength < 10) { goUp = false; }
                        }

                        if (goUp)
                        {
                            createTrail(xPoint, yPoint, MazePlatform.UP, curveLength);
                            yPoint -= curveLength;
                            priorDirection = MazePlatform.UP;
                        }
                    }
                }
                else if ((priorDirection == MazePlatform.DOWN || priorDirection == MazePlatform.UP) && curves != curveBreaks)
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(3, 5);

                    if (direction == MazePlatform.LEFT)
                    {
                        bool goLeft = false;
                        int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.LEFT);

                        if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.LEFT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            goLeft = true;
                        }

                        if (distanceToBorder < curveLength)
                        {
                            curveLength = distanceToBorder - 20;
                            if (curveLength < 10) { goLeft = false; }
                        }

                        if (goLeft)
                        {
                            createTrail(xPoint, yPoint, MazePlatform.LEFT, curveLength);
                            xPoint -= curveLength;
                            priorDirection = MazePlatform.LEFT;
                        }
                    }
                    else if (direction == MazePlatform.RIGHT)
                    {
                        bool goRight = false;
                        int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.RIGHT);

                        if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.RIGHT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            goRight = true;
                        }

                        if (distanceToBorder < curveLength)
                        {
                            curveLength = distanceToBorder - 20;
                            if (curveLength < 10) { goRight = false; }
                        }

                        if (goRight)
                        {
                            createTrail(xPoint, yPoint, MazePlatform.RIGHT, curveLength);
                            xPoint += curveLength;
                            priorDirection = MazePlatform.RIGHT;
                        }
                    }
                }
                else if (curves == curveBreaks)
                {
                    int direction = rnd.Next(1, 5);
                    int distanceToBorder = 0;

                    if (direction == MazePlatform.DOWN)
                    {
                        if (distanceToTrail(xPoint, yPoint, MazePlatform.DOWN) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.DOWN);
                            createTrail(xPoint, yPoint, MazePlatform.DOWN, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.UP) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.UP);
                            createTrail(xPoint, yPoint, MazePlatform.UP, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.LEFT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.LEFT);
                            createTrail(xPoint, yPoint, MazePlatform.LEFT, distanceToBorder);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.RIGHT);
                            createTrail(xPoint, yPoint, MazePlatform.RIGHT, distanceToBorder);
                        }
                    }
                    else if (direction == MazePlatform.UP)
                    {
                        if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.UP) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.UP);
                            createTrail(xPoint, yPoint, MazePlatform.UP, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.DOWN) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.DOWN);
                            createTrail(xPoint, yPoint, MazePlatform.DOWN, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.LEFT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.LEFT);
                            createTrail(xPoint, yPoint, MazePlatform.LEFT, distanceToBorder);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.RIGHT);
                            createTrail(xPoint, yPoint, MazePlatform.RIGHT, distanceToBorder);
                        }
                    }
                    else if (direction == MazePlatform.LEFT)
                    {
                        if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.LEFT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.LEFT);
                            createTrail(xPoint, yPoint, MazePlatform.LEFT, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.DOWN) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.DOWN);
                            createTrail(xPoint, yPoint, MazePlatform.DOWN, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.UP) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.UP);
                            createTrail(xPoint, yPoint, MazePlatform.UP, distanceToBorder);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.RIGHT);
                            createTrail(xPoint, yPoint, MazePlatform.RIGHT, distanceToBorder);
                        }
                    }
                    else if (direction == MazePlatform.RIGHT)
                    {
                        if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.RIGHT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.RIGHT);
                            createTrail(xPoint, yPoint, MazePlatform.RIGHT, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.DOWN) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.DOWN);
                            createTrail(xPoint, yPoint, MazePlatform.DOWN, distanceToBorder);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, MazePlatform.LEFT) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.LEFT);
                            createTrail(xPoint, yPoint, MazePlatform.LEFT, distanceToBorder);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, MazePlatform.UP);
                            createTrail(xPoint, yPoint, MazePlatform.UP, distanceToBorder);
                        }
                    }
                }
            }
        }    
    }
}
