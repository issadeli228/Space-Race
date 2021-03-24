using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Space_Race
{
    public partial class Form1 : Form
    {
        #region global variables
        int heroX = 200;
        int heroY = 350;
        int hero2X = 400;
        int hero2Y = 350;
        int heroWidth = 10;
        int heroHeight = 30;
        int heroSpeed = 7;

        int hero1ScoreCounter = 0;
        int hero2ScoreCounter = 0;

        List<int> ballXList = new List<int>();
        List<int> ballYList = new List<int>();
        List<int> ballSpeedList = new List<int>();
        List<string> ballColourList = new List<string>();
        List<int> rightBallXList = new List<int>();
        List<int> rightBallYList = new List<int>();
        List<int> rightBallSpeedList = new List<int>();

        int ballSize = 10;

        int score = 0;
        int time = 500;

        bool upDown = false;
        bool downDown = false;
        bool wDown = false;
        bool sDown = false;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;

        string gameState = "waiting";

        SoundPlayer explosion = new SoundPlayer(Properties.Resources._522209__kutejnikov__explosion);
        SoundPlayer scorepoint = new SoundPlayer(Properties.Resources._535840__evretro__8_bit_mini_win_sound_effect);
        SoundPlayer win = new SoundPlayer(Properties.Resources._518305__mrthenoronha__stage_clear_8_bit);

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            #region game initialize 
            titleLabel.Text = "";
            subTitleLabel.Text = "";
            gameTimer.Enabled = true;
            gameState = "running";
            time = 5000;
            ballXList.Clear();
            ballYList.Clear();
            ballSpeedList.Clear();
            heroX = 200;
            heroY = 350;
            hero2X = 400;
            hero2Y = 350;
            hero1ScoreCounter = 0;
            hero2ScoreCounter = 0;
            #endregion
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region key down
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
            #endregion
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            #region keyup
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }
            #endregion
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region start/game over screen
            if (gameState == "waiting")
            {
                titleLabel.Text = "Space Race";
                subTitleLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                //update labels                
                //draw ground                
                //draw hero 
                e.Graphics.FillRectangle(whiteBrush, heroX, heroY, heroWidth, heroHeight);
                e.Graphics.FillRectangle(whiteBrush, hero2X, hero2Y, heroWidth, heroHeight);
                //draw balls 
                for (int i = 0; i < ballXList.Count(); i++)
                {
                    if (ballColourList[i] == "white")
                    {
                        e.Graphics.FillEllipse(whiteBrush, ballXList[i], ballYList[i], ballSize, ballSize);
                    }
                }
                for (int i = 0; i < rightBallXList.Count(); i++)
                {
                    if (ballColourList[i] == "white")
                    {
                        e.Graphics.FillEllipse(whiteBrush, rightBallXList[i], rightBallYList[i], ballSize, ballSize);
                    }
                }
            }
            else if (gameState == "over" && hero1ScoreCounter == 3)
            {
                titleLabel.Text = "GAME OVER";
                subTitleLabel.Text = $"Player 1 is the winner!";
                subTitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "over" && hero2ScoreCounter == 3)
            {
                titleLabel.Text = "GAME OVER";
                subTitleLabel.Text = $"Player 2 is the winner!";
                subTitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
            }
            #endregion
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region move hero
            //move hero 
            if (upDown == true && hero2Y > -10)
            {
                hero2Y -= heroSpeed;
            }

            if (downDown == true && hero2Y < this.Height - heroHeight)
            {
                hero2Y += heroSpeed;
            }
            if (wDown == true && heroY > -10)
            {
                heroY -= heroSpeed;
            }

            if (sDown == true && heroY < this.Height - heroHeight)
            {
                heroY += heroSpeed;
            }
            #endregion

            #region left side balls
            //check to see if a new ball should be created 
            randValue = randGen.Next(0, 50);

            if (randValue >= 45) 
            {
                ballXList.Add(0);
                ballYList.Add(randGen.Next(0, 300));
                ballSpeedList.Add(randGen.Next(2, 10));
                ballColourList.Add("white");
            }
            

            
            // move balls 
            for (int i = 0; i < ballYList.Count(); i++)
            {
                ballXList[i] += ballSpeedList[i];
            }
            

            
            //check if ball is below play area and remove it if it is 
            for (int i = 0; i < ballXList.Count(); i++)
            {
                if (ballXList[i] > 600)
                {
                    ballXList.RemoveAt(i);
                    ballYList.RemoveAt(i);
                    ballSpeedList.RemoveAt(i);
                    ballColourList.RemoveAt(i);
                    break;
                }
            }
            #endregion

            #region right side balls
            if (randValue >= 45)
            {
                rightBallXList.Add(600);
                rightBallYList.Add(randGen.Next(0, 300));
                rightBallSpeedList.Add(randGen.Next(2, 10));
                ballColourList.Add("white");
            }

            // move balls 
            for (int i = 0; i < rightBallYList.Count(); i++)
            {
                rightBallXList[i] -= rightBallSpeedList[i];
            }



            //check if ball is below play area and remove it if it is 
            for (int i = 0; i < rightBallXList.Count(); i++)
            {
                if (rightBallXList[i] < 0)
                {
                    rightBallXList.RemoveAt(i);
                    rightBallYList.RemoveAt(i);
                    rightBallSpeedList.RemoveAt(i);
                    ballColourList.RemoveAt(i);
                    break;
                }
            }
            #endregion

            #region left ball collision
            //check collision of ball and paddle 
            Rectangle heroRec = new Rectangle(heroX, heroY, heroWidth, heroHeight);
            Rectangle hero2Rec = new Rectangle(hero2X, hero2Y, heroWidth, heroHeight);

            for (int i = 0; i < ballXList.Count(); i++)
            {
                Rectangle ballRec = new Rectangle(ballXList[i], ballYList[i], 10, 10);

                if (heroRec.IntersectsWith(ballRec))
                {
                    heroY = 350;

                    ballXList.RemoveAt(i);
                    ballYList.RemoveAt(i);
                    ballSpeedList.RemoveAt(i);
                    ballColourList.RemoveAt(i);
                    explosion.Play();
                    break;
                }
                if (hero2Rec.IntersectsWith(ballRec))
                {
                    hero2Y = 350;

                    ballXList.RemoveAt(i);
                    ballYList.RemoveAt(i);
                    ballSpeedList.RemoveAt(i);
                    ballColourList.RemoveAt(i);
                    explosion.Play();
                    break;
                }
            }
            #endregion

            #region right ball collision
            for (int i = 0; i < rightBallXList.Count(); i++)
            {
                Rectangle rightBallRec = new Rectangle(rightBallXList[i], rightBallYList[i], 10, 10);

                if (heroRec.IntersectsWith(rightBallRec))
                {
                    heroY = 350;

                    rightBallXList.RemoveAt(i);
                    rightBallYList.RemoveAt(i);
                    rightBallSpeedList.RemoveAt(i);
                    ballColourList.RemoveAt(i);
                    explosion.Play();
                    break;
                }
                if (hero2Rec.IntersectsWith(rightBallRec))
                {
                    hero2Y = 350;

                    rightBallXList.RemoveAt(i);
                    rightBallYList.RemoveAt(i);
                    rightBallSpeedList.RemoveAt(i);
                    ballColourList.RemoveAt(i);
                    explosion.Play();
                    break;
                }
            }

            #endregion

            #region scoring
            if (gameState == "running")
            {
                if (heroY <= 0)
                {
                    hero1ScoreCounter++;
                    hero1ScoreLabel.Text = $"{hero1ScoreCounter}";
                    heroY = 350;
                    scorepoint.Play();
                }
                if (hero2Y <= 10)
                {
                    hero2ScoreCounter++;
                    hero2ScoreLabel.Text = $"{hero2ScoreCounter}";
                    hero2Y = 350;
                    scorepoint.Play();
                }
            }

            if (hero1ScoreCounter == 3)
            {
                gameTimer.Enabled = false;
                titleLabel.Text = $"player 1 Wins!";
                subTitleLabel.Text = $"press spacet to play again or escape to exit";
                win.Play();
                gameState = "over";
            }
            if (hero2ScoreCounter == 3)
            {
                gameTimer.Enabled = false;
                titleLabel.Text = $"player 2 Wins!";
                subTitleLabel.Text = $"press spacet to play again or escape to exit";
                win.Play();
                gameState = "over";
            }
            #endregion 

            Refresh();
        }
    }
}


