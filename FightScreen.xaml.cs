using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using Gra.Properties;

namespace Gra
{
    /// <summary>
    /// Interaction logic for FightScreen.xaml
    /// </summary>
    public partial class FightScreen : Window           // a window where fight is being visualised
    {
        public Character Enemy { get; set; }
        public MainHero Hero { get; set; }
        public MainWindow MainWindow { get; }
        private Fight FightHandler;

        public FightScreen(MainHero hero, Character enemy, MainWindow mainWindow)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // lokates window in center of the screen
            this.Hero = hero;
            this.Enemy = enemy;
            MainWindow = mainWindow;
            FightHandler = new Fight(this);
            //sets hero's image
            HeroImage(DirectoryProvider.GetRelativeDirectory(@"C:\Users\LEN\source\repos\Gra\Gra\Graphics\Conan.jpg"));
            //sets enemy's image based on enemy's class
            ChooseEnemyImage();
            SetStats();            
            SetButtons();
        }

         #region ButtonHandling
                private void SetButtons()   //assigns an attacks name based on its number
                {
                    btn1.Content = Hero.AttackOne.AttackName;
                    btn2.Content = Hero.AttackTwo.AttackName;
                    btn3.Content = Hero.AttackThree.AttackName;
                    btn4.Content = Hero.AttackFour.AttackName;
                }
        
                private void btn1_Click(object sender, RoutedEventArgs e)//assingns buttons click an attack command
                {
                    FightHandler.Turn(Hero, Enemy, 1);
                    FightHandler.Turn(Enemy, Hero);
                }

                private void btn2_Click(object sender, RoutedEventArgs e)//assingns buttons click an attack command
                {
                    FightHandler.Turn(Hero, Enemy, 2);
                    FightHandler.Turn(Enemy, Hero);
                }

                private void btn3_Click(object sender, RoutedEventArgs e)//assingns buttons click an attack command
                {
                    FightHandler.Turn(Hero, Enemy, 3);
                    FightHandler.Turn(Enemy, Hero);
                }

                private void btn4_Click(object sender, RoutedEventArgs e)//assingns buttons click an attack command
                {
                    FightHandler.Turn(Hero, Enemy, 4);
                    FightHandler.Turn(Enemy, Hero);
                }

                private void btnNext_Click(object sender, RoutedEventArgs e)            //hides a Start and Next button to uncover
                {                                                                       //attack buttons
                    btnNext.Visibility = Visibility.Hidden;
                }

                #endregion ButtonHandling


        #region ImageHandling

        void HeroImage(string imageSource)                    // sets hero's image 
        {
            try
            {
                BitmapImage Hero = new BitmapImage();
                Hero.BeginInit();
                Hero.UriSource = new Uri(imageSource);
                Hero.DecodePixelHeight = 150;
                Hero.EndInit();
                imgHero.Source = Hero;
            }
            catch
            {
                imgHero = null;
                lblBattle.Text += "Hero image not found";
            }
        }

        void ChooseEnemyImage()        // chooses enemy's image by its class
        {
            if (Enemy.GetType().ToString() == "Gra.Knight")
            {
                SetEnemyImage(DirectoryProvider.GetRelativeDirectory(@"C:\Users\LEN\source\repos\Gra\Gra\Graphics\Knight.jpg"));
            }
            else if (Enemy.GetType().ToString() == "Gra.Dwarf")
            {
                SetEnemyImage(DirectoryProvider.GetRelativeDirectory(@"C:\Users\LEN\source\repos\Gra\Gra\Graphics\Dwarf.jpg"));
            }
        }

        void SetEnemyImage(string imageSource) // sets enemy image choosen by ChooseEnemyImage
        {
            try
            {
                BitmapImage Enemy = new BitmapImage();
                Enemy.BeginInit();
                Enemy.UriSource = new Uri(imageSource);
                Enemy.DecodePixelHeight = 150;
                Enemy.EndInit();
                imgEnemy.Source = Enemy;
            }
            catch
            {
                imgEnemy = null;
                lblBattle.Text += "Enemy image not found";
            }
        }

        #endregion ImageHandling

        //setting all the visible variables
        private void SetStats()
        {
            lblEnemyName.Content = Enemy.Name + " - Lv: " + Enemy.Level; 
            lblHeroName.Content = Hero.Name + " - Lv: " + Hero.Level;
            progBarEnemy.Maximum = Enemy.MaxHealth;
            progBarEnemy.Value = Enemy.Health;
            progBarHero.Value = Hero.Health;
            progBarHero.Maximum = Hero.MaxHealth;
            lblEnemyHP.Content = $"HP: {Enemy.Health}";
            lblHeroHP.Content = $"HP: {Hero.Health}";
        }

        //actualises the visible variables
        public void UpdateScreen()
        {
            progBarEnemy.Value = Enemy.Health;
            progBarHero.Value = Hero.Health;
            lblEnemyHP.Content = $"HP: {Enemy.Health}";
            lblHeroHP.Content = $"HP: {Hero.Health}";
        }
    }
}
