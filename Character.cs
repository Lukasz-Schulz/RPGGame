using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public abstract class Character //an abstract class defining a base for characters which appear on a board and are able
                                    //to interact with each other
    {
        public abstract Avatar CharacterAvatar { get; set; }

        public abstract string Name { get; protected set; }
        public abstract int MaxHealth { get; protected set; }
        public abstract int Health { get; set; }
        public abstract int Att { get; protected set; }
        public abstract int Def { get; protected set; }
        public abstract int Level { get; protected set; }

        public static MainWindow MainWindow { get; set; }

        public Character(string name, int maxHealth, int att, int def, int level, MainWindow mainWindow)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Att = att;
            Def = def;
            Level = level;
            MainWindow = mainWindow;
        }
        //attacks that can be used by the character during fight

        public abstract Attack AttackOne { get; }
        public abstract Attack AttackTwo { get; }
        public abstract Attack AttackThree { get; }
        public abstract Attack AttackFour { get; }

        protected static int RandomLocalisation()        //a method that generates random localisation for character's avatar
        {
            Random random = new Random();
            return random.Next(0, (int)(MainWindow.Board.Height / MainWindow.SIZE));
        }
    }
}
