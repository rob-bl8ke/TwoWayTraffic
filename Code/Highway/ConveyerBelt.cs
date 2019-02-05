using System;
using System.Collections.Generic;
using System.Text;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public delegate void ServedHandler(object sender, EventArgs e);

    public class ConveyerBelt
    {
        // The purpose of the Conveyer belt is to generate an event so that the
        // receiver of the event will know that another item is starting its trip.

        public event ServedHandler Served;
        private int ticksAfterLastServe = 0;
        private Random random = new Random();

        private int waitTicks = 50;
        public int WaitTicks
        {
            get { return this.waitTicks; }
            set { this.waitTicks = value; }
        }

        private int offsetPixels;
        public int OffsetPixels
        {
            // Offset pixels is not currently used, but can be used to create a
            // better algorithm, if needed to randomly generate events.
            get { return this.offsetPixels; }
            set { this.offsetPixels = value; }
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
