namespace Gra
{
    public interface ILandscapeObject //interface conneting avatars which can be used as landscape objects
    {
        Avatar Element { get; }
        string ImagePath { get; }
    }
}
