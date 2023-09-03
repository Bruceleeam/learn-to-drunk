using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public GameData()
    {

    }

    public GameData(int lifes, string town, List<Card> unlocked)
    {
        Lifes = lifes;
        Town = town;
        Unlocked = unlocked;
    }

    public int Lifes
    {
        get;
        set;
    }

    public string Town
    {
        get;
        set;
    }

    public List<Card> Unlocked
    {
        get;
        set;
    }
}

[Serializable]
public class Card
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Card()
    {

    }

    public Card(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
