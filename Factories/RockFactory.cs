using System.Collections.Generic;

namespace Gra
{
    public class RockFactory : AbstractLandscapeFatory //factory that creates concrete ILandscape objects
    {
        public RockFactory(List<ILandscapeObject> list, MainWindow mainWindow)
            : base(list, mainWindow) { }

        public override ILandscapeObject Create()
        {
                return new Rock(_List, _MainWindow);          
        }
    }
}
