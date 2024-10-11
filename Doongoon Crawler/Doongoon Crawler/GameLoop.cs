using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DungeonElement;

static class GameLoop
{
    static public Player player;
    static public double visionRange = 5; //what distance things should become visible
    static public int defaultCursorPosition = 21; //what y-position the cursor should return to
    static public int currentCursorPosition;//what line should we write text on
    static public bool gameplay = true;

    static void Main(string[] args)
    {
        LevelData.Load("Level1.txt");
        Console.CursorVisible = false;
        StartGameLoop();
    }
    static public Player CreatePlayer(int x, int y)
    {
        player = new Player(x, y);
        player.Draw();
        return player;
    }
    static public void StartGameLoop()
    {
        while (gameplay)
        {
            
            ConsoleKey playerInput = Console.ReadKey(true).Key;
            if (PlayerTurn(playerInput))
            {
                EnemyTurns();
                VisionCheck();
            }
        }
    }
    static void ClearConsole()
    {
        for (int i = currentCursorPosition - 1; i >= defaultCursorPosition; i--)
        {
            Console.SetCursorPosition(0,i);
            Console.Write(" ".PadRight(Console.BufferWidth));
        }
        currentCursorPosition = defaultCursorPosition;
    }
    static public bool PlayerTurn(ConsoleKey input)
    {
        ClearConsole();
        //check if you pressed a direction and move the player if you did
        DungeonElement? target;//what is in the place we are trying to move to
        if (input == ConsoleKey.RightArrow || input == ConsoleKey.D)
        {
            target = GetElementFromLocation(player.location.x + 1, player.location.y); //
            if (target != null)
            {
                if (target.GetType().IsSubclassOf(typeof(Enemy)))
                {
                    player.Attack(target as Damageable);
                }
            }
            else
            {
                MoveElementToLocation(player, player.location.x + 1, player.location.y);
            }
        }
        else if (input == ConsoleKey.LeftArrow || input == ConsoleKey.A)
        {
            target = GetElementFromLocation(player.location.x - 1, player.location.y); //
            if (target != null)
            {
                if (target.GetType().IsSubclassOf(typeof(Enemy)))
                {
                    player.Attack(target as Damageable);
                }
            }
            else
            {
                MoveElementToLocation(player, player.location.x - 1, player.location.y);
            }
        }
        else if (input == ConsoleKey.DownArrow || input == ConsoleKey.S)
        {
            target = GetElementFromLocation(player.location.x, player.location.y + 1); //
            if (target != null)
            {
                if (target.GetType().IsSubclassOf(typeof(Enemy)))
                {
                    player.Attack(target as Damageable);
                }
            }
            else
            {
                MoveElementToLocation(player, player.location.x, player.location.y + 1);
            }
        }
        else if (input == ConsoleKey.UpArrow || input == ConsoleKey.W)
        {
            target = GetElementFromLocation(player.location.x, player.location.y - 1); //
            if (target != null)
            {
                if (target.GetType().IsSubclassOf(typeof(Enemy)))
                {
                    player.Attack(target as Damageable);
                }
            }
            else
            {
                MoveElementToLocation(player, player.location.x, player.location.y - 1);
            }
        }
        else if(input == ConsoleKey.Spacebar)
        {
            //idle
        }
        else
        {
            //not a valid keypress, go back to picking a key
            return false;
        }
        return true;
    }

    
    static public void EnemyTurns() //for every enemy, do its update thingy
    {
        foreach(DungeonElement element in LevelData.Elements)
        {
            if (element.GetType().IsSubclassOf(typeof(Enemy)))
            {
                if (element.alive)
                {
                    (element as Enemy).Update();
                }
                
            }
        }
    }

    static public void VisionCheck() //draws every Dungeonelement in within visionRange distance and every wall that has previously been drawn
    {
        foreach (DungeonElement element in LevelData.Elements)
        {
            int distancex = Math.Abs(player.location.x - element.location.x);
            int distancey = Math.Abs(player.location.y - element.location.y);
            double distanceToPlayer = Math.Sqrt(distancex * distancex + distancey * distancey);
            if (distanceToPlayer <= visionRange || element.forceVisibility)
            {
                if (element.alive)
                {
                    element.Draw();
                }
            }
            /*
            else if (!ReferenceEquals(element.GetType(), typeof(Wall))) //if it is not in range and not a wall, hide it
            {
                RemoveCharacterFromLocation(element.location.x , element.location.y);
            } */
        }
        player.Draw();

    }

    //below are some general functions for everyone

    static public DungeonElement? GetElementFromLocation(int x, int y) //returns the DungeonElement at those coordinates, if nothing is there, returns null
    {
        foreach(DungeonElement element in LevelData.Elements)
        {
            if((element.location.x, element.location.y) == (x , y))
            {
                if (element.alive)
                {
                    return element;
                }
                
            }
        }
        return null;
    }
    static public void RemoveCharacterFromLocation(int x, int y) //replaces the character at the location with ' '
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
        Console.SetCursorPosition(0, defaultCursorPosition);
        
    }
    static public DungeonElement? MoveElementToLocation(DungeonElement element, int x, int y) //moves the DungeonElement to those coordinates if they are empty. if not, returns false
    {
        if(GetElementFromLocation(x, y) == null)
        {
            RemoveCharacterFromLocation(element.location.x, element.location.y);
            element.location.x = x;
            element.location.y = y;
            return null;
        }
        else
        {
            return GetElementFromLocation(x, y);
        }
    }
    
}