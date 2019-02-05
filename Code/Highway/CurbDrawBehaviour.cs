using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.Highway
{
    public class CurbDrawBehaviour : IDrawBehaviour
    {
        #region IDrawBehaviour Members

        public void Draw(System.Drawing.Graphics graphicsEngine, GameEntity gameEntity, System.Drawing.Color color)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Draw(System.Drawing.Graphics graphicsEngine, GameEntity gameEntity, System.Drawing.Image image)
        {
            TextureBrush textureBrush = new TextureBrush(image);
            Pen blackPen = new Pen(Color.Black);
            textureBrush.WrapMode = WrapMode.TileFlipX;
            graphicsEngine.FillRectangle(textureBrush, gameEntity.GetRectangle());
            graphicsEngine.DrawRectangle(blackPen, gameEntity.GetRectangle());
            blackPen.Dispose();
            textureBrush.Dispose();
        }

        #endregion
    }
}
