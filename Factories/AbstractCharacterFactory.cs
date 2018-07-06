using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public abstract class AbstractCharacterFactory  //abstract factory to implement characters
    {
        public abstract CharacterPropertiesChooser PropertiesChooser { get; protected set; }    //allows access to tools that
                                                                                                //can set random properties
        public abstract Character Create(int level, MainWindow mainWindow);
    }
}
