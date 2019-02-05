using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class Lane : GameEntity, IPipeLane
    {
        private bool configured = false;
        private Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();
        private IPipeConveyerBelt conveyerBelt = new DefaultConveyerBelt();

        private ImageFolderRandomizer randomizer = new ImageFolderRandomizer();

        public Lane()
        {
            base.DrawingBehaviour = new LaneDrawBehaviour();
            conveyerBelt.Served += new ServedHandler(conveyerBelt_Served);
        }

        private void conveyerBelt_Served(object sender, EventArgs e)
        {
            // Conveyer belt tells us that a new vehicle is coming through.
            Vehicle vehicle = new Vehicle();
            vehicle.OffsetPixels = offsetPixels;
            vehicle.ParentArea = this.GetRectangle();
            vehicle.ScreenImage = randomizer.Next();
            vehicle.Direction = this.direction;
            vehicle.Start();
            vehicles.Add(vehicle.ToString(), vehicle);
        }

        #region IPipeLane Members

        private int offsetPixels;
        public int OffsetPixels
        {
            get { return this.offsetPixels; }
            set { this.offsetPixels = value; }
        }

        private string rightTravellingObjectFolder;
        public string RightTravellingObjectFolder
        {
            get { return this.rightTravellingObjectFolder; }
            set { this.rightTravellingObjectFolder = value; }
        }

        private string leftTravellingObjectFolder;
        public string LeftTravellingObjectFolder
        {
            get { return this.leftTravellingObjectFolder; }
            set { this.leftTravellingObjectFolder = value; }
        }

        private GameEntityDirectionEnum direction;
        public GameEntityDirectionEnum Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        private int percentDifficulty;
        public int PercentDifficulty
        {
            get { return this.percentDifficulty; }
            set { this.percentDifficulty = value; }
        }

        public void Configure()
        {
            // Required because we need to know which direction vehicles are 
            // travelling in, and we need to set the conveyer belt settings.

            vehicles.Clear();

            this.DrawingBehaviour = new LaneDrawBehaviour();
            if (this.direction == GameEntityDirectionEnum.Left)
                randomizer.Folder = leftTravellingObjectFolder;
            else
                randomizer.Folder = rightTravellingObjectFolder;

            conveyerBelt.PercentDifficulty = this.percentDifficulty;
            conveyerBelt.WaitTicks = 50;

            configured = true;
        }

        public void Move()
        {
            if (configured)
            {
                // Move all vehicles on this lane. Destroy vehicles that
                // have finished their journey. Keep the conveyer belt rolling.
                foreach (KeyValuePair<string, Vehicle> vehicle in vehicles)
                    vehicle.Value.Move();

                killFinishedVehicles();
                conveyerBelt.Execute();
            }
        }

        #endregion

        // Overriding the Draw method of the base class.
        public override void Draw(Graphics gameGraphics)
        {
            if (configured)
            {
                // We delegate responsibility to the drawing object we've chosen.
                // Draw the lane and each car that is currently travelling.
                //this.DrawingBehaviour.Draw(gameGraphics, this, Color.Black);
                //foreach (KeyValuePair<string, Vehicle> vehicle in vehicles)
                //    vehicle.Value.Draw(gameGraphics);

                this.DrawingBehaviour.Draw(gameGraphics, this, Properties.Resources.road);
                foreach (KeyValuePair<string, Vehicle> vehicle in vehicles)
                    vehicle.Value.Draw(gameGraphics);

            }
        }


        private void killFinishedVehicles()
        {
            // We must ensure that the vehicles that have finished are destroyed
            // or our dictionary will just keep growing in size.
            int y = 0;
            List<string> finished = new List<string>();

            foreach (KeyValuePair<string, Vehicle> vehicle in vehicles)
            {
                if (vehicle.Value.CompletedTravel)
                {
                    y++;
                    finished.Add(vehicle.Key);
                }
            }

            foreach (string key in finished)
                vehicles.Remove(key);
        }


        public bool CollisionOccured(Rectangle pedestrianArea, out Vehicle collidingVehicle)
        {
            collidingVehicle = null;

            foreach (KeyValuePair<string, Vehicle> vehiclePair in vehicles)
            {
                if (vehiclePair.Value.GetRectangle().IntersectsWith(pedestrianArea))
                {
                    Console.WriteLine("Colliding vehicle count: " + vehicles.Count.ToString());
                    collidingVehicle = vehiclePair.Value;
                    return true;
                }
            }
            return false;
        }

    }
}
