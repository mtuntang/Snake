using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classic_Snake
{
    

    public partial class Form1 : Form
    {
        private Snake _snake;
        private Circle _food = new Circle();

        private int _maxWidth;
        private int _maxHeight;
        private int _score;
        private int _highScore;
        private Settings _settings;

        private Random _rng = new Random();

        public Form1()
        {
            InitializeComponent();
            _snake = new Snake();
            _settings = new Settings();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void HighScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && _settings.CurrentDirection != Directions.Right)
            {
                _settings.CurrentDirection = Directions.Left;
            }
            if (e.KeyCode == Keys.Right && _settings.CurrentDirection != Directions.Left)
            {
                _settings.CurrentDirection = Directions.Right;
            }
            if (e.KeyCode == Keys.Up && _settings.CurrentDirection != Directions.Down)
            {
                _settings.CurrentDirection = Directions.Up;
            }
            if (e.KeyCode == Keys.Down && _settings.CurrentDirection != Directions.Up)
            {
                _settings.CurrentDirection = Directions.Down;
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;

            for (int i = 0; i < _snake.Body.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    _snake.Body[i].X * Settings.Width,
                    _snake.Body[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }


            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            _food.X * Settings.Width,
            _food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));
        }

        private void RestartGame()
        {
            _maxWidth = GameScreen.Width / Settings.Width - 1;
            _maxHeight = GameScreen.Height / Settings.Height - 1;

            StartButton.Enabled = false;
            CaptureButton.Enabled = false;
            _score = 0;
            ScoreLabel.Text = "Score: " + _score;

            Circle head = new Circle { X = 10, Y = 5 };
            _snake.AddHead(head);

            _food = new Circle { X = _rng.Next(2, _maxWidth), Y = _rng.Next(2, _maxHeight) };
            gameTimer.Start();
        }

        private void CheckFoodCollision()
        {
            Circle head = _snake.Body[0];
            if (head.X == _food.X && head.Y == _food.Y)
            {
                _snake.Grow();
                _food = new Circle() { X = _rng.Next(2, _maxWidth), Y = _rng.Next(2, _maxHeight) }; ;
                _score++;
            }
        }

        private void GameOver()
        {
            gameTimer.Stop();
            StartButton.Enabled = true;
            CaptureButton.Enabled = true;

            if (_score > _highScore)
            {
                _highScore = _score;

                HighScoreLabel.Text = "High Score: " + Environment.NewLine + _highScore;
                HighScoreLabel.ForeColor = Color.Maroon;
                HighScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void GameTimerTick(object sender, EventArgs e)
        {
            if (!_snake.UpdatePosition(_settings, _maxWidth, _maxHeight))
            {
                GameOver();
            }
            CheckFoodCollision();
            

            GameScreen.Invalidate();
        }
    }
}
