using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_A_5_MattWilliamson
{
    class Block
    {
        //properties
        public static int BlockHeight = 100;
        public static int BlockWidth = 250;

        private Rectangle recGamePlayArea;
        private Rectangle recBlockCanvas;

        public Rectangle DiplayArea
        {
            get { return recBlockCanvas; }
        }

        public Block(Rectangle recGamePlayArea, int xPlacement, int yPlacement, int width, int height)
        {
            this.recGamePlayArea = recGamePlayArea;

            recBlockCanvas.Width = width;
            recBlockCanvas.Height = height;

            recBlockCanvas.Y = yPlacement;
            recBlockCanvas.X = xPlacement;
        }

        //draw
        public void Draw(Graphics graphics, Color color)
        {
            SolidBrush brush = new SolidBrush(color);

            graphics.FillRectangle(brush, recBlockCanvas);

        }
    }
}
