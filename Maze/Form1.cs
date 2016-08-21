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

        public static int difficulty = 0;

        public static int DifficultyLevel
        {
            get
            {
                if (difficulty < 4 || difficulty > 7)
                {
                    return 7;
                }
                else
                {
                    return difficulty;
                };
            }
        }

        public Maze()
        {
            InitializeComponent();

            try
            {
                difficulty = int.Parse(difficulty_txt.Text);
            }
            catch
            {
                difficulty = 7;
            };
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
                        myBrush = Brushes.Black;
                        g.FillRectangle(myBrush, mazePlatform.mazeX[x], mazePlatform.mazeY[y], 1, 1);
                    }
                    else if (mazePlatform.status[x, y] == MazePlatform.OPEN)
                    {
                        myBrush = Brushes.BlanchedAlmond;
                        g.FillRectangle(myBrush, mazePlatform.mazeX[x], mazePlatform.mazeY[y], 1, 1);
                    }
                    else if (mazePlatform.status[x, y] == MazePlatform.TRAIL ||
                             mazePlatform.status[x, y] == MazePlatform.OPENS_DOWN ||
                             mazePlatform.status[x, y] == MazePlatform.OPENS_LEFT ||
                             mazePlatform.status[x, y] == MazePlatform.OPENS_RIGHT ||
                             mazePlatform.status[x, y] == MazePlatform.OPENS_UP)
                    {
                        myBrush = Brushes.White;
                        g.FillRectangle(myBrush, mazePlatform.mazeX[x], mazePlatform.mazeY[y], 1, 1);
                    }
                }
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            mazePlatform = new MazePlatform();
            mazeSolution = new MazeSolution();

            mazePlatform.CreateMazePlatform(canvas.Width, canvas.Height);
            mazeSolution.CreateMazeSolution(mazeSolution, mazePlatform);

            DrawMaze(mazePlatform);
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            try
            {
                difficulty = int.Parse(difficulty_txt.Text);
            }
            catch
            {
                difficulty = 7;
            }

            mazePlatform = new MazePlatform();
            mazeSolution = new MazeSolution();

            mazePlatform.CreateMazePlatform(canvas.Width, canvas.Height);
            mazeSolution.CreateMazeSolution(mazeSolution, mazePlatform);
            canvas.Refresh();
        }

        private void num_lines_Click(object sender, EventArgs e)  // VS won't let me remove this
        {

        }

        private void Maze_Load(object sender, EventArgs e)    // VS won't let me remove this
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = canvas.CreateGraphics();

            for (int i = 0; i < mazeSolution.xPosition.Count; i++)
            {
                myBrush = Brushes.Crimson;
                g.FillRectangle(myBrush, mazePlatform.mazeX[mazeSolution.xPosition[i]], mazePlatform.mazeY[mazeSolution.yPosition[i]], 1, 1);
            }
        }
    }
}
