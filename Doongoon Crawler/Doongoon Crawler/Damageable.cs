abstract class Damageable : DungeonElement
{
    public int health;
    public Dice attackDice;
    public Dice defenseDice;

    
    public void Attack(Damageable defender)
    {
        int attackRoll = attackDice.Throw();
        int defenseRoll = defender.defenseDice.Throw();
        int damage = attackRoll - defenseRoll;
        if (damage > 0)
        {
            defender.health -= damage;
            Console.SetCursorPosition(0, GameLoop.currentCursorPosition);
            Console.Write((name + "(" + attackDice.ToString() + ") attacks " + defender.name + "(" + defender.defenseDice.ToString() + ")! " + attackRoll + " - " + defenseRoll + " = " + damage + " damage! " + defender.name + " has " + defender.health + " health remaining.").PadRight(Console.BufferWidth));
            GameLoop.currentCursorPosition++;
            
        }
        else
        {
            Console.SetCursorPosition(0, GameLoop.currentCursorPosition);
            Console.Write((name + "(" + attackDice.ToString() + ") attacks " + defender.name + "(" + defender.defenseDice.ToString() + ")! " + attackRoll + " - " + defenseRoll + " = 0 damage. " + defender.name + " has " + defender.health + " health remaining.").PadRight(Console.BufferWidth));
            GameLoop.currentCursorPosition++;
        }
        if(defender.health <= 0)
        {
            defender.Die();
        }
        else
        {
            //counterattack!
            attackRoll = defender.attackDice.Throw();
            defenseRoll = defenseDice.Throw();
            damage = attackRoll - defenseRoll;
            if (damage > 0)
            {
                health -= damage;
                Console.SetCursorPosition(0, GameLoop.currentCursorPosition);
                Console.Write((defender.name + "(" + defender.attackDice.ToString() + ") counterattacks " + name + "(" + defenseDice.ToString() + ")! " + attackRoll + " - " + defenseRoll + " = " + damage + " damage! " + name + " has " + health + " health remaining.").PadRight(Console.BufferWidth));
                GameLoop.currentCursorPosition++;

            }
            else
            {
                Console.SetCursorPosition(0, GameLoop.currentCursorPosition);
                Console.Write((defender.name + "(" + defender.attackDice.ToString() + ") counterattacks " + name + "(" + defenseDice.ToString() + ")! " + attackRoll + " - " + defenseRoll + " = 0 damage. " + name + " has " + health + " health remaining.").PadRight(Console.BufferWidth));
                GameLoop.currentCursorPosition++;
            }
        }
        if (health <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Console.SetCursorPosition(0, GameLoop.currentCursorPosition);
        Console.Write((name + " died! You gained 0 EXP because i havent implemented it yet").PadRight(Console.BufferWidth));
        GameLoop.currentCursorPosition++;
        GameLoop.RemoveCharacterFromLocation(location.x, location.y);
        LevelData.Destroy(this);
    }
}