namespace Gra
{
    public class KnightFactory : AbstractCharacterFactory   //concrete character factory for knights
    {
        public override CharacterPropertiesChooser PropertiesChooser { get; protected set; }
        

        public override Character Create(int level, MainWindow mainWindow)
        {
            PropertiesChooser = new CharacterPropertiesChooser(level);
            return new Knight(PropertiesChooser.GetName,
                PropertiesChooser.MaxHealth,
                PropertiesChooser.Attack,
                PropertiesChooser.Defence,
                level, mainWindow);
        }
    }
}
