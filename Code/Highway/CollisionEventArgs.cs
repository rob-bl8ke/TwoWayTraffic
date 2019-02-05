using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.Highway
{
    public class CollisionEventArgs
    {
        public readonly Vehicle CollidingVehicle;

        public CollisionEventArgs(Vehicle collidingVehicle)
        {
            CollidingVehicle = collidingVehicle;
        }
    }
}
