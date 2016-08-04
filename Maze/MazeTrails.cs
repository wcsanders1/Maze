using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeTrails  //These are trails in the maze that all have dead ends, i.e., they're not solutions, though a solution is a Trail
    {                   // This has methods for creating and erasing trails

        public static void createTrail(int x, int y, int direction, int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                MazePlatform.status[x, y] = MazePlatform.TRAIL;
                if (direction == MazePlatform.RIGHT && MazePlatform.status[x++, y] != MazePlatform.TRAIL) { x++; }
                if (direction == MazePlatform.LEFT && MazePlatform.status[x--, y] != MazePlatform.TRAIL) { x--; }
                if (direction == MazePlatform.DOWN && MazePlatform.status[x, y++] != MazePlatform.TRAIL) { y++; }
                if (direction == MazePlatform.UP && MazePlatform.status[x, y--] !=MazePlatform.TRAIL) { y--; }
            }
        }

        public static int distanceToBorder(int x, int y, int direction)
        {
            int intialX = x;
            int initialY = y;
            int distance = 0;

            //catch error of entering direction that isn't left, right, up or down

            while (MazePlatform.status[x, y] != MazePlatform.BORDER)
            {
                if (direction == MazePlatform.RIGHT) { x++; }
                if (direction == MazePlatform.LEFT) { x--; }
                if (direction == MazePlatform.DOWN) { y++; }
                if (direction == MazePlatform.UP) { y--; }
                distance++;
            }

            return distance;  
        }

        public static int distanceToTrail(int x, int y, int direction)
        {
            int distance = 0;

            //catch error of entering direction that isn't left, right, up or down

            while (MazePlatform.status[x, y] != MazePlatform.TRAIL)
            {
                if (MazePlatform.status[x, y] == MazePlatform.BORDER) { return MazePlatform.NO_TRAIL_IN_WAY; }

                if (direction == MazePlatform.RIGHT) { x++; }
                if (direction == MazePlatform.LEFT) { x--; }
                if (direction == MazePlatform.DOWN) { y++; }
                if (direction == MazePlatform.UP) { y--; }

                distance++;
            }

            return distance;
        }
    }
}
