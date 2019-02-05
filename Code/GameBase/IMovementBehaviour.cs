using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public interface IMovementBehaviour
    {
        // Allows you to delegate the movement behaviour out to an object that
        // implements this interface. A GameEntity object does not need to know
        // how it moves, however, the object that it delegates to ie. the object
        // that implements this interface is responsible for movement.

        int OffsetPixels { get; set;}
        Rectangle Area { get; set; }
        Rectangle ParentArea { get; set;}
        Image ScreenImage { get; set; }
        GameEntityDirectionEnum Direction { get; set;}
        void Move();
        void Start();
    }
}
