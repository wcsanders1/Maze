using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeSolution : MazeTrail
    {
        public MazeSolution() : base()
        {
            solution = true;
        }

        //CreateMazeSolution makes the solution of the maze, which other trails then branch off of; the solution never goes left

        public void CreateMazeSolution(MazeSolution mazeSolution, MazePlatform mazePlatform)
        {
            Random rnd = new Random();
            int yPoint = rnd.Next(100, (mazePlatform.mazeHeight - 100));
            int xPoint = 1;
            int priorDirection = RIGHT;
            bool initialCurve = true;
            bool keepGoing = true;
            int curveLength = 0;

            mazeTrailList = new List<MazeTrail>();

            for (int i = 1; i < trailWidth; i++)   // This makes the beginning of the solution open
            {
                mazePlatform.status[0, ((yPoint - halfTrailWidth) + i)] = OPEN;
            }

            while (keepGoing)
            {
                if (initialCurve)
                {
                    curveLength = 60;

                    CreateTrail(xPoint, yPoint, RIGHT, curveLength, mazeSolution, mazePlatform);
                    DrawTrails(mazeSolution, mazePlatform);
                    xPoint += curveLength;
                    initialCurve = false;
                }
                else if (priorDirection == RIGHT)
                {
                    int direction = rnd.Next(UP, (DOWN + 1));

                    if (direction == DOWN)
                    {
                        curveLength = GetTrailLength();
                        bool goDown = true;
                        int _distanceToBorder = DistanceToBorder(xPoint, yPoint, DOWN, mazePlatform);

                        if (_distanceToBorder < curveLength + 20)
                        {
                            goDown = false;
                        }

                        if (goDown)
                        {
                            CreateTrail(xPoint, yPoint, DOWN, curveLength, mazeSolution, mazePlatform);
                            DrawTrails(mazeSolution, mazePlatform);
                            yPoint += curveLength;
                        }

                        priorDirection = DOWN;
                    }
                    else if (direction == UP)
                    {
                        curveLength = GetTrailLength();
                        bool goUp = true;
                        int _distanceToBorder = DistanceToBorder(xPoint, yPoint, UP, mazePlatform);

                        if (_distanceToBorder < curveLength + 20)
                        {
                            goUp = false;
                        }

                        if (goUp)
                        {
                            CreateTrail(xPoint, yPoint, UP, curveLength, mazeSolution, mazePlatform);
                            DrawTrails(mazeSolution, mazePlatform);
                            yPoint -= curveLength;
                        }

                        priorDirection = UP;
                    }
                }
                else if (priorDirection == DOWN || priorDirection == UP)
                {
                    curveLength = GetTrailLength();
                    int distanceToBorder = DistanceToBorder(xPoint, yPoint, RIGHT, mazePlatform);

                    if (distanceToBorder <= curveLength + 20)
                    {
                        CreateTrail(xPoint, yPoint, RIGHT, distanceToBorder, mazeSolution, mazePlatform);
                        DrawTrails(mazeSolution, mazePlatform);
                        keepGoing = false;
                    }
                    else
                    {
                        CreateTrail(xPoint, yPoint, RIGHT, curveLength, mazeSolution, mazePlatform);
                        DrawTrails(mazeSolution, mazePlatform);
                        xPoint += curveLength;
                        priorDirection = RIGHT;
                    }
                }
            }

            for (int i = 1; i < trailWidth; i++)
            {
                mazePlatform.status[(mazePlatform.mazeWidth - 1), ((yPoint - halfTrailWidth) + i)] = OPEN;   // This opens the end of the solution
            }

            mazeTrailList.Add(mazeSolution);

            CreateMazeDeadEnd(mazeTrailList, mazePlatform);
        }    
    }
}
