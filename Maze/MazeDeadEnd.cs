using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeDeadEnd : MazeTrail
    {
        public MazeDeadEnd() : base ()
        {
            
        }

        public int [,] CreateMazeDeadEnd(ref MazeTrail[] mazeTrail, MazePlatform mazePlatform)
        {
            int priorDirection = 0;
            int stepsInSameDirection = 0;
            Random rnd = new Random();
            int openingLocation = 0;
            int openingDirection = 0;

            foreach (MazeTrail trail in mazeTrail)
            {
                stepsInSameDirection = 0;
                priorDirection = trail.trailDirection[0];

                for (int i = 0; i < trail.xPosition.Count; i++)
                {
                    if (priorDirection == trail.trailDirection[i])
                    {
                        stepsInSameDirection++;
                    
                        if (stepsInSameDirection == 20)
                        {
                            if (rnd.Next(10) < 5)  //This makes a trail opening on a curve 50% of the time
                            {
                                if (trail.trailDirection[i] == LEFT || trail.trailDirection[i] == RIGHT)
                                {
                                    openingLocation = rnd.Next(0, 5);
                                    openingDirection = rnd.Next(5, 7);

                                    for (int x = 0; x < trailWidth; x++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i] - x), (trail.yPosition[i])] = openingDirection;
                                        trail.positionStatus[i + x] = openingDirection;
                                    }
                                }
                                else if (trail.trailDirection[i] == UP || trail.trailDirection[i] == DOWN)
                                {
                                    openingLocation = rnd.Next(0, 5);
                                    openingDirection = rnd.Next(7, 9);

                                    for (int y = 0; y < trailWidth; y++)
                                    {
                                        mazePlatform.status[(trail.xPosition[i]), (trail.yPosition[i]) - y] = openingDirection;
                                        trail.positionStatus[i + y] = openingDirection;
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

            return mazePlatform.status;
        }
    }
}
