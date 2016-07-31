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
            this.go_button = new System.Windows.Forms.Button();
            this.increment_txt = new System.Windows.Forms.TextBox();
            this.length_txt = new System.Windows.Forms.TextBox();
            this.angle_txt = new System.Windows.Forms.TextBox();
            this.num_lines_txt = new System.Windows.Forms.TextBox();
            this.increment_label = new System.Windows.Forms.Label();
            this.length = new System.Windows.Forms.Label();
            this.angle = new System.Windows.Forms.Label();
            this.num_lines = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.Panel();
            this.control_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.control_panel.Controls.Add(this.go_button);
            this.control_panel.Controls.Add(this.increment_txt);
            this.control_panel.Controls.Add(this.length_txt);
            this.control_panel.Controls.Add(this.angle_txt);
            this.control_panel.Controls.Add(this.num_lines_txt);
            this.control_panel.Controls.Add(this.increment_label);
            this.control_panel.Controls.Add(this.length);
            this.control_panel.Controls.Add(this.angle);
            this.control_panel.Controls.Add(this.num_lines);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(1113, 100);
            this.control_panel.TabIndex = 0;
            this.control_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.control_panel_Paint);
            // 
            // go_button
            // 
            this.go_button.Location = new System.Drawing.Point(928, 27);
            this.go_button.Name = "go_button";
            this.go_button.Size = new System.Drawing.Size(87, 39);
            this.go_button.TabIndex = 8;
            this.go_button.Text = "Go";
            this.go_button.UseVisualStyleBackColor = true;
            this.go_button.Click += new System.EventHandler(this.go_button_Click);
            // 
            // increment_txt
            // 
            this.increment_txt.Location = new System.Drawing.Point(771, 31);
            this.increment_txt.Name = "increment_txt";
            this.increment_txt.Size = new System.Drawing.Size(45, 22);
            this.increment_txt.TabIndex = 7;
            this.increment_txt.Text = "1";
            // 
            // length_txt
            // 
            this.length_txt.Location = new System.Drawing.Point(501, 31);
            this.length_txt.Name = "length_txt";
            this.length_txt.Size = new System.Drawing.Size(45, 22);
            this.length_txt.TabIndex = 6;
            this.length_txt.Text = "5";
            // 
            // angle_txt
            // 
            this.angle_txt.Location = new System.Drawing.Point(306, 31);
            this.angle_txt.Name = "angle_txt";
            this.angle_txt.Size = new System.Drawing.Size(45, 22);
            this.angle_txt.TabIndex = 5;
            this.angle_txt.Text = "74";
            // 
            // num_lines_txt
            // 
            this.num_lines_txt.Location = new System.Drawing.Point(170, 31);
            this.num_lines_txt.Name = "num_lines_txt";
            this.num_lines_txt.Size = new System.Drawing.Size(45, 22);
            this.num_lines_txt.TabIndex = 4;
            this.num_lines_txt.Text = "100";
            // 
            // increment_label
            // 
            this.increment_label.AutoSize = true;
            this.increment_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.increment_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.increment_label.Location = new System.Drawing.Point(611, 31);
            this.increment_label.Name = "increment_label";
            this.increment_label.Size = new System.Drawing.Size(98, 25);
            this.increment_label.TabIndex = 3;
            this.increment_label.Text = "Increment";
            // 
            // length
            // 
            this.length.AutoSize = true;
            this.length.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.length.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.length.Location = new System.Drawing.Point(423, 31);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(72, 25);
            this.length.TabIndex = 2;
            this.length.Text = "Length";
            // 
            // angle
            // 
            this.angle.AutoSize = true;
            this.angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.angle.Location = new System.Drawing.Point(237, 31);
            this.angle.Name = "angle";
            this.angle.Size = new System.Drawing.Size(63, 25);
            this.angle.TabIndex = 1;
            this.angle.Text = "Angle";
            // 
            // num_lines
            // 
            this.num_lines.AutoSize = true;
            this.num_lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_lines.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.num_lines.Location = new System.Drawing.Point(12, 31);
            this.num_lines.Name = "num_lines";
            this.num_lines.Size = new System.Drawing.Size(154, 25);
            this.num_lines.TabIndex = 0;
            this.num_lines.Text = "Number of Lines";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.Info;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 100);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1113, 443);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 543);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.control_panel);
            this.Name = "Maze";
            this.ShowIcon = false;
            this.Text = "Maze";
            this.control_panel.ResumeLayout(false);
            this.control_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.Label angle;
        private System.Windows.Forms.Label num_lines;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button go_button;
        private System.Windows.Forms.TextBox increment_txt;
        private System.Windows.Forms.TextBox length_txt;
        private System.Windows.Forms.TextBox angle_txt;
        private System.Windows.Forms.TextBox num_lines_txt;
        private System.Windows.Forms.Label increment_label;
        private System.Windows.Forms.Label length;
    }
}

