using System.Runtime.CompilerServices;

class Player : Damageable
{
    
    public Player(int x, int y)
    {
        name = "Player";
        myColor = ConsoleColor.White;
        character = '@';
        location.x = x;
        location.y = y;
        health = 100;
        attackDice = new Dice(2, 6, 2);
        defenseDice = new Dice(2, 6, 0);
    }
    public override void Die()
    {
        GameLoop.visionRange = 100;//reveal the whole dungeon
        Console.SetCursorPosition(0, GameLoop.currentCursorPosition);
        Console.Write((name + " died! Final Score: 0 EXP because i still havent implemented it. press a button or something to leave").PadRight(Console.BufferWidth));
        GameLoop.currentCursorPosition++;
        GameLoop.gameplay = false;
    }
}