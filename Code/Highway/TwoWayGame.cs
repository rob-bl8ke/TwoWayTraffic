using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.Highway
{
    public class TwoWayGame
    {
        private int noOfLives;
        private string pedestrianName;

        private List<LaneSetting> laneCollection;
        public List<LaneSetting> LaneCollection
        {
            get { return this.laneCollection; }
            set { this.laneCollection = value; }
        }

        private int laneWidth = 100;
        public int LaneWidth
        {
            get { return this.laneWidth; }
            set { this.laneWidth = value; }
        }

        private string leftToRightVehicleImageFolder;
        public string LeftToRightVehicleImageFolder
        {
            get { return this.leftToRightVehicleImageFolder; }
            set { this.leftToRightVehicleImageFolder = value; }
        }

        private string rightToLeftVehicleImageFolder;
        public string RightToLeftVehicleImageFolder
        {
            get { return this.rightToLeftVehicleImageFolder; }
            set { this.rightToLeftVehicleImageFolder = value; }
        }

        private int laneSeperatorWidth;
        public int LaneSeperatorWidth
        {
            get { return this.laneSeperatorWidth; }
            set { this.laneSeperatorWidth = value; }
        }

        private int bottomCurbWidth = 100;
        public int BottomCurbWidth
        {
            get { return this.bottomCurbWidth; }
            set { this.bottomCurbWidth = value; }
        }

        private Rectangle gameScreenArea;
        public Rectangle GameScreenArea
        {
            get { return this.gameScreenArea; }
            set { this.gameScreenArea = value; }
        }

        private int upKey;
        public int UpKey
        {
            get { return this.upKey; }
            set { this.upKey = value; }
        }

        private int downKey;
        public int DownKey
        {
            get { return this.downKey; }
            set { this.downKey = value; }
        }

        private int rightKey;
        public int RightKey
        {
            get { return this.rightKey; }
            set { this.rightKey = value; }
        }

        private int leftKey;
        public int LeftKey
        {
            get { return this.leftKey; }
            set { this.leftKey = value; }
        }

        public void Configure()
        {
        }

        public void StartNewGame()
        {
        }

        public void NextLife()
        {
        }

        public void StopGame()
        {
        }

        public void InstructPedestrian()
        {
        }

        public void DrawWorld(bool moveEntities)
        {
        }
    }
}
