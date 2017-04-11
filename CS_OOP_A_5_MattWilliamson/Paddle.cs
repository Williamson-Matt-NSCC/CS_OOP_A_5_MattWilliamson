using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_A_5_MattWilliamson
{
    public class Paddle
    {
        //properties
        private readonly int paddleHeight = 10;
        private readonly int paddleWidth = 200;

        private Rectangle recPaddleCanvas;
        private Rectangle recGamePlayArea;

        //distance to move the paddle
        private readonly int moveInterval = 20;

        public enum Direction { Left, Right };
        public Rectangle DiplayArea
        {
            get { return recPaddleCanvas; }
        }

        public Paddle(Rectangle recGamePlayArea)
        {
            this.recGamePlayArea = recGamePlayArea;

            recPaddleCanvas.Height = paddleHeight;
            recPaddleCanvas.Width = paddleWidth;

            recPaddleCanvas.Y = 
                  recGamePlayArea.Bottom 
                - 50
                - (recPaddleCanvas.Height / 2);

            recPaddleCanvas.X = 
                      (recGamePlayArea.Width / 2) 
                    - (recPaddleCanvas.Width / 2);

        }

        //x y co-ords
        //private int xPaddlePos;
        //private int yPaddlePos;

        //move
        public void Move(Direction direction)
        {
            //paddle only moves left and right
            switch (direction)
            {
                case Direction.Left:
                    {
                        //check to make sure the paddle isnt at left bound
                        if ((recPaddleCanvas.X - moveInterval) > recGamePlayArea.Left)
                        {
                            recPaddleCanvas.X -= moveInterval;
                        }
                        else
                        {
                            recPaddleCanvas.X = recGamePlayArea.Left;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        //moveinterval is used here to 'forsee' if the paddle will go off the screen and correct it
                        if ((recPaddleCanvas.X + recPaddleCanvas.Width + moveInterval) < recGamePlayArea.Right)
                        {
                            recPaddleCanvas.X += moveInterval;
                        }
                        else
                        {
                            recPaddleCanvas.X = recGamePlayArea.Right - recPaddleCanvas.Width;
                        }
                        break;
                    }
            }


        }

        //draw
        public void Draw(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.Aqua);

            graphics.FillRectangle(brush, recPaddleCanvas);

        }
    }
}
