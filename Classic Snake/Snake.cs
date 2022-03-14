using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic_Snake
{
    class Snake
    {
        public List<Circle> Body;

        public Snake()
        {
            Body = new List<Circle>();
        }

        public void Clear()
        {
            Body.Clear();
        }

        public bool UpdatePosition(Settings settings, int maxWidth, int maxHeight)
        {
            // Tail follows the circle infront
            for (int i = Body.Count - 1; i >= 0; i--)
            {
                // If circle is the head, update body based on current direction and then check boundaries
                if (i == 0)
                {
                    UpdateBody(Body[i], settings);
                    CheckBoundaries(Body[i], settings, maxWidth, maxHeight);
                    if (CheckSuicide())
                    {
                        return false;
                    }
                }
                else
                { 
                    // Circle follows the circle infront
                    Body[i].X = Body[i - 1].X;
                    Body[i].Y = Body[i - 1].Y;
                }
            }
            return true;
        }

        public void Grow()
        {
            Circle tail = new Circle
            {
                X = Body[Body.Count - 1].X,
                Y = Body[Body.Count - 1].Y
            };
            Body.Add(tail);
        }

        private void UpdateBody(Circle circle, Settings settings)
        {
            switch (settings.CurrentDirection)
            {
                case Directions.Left:
                    circle.X--;
                    break;
                case Directions.Right:
                    circle.X++;
                    break;
                case Directions.Down:
                    circle.Y++;
                    break;
                case Directions.Up:
                    circle.Y--;
                    break;
            }
        }

        private void CheckBoundaries(Circle circle, Settings settings, int maxWidth, int maxHeight)
        {
            if (circle.X < 0)
            {
                circle.X = maxWidth;
            }
            if (circle.X > maxWidth)
            {
                circle.X = 0;
            }
            if (circle.Y < 0)
            {
                circle.Y = maxHeight;
            }
            if (circle.Y > maxHeight)
            {
                circle.Y = 0;
            }
        }

        private bool CheckSuicide()
        {
            // Check if head (body[0]) collides with anything else
            // TODO: this is pretty bad using a double for loop but its the easiest to implement for now :b. Maybe store and update all the coordinates of every circle?
            for (int i = 1; i < Body.Count; i++)
            {
                if (Body[0].X == Body[i].X && Body[0].Y == Body[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddHead(Circle head)
        {
            Body.Add(head);
        }

        public Circle GetHead()
        {
            return Body[0];
        }
    }
}
