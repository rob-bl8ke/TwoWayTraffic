using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public class PipelineTravellerConveyerBelt
    {
        //public delegate void ServedHandler(object sender, ConveyerBeltEventArgs e);
        //public event ServedHandler Served;

        //private int tickTock;
        //Random ran = new Random();

        //private PipelineTravellerImageRandomizer imageRandomizer;
        //public PipelineTravellerImageRandomizer ImageRandomizer
        //{
        //    get { return this.imageRandomizer; }
        //    set { this.imageRandomizer = value; }
        //}


        //public string Folder
        //{
        //    get { return this.imageRandomizer.Folder; }
        //    set
        //    {
        //        //imageRandomizer = new TravellerImageRandomizer();
        //        imageRandomizer.Folder = value;
        //    }
        //}

        //private int waitTicks = 50;
        //public int WaitTicks
        //{
        //    get { return this.waitTicks; }
        //    set { this.waitTicks = value; }
        //}

        //private int offsetPixels;
        //public int OffsetPixels
        //{
        //    get { return this.offsetPixels; }
        //    set { this.offsetPixels = value; }
        //}

        //private GameEntityDirectionEnum direction = GameEntityDirectionEnum.Right;
        //public GameEntityDirectionEnum Direction
        //{
        //    get { return this.direction; }
        //    set
        //    {
        //        //if (!Common.ValidTravellerDirection(value))
        //        //    throw new ApplicationException(ExceptionMessages.InvalidTravellerMovement);
        //        //else
        //        //    this.direction = value;
        //    }
        //}

        //private Rectangle pipeRectangle;
        //public Rectangle PipeRectangle
        //{
        //    get { return this.pipeRectangle; }
        //    set { this.pipeRectangle = value; }
        //}

        //private int percentDifficulty = 40;
        //public int PercentDifficulty
        //{
        //    get { return this.percentDifficulty; }
        //    set
        //    {
        //        //if (!validPercentage(value))
        //        //    throw new ApplicationException(ExceptionMessages.InvalidConveyerDifficultyRatio);
        //        //else
        //        //    this.percentDifficulty = value;
        //    }
        //}

        //public void RequestTraveller()
        //{
        //    if (imageRandomizer.Folder == "")
        //        throw new ApplicationException(ExceptionMessages.InvalidImageFolder);

        //    if (tickTock > waitTicks)
        //    {
        //        tickTock = 0;
        //        maybeServeTraveller();
        //    }
        //    else
        //        tickTock++;
        //}

        //private void maybeServeTraveller()
        //{
        //    int randomNumber = ran.Next(100);
        //    if ((randomNumber <= percentDifficulty) && (Served != null))
        //    {
        //        //Traveller traveller = startTraveller();
        //        //Served(this, new ConveyerBeltEventArgs(traveller));
        //    }
        //}

        //private bool validPercentage(int percentage)
        //{
        //    if ((percentage < 20) || (percentage > 80))
        //        return false;
        //    else
        //        return true;
        //}

        //private IPipelineTraveller startTraveller()
        //{
        //    //Image travellerFile = imageRandomizer.NextTraveller();
        //    //Traveller traveller = new Traveller(travellerFile, pipeRectangle, direction);
        //    //traveller.OffsetPixels = this.offsetPixels;
        //    //traveller.Start();
        //    //return traveller;
        //}
    }
}
