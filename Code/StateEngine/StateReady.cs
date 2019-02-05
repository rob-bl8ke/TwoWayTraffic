using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.Highway;
using CygX1.TwoWay.GameBaseEngine;
using CygX1.TwoWay.Configuration;

namespace CygX1.TwoWay.StateEngine
{
    public class StateReady : IGameState
    {
        // Using the State Pattern to configure and react to different states.

        Engine engine;

        public StateReady(Engine engine)
        {
            this.engine = engine;
        }

        #region IGameState Members

        public void Move()
        {
            // Game does not currently react to this function in this state...
        }

        public void Stop()
        {
            // Game does not currently react to this function in this state...
        }

        public void Start()
        {
            engine.CurrentState = new StatePlaying(engine);
        }

        public void Pause()
        {
            // Game does not currently react to this function in this state...
        }

        public void Configure(GameSettings gameSettings, Rectangle gameScreen)
        {
            engine.GameRoad.ParentArea = gameScreen;
            engine.GameRoad.Configuration = gameSettings;
            engine.GameRoad.Configure();
        }

        public void Draw(Graphics gameGraphics, Rectangle gameScreen)
        {
            engine.GameRoad.ParentArea = gameScreen;
            engine.GameRoad.Draw(gameGraphics);
        }

        public void InstructGame(int keyValue)
        {
            // Game does not currently react to this function in this state...
        }

        #endregion
    }
}
