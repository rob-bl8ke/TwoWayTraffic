using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.GameBaseEngine
{
    // Used for a collision event to pass the colliding object details to the
    // caller. Because different objects can collide with each other, but all
    // game objects derive from GameEntity and have a unique GUID. GameEntity 
    // is the parameter passed to the caller for versatility.

    public delegate void CollisionHandler(object sender, CollisionEventArgs e);

    public class CollisionEventArgs : EventArgs
    {
        public readonly GameEntity CollidingObject;

        public CollisionEventArgs(GameEntity collidingObject)
        {
            CollidingObject = collidingObject;
        }
    }
}
