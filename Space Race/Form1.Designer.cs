
namespace Space_Race
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.hero1ScoreLabel = new System.Windows.Forms.Label();
            this.hero2ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Red;
            this.titleLabel.Location = new System.Drawing.Point(42, 72);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(513, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Space Race";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subTitleLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitleLabel.ForeColor = System.Drawing.Color.Lime;
            this.subTitleLabel.Location = new System.Drawing.Point(65, 153);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(477, 38);
            this.subTitleLabel.TabIndex = 1;
            this.subTitleLabel.Text = "Press Spacebar to begin or Escape to Exit";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hero1ScoreLabel
            // 
            this.hero1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.hero1ScoreLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hero1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.hero1ScoreLabel.Location = new System.Drawing.Point(12, 338);
            this.hero1ScoreLabel.Name = "hero1ScoreLabel";
            this.hero1ScoreLabel.Size = new System.Drawing.Size(47, 53);
            this.hero1ScoreLabel.TabIndex = 2;
            this.hero1ScoreLabel.Text = "0";
            this.hero1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hero2ScoreLabel
            // 
            this.hero2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.hero2ScoreLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hero2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.hero2ScoreLabel.Location = new System.Drawing.Point(541, 338);
            this.hero2ScoreLabel.Name = "hero2ScoreLabel";
            this.hero2ScoreLabel.Size = new System.Drawing.Size(47, 53);
            this.hero2ScoreLabel.TabIndex = 3;
            this.hero2ScoreLabel.Text = "0";
            this.hero2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.hero2ScoreLabel);
            this.Controls.Add(this.hero1ScoreLabel);
            this.Controls.Add(this.subTitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.Label hero1ScoreLabel;
        private System.Windows.Forms.Label hero2ScoreLabel;
    }
}

