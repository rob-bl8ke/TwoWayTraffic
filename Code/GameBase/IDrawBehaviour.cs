using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public interface IDrawBehaviour
    {
        // Any object that implements this interface can be used to draw a
        // GameEntity on the screen.
        void Draw(Graphics graphicsEngine, GameEntity gameEntity, Color color);
        void Draw(Graphics graphicsEngine, GameEntity gameEntity, Image image);
    }
}
