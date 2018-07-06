namespace Gra
{
    public class DwarfFactory : AbstractCharacterFactory    //concrete character factory
    {
        public override CharacterPropertiesChooser PropertiesChooser { get; protected set; }
                                                                            //allows random parameter setting
        public override Character Create(int level, MainWindow mainWindow)
        {
            PropertiesChooser = new CharacterPropertiesChooser(level);
            return new Dwarf(PropertiesChooser.GetName,
                             PropertiesChooser.MaxHealth,
                             PropertiesChooser.Attack,
                             PropertiesChooser.Defence,
                             level, mainWindow);
        }
    }
}
