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
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle Food = new Circle();

        private int maxWidth;
        private int maxHeight;
        private int score;
        private int highScore;
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }

        Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
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

        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
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
    }
}
