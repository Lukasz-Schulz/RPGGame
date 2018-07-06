using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gra
{
    public class MainHero : Character                                       //hero's class
    {
        public MainHero(string name, int maxHealth, int att, int def, int level,MainWindow mainWindow) 
            : base(name, maxHealth, att, def, level, mainWindow)
        {
            CharacterAvatar = new Avatar(               //sets default avatar parameters
                22,
                20,
                DirectoryProvider.GetRelativeDirectory(@"C:\Users\LEN\source\repos\Gra\Gra\Graphics\HeroAvatar.jpg"),
                mainWindow);
        }

        public override Avatar CharacterAvatar { get; set; }

        public override string Name { get; protected set; }
        public override int MaxHealth { get; protected set; }
        public override int Health { get; set; }
        public override int Att { get; protected set; }
        public override int Def { get; protected set; }
        public override int Level { get; protected set; }
        private int Exp;
        
        public override Attack AttackOne => new Pound(this);

        public override Attack AttackTwo => new Heal(this);

        public override Attack AttackThree => new Berserk(this);

        public override Attack AttackFour => new HammerSlam(this);

        //handles gaining levels by hero
        public void GainExp(Character enemy)
        {
            Exp += (enemy.Att + enemy.Def) * enemy.Level;

            if(Exp >= Level * 30)
            {
                Level += 1;
                Exp = 0;
                Att += 1;
                Def += 1;
                MaxHealth += 10;
                MessageBox.Show($"{Name} have levelled up!");
            }
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}


