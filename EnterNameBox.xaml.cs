using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gra
{
    public partial class EnterNameBox : Window  //welcoming window with textbox for writing hero's name
    {
        MainHero Hero;
        MainWindow Window;

        public EnterNameBox(MainHero hero, MainWindow window)
        {
            InitializeComponent();
            Show();
            this.Hero = hero;
            this.Window = window;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
            
        private void Button_Click(object sender, RoutedEventArgs e) //checks if the name is not too short and sets it as hero's name
        {
            Window.IsEnabled = true;
            if (Input.Text.Length > 2)
            {
                Hero.SetName(Input.Text);
                Close();
            }
            else
                MessageBox.Show("Name must be at least 3 characters long.");            
        }        
    }
}
