namespace Gra
{
    public abstract class Attack //abstract class being base for attack classes. It encapsulates attacks
    {
        public Attack(Character attacker)
        {
            Attacker = attacker;
        }
        public abstract string AttackName { get; } //attack name
        public abstract string Message { get; protected set; } // attack description
        
        public Character Attacker { get; }

        public abstract void Proceed(Character Attacked); //a method proceeding a command which is an attack
    }
}
