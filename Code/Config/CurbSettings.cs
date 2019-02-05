using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.Configuration
{
    public class CurbSettings
    {
        private int bottomCurbWidth = 100;
        public int BottomCurbWidth
        {
            get { return this.bottomCurbWidth; }
            set { this.bottomCurbWidth = value; }
        }
    }
}
