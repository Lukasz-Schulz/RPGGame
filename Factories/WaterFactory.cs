using System.Collections.Generic;

namespace Gra
{
    public class WaterFactory : AbstractLandscapeFatory //factory that creates concrete ILandscape objects
    {
        public WaterFactory(List<ILandscapeObject> list, MainWindow mainWindow)
            : base(list, mainWindow) { }

        public override ILandscapeObject Create()
        {
            return new Water(_List, _MainWindow);
        }
    }
}
