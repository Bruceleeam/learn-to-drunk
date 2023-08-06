using System;

[Serializable]
public class GameData
{
    public string _lastTown;
    public int _lifes;
    // Altri campi dati da memorizzare
    // public List<string> _unlockedCards = new List<string>();

    public GameData()
    {
        _lastTown = null;
        _lifes = 3;
    }
}