namespace Gra
{
    public class HammerSlam : Attack   //Concrete attack
    {
        public HammerSlam(Character attacker) : base(attacker)
        {
        }

        public override string AttackName => "Hammer slam";

        public override string Message { get; protected set; }

        public override void Proceed(Character Attacked)
        {
            Attacked.Health -= Attacker.Att * 4 / 3;
            Message = ($"{Attacker.Name} used Hammer Slam and dealed {Attacker.Att * 4 / 3} dmg!\n");
        }
    }
}
