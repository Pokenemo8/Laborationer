abstract class Enemy : Damageable
{
    public void MoveRight()
    {
        if (GameLoop.GetElementFromLocation(location.x + 1, location.y) == null)
        {
            GameLoop.MoveElementToLocation(this, location.x + 1, location.y);
        }
        else if (GameLoop.GetElementFromLocation(location.x + 1, location.y) == GameLoop.player)
        {
            Attack(GameLoop.GetElementFromLocation(location.x + 1, location.y) as Player);
        }
    }
    public void MoveLeft()
    {
        if (GameLoop.GetElementFromLocation(location.x - 1, location.y) == null)
        {
            GameLoop.MoveElementToLocation(this, location.x - 1, location.y);
        }
        else if (GameLoop.GetElementFromLocation(location.x - 1, location.y) == GameLoop.player)
        {
            Attack(GameLoop.GetElementFromLocation(location.x - 1, location.y) as Player);
        }
    }
    public void MoveDown()
    {
        if (GameLoop.GetElementFromLocation(location.x, location.y + 1) == null)
        {
            GameLoop.MoveElementToLocation(this, location.x, location.y + 1);
        }
        else if (GameLoop.GetElementFromLocation(location.x, location.y + 1) == GameLoop.player)
        {
            Attack(GameLoop.GetElementFromLocation(location.x, location.y + 1) as Player);
        }
    }
    public void MoveUp()
    {
        if (GameLoop.GetElementFromLocation(location.x, location.y - 1) == null)
        {
            GameLoop.MoveElementToLocation(this, location.x, location.y - 1);
        }
        else if (GameLoop.GetElementFromLocation(location.x, location.y - 1) == GameLoop.player)
        {
            Attack(GameLoop.GetElementFromLocation(location.x, location.y - 1) as Player);
        }
    }
    public abstract void Update();
}
