using LadybugGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LadybugGame
{
    internal class LadyBug : Animal, IPredator
    {
        public Color Color { get; set; }
        public LadyBug(int maxAge, Color color) : base(16, Colors.Red)
        {
            Color = color;
        }

        public List<bool> HungerLevel { get; set; } = new List<bool>();
        public bool IsNotHungry { get; set; } = true;

        public LadyBug(int maxAge, Color color, Position initialPosition) : base(maxAge, color, initialPosition)
        {
        }

        public bool CanEat(IAnimal animal)
        {
            return animal.GetType() == typeof(IPredator) ? false : true;
        }

        public void Hunt(IList<IAnimal> possibleVictims)
        {
            IsNotHungry = false;

            foreach(IAnimal animal in possibleVictims)
            {
                if (animal != null)
                {
                    if (CanEat(animal))
                    {
                        animal.IsDead = true;
                        animal.StopDisplaying();
                        IsNotHungry = true;
                    }
                }
                
            }

            HungerLevel.Add(IsNotHungry);
        }

        public override IAnimal TryBreed()
        {
            if (!IsDead && Age >= 2)
            {
                return new LadyBug(16, Colors.Red, this.Position);
            }

            return null;
        }
    }
}
