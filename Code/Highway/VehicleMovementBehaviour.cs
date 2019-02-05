using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class VehicleMovementBehaviour : IMovementBehaviour
    {
        // My purpose is to move a vehicle across a lane.

        #region IMovementBehaviour Members

        private Image screenImage;
        public Image ScreenImage
        {
            get { return this.screenImage; }
            set { this.screenImage = value; }
        }

        private int offsetPixels;
        public int OffsetPixels
        {
            get { return this.offsetPixels; }
            set { this.offsetPixels = value; }
        }

        private Rectangle area;
        public Rectangle Area
        {
            get { return this.area; }
            set { this.area = value; }
        }

        private Rectangle parentArea;
        public Rectangle ParentArea
        {
            get { return this.parentArea; }
            set { this.parentArea = value; }
        }

        private GameEntityDirectionEnum direction;
        public GameEntityDirectionEnum Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        public void Move()
        {
            int newXPosition = 0;
            Rectangle newArea = area;

            if (this.direction == GameEntityDirectionEnum.Right)
            {
                newXPosition = area.X + this.offsetPixels;
                newArea = new Rectangle(newXPosition, area.Y, area.Width, area.Height);

            }
            else if (this.direction == GameEntityDirectionEnum.Left)
            {
                newXPosition = area.X - this.offsetPixels;
                newArea = new Rectangle(newXPosition, area.Y, area.Width, area.Height);
            }
            area = newArea;
        }

        public void Start()
        {
            area.Width = screenImage.Width;
            area.Height = screenImage.Height;

            if (this.direction == GameEntityDirectionEnum.Right)
                area.X = this.parentArea.X - area.Width;

            else if (this.direction == GameEntityDirectionEnum.Left)
                area.X = this.parentArea.Width + area.Width;

            area.Y = middleOfLane();
        }

        #endregion

        private int middleOfLane()
        {
            return (parentArea.Top + (parentArea.Height / 2)) - (area.Height / 2);
        }
    }
}
