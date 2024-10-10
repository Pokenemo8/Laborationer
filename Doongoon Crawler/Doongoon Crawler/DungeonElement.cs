using System.Numerics;

abstract class DungeonElement
{
    public char character;
    public ConsoleColor myColor;
    public Location location;
    public string name = "default name";
    public bool forceVisibility = false; //this is only for walls
    public struct Location
    {
        public int x;
        public int y;
    }
    
    
    public virtual void Draw()
    {
        Console.SetCursorPosition(location.x, location.y);
        Console.ForegroundColor = myColor;
        Console.Write(character);
        Console.SetCursorPosition(0, GameLoop.defaultCursorPosition);
    }
    /*
    public bool MoveLeft()
    {
        MoveElementToLocation(player, player.location.x + 1, player.location.y);
    } */
}
