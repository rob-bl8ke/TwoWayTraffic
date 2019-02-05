using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using CygX1.TwoWay.GameBaseEngine;
using CygX1.TwoWay.Configuration;

namespace CygX1.TwoWay.Highway
{
    public class Road : GameEntity
    {
        public delegate void ArrivedAliveHandler(object sender, EventArgs e);
        public event CollisionHandler Collision;
        public event ArrivedAliveHandler ArrivedAlive;

        SideCurb bottomCurb = null;
        SideCurb topCurb = null;
        private List<Lane> lanes = new List<Lane>();
        private Pedestrian pedestrian = new Pedestrian();

        private GameSettings configuration;
        public GameSettings Configuration
        {
            get { return this.configuration; }
            set { this.configuration = value; }
        }

        public void Configure()
        {
            int currentYPosition = 0;
            this.lanes.Clear();
            this.ParentArea = configuration.HighwayOptions.GameScreenArea;
            this.SetPosition(configuration.HighwayOptions.GameScreenArea);

            List<LaneSetting> laneSettings = configuration.HighwayOptions.LaneCollection;

            bottomCurb = createBottomCurb(currentYPosition, out currentYPosition);

            foreach (LaneSetting laneSetting in laneSettings)
            {
                int yPositionAfter;
                int yPositionBefore = currentYPosition;

                Lane lane = createLane(laneSetting, yPositionBefore, out yPositionAfter);
                currentYPosition = yPositionAfter;

                lanes.Add(lane);
            }

            topCurb = createTopCurb(currentYPosition);

            createPedestrian();
        }

        public void Instruct(int keyValue)
        {
            if (keyValue == configuration.KeyOptions.UpKey)
                pedestrian.Direction = GameEntityDirectionEnum.Up;

            else if (keyValue == configuration.KeyOptions.DownKey)
                pedestrian.Direction = GameEntityDirectionEnum.Down;

            else if (keyValue == configuration.KeyOptions.RightKey)
                pedestrian.Direction = GameEntityDirectionEnum.Right;

            else if (keyValue == configuration.KeyOptions.LeftKey)
                pedestrian.Direction = GameEntityDirectionEnum.Left;
        }

        public void Move()
        {
            foreach (Lane lane in lanes)
                lane.Move();
            pedestrian.Move();
        }

        public override void Draw(Graphics gameGraphics)
        {
            bottomCurb.Draw(gameGraphics);

            foreach (Lane lane in lanes)
                lane.Draw(gameGraphics);

            topCurb.Draw(gameGraphics);
            pedestrian.Draw(gameGraphics);

            checkForCollisions();
            checkForArriveAlive();
        }

        #region Private Functions

        private Lane createLane(LaneSetting laneSetting, int yBefore, out int yAfter)
        {
            // Create the drawing area rectangle for this lane.
            // We'll draw from the bottom up
            Rectangle laneArea = new Rectangle();
            laneArea.X = 0;
            laneArea.Y = yBefore;
            laneArea.Height = configuration.HighwayOptions.LaneWidth;
            laneArea.Width = this.ParentArea.Width;

            // Create a new vehicle lane.
            Lane lane = new Lane();
            lane.DrawingBehaviour = new DefaultDrawBehaviour();
            lane.Direction = laneSetting.Direction;
            lane.PercentDifficulty = laneSetting.PercentDifficulty;
            lane.OffsetPixels = laneSetting.OffsetPixels;
            lane.LeftTravellingObjectFolder =
                configuration.HighwayOptions.LeftToRightVehicleImageFolder;
            lane.RightTravellingObjectFolder =
                configuration.HighwayOptions.RightToLeftVehicleImageFolder;
            lane.SetPosition(laneArea);
            lane.Configure();

            // Record the next drawing position.
            yAfter = yBefore - 
                (laneArea.Height + (configuration.HighwayOptions.LaneSeperatorWidth + 1));
            return lane;
        }

        private SideCurb createBottomCurb(int yBefore, out int yAfter)
        {
            int yCoord = yBefore;
            yCoord = this.ParentArea.Height - configuration.HighwayOptions.BottomCurbWidth;
           
            // Get the area for the curb to draw.
            Rectangle area = new Rectangle();
            area.X = 0;
            area.Y = yCoord;
            area.Width = this.ParentArea.Width;
            area.Height = configuration.HighwayOptions.BottomCurbWidth;

            // Create the curb.
            SideCurb curb = new SideCurb();
            curb.SetPosition(area);

            // Record the next drawing position.
            yAfter = yCoord - configuration.HighwayOptions.LaneWidth;
            return curb;
        }

        private SideCurb createTopCurb(int yBefore)
        {
            int yCoord = yBefore;

            Rectangle area = new Rectangle();
            area.X = 0;
            area.Y = 0;
            area.Width = this.ParentArea.Width;
            area.Height = yCoord + configuration.HighwayOptions.LaneWidth + 1;

            SideCurb curb = new SideCurb();
            curb.SetPosition(area);
            return curb;
        }

        private void createPedestrian()
        {
            pedestrian.Direction = GameEntityDirectionEnum.Stopped;
            pedestrian.DrawingBehaviour = new PedestrianDrawBehaviour();
            pedestrian.ImageFile = configuration.PedestrianOptions.ImageFile;
            pedestrian.OffsetPixels = configuration.PedestrianOptions.OffsetPixels;
            pedestrian.ParentArea = this.ParentArea;
            pedestrian.Start();
        }

        private void checkForCollisions()
        {
            foreach (Lane lane in lanes)
            {
                Vehicle collidingVehicle;

                Rectangle rec = pedestrian.GetRectangle();
                if (lane.CollisionOccured(pedestrian.GetRectangle(), out collidingVehicle))
                {
                    if (Collision != null)
                    {
                        Collision(this, new CollisionEventArgs(collidingVehicle));
                        break;
                    }
                }
            }
        }

        private void checkForArriveAlive()
        {
            Rectangle curb = topCurb.GetRectangle();
            Rectangle pedestrianRectangle = pedestrian.GetRectangle();
            if ((pedestrianRectangle.Y + pedestrianRectangle.Height) < (curb.Y + curb.Height))
            {
                if (ArrivedAlive != null)
                    ArrivedAlive(this, new EventArgs());
            }
        }

        #endregion
    }
}
