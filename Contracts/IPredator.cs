using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadybugGame.Contracts
{
    internal interface IPredator:IAnimal
    {

        bool CanEat(IAnimal animal);
        void Hunt(IList<IAnimal> possibleVictims);
    }
}
