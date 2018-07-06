using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gra
{
    public class Avatar             // class containing a graphic visualisation and localisation of characters 
                                    //avatar on the main screen
    {                              
        public Image Image { get; set; }
        public string ImageSource { get; }
        public MainWindow MainWindow { get; }

        public int X;               //localisation parameters
        public int Y;

        public Avatar(int x, int y, string imageSource, MainWindow mainWindow)
        {
            X = x;
            Y = y;
            ImageSource = imageSource;
            MainWindow = mainWindow;

            SetImageSource();
        }

        // initializes an image by image source
        void SetImageSource()
        {
            Image = new Image();
            BitmapImage avatar = new BitmapImage();
            try
            {
                avatar.BeginInit();
            }
            catch (InvalidOperationException ex)
            { MessageBox.Show(ex.Message); }

            try { avatar.UriSource = new Uri(ImageSource);} catch(UriFormatException ex){ MessageBox.Show(ex.Message); }
            catch (ArgumentNullException ex) { MessageBox.Show(ex.Message); }
            avatar.DecodePixelHeight = 10;
            try {avatar.EndInit();} catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); }
            Image.Source = avatar;

            MainWindow.imgHeroAvatar = Image;
        }

        //sets the localisation of avatar
        public void DrawAvatar(MainWindow mainWindow)
        {
            Grid.SetColumn(Image, X);
            Grid.SetRow(Image, Y);
        }
    }
}
