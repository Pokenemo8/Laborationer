static class LevelData
{
    static private List<DungeonElement> elements = new List<DungeonElement>(); //the list of every dungeonElement
    static public List<DungeonElement> Elements {  get { return elements; } }
    static public void Load(string filename)
    {
        string[] lines = File.ReadAllLines(filename); //Put the lines into an array of strings
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                char character = lines[i][j];//gets the character from position j in line i
                if (character == '#')
                {
                    elements.Add(new Wall(j, i));
                }
                else if (character == 'r')
                {
                    elements.Add(new Rat(j, i));
                }
                else if (character == 's')
                {
                    elements.Add(new Snake(j, i));
                }
                else if (character == '@')
                {
                    elements.Add(GameLoop.CreatePlayer(j, i));
                }
                else if (character == 'h')
                {
                    elements.Add(new Hedgehog(j, i));
                }
            }
        }
        GameLoop.VisionCheck();
    }
    static public void Destroy(DungeonElement element)
    {
        elements.Remove(element);
    }
}
