using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class VehicleDrawBehaviour : IDrawBehaviour
    {
        // I implement the IDrawBehaviour object and the vehicle that instantiates me
        // will delegate the drawing responsibility to me. I'm a custom built drawing
        // concrete behaviour.

        #region IDrawBehaviour Members

        public void Draw(Graphics graphicsEngine, GameEntity gameEntity, Color color)
        {
            // I don't implement this yet, but I can in the future.
            throw new Exception("The method or operation is not implemented.");
        }

        public void Draw(Graphics graphicsEngine, GameEntity gameEntity, Image image)
        {
            // Send me the image and the vehicle and I will draw it.
            graphicsEngine.DrawImage(image, gameEntity.GetRectangle());
        }

        #endregion
    }
}
