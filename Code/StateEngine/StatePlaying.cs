using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.GameBaseEngine;
using CygX1.TwoWay.Configuration;

namespace CygX1.TwoWay.StateEngine
{
    public class StatePlaying : IGameState
    {
        // Using the State Pattern to configure and react to different states.

        Engine engine;

        public StatePlaying(Engine engine)
        {
            this.engine = engine;
        }

        #region IGameState Members

        public void Move()
        {
            engine.GameRoad.Move();
        }

        public void Stop()
        {
            engine.GameRoad.Configure();
            engine.CurrentState = new StateReady(engine);
        }

        public void Start()
        {
            // Game does not currently react to this function in this state...
        }

        public void Pause()
        {
            engine.CurrentState = new StatePaused(engine);
        }

        public void Configure(GameSettings gameSettings, Rectangle gameScreen)
        {
            // Game does not currently react to this function in this state...
        }

        public void Draw(Graphics gameGraphics, Rectangle gameScreen)
        {
            engine.GameRoad.Draw(gameGraphics);
        }

        public void InstructGame(int keyValue)
        {
            engine.GameRoad.Instruct(keyValue);
        }

        #endregion

    }
}
