class Wall : DungeonElement
{
    public Wall(int x, int y)
    {
        myColor = ConsoleColor.DarkGray;
        character = '#';
        location.x = x;
        location.y = y;
    }

    public override void Draw()
    {
        Console.SetCursorPosition(location.x, location.y);
        Console.ForegroundColor = myColor;
        Console.Write(character);
        Console.SetCursorPosition(0, GameLoop.defaultCursorPosition);
        forceVisibility = true;
    }
}
