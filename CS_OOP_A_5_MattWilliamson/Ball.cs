using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_A_5_MattWilliamson
{
    public class Ball
    {
        private readonly int ballHeight = 10;
        private readonly int ballWidth = 10;

        private Rectangle recGamePlayArea;
        private Rectangle recBallCanvas;

        public Rectangle DiplayArea
        {
            get { return recBallCanvas; }
        }

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }


        public Ball(Rectangle recGamePlayArea)
        {
            this.recGamePlayArea = recGamePlayArea;

            recBallCanvas.Width = ballWidth;
            recBallCanvas.Height = ballHeight;

            Random random = new Random();
            
            XVelocity = random.Next(-4, 4);
            //YVelocity = random.Next(-4, 4);

            //XVelocity = -5;
            YVelocity = -4;

            //start ball in centre of screen
            recBallCanvas.X = recGamePlayArea.Width / 2;
            recBallCanvas.Y = recGamePlayArea.Height - 150;


        }



        public void Move()
        {
            //detect if ball hits paddle
            //if ((recBallCanvas.Y + recBallCanvas.Height + YVelocity) == ball)
            recBallCanvas.X += XVelocity;
            recBallCanvas.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.BurlyWood);
            graphics.FillEllipse(brush, recBallCanvas);
        }
    }
}
