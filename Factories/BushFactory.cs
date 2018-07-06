using System.Collections.Generic;

namespace Gra
{
    public class BushFactory : AbstractLandscapeFatory //factory that creates concrete ILandscape objects
    {
        public BushFactory(List<ILandscapeObject> list, MainWindow mainWindow) 
            : base(list, mainWindow) { }

        public override ILandscapeObject Create()
        {
            return new Bush(_List, _MainWindow);
        }
    }
}
