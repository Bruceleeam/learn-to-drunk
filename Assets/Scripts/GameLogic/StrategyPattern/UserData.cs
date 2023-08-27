using System;

[Serializable]
public class UserData
{

    public UserData(int lifes = 3, string town = null)
    {
        Lifes = lifes;
        Town = town;
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
}