using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;
using CygX1.TwoWay.Configuration;

namespace CygX1.TwoWay.StateEngine
{
    public interface IGameState
    {
        void Move();
        void Stop();
        void Start();
        void Pause();
        void Configure(GameSettings gameSettings, Rectangle gameScreen);
        void Draw(Graphics gameGraphics, Rectangle gameScreen);
        
        // Here we're only taking one key code instruction, but we can overload
        // to handle more elaborate instructions.
        void InstructGame(int keyValue);
    }
}
