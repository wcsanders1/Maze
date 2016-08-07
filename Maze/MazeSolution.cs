using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeSolution : MazeTrail             //This class should create the maze solution and do other things, like display it on demand
    {                                           //This class can inherit from the MazeTrails class because it's a trail, except it's the lone solution
        public MazeSolution() : base()
        {

        }

        public const int OPEN = MazePlatform.OPEN;
        public const int TRAIL = MazePlatform.TRAIL;
        public const int BORDER = MazePlatform.BORDER;

        public const int NO_TRAIL_IN_WAY = MazePlatform.NO_TRAIL_IN_WAY;

        public const int SOLUTION = MazePlatform.SOLUTION;

        public const int UP = MazePlatform.UP;
        public const int DOWN = MazePlatform.DOWN;
        public const int RIGHT = MazePlatform.RIGHT;
        public const int LEFT = MazePlatform.LEFT;

        public int[,] CreateMazeSolution(MazePlatform mazePlatform)
        {
            Random rnd = new Random();
            int yPoint = rnd.Next(10, 190);
            int xPoint = 1;
            int curveBreaks = 25;
            int priorDirection = RIGHT;

            for (int curves = 1; curves <= curveBreaks; curves++)
            {
                if (curves == 1)                     //first direction of solution is always to the right
                {
                    int curveLength = rnd.Next(20, 50);

                    mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                    xPoint += curveLength;
                }
                else if ((priorDirection == RIGHT || priorDirection == LEFT) && curves != curveBreaks)
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(1, 3);

                    if (direction == DOWN)
                    {
                        bool goDown = false;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);

                        if (MazeTrail.distanceToTrail(xPoint, yPoint, DOWN, mazePlatform) == NO_TRAIL_IN_WAY)
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
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, curveLength, mazePlatform);
                            yPoint += curveLength;
                            priorDirection = DOWN;
                        }
                    }
                    else if (direction == UP)
                    {
                        bool goUp = false;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, UP, mazePlatform);

                        if (distanceToTrail(xPoint, yPoint, UP, mazePlatform) == NO_TRAIL_IN_WAY)
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
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, curveLength, mazePlatform);
                            yPoint -= curveLength;
                            priorDirection = UP;
                        }
                    }
                }
                else if ((priorDirection == DOWN || priorDirection == UP) && curves != curveBreaks)
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(3, 5);

                    if (direction == LEFT)
                    {
                        bool goLeft = false;
                        int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, LEFT, mazePlatform);

                        if (MazeTrail.distanceToTrail(xPoint, yPoint, LEFT, mazePlatform) == NO_TRAIL_IN_WAY)
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
                            mazePlatform.status = createTrail(xPoint, yPoint, LEFT, curveLength, mazePlatform);
                            xPoint -= curveLength;
                            priorDirection = LEFT;
                        }
                    }
                    else if (direction == RIGHT)
                    {
                        bool goRight = false;
                        int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);

                        if (MazeTrail.distanceToTrail(xPoint, yPoint, RIGHT, mazePlatform) == NO_TRAIL_IN_WAY)
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
                            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                            xPoint += curveLength;
                            priorDirection = RIGHT;
                        }
                    }
                }
                else if (curves == curveBreaks)
                {
                    int direction = rnd.Next(1, 5);
                    int distanceToBorder = 0;

                    if (direction == DOWN)
                    {
                        if (distanceToTrail(xPoint, yPoint, DOWN, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, UP, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, UP, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, LEFT, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, LEFT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, LEFT, distanceToBorder, mazePlatform);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazePlatform);
                        }
                    }
                    else if (direction == UP)
                    {
                        if (MazeTrail.distanceToTrail(xPoint, yPoint, UP, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, UP, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, DOWN, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, LEFT, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, LEFT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, LEFT, distanceToBorder, mazePlatform);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazePlatform);
                        }
                    }
                    else if (direction == LEFT)
                    {
                        if (MazeTrail.distanceToTrail(xPoint, yPoint, LEFT, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, LEFT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, LEFT, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, DOWN, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, UP, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, UP, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, distanceToBorder, mazePlatform);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazePlatform);
                        }
                    }
                    else if (direction == RIGHT)
                    {
                        if (MazeTrail.distanceToTrail(xPoint, yPoint, RIGHT, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, DOWN, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, distanceToBorder, mazePlatform);
                        }
                        else if (MazeTrail.distanceToTrail(xPoint, yPoint, LEFT, mazePlatform) == NO_TRAIL_IN_WAY)
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, LEFT, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, LEFT, distanceToBorder, mazePlatform);
                        }
                        else
                        {
                            distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, UP, mazePlatform);
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, distanceToBorder, mazePlatform);
                        }
                    }
                }
            }
            return mazePlatform.status;
        }    
    }
}
