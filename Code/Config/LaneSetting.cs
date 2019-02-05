using System;
using System.Collections.Generic;
using System.Text;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Configuration
{
    public class LaneSetting
    {

        public LaneSetting()
        {
        }

        public LaneSetting(GameEntityDirectionEnum direction, int percentDifficulty, int waitFrameCount, int offsetPixels)
        {
            this.percentDifficulty = percentDifficulty;
            this.direction = direction;
            this.offsetPixels = offsetPixels;
            this.waitFrameCount = waitFrameCount;
        }
        private int percentDifficulty;
        public int PercentDifficulty
        {
            get { return this.percentDifficulty; }
            set { this.percentDifficulty = value; }
        }

        private GameEntityDirectionEnum direction;
        public GameEntityDirectionEnum Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        private int waitFrameCount;
        public int WaitFrameCount
        {
            get { return this.waitFrameCount; }
            set { this.waitFrameCount = value; }
        }

        private int offsetPixels;
        public int OffsetPixels
        {
            get { return this.offsetPixels; }
            set { this.offsetPixels = value; }
        }
    }
}

