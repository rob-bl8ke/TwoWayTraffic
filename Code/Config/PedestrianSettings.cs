using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.Configuration
{
    public class PedestrianSettings
    {
        private string imageFile;
        public string ImageFile
        {
            get { return this.imageFile; }
            set { this.imageFile = value; }
        }

        private int offsetPixels;
        public int OffsetPixels
        {
            get { return this.offsetPixels; }
            set { this.offsetPixels = value; }
        }
    }
}
