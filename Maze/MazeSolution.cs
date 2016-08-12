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

        public void CreateMazeSolution(MazePlatform mazePlatform)
        {
            Random rnd = new Random();
            int yPoint = rnd.Next(50, (mazePlatform.mazeHeight - 50));
            int xPoint = 1;
            int priorDirection = RIGHT;
            bool initialCurve = true;
            bool keepGoing = true;

            mazeTrailList = new List<MazeTrail>();

            for (int i = 1; i < trailWidth; i++)   // This makes the beginning of the solution open
            {
                mazePlatform.status[0, ((yPoint - halfTrailWidth) + i)] = OPEN;
            }

            while (keepGoing)
            {
                if (initialCurve)
                {
                    int curveLength = rnd.Next(15, 60);

                    mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, this, mazePlatform);
                    xPoint += curveLength;
                    initialCurve = false;
                }
                else if (priorDirection == RIGHT || priorDirection == LEFT)
                {
                    int curveLength = rnd.Next(15, 60);
                    int direction = rnd.Next(1, 3);

                    if (direction == DOWN)
                    {
                        bool goDown = true;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, DOWN, mazePlatform);

                        if (_distanceToBorder < curveLength + 20)
                        {
                            goDown = false;
                        }

                        if (goDown)
                        {
                            mazePlatform.status = createTrail(xPoint, yPoint, DOWN, curveLength, this, mazePlatform);
                            yPoint += curveLength;
                        }

                        priorDirection = DOWN;
                    }
                    else if (direction == UP)
                    {
                        bool goUp = true;
                        int _distanceToBorder = distanceToBorder(xPoint, yPoint, UP, mazePlatform);

                        if (_distanceToBorder < curveLength + 20)
                        {
                            goUp = false;
                        }

                        if (goUp)
                        {
                            mazePlatform.status = createTrail(xPoint, yPoint, UP, curveLength, this, mazePlatform);
                            yPoint -= curveLength;
                        }

                        priorDirection = UP;
                    }
                }
                else if (priorDirection == DOWN || priorDirection == UP)
                {
                    int curveLength = rnd.Next(15, 60);
                    int distanceToBorder = MazeTrail.distanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);

                    if (distanceToBorder <= curveLength + 20)
                    {
                        mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, distanceToBorder, this, mazePlatform);
                        keepGoing = false;
                    }
                    else
                    {
                        mazePlatform.status = createTrail(xPoint, yPoint, RIGHT, curveLength, this, mazePlatform);
                        xPoint += curveLength;
                        priorDirection = RIGHT;
                    }
                }
            }

            for (int i = 1; i < trailWidth; i++)
            {
                mazePlatform.status[(mazePlatform.mazeWidth - 1), ((yPoint - halfTrailWidth) + i)] = OPEN;   // This opens the end of the solution
            }

            mazeTrailList.Add(this);

            CreateMazeDeadEnd(mazeTrailList, mazePlatform);

        }    
    }
}
