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
            int yPoint = rnd.Next(0, 200);
            int xPoint = 0;
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
                        bool fullDown = true;

                        for (int i = 1; i <= curveLength; i++)   // test to see whether going down will run into a border or itself, and if so only make trail within 5 px of the closed px
                        {
                            if (MazePlatform.status[xPoint, yPoint + i] == MazePlatform.CLOSED)
                            {
                                fullDown = false;

                                if (i <= 20)
                                {
                                    break;
                                }
                                else
                                {
                                    curveLength = i - 5;
                                    MazeTrails.createTrail(xPoint, yPoint, MazePlatform.DOWN, curveLength);
                                    yPoint += curveLength;
                                    break;
                                }
                            }
                        }
                        if (fullDown)
                        {
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.DOWN, curveLength);
                            yPoint += curveLength;
                        }
                    }
                    else if (direction == MazePlatform.UP)
                    {
                        bool fullUp = true;

                        for (int i = 1; i <= curveLength; i++)
                        {
                            if (MazePlatform.status[xPoint, yPoint - i] == MazePlatform.CLOSED)
                            {
                                fullUp = false;

                                if (i <= 20)
                                {
                                    break;
                                }
                                else
                                {
                                    curveLength = i - 5;
                                    MazeTrails.createTrail(xPoint, yPoint, MazePlatform.UP, curveLength);
                                    yPoint -= curveLength;
                                    break;
                                }
                            }
                        }
                        if (fullUp)
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
                        bool fullLeft = true;

                        for (int i = 1; i <= curveLength; i++)
                        {
                            if (MazePlatform.status[xPoint - i, yPoint] == MazePlatform.CLOSED)
                            {
                                fullLeft = false;

                                if (i <= 20)
                                {
                                    break;
                                }
                                else
                                {
                                    curveLength = i - 5;
                                    MazeTrails.createTrail(xPoint, yPoint, MazePlatform.LEFT, curveLength);
                                    xPoint -= curveLength;
                                    break;
                                }
                            }
                        }
                        if (fullLeft)
                        {
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.LEFT, curveLength);
                            xPoint -= curveLength;
                        }
                    }
                    else if (direction == MazePlatform.RIGHT)
                    {
                        bool fullRight = true;

                        for (int i = 1; i <= curveLength; i++)
                        {
                            if (MazePlatform.status[xPoint + i, yPoint] == MazePlatform.CLOSED)
                            {
                                fullRight = false;

                                if (i <= 20)
                                {
                                    break;
                                }
                                else
                                {
                                    curveLength = i - 5;
                                    MazeTrails.createTrail(xPoint, yPoint, MazePlatform.RIGHT, curveLength);
                                    xPoint += curveLength;
                                    break;
                                }
                            }
                        }
                        if (fullRight)
                        {
                            MazeTrails.createTrail(xPoint, yPoint, MazePlatform.RIGHT, curveLength);
                            xPoint += curveLength;
                        }
                    }                       
                }
                else if (curves % 2 == 0 && curves == curveBreaks)
                {
                    int direction = rnd.Next(1, 3);

                    if (direction == MazePlatform.DOWN)
                    {
                        while (yPoint < 200)
                        {
                            yPoint++;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.CLOSED;
                        }
                    }
                    else if (direction == MazePlatform.UP)
                    {
                        while (yPoint > 0)
                        {
                            yPoint--;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.CLOSED;
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
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.CLOSED;
                        }
                    }
                    else if (direction == MazePlatform.LEFT)
                    {
                        while (xPoint > 0)
                        {
                            xPoint--;
                            MazePlatform.status[xPoint, yPoint] = MazePlatform.CLOSED;
                        }
                    }
                }
            }
        }
    }
}
