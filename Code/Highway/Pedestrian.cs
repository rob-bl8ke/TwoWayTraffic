using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class Pedestrian : GameEntity
    {
        private IDrawBehaviour pedestrianDrawBehaviour = new PedestrianDrawBehaviour();
        private IMovementBehaviour pedestrianMoveBehaviour = new PedestrianMoveBehaviour();

        private Image screenImage;
        private string imageFile;
        public string ImageFile
        {
            get { return this.imageFile; }
            set
            {
                this.imageFile = value;
                screenImage = createImageFromFile(value);

                Rectangle rect = new Rectangle();
                rect.X = 0;
                rect.Y = 0;
                rect.Width = screenImage.Width;
                rect.Height = screenImage.Height;
                this.SetPosition(rect);
                this.pedestrianMoveBehaviour.Area = this.GetRectangle();
                this.pedestrianMoveBehaviour.ScreenImage = screenImage;
            }
        }

        public int OffsetPixels
        {
            get { return this.pedestrianMoveBehaviour.OffsetPixels; }
            set { this.pedestrianMoveBehaviour.OffsetPixels = value; }
        }

        public GameEntityDirectionEnum Direction
        {
            get { return this.pedestrianMoveBehaviour.Direction; }
            set { this.pedestrianMoveBehaviour.Direction = value; }
        }

        public void Start()
        {
            this.pedestrianMoveBehaviour.ParentArea = this.ParentArea;
            this.pedestrianMoveBehaviour.Start();
            this.SetPosition(this.pedestrianMoveBehaviour.Area);
        }

        public void Move()
        {
            this.pedestrianMoveBehaviour.Move();
            this.pedestrianMoveBehaviour.ParentArea = this.ParentArea;
            this.SetPosition(this.pedestrianMoveBehaviour.Area);
        }

        private Image createImageFromFile(string imageFile)
        {
            Bitmap bmp = new Bitmap(imageFile);
            bmp.MakeTransparent(Color.White);
            return bmp;
        }

        public override void Draw(Graphics gameGraphics)
        {
            pedestrianDrawBehaviour.Draw(gameGraphics, this, pedestrianMoveBehaviour.ScreenImage);
        }
    }
}
