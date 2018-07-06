using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class AttackChooser//a class containing tools which choose one of characters attacks
    {                               
        public Attack ChooseAttack(Character attacker) //chooses attack randomly
        {
            Random rand = new Random();
            int i = rand.Next(0, 4);
            Attack attack;
            switch (i)
            {
                case 0:
                    attack = attacker.AttackOne;
                    break;
                case 1:
                    attack = attacker.AttackTwo;
                    break;
                case 2:
                    attack = attacker.AttackThree;
                    break;
                default:
                    attack = attacker.AttackFour;
                    break;
            }
            return attack;
        }

        public Attack ChooseAttack(Character attacker, int attackNumber) //chooses a specific attack by its number
        {
            int i = attackNumber;
            Attack attack;
            switch (i)
            {
                case 1:
                    attack = attacker.AttackOne;
                    break;
                case 2:
                    attack = attacker.AttackTwo;
                    break;
                case 3:
                    attack = attacker.AttackThree;
                    break;
                default:
                    attack = attacker.AttackFour;
                    break;
            }
            return attack;
        }
    }
}
