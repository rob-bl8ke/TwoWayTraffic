using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.Configuration
{
    public class HighwaySettings
    {
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
    }
}
