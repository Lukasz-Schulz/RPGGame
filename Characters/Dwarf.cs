using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    class Dwarf : Character     // one of the enemy classes
    {
        public Dwarf(string name, int maxHealth, int att, int def, int level, MainWindow mainWindow) 
            : base(name, maxHealth, att, def, level, mainWindow)
        {
        }

        public override string Name { get; protected set; }
        public override int MaxHealth { get; protected set; }
        public override int Health { get; set; }
        public override int Att { get; protected set; }
        public override int Def { get; protected set; }
        public override int Level { get; protected set; }

        //overriden attacks which are implemented as specific attacks

        public override Attack AttackOne => new Pound(this);

        public override Attack AttackTwo => new HammerSlam(this);

        public override Attack AttackThree => new Berserk(this);

        public override Attack AttackFour => new Slam(this);

        //overriden Avatar with its image set 

        public override Avatar CharacterAvatar { get; set; } = new Avatar(RandomLocalisation(),RandomLocalisation(), 
                                            @"C:\Users\LEN\source\repos\Gra\Gra\Graphics\EnemyAvatar.jpg", MainWindow);
        
    }
}
