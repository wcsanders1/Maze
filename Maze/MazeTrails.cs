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
                MazePlatform.status[x, y] = MazePlatform.CLOSED;
                if (direction == MazePlatform.RIGHT && MazePlatform.status[x++, y] != MazePlatform.CLOSED) { x++; }
                if (direction == MazePlatform.LEFT && MazePlatform.status[x--, y] != MazePlatform.CLOSED) { x--; }
                if (direction == MazePlatform.DOWN && MazePlatform.status[x, y++] != MazePlatform.CLOSED) { y++; }
                if (direction == MazePlatform.UP && MazePlatform.status[x, y--] !=MazePlatform.CLOSED) { y--; }
            }
        }
    }
}
