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

namespace MarioPROJ
{
    public partial class Form1 : Form
    {
        private SoundPlayer _gameplay;
        //private SoundPlayer _gamecoin;
        bool goLeft, goRight, jumping;
        int seconds = 300;
        int jumpSpeed = 10;
        int force = 8;
        int points = 0;
        int score = 0;
        int flowerpoints = 0;
        int playerSpeed = 4;
        int backgroundSpeed = 12;

        public Form1()
        {
           InitializeComponent();
            _gameplay = new SoundPlayer(@"C:\Users\anant\Desktop\.NET\MarioPROJ\MarioPROJ\Resources\Audio_Gameplay.wav");
            //_gameplay.Play();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            txtTime.Text = seconds--.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtPoints.Text = "" + (score * 10) + flowerpoints;
            txtScore.Text ="x " + score;
            player.Top += jumpSpeed;

            if(goLeft == true && player.Left > 60)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left + (player.Width + 60) < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
            }

            if (goLeft == true && background.Left < 0)
            {
                background.Left += backgroundSpeed;
                MoveGameElements("forward");
            }
            if (goRight == true && background.Left > -1375)
            {
                background.Left -= backgroundSpeed;
                MoveGameElements("backward");
            }

            if(jumping == true)
            {
                jumpSpeed = -12;
                force -= 0;
            }
            else
            {
                jumpSpeed = 10;
            }

            if(jumping == true && force < 0)
            {
                jumping = false;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "platform")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        jumpSpeed = 0;
                    }
                    x.BringToFront();
                }

                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        //_gamecoin = new SoundPlayer(@"C:\Users\anant\Desktop\.NET\MarioPROJ\MarioPROJ\Resources\Audio_Coin.wav");
                        //_gamecoin.Play();
                        score += 1;
                    
                    }
                }

                if (x is PictureBox && (string)x.Tag == "flower")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                         flowerpoints += 50;

                    }
                }

                if (x is PictureBox && (string)x.Tag == "fire")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        GameTimer.Stop();
                        MessageBox.Show("You Died !" + Environment.NewLine + "Click OK to play again");
                        RestartGame();

                    }
                }
            }

            
            if (player.Bounds.IntersectsWith(door.Bounds))
            {
                GameTimer.Stop();
                FinishGame();
            }

            if(player.Top + player.Height > this.ClientSize.Height)
            {
                GameTimer.Stop();
                MessageBox.Show("You Died !" + Environment.NewLine + "Click OK to play again");
                RestartGame();
            }
        }
        
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            countdownTimer.Start();
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }
        }
        
        private void CloseGame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FinishGame()
        {
            End endWindow = new End(txtPoints.Text, txtScore.Text);
            this.Hide();
            endWindow.ShowDialog();
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {
            Start newWindow = new Start();
            this.Hide();
            newWindow.Show();
            
        }

        private void MoveGameElements(string direction)
        {
            foreach(Control  x in this.Controls)
                if(x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "door" || x is PictureBox && (string)x.Tag == "fire" || x is PictureBox && (string)x.Tag == "flower" || x is PictureBox && (string)x.Tag == "cloud")
                {
                    if(direction == "backward")
                    {
                        x.Left -= backgroundSpeed;
                    }
                    if(direction == "forward")
                    {
                        x.Left += backgroundSpeed;
                    }
                }
        }
    }
 }
