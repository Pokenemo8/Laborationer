class Dice
{
    int amount;
    int sides;
    int modifier;
    Random random = new Random();
    public Dice(int numberOfDice, int numberOfSides, int addModifier)
    {
        amount = numberOfDice;
        sides = numberOfSides;
        modifier = addModifier;
    }
    public int Throw()
    {
        int result = modifier;
        for (int i = 0; i < amount; i++)
        {
            result += random.Next(1, sides);
        }
        return result;
    }
    public override string ToString()
    {
        return (amount + "d" + sides + "+" + modifier);
    }
}