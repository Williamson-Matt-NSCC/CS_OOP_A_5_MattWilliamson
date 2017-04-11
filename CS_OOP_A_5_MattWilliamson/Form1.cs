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
        List<Block> blockArray;
        Graphics graphics;

        int numBlocks;

        int blockWidth;
        int blockHeight;

        int blockBumper;
        int topBumper;
        int numberOfRowsOfBlocks;

        bool gamelost;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            newGame();
        }

        private void newGame()
        {
            numBlocks = 12;
            blockWidth = 0;
            blockHeight = 50;
            blockBumper = 0;
            topBumper = 50;
            numberOfRowsOfBlocks = 3;
            gamelost = false;
            KeyPreview = true;

            //max window
            this.WindowState = FormWindowState.Maximized;

            paddle = new Paddle(this.DisplayRectangle);
            ball = new Ball(this.DisplayRectangle);
            blockArray = new List<Block>();
            setBlockSize(numBlocks);
            //generates an array with the specified number of blocks
            makeBlocks();
            timer1.Start();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            this.graphics = e.Graphics;
            
            paddle.Draw(e.Graphics);
            ball.Draw(e.Graphics);

            foreach (Block block in blockArray)
            {
                block.Draw(graphics, Color.Blue);
            }
            if (gamelost)
                GameOver(false);
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
            //added the balls velocity to prevent the ball from temporarily going through the wall
            if (ball.DiplayArea.Right <= 0 - ball.XVelocity || ball.DiplayArea.X >= this.DisplayRectangle.Right - ball.XVelocity)
            {
                ball.XVelocity *= -1;
            }
            if (ball.DiplayArea.Top <= 0)
            {
                ball.YVelocity *= -1;
            }
            else if (ball.DiplayArea.IntersectsWith(paddle.DiplayArea))
            {
                redirectBallFromPaddle();
                ball.YVelocity *= -1;
                //ball.Move();
            }
            else if (ball.DiplayArea.Bottom >= this.DisplayRectangle.Bottom)
            {
                //add checking for gameover
                gamelost = true;
            }
            redirectBallFromBlock();
        }


        private void redirectBallFromBlock()
        {
            foreach (Block block in blockArray)
            {
                if (ball.DiplayArea.IntersectsWith(block.DiplayArea))
                {
                    if (block.DiplayArea.Left < ball.DiplayArea.Left && ball.DiplayArea.Right < block.DiplayArea.Right)
                    {
                        ball.YVelocity *= -1;
                    } else
                    {
                        ball.XVelocity *= -1;
                    }

                    blockArray.Remove(block);
                    blockArray.TrimExcess();
                    break;
                }
            }
            if (blockArray.Count == 0)
            {
                GameOver(true);
            }
        }

        private void redirectBallFromPaddle()
        {
            int ballCenter = ball.DiplayArea.X + (ball.DiplayArea.Width / 2);
            int paddleCenter = paddle.DiplayArea.X + (paddle.DiplayArea.Width / 2);

            int ballPaddleDifference = (ballCenter - paddleCenter) / 10;
            
            ball.XVelocity += ballPaddleDifference;

            if (ball.XVelocity > 4)
                ball.XVelocity = 4;
            else if (ball.XVelocity < -4)
                ball.XVelocity = -4;
        }
        
        private void makeBlocks()
        {
            for (int j = 0; j < numberOfRowsOfBlocks; j++)
            {
                setBlockSize((numBlocks - (3 * j)));
                for (int i = 0; i < numBlocks; i++)
                {
                    int xValOfNewBlock = blockBumper / 2 + (i * (blockBumper + this.blockWidth));
                    int yValOfNewBlock = topBumper + ((topBumper *2) * j) + Block.BlockHeight;

                    blockArray.Add(new Block(this.DisplayRectangle, xValOfNewBlock, yValOfNewBlock, blockWidth, blockHeight));
                    //moved this to the draw method
                    //blockArray[i].Draw(graphics, Color.Blue);
                }
            }
            
        }

        private void setBlockSize(int numberOfBlocks)
        {
            int screenWidth = this.DisplayRectangle.Width;

            this.blockWidth = screenWidth / (numberOfBlocks + 1);

            //no idea why the +5 makes the spacing proper, but i'll take it
            this.blockBumper = (this.blockWidth / (numberOfBlocks - 1));
            //this.blockBumper = 0;
            

        }
        

        private void GameOver(bool Won)
        {
            timer1.Stop();

            if (gamelost)
            {
                lblWinLose.Text = "Game Over";
            }
            
            pnlWinLose.Left = (this.DisplayRectangle.Width / 2) - pnlWinLose.Width / 2;
            pnlWinLose.Top = this.DisplayRectangle.Height / 2;

            pnlWinLose.Visible = true;

        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            pnlWinLose.Visible = false;
            newGame();



        }
    }
}
