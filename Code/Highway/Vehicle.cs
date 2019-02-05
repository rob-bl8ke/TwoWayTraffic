using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class Vehicle : GameEntity
    {
        public delegate void EndOfLaneHandler(object sender, EventArgs e);
        public event EndOfLaneHandler EndOfLane;

        private IMovementBehaviour movementBehaviour = new VehicleMovementBehaviour();
        private IDrawBehaviour drawBehaviour = new VehicleDrawBehaviour();

        private bool completedTravel = false;
        public bool CompletedTravel
        {
            get { return this.completedTravel; }
            set { this.completedTravel = value; }

        }

        private int offsetPixels;
        public int OffsetPixels
        {
            get { return this.offsetPixels; }
            set { this.offsetPixels = value; }
        }

        private GameEntityDirectionEnum direction;
        public GameEntityDirectionEnum Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        private Image screenImage;
        public Image ScreenImage
        {
            get { return this.screenImage; }
            set { this.screenImage = value; }
        }

        public void Start()
        {
            // Ask the IMovementBehaviour object to start me on my journey.
            movementBehaviour.ScreenImage = this.screenImage;
            movementBehaviour.ParentArea = this.ParentArea;
            movementBehaviour.Direction = direction;
            movementBehaviour.OffsetPixels = offsetPixels;

            movementBehaviour.Start();
            this.SetPosition(movementBehaviour.Area);
        }

        public void Move()
        {
            // Ask the IMovementBehaviour object to move me, and throw
            // an event if I've ended my journey.
            movementBehaviour.Move();
            this.SetPosition(movementBehaviour.Area);

            if (endOfLane())
            {
                this.completedTravel = true;
                if (EndOfLane != null)
                    EndOfLane(this, new EventArgs());
            }
        }

        public override void Draw(Graphics gameGraphics)
        {
            drawBehaviour.Draw(gameGraphics, this, screenImage);
        }

        private bool endOfLane()
        {
            // How do we know if this vehicle has reached the end of the lane?
            // We use the IMovementBehaviour object, which knows about how this vehicle
            // is being moved.
            if ((this.movementBehaviour.Direction == GameEntityDirectionEnum.Right) &&
                (this.movementBehaviour.Area.X >= (this.movementBehaviour.ParentArea.Width +
                this.movementBehaviour.Area.Width)))
                return true;

            else if ((this.movementBehaviour.Direction == GameEntityDirectionEnum.Left) &&
                (this.movementBehaviour.Area.X <= (this.movementBehaviour.ParentArea.X -
                this.movementBehaviour.Area.Width)))
                return false;

            else
                return false;
        }
    }
}
