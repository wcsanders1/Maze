namespace Maze
{
    partial class Maze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.control_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.go_button = new System.Windows.Forms.Button();
            this.difficulty_txt = new System.Windows.Forms.TextBox();
            this.num_lines = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.control_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.control_panel.Controls.Add(this.button1);
            this.control_panel.Controls.Add(this.label1);
            this.control_panel.Controls.Add(this.go_button);
            this.control_panel.Controls.Add(this.difficulty_txt);
            this.control_panel.Controls.Add(this.num_lines);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(1207, 100);
            this.control_panel.TabIndex = 0;
            this.control_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.control_panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "(Caution: levels beyond 7 may take a long time to load)";
            // 
            // go_button
            // 
            this.go_button.Location = new System.Drawing.Point(624, 22);
            this.go_button.Name = "go_button";
            this.go_button.Size = new System.Drawing.Size(87, 50);
            this.go_button.TabIndex = 8;
            this.go_button.Text = "Make Maze";
            this.go_button.UseVisualStyleBackColor = true;
            this.go_button.Click += new System.EventHandler(this.go_button_Click);
            // 
            // difficulty_txt
            // 
            this.difficulty_txt.Location = new System.Drawing.Point(398, 35);
            this.difficulty_txt.Name = "difficulty_txt";
            this.difficulty_txt.Size = new System.Drawing.Size(80, 22);
            this.difficulty_txt.TabIndex = 4;
            this.difficulty_txt.Text = "7";
            // 
            // num_lines
            // 
            this.num_lines.AutoSize = true;
            this.num_lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_lines.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.num_lines.Location = new System.Drawing.Point(165, 35);
            this.num_lines.Name = "num_lines";
            this.num_lines.Size = new System.Drawing.Size(193, 25);
            this.num_lines.TabIndex = 0;
            this.num_lines.Text = "Enter Difficulty Level:";
            this.num_lines.Click += new System.EventHandler(this.num_lines_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Black;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 100);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1207, 525);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(851, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 50);
            this.button1.TabIndex = 10;
            this.button1.Text = "Show Solution";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1207, 625);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.control_panel);
            this.Name = "Maze";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Maze_Load);
            this.control_panel.ResumeLayout(false);
            this.control_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.Label num_lines;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button go_button;
        private System.Windows.Forms.TextBox difficulty_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

