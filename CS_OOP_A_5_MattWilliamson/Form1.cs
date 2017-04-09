using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_OOP_A_5_MattWilliamson
{
    public partial class GameForm : Form
    {
        Paddle paddle;
        Ball ball;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //max window
            this.WindowState = FormWindowState.Maximized;

            paddle = new Paddle(this.DisplayRectangle);
            ball = new Ball(this.DisplayRectangle);

        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            paddle.Draw(e.Graphics);
            ball.Draw(e.Graphics);
            
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        //move left
                        paddle.Move(Paddle.Direction.Left);
                        break;
                    }
                case Keys.Right:
                    {
                        //move right
                        paddle.Move(Paddle.Direction.Right);
                        break;
                    }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckCollisions();
            ball.Move();
            Invalidate();
        }

        private void CheckCollisions()
        {
            //wall
            if (ball.DiplayArea.Right <= 0 || ball.DiplayArea.X >= this.DisplayRectangle.Right)
            {
                ball.XVelocity *= -1;
            }
            //top and paddle 
            if (ball.DiplayArea.Top <= 0 || ball.DiplayArea.IntersectsWith(paddle.DiplayArea))
            {
                ball.YVelocity *= -1;
            }
            else if (ball.DiplayArea.Bottom >= this.DisplayRectangle.Bottom)
            {
                //add checking for gameover
                GameOver();
            }
        }

        private void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}
