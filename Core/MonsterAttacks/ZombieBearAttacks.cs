using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.MonsterAttacks
{
    class DeadlyCrunch : MonsterAttack
    {
        public DeadlyCrunch() 
        {
            _name = "Deadly Crunch";
            _description = "Bear charges with a massive bite using with sharp canines";
            _maxDamage = 100;
        }
    }

    class Roar : MonsterAttack
    {
        public Roar()
        {
            _name = "Roar";
            _description = "The bear growls terrifyingly, frightening the weak minds";
            _maxDamage = 12;
        }
    }

    class ClawGash : MonsterAttack
    {
        public ClawGash()
        {
            _name = "Claw Gash";
            _description = "A violent scraping attack with bear's sharp claws";
            _maxDamage = 25;
        }
    }

    class PawAttack : MonsterAttack
    {
        public PawAttack()
        {
            _name = "Paw Attack";
            _description = "With the rest of flesh and bones left in his paw, " +
                "the bear use all his weigh to punch with it";
            _maxDamage = 36;
        }
    }
}
