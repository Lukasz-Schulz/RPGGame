using System;

namespace Gra
{
    public class Slam : Attack   //Concrete attack
    {
        public Slam(Character attacker) : base(attacker)
        {
        } 

        public override string AttackName => "Slam";

        public override string Message { get; protected set; }

        public override void Proceed(Character Attacked)
        {
            Random rand = new Random();
            int i = rand.Next(0, 2);
            int superAtak = 2 * Attacker.Att - Attacked.Def;
            if (i > 0)
            {
                Attacked.Health -= superAtak;
                Message = $"{Attacker.Name} Slammed {Attacked.Name} " +
                       $"and dealed {superAtak} hitpoints!\n";
            }
            else { Message = $"{Attacker.Name} missed.\n"; }
        }
    }
}
