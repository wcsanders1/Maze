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


        //OLD PROGRAM I'M USING AS EXAMPLE IS COMMENTED OUT******************************************************

        

        //static int center_x, center_y;
        //static int start_x, start_y;
        //static int end_x, end_y;

        //static int my_angle = 0;
        //static int my_length = 0;
        //static int my_increment = 0;
        //static int my_num_lines = 0;

        public Maze()
        {
            InitializeComponent();

            MazePlatform.CreateMazePlatform();
            MazePlatform.InitializeMazeStatus();
            MazePlatform.CreateMazeBorders();
            MazePlatform.CreateMazeSolution();


            //start_x = canvas.Width / 2;    // to get to middle of canvas
            //start_y = canvas.Height / 2;
        }

        private void control_panel_Paint(object sender, PaintEventArgs e)
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
                    if (MazePlatform.status[x, y] == "closed")
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

        private void drawLine()
        {
            //my_angle += Int32.Parse(angle_txt.Text);
            //my_length += Int32.Parse(increment_txt.Text);

            //end_x = (int)(start_x + Math.Cos(my_angle * .01745329519) * my_length);
            //end_y = (int)(start_y + Math.Sin(my_angle * .017453292519) * my_length);

            //Point[] points =
            //{
            //    new Point(start_x, start_y),
            //    new Point(end_x, end_y)
            //};

            //start_x = end_x;
            //start_y = end_y;

            //g.DrawLines(myPen, points);
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            //my_length = Int32.Parse(length_txt.Text);
            //my_increment = Int32.Parse(increment_txt.Text);
            //my_angle = Int32.Parse(angle_txt.Text);

            //start_x = canvas.Width / 2;
            //start_y = canvas.Height / 2;

            MazePlatform.InitializeMazeStatus();
            MazePlatform.CreateMazeBorders();
            MazePlatform.CreateMazeSolution();
            canvas.Refresh();
        }
    }
}
