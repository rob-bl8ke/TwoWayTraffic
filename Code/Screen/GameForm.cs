using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CygX1.TwoWay.StateEngine;
using CygX1.TwoWay.Configuration;
using CygX1.TwoWay.GameBaseEngine;

namespace CygX1.TwoWay.UserInterface
{
    public partial class GameForm : Form
    {
        Engine engine = new Engine();

        public GameForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            allowAccess(engine.CurrentState);

            this.Text = "TWO-WAY TRAFFIC - [GAME READY]";

            engine.GamePaused += new GamePausedHandler(engine_GamePaused);
            engine.GamePlay += new GamePlayHandler(engine_GamePlay);
            engine.GameReady += new GameReadyHandler(engine_GameReady);
            engine.Collision += new GameCollisionHandler(engine_Collision);
            engine.MissionComplete += new GameMissionCompleteHandler(engine_MissionComplete);

            engine.Configure(getGameSettings(), this.ClientRectangle);
            allowAccess(engine.CurrentState);
        }

        private void engine_MissionComplete(object sender, EventArgs e)
        {
            engine.Pause();
            allowAccess(engine.CurrentState);

            MessageBox.Show(this, "You have made it, WELL DONE !!!", 
                "WINNER",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            engine.Stop();
            allowAccess(engine.CurrentState);
        }

        private void engine_Collision(object sender, EventArgs e)
        {
            MessageBox.Show(this, "You have collided, you're dead!",
                "LOSER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            engine.Stop();
            allowAccess(engine.CurrentState);
        }

        private void allowAccess(IGameState state)
        {
            if (state is StatePaused)
            {
                GameTimer.Enabled = false;
                PauseMenu.Enabled = false;
                StartMenu.Enabled = true;
                StopMenu.Enabled = false;
                ExitMenu.Enabled = true;
            }
            else if (state is StateReady)
            {
                GameTimer.Enabled = false;
                PauseMenu.Enabled = false;
                StartMenu.Enabled = true;
                StopMenu.Enabled = false;
                ExitMenu.Enabled = true;
            }
            else if (state is StatePlaying)
            {
                GameTimer.Interval = 5;
                GameTimer.Enabled = true;
                StartMenu.Enabled = false;
                PauseMenu.Enabled = true;
                StopMenu.Enabled = true;
                ExitMenu.Enabled = false;
            }
        }

        private void engine_GameReady(object sender, EventArgs e)
        {
            this.Text = "TWO-WAY TRAFFIC - [GAME READY]";
        }

        private void engine_GamePlay(object sender, EventArgs e)
        {
            this.Text = "TWO-WAY TRAFFIC - [GAME ON]";
        }

        private void engine_GamePaused(object sender, EventArgs e)
        {
            this.Text = "TWO-WAY TRAFFIC - [GAME PAUSED]";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            engine.Instruct(e.KeyValue);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rec = this.ClientRectangle;
            engine.Draw(e.Graphics, rec);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            engine.Move();
            this.Invalidate();
        }

        private void StartMenu_Click(object sender, EventArgs e)
        {
            engine.Start();
            allowAccess(engine.CurrentState);
        }

        private void PauseMenu_Click(object sender, EventArgs e)
        {
            engine.Pause();
            allowAccess(engine.CurrentState);
        }

        private void StopMenu_Click(object sender, EventArgs e)
        {
            engine.Stop();
            allowAccess(engine.CurrentState);
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private GameSettings getGameSettings()
        {
            // The game needs to be as configurable as possible. For this purpose we have
            // a configurations module see TwoWayConfig module.

            GameSettings gameSettings = new GameSettings();

            gameSettings.HighwayOptions.GameScreenArea = this.ClientRectangle;

            // Key options are configurable...
            gameSettings.KeyOptions.DownKey = (int)Keys.Down;
            gameSettings.KeyOptions.UpKey = (int)Keys.Up;
            gameSettings.KeyOptions.RightKey = (int)Keys.Right;
            gameSettings.KeyOptions.LeftKey = (int)Keys.Left;

            // Basic setting to display appearance of the game.
            gameSettings.HighwayOptions.BottomCurbWidth = 200;
            gameSettings.HighwayOptions.LaneSeperatorWidth = 1;
            gameSettings.HighwayOptions.LaneWidth = 50;

            // Instead of using a resource file for the moving entities, a decision is made
            // to use image files to improve configurability.
            gameSettings.HighwayOptions.LeftToRightVehicleImageFolder = @"Files\Images\left";
            gameSettings.HighwayOptions.RightToLeftVehicleImageFolder = @"Files\Images\right";
            gameSettings.PedestrianOptions.ImageFile = @"Files\Images\pedestrian\human.GIF";

            gameSettings.PedestrianOptions.OffsetPixels = 2;

            List<LaneSetting> lanes = new List<LaneSetting>();

            // Lanes are configurable for later versions
            // Can configure direction, speed, wait frames, and difficulty level.
            LaneSetting lane1 = new LaneSetting(GameEntityDirectionEnum.Left, 25, 50, 2);
            LaneSetting lane2 = new LaneSetting(GameEntityDirectionEnum.Right, 32, 50, 2);

            lanes.Add(lane1);
            lanes.Add(lane2);

            gameSettings.HighwayOptions.LaneCollection = lanes;

            return gameSettings;

        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreditsForm creditsForm = new CreditsForm();
            creditsForm.ShowDialog(this);
            this.Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
            this.Invalidate();
        }
    }
}

