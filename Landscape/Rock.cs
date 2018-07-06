using System;
using System.Collections.Generic;

namespace Gra
{
    public class Rock : ILandscapeObject//concrete landscape object adding itself to a list in constructor
    {
        public Avatar Element { get; protected set; }
        public string ImagePath { get; } = @"C:\Users\LEN\source\repos\Gra\Gra\Graphics\Rock.jpg";

        public Rock(List<ILandscapeObject> list, MainWindow mainWindow)
        {
            Random rand = new Random();
            Element = new Avatar(
                rand.Next(1,
                (int)mainWindow.Width / 15),
                rand.Next(1, (int)mainWindow.Height / 15),
                DirectoryProvider.GetRelativeDirectory(ImagePath),
                mainWindow);
            list.Add(this);
        }
    }
}
