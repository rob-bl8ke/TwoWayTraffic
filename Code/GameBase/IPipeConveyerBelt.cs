using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.GameBaseEngine
{
    // This object aids in the random display of GameEntities that are handled within
    // an IPipeLane implementing object.

    public delegate void ServedHandler(object sender, EventArgs e);

    public interface IPipeConveyerBelt
    {
        int WaitTicks { get;set;}
        int PercentDifficulty { get;set;}
        void Execute();
        event ServedHandler Served;
    }
}
