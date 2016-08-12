using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class Maze : Form
    {
        public Brush myBrush = (Brush)Brushes.Black;
        
        public Graphics g = null;

        MazeSolution mazeSolution = null;
        MazePlatform mazePlatform = null;
        MazeDeadEnd mazeDeadEnd = null;



        public static int difficultyLevel = 0;

        public Maze()
        {
            InitializeComponent();

            difficultyLevel = int.Parse(difficulty_txt.Text);

            mazePlatform = new MazePlatform();
            mazeSolution = new MazeSolution();
            mazeDeadEnd = new MazeDeadEnd();

            mazePlatform.CreateMazePlatform(canvas.Width, canvas.Height);
            mazeSolution.CreateMazeSolution(mazePlatform);

            mazeSolution.DrawTrails(mazeSolution, mazePlatform);
            DrawMaze(mazePlatform);
        }

        private void control_panel_Paint(object sender, PaintEventArgs e) // VS doesn't like it when I try to remove this
        {

        }

        public void DrawMaze(MazePlatform mazePlatform)
        {
            g = canvas.CreateGraphics();

            for (int x = 0; x < mazePlatform.mazeWidth; x++)
            {
                for (int y = 0; y < mazePlatform.mazeHeight; y++)
                {
                    if (mazePlatform.status[x, y] == MazePlatform.TRAILBORDER || mazePlatform.status[x, y] == MazePlatform.BORDER)
                    {
                        g.FillRectangle(myBrush, mazePlatform.mazeX[x], mazePlatform.mazeY[y], 1, 1);
                    }
                }
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawMaze(mazePlatform);
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            difficultyLevel = int.Parse(difficulty_txt.Text);

            mazePlatform = new MazePlatform();
            mazeSolution = new MazeSolution();

            mazePlatform.CreateMazePlatform(canvas.Width, canvas.Height);
            mazeSolution.CreateMazeSolution(mazePlatform);
            mazeSolution.DrawTrails(mazeSolution, mazePlatform);
            canvas.Refresh();
        }

        private void num_lines_Click(object sender, EventArgs e)
        {

        }
    }
}
