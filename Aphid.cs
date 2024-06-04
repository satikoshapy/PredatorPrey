using LadybugGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LadybugGame
{
    internal class Aphid : Animal
    {
        public Ellipse ellipse;
        public Color Color { get; set; }
        public int Age { get; set; }
        public Aphid(int maxAge, Color color) 
            : base(maxAge, color)
        {
        }

        public Aphid(int maxAge, Color color, Position initialPosition) 
            : base(maxAge, color, initialPosition)
        {
            

        }

        public override IAnimal TryBreed()
        {
            if (!IsDead && Age >= 2)
            {
                return new Aphid(6, Colors.GreenYellow, this.Position);
            }

            return null;
        }
    }
}
