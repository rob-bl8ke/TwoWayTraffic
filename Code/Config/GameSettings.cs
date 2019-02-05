using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.Configuration
{
    public class GameSettings
    {
        private HighwaySettings highwayOptions = new HighwaySettings();
        public HighwaySettings HighwayOptions
        {
            get { return this.highwayOptions; }
            set { this.highwayOptions = value; }
        }

        private PedestrianSettings pedestrianOptions = new PedestrianSettings();
        public PedestrianSettings PedestrianOptions
        {
            get { return this.pedestrianOptions; }
            set { this.pedestrianOptions = value; }
        }

        private KeySetting keyOptions = new KeySetting();
        public KeySetting KeyOptions
        {
            get { return this.keyOptions; }
            set { this.keyOptions = value; }
        }
    }
}
