﻿/////////////////////////////////////////////////////
// Projekt LineRider  // Simon Müller              //
// ET2012a            // Hard- und Softwaretechnik //
// 28.01.2016         // V1.0.0                    //
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LineRider
{
    public class Player
    {
        /// <summary>
        /// Winkel des Spielers
        /// </summary>
        public double Angle;
        /// <summary>
        /// Geschwindigkeit des Spielers
        /// </summary>
        public double Speed;
        /// <summary>
        /// Grösse des Spielers
        /// </summary>
        private int Size;
        /// <summary>
        /// Kontakt des Spielers zu einer Linie
        /// </summary>
        public Line Contacted;
        /// <summary>
        /// Position des Spielers
        /// </summary>
        public PointF Position;
        /// <summary>
        /// Bild des Spielers
        /// </summary>
        public Bitmap Image;
        private Font Text_Font;
        private SolidBrush Text_Brush;

        public Player(PointF position, int size, Bitmap image)
        {
            Angle = 270;
            Speed = 0;
            Size = size;
            Contacted = null;
            Position = position;
            Image = image;
            Text_Font = new Font("Arial", 12f, FontStyle.Regular);
            Text_Brush = new SolidBrush(Color.Blue);
        }

        /// <summary>
        /// Zeichnen der Linie
        /// </summary>
        /// <param name="g">Graphikhandle</param>
        /// <param name="Offset">Fensteroffset</param>
        /// <param name="Origin">Koordinatennullpunkt</param>
        public void Draw(Graphics g, Point Offset, Point Origin)
        {
            // draw player image
            g.DrawImage(Image, (int)(Offset.X + (Origin.X + Position.X) - 0.5 * Size), (int)(Offset.Y - (Origin.Y + Position.Y) - 0.8 * Size), Size, Size);

            // check for drawing angles and acceleration
            string Details = "";
            if (Engine.SHOW_ANGLES)
            {
                Details += Angle.ToString() + "°\n";
            }
            if (Engine.SHOW_PLAYER_SPEED)
            {
                Details += Speed.ToString() + "\n";
            }

            // draw details
            if (Details != "")
            {
                g.DrawString(Details, Text_Font, Text_Brush, (int)(Offset.X + (Origin.X + Position.X) + 0.5 * Size), (int)(Offset.Y - (Origin.Y + Position.Y) - 0.5 * Size));
            }
        }
    }
}
