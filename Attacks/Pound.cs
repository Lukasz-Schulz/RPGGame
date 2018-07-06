namespace Gra
{
    public class Pound : Attack   //Concrete attack
    {
        public Pound(Character attacker) 
            : base(attacker)
        {
        }

        public override string AttackName => "Pound";

        public override string Message { get; protected set; } 

        public override void Proceed(Character Attacked)
        {
            Attacked.Health -= (Attacker.Att - Attacked.Def);
            Message = $"{Attacker.Name} pounded {Attacked.Name} " +
                       $"and dealed {Attacker.Att - Attacked.Def} hitpoints!\n";
        }
    }
}
