using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.GameBaseEngine
{
    // Implements the IPipeConveyerBelt interface. This class throws a random event
    // and ensures travelling game entities appear in a random fashion at intervals
    // but do not appear on top of each other. Implements the IPipeConveyerBelt
    // interface to allow the developer an option to swap to a better algorithm if 
    // required.

    public class DefaultConveyerBelt : IPipeConveyerBelt
    {
        private int ticksAfterLastServe = 0;
        private Random random = new Random();

        #region IPipeConveyerBelt Members

        public event ServedHandler Served;

        private int waitTicks = 50;
        public int WaitTicks
        {
            get { return this.waitTicks; }
            set { this.waitTicks = value; }
        }

        private int percentDifficulty;
        public int PercentDifficulty
        {
            get { return this.percentDifficulty; }
            set { this.percentDifficulty = value; }
        }

        public void Execute()
        {
            // Can be called on every new frame. After a certain number of frames
            // a new travelling object can be requested depending on the randomServe()
            // function.
            if (ticksAfterLastServe > waitTicks)
            {
                ticksAfterLastServe = 0;
                randomServe();
            }
            else
                ticksAfterLastServe++;
        }        

        #endregion

        private void randomServe()
        {
            // Randomly decide whether a new item will be generated. Event is
            // thrown and its up to the caller, in this case a Lane object, to
            // handle the request and generate a new vehicle.
            int randomNumber = random.Next(100);
            if ((randomNumber <= percentDifficulty) && (Served != null))
            {
                Served(this, new EventArgs());
            }
        }
    }
}
