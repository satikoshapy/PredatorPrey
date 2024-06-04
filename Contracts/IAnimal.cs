using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadybugGame.Contracts
{
    internal interface IAnimal :IDisplayable
    {

        Position Position { get; }
        bool IsDead { get; set; }

        //move 1 step any direction 
        public void Move();

        //reproduce, if succesful the newborn animal is returned, if fail null is returned
        public IAnimal TryBreed();
    }
}
