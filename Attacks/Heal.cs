namespace Gra
{
    public class Heal : Attack   //Concrete attack
    {
        public Heal(Character attacker) : base(attacker)
        {
        }

        public override string AttackName => "Heal";

        public override string Message { get; protected set; }

        public override void Proceed(Character Attacked)    //metoda wywołująca atak "Heal", który zwiększa ilość punktów życia
        {                                                   //o ilość wyliczoną na podstawie ilości punktów obrony
            int healingAmount = Attacker.Def * 3;

            if(healingAmount<=Attacker.MaxHealth - Attacker.Health)
            {
                Attacker.Health += healingAmount;
            }
            else
            {
                Attacker.Health = Attacker.MaxHealth;
            }

            Message = $"{Attacker.Name} healed " +
                       $"{Attacker.Def * 3} hitpoints!\n";
        }
    }
}
