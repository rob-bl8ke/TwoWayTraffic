using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class PedestrianMoveBehaviour : IMovementBehaviour
    {
        #region IMovementBehaviour Members

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

        private Image screenImage;
        public Image ScreenImage
        {
            get { return this.screenImage; }
            set { this.screenImage = value; }
        }

        private GameEntityDirectionEnum direction;
        public GameEntityDirectionEnum Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        public void Move()
        {
            switch (this.direction)
            {
                case GameEntityDirectionEnum.Down:
                    {
                        if ((this.area.Y + this.area.Height) >= parentArea.Height)
                            this.direction = GameEntityDirectionEnum.Stopped;
                        else
                            this.area.Y = this.area.Y + offsetPixels;
                        break;
                    }
                case GameEntityDirectionEnum.Left:
                    {
                        if (this.area.X <= 0)
                            this.direction = GameEntityDirectionEnum.Stopped;
                        else
                            this.area.X = this.area.X - offsetPixels; ;
                        break;
                    }
                case GameEntityDirectionEnum.Right:
                    {
                        if ((this.area.X + this.area.Width) >= parentArea.Width)
                            this.direction = GameEntityDirectionEnum.Stopped;
                        else
                            this.area.X = this.area.X + offsetPixels;
                        break;
                    }
                case GameEntityDirectionEnum.Up:
                    {
                        if (this.area.Y <= 0)
                            this.direction = GameEntityDirectionEnum.Stopped;
                        else
                            this.area.Y = this.area.Y - offsetPixels;
                        break;
                    }
            }
        }

        public void Start()
        {
            this.area.Height = this.screenImage.Height;
            this.area.Width = this.screenImage.Width;
            this.area.Y = (parentArea.Height - this.area.Height) - (this.area.Height / 2);
            this.area.X = (parentArea.Width / 2) - (this.area.Width / 2);
        }

        #endregion
    }
}
