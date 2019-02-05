using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public interface IPipeLane
    {
        // A travelling medium for GameEntity objects to move within.

        int OffsetPixels { get; set;}
        string RightTravellingObjectFolder { get; set;}
        string LeftTravellingObjectFolder { get; set;}
        GameEntityDirectionEnum Direction { get; set;}
        void Configure();
        void Move();
    }
}