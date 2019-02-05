using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class SideCurb : GameEntity
    {
        public SideCurb()
        {
            this.DrawingBehaviour = new CurbDrawBehaviour();
        }
        // SideCurb is a static GameEntity object that uses the IDrawBehaviour object
        // property of the GameEntity base class to delegate the responsibility of
        // drawing.
        public override void Draw(Graphics gameGraphics)
        {
            this.DrawingBehaviour.Draw(gameGraphics, this, Properties.Resources.grass);
        }
    }
}
