using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Gra
{    
    public class LandScape  //class responsible for managing the factories
    {
        public List<ILandscapeObject> list { get; protected set; } = new List<ILandscapeObject>();

        BushFactory _BushFactory;
        WaterFactory _WaterFactory;
        RockFactory _RockFactory;

        public LandScape(MainWindow window)
        {
            _BushFactory = new BushFactory(list, window);
            _WaterFactory= new WaterFactory(list, window);
            _RockFactory = new RockFactory(list, window);
        }

        //a method that takes number of each landscape object we want to create and put them on a list
        public void InitiateLandscape(int bushAmount, int waterAmount, int rockAmount)
        {
            for (int i = 0; i<bushAmount;i++)
            {
                _BushFactory.Create();
                Task.Delay(1).Wait(); //a 1ms delay to let the object be created and added to list. Otherwise it jumps to next step
            }
            for (int i = 0; i < waterAmount; i++)
            {
                _WaterFactory.Create();
                Task.Delay(1).Wait(); //a 1ms delay to let the object be created and added to list. Otherwise it jumps to next step
            }
            for (int i = 0; i < rockAmount; i++)
            {
                _RockFactory.Create();
                Task.Delay(1).Wait(); //a 1ms delay to let the object be created and added to list. Otherwise it jumps to next step
            }
        }
    }
}
