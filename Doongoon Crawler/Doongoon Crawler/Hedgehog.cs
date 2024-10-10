class Hedgehog : Enemy 
{
    int VisionRange = 5; //if player is within this distance, hedgehog should run towards them
    public Hedgehog(int x, int y)
    {
        name = "Heghog";
        myColor = ConsoleColor.Magenta;
        character = 'h';
        location.x = x;
        location.y = y;
        health = 15;
        attackDice = new Dice(2, 4, 4);
        defenseDice = new Dice(1, 10, 2);
    }

    public override void Update()
    {
        int distancex = GameLoop.player.location.x - location.x; //horizontal distance to player. positive = player is more to the right
        int distancey = GameLoop.player.location.y - location.y; //vertical distance to player. positive = player is more up
        if (Math.Abs(distancex) + Math.Abs(distancey) <= VisionRange) 
        {
            Random random = new Random();
            if (distancex == 0) //checks if player is directly above or below
            {
                if (distancey < 0)
                {
                    MoveUp();
                }
                else if (distancey > 0)
                {
                    MoveDown();
                }
            }
            else if (distancey == 0) //checks if player is directly right or left
            {
                if (distancex < 0)
                {
                    MoveLeft();
                }
                else if (distancex > 0)
                {
                    MoveRight();
                }
            }
            //ok, time for diagonals
            if (distancex < 0 && distancey < 0) //player is left, up
            {
                if (random.Next(0, 2) == 0)
                {
                    MoveLeft();
                }
                else
                {
                    MoveUp();
                }
            }
            if (distancex > 0 && distancey < 0) //player is right, up
            {
                if (random.Next(0, 2) == 0)
                {
                    MoveRight();
                }
                else
                {
                    MoveUp();
                }
            }
            if (distancex < 0 && distancey > 0) //player is left, down
            {
                if (random.Next(0, 2) == 0)
                {
                    MoveLeft();
                }
                else
                {
                    MoveDown();
                }
            }
            if (distancex > 0 && distancey > 0) //player is right, down
            {
                if (random.Next(0, 2) == 0)
                {
                    MoveRight();
                }
                else
                {
                    MoveDown();
                }
            }
        }
    }
}
