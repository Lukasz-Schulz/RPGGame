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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window    //a main window with a board where the main hero character can move around
    {
        public static int SIZE { get; } = 15;      // variable defining the basic surface unit
        public MainHero Hero;                   //a field containg hero character
        Character Enemy;                       // a field containing an enemy character
        
        private int EnemyPosX;               //enemy's localisation parameters to be compared by different methods
        private int EnemyPosY;

        LandScape LocalLandScape;

        DwarfFactory Dwarf = new DwarfFactory();
        KnightFactory Knight = new KnightFactory();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitBoard();    //defines board's parameters
            InitMainHero();   //instantiates main hero character and puts it on the board
            Enemy = RandomEnemy();  //instantiates enemy's character
            InitEnemy(Enemy.CharacterAvatar);   //localises enemy's avatara on the board
            InitLandscape();    //runs all the methods responsible for filling the landscape  
            
            EnterName(); //Opens welcoming window
        }
     #region Window initialisation

        //runs all the methods responsible for filling the landscape  
        void InitLandscape()    
        {
            LocalLandScape = new LandScape(this);
            LocalLandScape.InitiateLandscape(25, 30, 35);
            AutoInitLandscape(LocalLandScape); 
        }

        //Initialises and defines parameters of the board
        void InitBoard() 
        {
            for (int i = 0; i < Board.Width / SIZE; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(SIZE);
                Board.ColumnDefinitions.Add(columnDefinition);
            }
            for (int j = 0; j < Board.Height / SIZE; j++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(SIZE);
                Board.RowDefinitions.Add(rowDefinition);
            }
        }
        //instantiates main hero character and puts it on the board
        void InitMainHero()
        {
            Hero = new MainHero("", 200, 12, 5, 1,this);//default hero settings
            
            Board.Children.Add(Hero.CharacterAvatar.Image);   //adds an avatar to the board
            Hero.CharacterAvatar.DrawAvatar(this);              //draws an avatar on the board
        }

        // adds and draws enemy's avatar on the board. Also passes its localisation parameters to the class' fields
        void InitEnemy(Avatar avatar)
        {
            Board.Children.Add(avatar.Image);

            avatar.DrawAvatar(this);

            EnemyPosX = Enemy.CharacterAvatar.X;
            EnemyPosY = Enemy.CharacterAvatar.Y;
        }

        // Adds and draws all the landscape elements on the board.
        void AutoInitLandscape(LandScape landScape)
        {
            foreach(ILandscapeObject landscapeObject in landScape.list)
            {
                Board.Children.Add(landscapeObject.Element.Image);

                Grid.SetColumn(landscapeObject.Element.Image, landscapeObject.Element.X);
                Grid.SetRow(landscapeObject.Element.Image, landscapeObject.Element.Y);
            }
        }

        #endregion Window initialisation

        #region Movement handling
        //Changes hero's localisation parameters and if the conditions are met - redraws it in new localisation
        void Move(int x, int y)
            {
                Hero.CharacterAvatar.X += x;
                Hero.CharacterAvatar.Y += y;
                Hero.CharacterAvatar.DrawAvatar(this);
            }

            private void Window_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Left)
                {
                    if (Hero.CharacterAvatar.X > 0)
                    if(!CheckCollision(-1,0))
                        Move(-1, 0);    
                }
                if (e.Key == Key.Right)
                {
                    if (Hero.CharacterAvatar.X < Board.Width / SIZE - 2)
                    if (!CheckCollision(1, 0))
                        Move(1, 0);
                }
                if (e.Key == Key.Up)
                {
                    if (Hero.CharacterAvatar.Y > 0)
                    if (!CheckCollision(0, -1))
                        Move(0, -1);
                }
                if (e.Key == Key.Down)
                {
                    if (Hero.CharacterAvatar.Y < Board.Height / SIZE - 2)
                    if (!CheckCollision(0, 1))
                        Move(0, 1);
                }

                // checks if hero's and enemy's localisation are the same and if they are it opens a fightscreen

                if (Hero.CharacterAvatar.X == EnemyPosX && Hero.CharacterAvatar.Y == EnemyPosY)
                {
                    Fight(RandomEnemy());
                    Board.Children.Remove(Enemy.CharacterAvatar.Image);// deletes enemy's image from the grid
                    Enemy = RandomEnemy();//randomly generates new enemy's localisation and initiates it on the board
                    InitEnemy(Enemy.CharacterAvatar);
                }
        }
        //checks if hero's localisation is not going to be the same as landscape element localisation
        bool CheckCollision(int moveX, int moveY)   
        {
            foreach (ILandscapeObject o in LocalLandScape.list)
            {
                if (Hero.CharacterAvatar.X + moveX == o.Element.X && Hero.CharacterAvatar.Y + moveY == o.Element.Y)
                    return true;
            }
            return false;
        }
        #endregion Movement handling
        
        // opens a welcoming window where you can give name to the hero
        void EnterName()
        {
            IsEnabled = false;
            EnterNameBox entername = new EnterNameBox(Hero, this);
        }

        //opens the fight screen
        public void Fight(Character enemy)
        {
            this.IsEnabled = false;
            FightScreen fight = new FightScreen(Hero, enemy, this);
            fight.Show();
        }

        private Character RandomEnemy() //radomly chooses a factory to use it to create the new enemy
        {
            Random random = new Random();
            switch (random.Next(0, 2))
            {
                case 0:
                    return Dwarf.Create(Hero.Level, this);
                case 1:
                    return Knight.Create(Hero.Level, this);
                default: return Knight.Create(1, this);
            }
        }
    }
}
