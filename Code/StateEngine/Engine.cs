using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CygX1.TwoWay.Configuration;
using CygX1.TwoWay.GameBaseEngine;
using CygX1.TwoWay.Highway;

namespace CygX1.TwoWay.StateEngine
{
    public delegate void GameCollisionHandler(object sender, EventArgs e);
    public delegate void GameStoppedHandler(object sender, EventArgs e);
    public delegate void GamePausedHandler(object sender, EventArgs e);
    public delegate void GameReadyHandler(object sender, EventArgs e);
    public delegate void GamePlayHandler(object sender, EventArgs e);
    public delegate void GameMissionCompleteHandler(object sender, EventArgs e);

    public class Engine
    {
        // Using the State Pattern to configure and react to different states.
        // This class controls the TwoWayHighway game engine. All currently possible
        // states are contained within this class as states that implement the IGameState
        // interface. Allows us to add commands to each state if necessary, each state
        // determines how it react to these commands. New states can be added if the game
        // requires them.

        IGameState stateReady;
        IGameState statePaused;
        IGameState statePlaying;

        public event GamePausedHandler GamePaused;
        public event GameReadyHandler GameReady;
        public event GamePlayHandler GamePlay;
        public event GameCollisionHandler Collision;
        public event GameMissionCompleteHandler MissionComplete;

        private Road gameRoad = new Road();
        public Road GameRoad
        {
            get { return this.gameRoad; }
        }

        public Engine()
        {
            stateReady = new StateReady(this);
            statePaused = new StatePaused(this);
            statePlaying = new StatePlaying(this);
            currentState = stateReady;
            gameRoad.Collision += new CollisionHandler(gameRoad_Collision);
            gameRoad.ArrivedAlive += new Road.ArrivedAliveHandler(gameRoad_ArrivedAlive);
        }

        void gameRoad_ArrivedAlive(object sender, EventArgs e)
        {
            if (currentState is StatePlaying)
            {
                currentState.Pause();
                if (MissionComplete != null)
                    MissionComplete(this, new EventArgs());
            }
        }

        private void gameRoad_Collision(object sender, CollisionEventArgs e)
        {
            if (currentState is StatePlaying)
            {
                currentState.Pause();
                if (Collision != null)
                    Collision(this, new EventArgs());
            }
        }

        private IGameState currentState;
        public IGameState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }

        #region Public Methods

        public void Move()
        {
            currentState.Move();
        }

        public void Stop()
        {
            IGameState oldState = currentState;
            currentState.Stop();

            if ((currentState is StateReady) && !(oldState is StateReady) && (GameReady != null))
                GameReady(this, new EventArgs());
        }

        public void Start()
        {
            IGameState oldState = currentState;
            currentState.Start();

            if ((currentState is StatePlaying) && !(oldState is StatePlaying) && (GamePlay != null))
                GamePlay(this, new EventArgs());
        }

        public void Pause()
        {
            IGameState oldState = currentState;
            currentState.Pause();

            if ((currentState is StatePaused) && !(oldState is StatePaused) && (GamePaused != null))
                GamePaused(this, new EventArgs());
        }

        public void Configure(GameSettings gameSettings, Rectangle gameScreen)
        {
            currentState.Configure(gameSettings, gameScreen);

        }

        public void Draw(Graphics gameGraphics, Rectangle gameScreen)
        {
            currentState.Draw(gameGraphics, gameScreen);
        }

        public void Instruct(int keyValue)
        {
            currentState.InstructGame(keyValue);
        }

        #endregion
    }
}
