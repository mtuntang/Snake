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
        private List<Circle> Snake = new List<Circle>();
        private Circle Food = new Circle();

        private int _maxWidth;
        private int _maxHeight;
        private int _score;
        private int _highScore;
        private Settings _settings;

        public Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            _settings = new Settings();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

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
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _settings.CurrentDirection = Directions.Left;
                    break;
                case Keys.Right:
                    _settings.CurrentDirection = Directions.Right;
                    break;
                case Keys.Up:
                    _settings.CurrentDirection = Directions.Up;
                    break;
                case Keys.Down:
                    _settings.CurrentDirection = Directions.Down;
                    break;
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {

        }

        private void RestartGame()
        {

        }

        private void EatFood()
        {
   
        }

        private void GameOver()
        {

        }

        private void GameTimerTick(object sender, EventArgs e)
        {

        }
    }
}
