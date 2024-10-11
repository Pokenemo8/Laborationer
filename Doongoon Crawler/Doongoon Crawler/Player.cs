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
        GameLoop.gameplay = false;
    }
}