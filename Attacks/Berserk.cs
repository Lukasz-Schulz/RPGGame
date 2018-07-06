using System;

namespace Gra
{
    public class Berserk : Attack   //Concrete attack
    {
        public Berserk(Character attacker) : base(attacker)
        {
        }

        public override string AttackName => "Berserk";

        public override string Message { get; protected set; }

        public override void Proceed(Character Attacked)
        {
            Attacked.Health -= Attacker.Att * 3;
            Random rand = new Random();
            int i = rand.Next(0, 2);
            if (i < 1)
            {
                Attacker.Health -= Attacker.Att * 2;
                Message = ($"{Attacker.Name} used Berserk and dealed {Attacker.Att * 2} dmg!\n");
            }
            else
            {
                Attacker.Health -= Attacker.Att;
                Message = ($"{Attacker.Name} used Berserk and dealed {Attacker.Att} dmg!");
            }
        }
    }
}
