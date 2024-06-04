using LadybugGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LadybugGame
{
    internal class AnimalWorld : IAnimalWorld
    {
        //private IList<IAnimal> AllAnimals { get; set; } = new List<IAnimal>();

        Random random = new Random();
        public int CurrentRoundNumber { get; private set; }

        public IList<IAnimal> AllAnimals { get; } = new List<IAnimal>();
        public Canvas _canvas;

        public void AddAnimal(IAnimal animal)
        {
            AllAnimals.Add(animal);
        }

        public void ProcessRound()
        {
            var removedAnimals = new List<IAnimal>();
            var newAnimals = new List<IAnimal>();
            foreach (IAnimal animal in AllAnimals)
            {
                if (animal is Aphid aphid)
                {
                    if (aphid.Age >= 6)
                    {
                        removedAnimals.Add(aphid);
                    }
                    else
                    {
                        aphid.Move();
                        if (CurrentRoundNumber % 2 == 0)
                        {
                            IAnimal newAnimal = aphid.TryBreed(); 
                            if (newAnimal != null)
                            {
                                newAnimals.Add(newAnimal);
                            }
                            
                        }
                    }
                    
                }
                
                
                else if (animal is LadyBug predator)
                {
                    if (predator.Age >= 16)
                    {
                        removedAnimals.Add(predator);
                    }
                    else
                    {
                        if (predator.Age >= 3)
                        {
                            int count = predator.HungerLevel.Count;
                            if (count >= 3 && !predator.HungerLevel[count - 1] && !predator.HungerLevel[count - 2] && !predator.HungerLevel[count - 3])
                            {
                                removedAnimals.Add(predator);
                                predator.IsDead = true;
                                predator.StopDisplaying();
                            }
                        }
                        predator.Move();
                        var possibleVictims = AllAnimals.Where(a => !a.IsDead && a is Aphid && IsWithinDistance(predator.Position, a.Position, 3)).ToList();
                        predator.Hunt(possibleVictims);
                        if (CurrentRoundNumber % 4 == 0)
                        {
                            IAnimal newAnimal = predator.TryBreed();
                            if (newAnimal != null)
                            {
                                newAnimals.Add(newAnimal);
                            }
                        }
                    }
                    
                }
                
            }
            foreach (var animal in removedAnimals)
            {
                AllAnimals.Remove(animal);
                animal.StopDisplaying();
            }

            foreach (var animal in newAnimals)
            {
                AllAnimals.Add(animal);
                animal.DisplayOn(_canvas);
            }
            CurrentRoundNumber++;
        }

        public AnimalWorld(Canvas canvas)
        {
            CurrentRoundNumber = 0;
            _canvas = canvas;
            
        }

        private bool IsWithinDistance(Position a, Position b, int distance)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)) <= distance;
        }

        
    }
}
