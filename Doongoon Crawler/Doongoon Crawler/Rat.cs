class Rat : Enemy
{
    public Rat(int x, int y)
    {
        name = "Rat";
        myColor = ConsoleColor.Yellow;
        character = 'r';
        location.x = x;
        location.y = y;
        health = 10;
        attackDice = new Dice(1, 6, 3);
        defenseDice = new Dice(1, 6, 1);
    }

    public override void Update()
    {
        //attacks player if adjacent, if not, random move
        Random random = new Random();
        int distanceToPlayer = Math.Abs(location.x - GameLoop.player.location.x) + Math.Abs(location.y - GameLoop.player.location.y);
        int randomDirection = random.Next(0,4);//0 up, 1 right, 2 down, 3 left
        if(distanceToPlayer <= 1)
        {
            Attack(GameLoop.player);
        }
        else if (randomDirection == 0)
        {
            if (GameLoop.GetElementFromLocation(location.x, location.y - 1) == null)
            {
                MoveUp();
            }
        }
        else if (randomDirection == 1)
        {
            if (GameLoop.GetElementFromLocation(location.x + 1, location.y) == null)
            {
                MoveRight();
            }
        }
        else if (randomDirection == 2)
        {
            if (GameLoop.GetElementFromLocation(location.x, location.y + 1) == null)
            {
                MoveDown();
            }
        }
        else if (randomDirection == 3)
        {
            if (GameLoop.GetElementFromLocation(location.x - 1, location.y) == null)
            {
                MoveLeft();
            }
        }
    }
}
