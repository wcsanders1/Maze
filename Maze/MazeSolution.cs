using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeSolution : MazeTrails             //This class should create the maze solution and do other things, like display it on demand
    {                                           //This class can inherit from the MazeTrails class because it's a trail, except it's the lone solution
                                                //public MazeSolution() : base()
                                                //{ }        

        public static void CreateMazeSolution()
        {
            Random rnd = new Random();
            int yPoint = rnd.Next(10, 190);
            int xPoint = 1;
            int curveBreaks = 25;

            for (int curves = 1; curves <= curveBreaks; curves++)
            {
                if (curves == 1)                     //first direction of solution is always to the right
                {
                    int curveLength = rnd.Next(20, 50);

                    MazeTrails.createTrail(xPoint, yPoint, MazePlatform.RIGHT, curveLength);
                    xPoint += curveLength;
                }
                else if (curves % 2 == 0 && curves != curveBreaks)   // second direction and all even directions are up or down
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(1, 3);

                    if (direction == MazePlatform.DOWN)
                    {
                        bool goDown = false;
                        int distanceToBorder = MazeTrails.distanceToBorder(xPoint, yPoint, MazePlatform.DOWN);

                        if (MazeTrails.distanceToTrail(xPoint, yPoint, MazePlatform.DOWN) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            goDown = true;
                        }

                        if (distanceToBorder < curveLength)
                        {
                            curveLength = distanceToBorder - 20;
                            if (curveLength < 10) { goDown = false; }
                        }
                        
                        if (goDown)
                        {
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.DOWN, curveLength);
                            yPoint += curveLength;
                        }
                    }
                    else if (direction == MazePlatform.UP)
                    {
                        bool goUp = false;
                        int distanceToBorder = MazeTrails.distanceToBorder(xPoint, yPoint, MazePlatform.UP);

                        if (MazeTrails.distanceToTrail(xPoint, yPoint, MazePlatform.UP) == MazePlatform.NO_TRAIL_IN_WAY)
                        {
                            goUp = true;
                        }

                        if (distanceToBorder < curveLength)
                        {
                            curveLength = distanceToBorder - 20;
                            if (curveLength < 10) { goUp = false; }
                        }

                        if (goUp)
                        {
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.UP, curveLength);
                            yPoint -= curveLength;
                        }
                    }
                }
                else if (curves % 2 != 0 && curves != curveBreaks) //odd directions are left or right
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(3, 5);

                    if (direction == MazePlatform.LEFT)
                    {
                        bool goLeft = false;
                        int distanceToBorder = MazeTrails.distanceToBorder(xPoint, yPoint, MazePlatform.LEFT);

                        if (MazeTrails.distanceToTrail(xPoint, yPoint, MazePlatform.LEFT) == MazePlatform.NO_TRAIL_IN_WAY)
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
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.LEFT, curveLength);
                            xPoint -= curveLength;
                        }
                    }
                    else if (direction == MazePlatform.RIGHT)
                    {
                        bool goRight = false;
                        int distanceToBorder = MazeTrails.distanceToBorder(xPoint, yPoint, MazePlatform.RIGHT);

                        if (MazeTrails.distanceToTrail(xPoint, yPoint, MazePlatform.RIGHT) == MazePlatform.NO_TRAIL_IN_WAY)
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
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.RIGHT, curveLength);
                            xPoint += curveLength;
                        }
                    }
                }
                else if (curves % 2 == 0 && curves == curveBreaks)  // fix this to eliminate the gaps and to keep it from going over other trails
                {
                    int direction = rnd.Next(1, 3);

                    if (direction == MazePlatform.DOWN)
                    {
                        while (yPoint < 200)
                        {
                            yPoint++;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.TRAIL;
                        }
                    }
                    else if (direction == MazePlatform.UP)
                    {
                        while (yPoint > 0)
                        {
                            yPoint--;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.TRAIL;
                        }
                    }
                }
                else if (curves % 2 != 0 && curves == curveBreaks)
                {
                    int direction = rnd.Next(3, 5);

                    if (direction == MazePlatform.RIGHT)
                    {
                        while (xPoint < 199)
                        {
                            xPoint++;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.TRAIL;
                        }
                    }
                    else if (direction == MazePlatform.LEFT)
                    {
                        while (xPoint > 0)
                        {
                            xPoint--;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.TRAIL;
                        }
                    }
                }
            }
        }    
    }
}
