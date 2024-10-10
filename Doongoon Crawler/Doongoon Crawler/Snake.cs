class Snake : Enemy
{
    int runAwayDistance = 2; //if player is within this distance, snake should run away
    public Snake(int x, int y)
    {
        name = "Snake";
        myColor = ConsoleColor.Green;
        character = 's';
        location.x = x;
        location.y = y;
        health = 25;
        attackDice = new Dice(3, 4, 2);
        defenseDice = new Dice(1, 8, 5);
    }

    public override void Update()
    {
        //if player is within two distance, RUN AWAY AAAAAAAA
        int distancex = GameLoop.player.location.x - location.x; //horizontal distance to player. positive = player is more to the right
        int distancey = GameLoop.player.location.y - location.y; //vertical distance to player. positive = player is more up
        if (Math.Abs(distancex) + Math.Abs(distancey) <= runAwayDistance) //if within runAwayDistance(default 2) distance from the player
        {
            Random random = new Random();
            //ok time to calculate the direction of the player to find out the optimal direction to run in blind panic in
            if (distancex == 0) //checks if player is directly above or below
            {
                if (distancey < 0)
                {
                    MoveDown();
                }
                else if (distancey > 0)
                {
                    MoveUp();
                }
            }
            else if (distancey == 0) //checks if player is directly right or left
            {
                if (distancex < 0)
                {
                    MoveRight();
                }
                else if (distancex > 0)
                {
                    MoveLeft();
                }
            }
            //ok, time for diagonals
            if (distancex < 0 && distancey < 0) //player is left, up
            {
                if(random.Next(0,2) == 0)
                {
                    MoveRight();
                }
                else
                {
                    MoveDown();
                }
            }
            if (distancex > 0 && distancey < 0) //player is right, up
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
            if (distancex < 0 && distancey > 0) //player is left, down
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
            if (distancex > 0 && distancey > 0) //player is right, down
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
        }
    }
}