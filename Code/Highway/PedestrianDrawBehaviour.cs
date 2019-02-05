using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;


namespace CygX1.TwoWay.Highway
{
    public class PedestrianDrawBehaviour : IDrawBehaviour
    {
        #region IDrawBehaviour Members

        public void Draw(Graphics graphicsEngine, GameEntity gameEntity, Color color)
        {
            // We're not currently using this method but we can later if we want to.
        }

        public void Draw(Graphics graphicsEngine, GameEntity gameEntity, Image image)
        {
            // Currently we take the pedestrian image and draw it to its location.
            graphicsEngine.DrawImage(image, gameEntity.GetRectangle());
        }

        #endregion
    }
}
