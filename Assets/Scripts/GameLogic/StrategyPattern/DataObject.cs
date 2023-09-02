using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public GameData()
    {

    }

    public GameData(int lifes, string town, List<string> unlocked)
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

    public List<string> Unlocked
    {
        get;
        set;
    }
}
