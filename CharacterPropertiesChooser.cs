using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class CharacterPropertiesChooser //a class with submethods for character factiories which allow them to generate random 
    {                                       //properties
        public CharacterPropertiesChooser(int level)
        {
            Level = level;
        }
        List<string> Names = new List<string> {"Bob","Joe","John","Lee","Bruce","George","George II","Hannah","Indiana"};

        #region properties

        /// <summary>
        ///  self generating properties//
        /// </summary>

        public int MaxHealth
        {
            get
            {
                Random rand = new Random();
                return Level * 10 + rand.Next(80,110);
            }
        }
        public int Attack
        {
            get
            {
                Random rand = new Random();
                return Level + rand.Next(5,8);
            }
        }
        public int Defence
        {
            get
            {
                Random rand = new Random();
                return Level + rand.Next(1, 4);
            }
        }

        public string GetName
        {
            get
            {
                Random rand = new Random();
                return Names[rand.Next(0, Names.Count - 1)];
            }
        }

        public int Level { get; } 
        #endregion properties
    }
}
