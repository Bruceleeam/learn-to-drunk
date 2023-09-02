using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Factory;
using UnityEngine;

public class StaticGameData
{
    public static GameData _gameData;

    public static bool CheckTown()
    {
        if (_gameData.Town != null)
            return true;
        return false;
    }

    public static bool CheckLifes()
    {
        if (_gameData.Lifes > 0)
            return true;
        return false;
    }

    public static bool CheckCard(string cocktailName)
    {
        if (StaticGameData._gameData.Unlocked.Contains(cocktailName))
            return true;
        return false;
    }

    public static void UnlockCard(string cardName)
    {
        _gameData.Unlocked.Add(cardName);
    }

}
