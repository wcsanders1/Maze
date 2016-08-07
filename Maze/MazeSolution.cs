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
            int yPoint = rnd.Next(10, (mazePlatform.mazeHeight - 10));
            int xPoint = 1;
            int priorDirection = RIGHT;
            bool initialCurve = true;
            bool keepGoing = true;

            while (keepGoing)
            {
                if (initialCurve)
                {
                    int curveLength = rnd.Next(20, 50);

                    mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                    xPoint += curveLength;
                    initialCurve = false;
                }
                else if (priorDirection == RIGHT || priorDirection == LEFT)
                {
                    int curveLength = rnd.Next(20, 50);
                    int direction = rnd.Next(1, 3);

                    if (direction == DOWN)
                    {
                        bool goDown = true;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);

                        if (_distanceToBorder < curveLength + 10)
                        {
                            goDown = false;
                        }

                        if (goDown)
                        {
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, curveLength, mazePlatform);
                            yPoint += curveLength;
                        }

                        priorDirection = DOWN;
                    }
                    else if (direction == UP)
                    {
                        bool goUp = true;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, UP, mazePlatform);

                        if (_distanceToBorder < curveLength + 10)
                        {
                            goUp = false;
                        }

                        if (goUp)
                        {
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, curveLength, mazePlatform);
                            yPoint -= curveLength;
                        }

                        priorDirection = UP;
                    }
                }
                else if (priorDirection == DOWN || priorDirection == UP)
                {
                    int curveLength = rnd.Next(20, 50);
                    int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);

                    if (distanceToBorder <= curveLength)
                    {
                        mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazePlatform);
                        keepGoing = false;
                    }
                    else
                    {
                        mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, mazePlatform);
                        xPoint += curveLength;
                        priorDirection = RIGHT;
                    }
                }
            }
            return mazePlatform.status;
        }    
    }
}
