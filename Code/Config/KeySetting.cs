using System;

namespace CygX1.TwoWay.Configuration
{
    public class KeySetting
    {
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
    }
}
