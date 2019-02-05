using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public class DefaultDrawBehaviour : IDrawBehaviour
    {
        // Game objects that derive from GameEntity have an IDrawBehaviour property
        // which allows them to delegate the responsibility of drawing themselves to
        // another object that implements the IDrawBehaviour interface.

        // However this is a default draw behaviour object that comes with the 
        // GameBase game engine, which can be used for drawing a default coloured
        // rectangle.

        #region IDrawBehaviour Members

        public void Draw(Graphics graphicsEngine, GameEntity gameEntity, Color color)
        {
            drawColoredRectangle(graphicsEngine, gameEntity, color);
        }

        public void Draw(Graphics graphicsEngine, GameEntity gameEntity, Image image)
        {
            drawColoredRectangle(graphicsEngine, gameEntity, Color.Red);
        }

        #endregion

        private void drawColoredRectangle(Graphics graphicsEngine, GameEntity gameEntity, Color color)
        {
            // Use the GDI+ pen and brush object to draw basic shapes and the Graphics
            // object gives you access to the UI's drawable area.

            Pen newPen = new Pen(color);
            SolidBrush newBrush = new SolidBrush(color);

            graphicsEngine.DrawRectangle(newPen, gameEntity.GetRectangle());
            graphicsEngine.FillRectangle(newBrush, gameEntity.GetRectangle());

            newPen.Dispose();
            newBrush.Dispose();
        }
    }
}


