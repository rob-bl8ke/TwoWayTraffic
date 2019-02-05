using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public abstract class GameEntity
    {
        // Most objects on your screen will derive from GameEntity. This
        // class knows its position on the screen, has a unique identifier
        // to identify it if necessary. Also note that the DrawingBehaviour
        // allows this class to use another class that implements the
        // IDrawBehaviour interface to draw it on the screen.

        Guid uniqueIdentifier = Guid.NewGuid();
        private Rectangle rectangle;

        private Rectangle parentArea;
        public Rectangle ParentArea
        {
            get { return this.parentArea; }
            set { this.parentArea = value; }
        }

        private IDrawBehaviour drawingBehaviour = new DefaultDrawBehaviour();
        public IDrawBehaviour DrawingBehaviour
        {
            get { return this.drawingBehaviour; }
            set { this.drawingBehaviour = value; }
        }

        public Rectangle GetRectangle()
        {
            return this.rectangle;
        }

        public void SetPosition(Rectangle newPosition)
        {
            this.rectangle = newPosition;
        }

        public virtual void Draw(Graphics gameGraphics)
        {
            drawingBehaviour.Draw(gameGraphics, this, Color.Red);
        }

        public override string ToString()
        {
            // Who am I?
            return this.uniqueIdentifier.ToString();
        }
    }
}
