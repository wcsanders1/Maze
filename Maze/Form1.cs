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

        public Maze()
        {
            InitializeComponent();

            MazePlatform.CreateMazePlatform();
            MazePlatform.InitializeMazeStatus();
            MazePlatform.CreateMazeBorders();
            MazeSolution.CreateMazeSolution();
        }

        private void control_panel_Paint(object sender, PaintEventArgs e) // VS doesn't like it when I try to remove this
        {

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {

            //myPen.Width = 1;

            //my_length = Int32.Parse(length_txt.Text);


            g = canvas.CreateGraphics();

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    if (MazePlatform.status[x, y] == MazePlatform.TRAIL || MazePlatform.status[x, y] == MazePlatform.BORDER)
                    {
                        g.FillRectangle(myBrush, MazePlatform.mazeX[x], MazePlatform.mazeY[y], 1, 1);
                    }
                }
            }

            //for (int i = 0; i < Int32.Parse(num_lines_txt.Text); i++)
            //{
            //    drawLine();
            //}
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            MazePlatform.InitializeMazeStatus();
            MazePlatform.CreateMazeBorders();
            MazeSolution.CreateMazeSolution();
            canvas.Refresh();
        }
    }
}
