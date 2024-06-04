using LadybugGame.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;

namespace LadybugGame
{
    abstract class Animal : IAnimal
    {
        public Position Position { get; private set; }
        public int MaxAge { get; private set; }
        public int Age { get; private set; }
        public bool IsDead { get; set ; }

        private Ellipse ellipse;
        private static readonly Random random = new Random();

        protected Animal(int maxAge, Color color)
            : this(maxAge, color, new Position(random.Next(16), random.Next(16)))
        {
            
        }
        protected Animal(int maxAge, Color color, Position initialPosition)
        {
            Position = initialPosition;
            IsDead = false;
            Age = 0;
            MaxAge = maxAge;
            ellipse = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = new SolidColorBrush(color),
            };

        }
        public void DisplayOn(Canvas canvas)
        {
            
            canvas.Children.Add(ellipse);
            
            UpdateDisplay();
        }

        public void Move()
        {
            if (Age >= MaxAge)
            {
                IsDead = true;
                
            }
            int direction = random.Next(4); // Generate a random number between 0 and 3
            switch (direction)
            {
                case 0:
                    Position.MoveUp();
                    break;
                case 1:
                    Position.MoveDown();
                    break;
                case 2:
                    Position.MoveLeft();
                    break;
                case 3:
                    Position.MoveRight();
                    break;
            }
            Age += 1;
            UpdateDisplay();
        }

        public void StopDisplaying()
        {
            if (ellipse.Parent is Canvas canvas)
            {
                canvas.Children.Remove(ellipse);
            }
        }

        public abstract IAnimal TryBreed();

        public void UpdateDisplay()
        {
            Canvas.SetLeft(ellipse, Position.X * 10);
            Canvas.SetTop(ellipse, Position.Y * 10);
        }
    }
}
