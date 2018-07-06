using System.Collections.Generic;

namespace Gra
{
    public abstract class AbstractLandscapeFatory //abstract factory for creating landscape objects
    {
        public List<ILandscapeObject> _List { get; }
        public MainWindow _MainWindow { get; }

        public AbstractLandscapeFatory(List<ILandscapeObject> list, MainWindow mainWindow)
        {
            _List = list;
            _MainWindow = mainWindow;
        }
        
        public abstract ILandscapeObject Create();
    }
}
