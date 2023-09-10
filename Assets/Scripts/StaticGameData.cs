using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static bool CheckCard(Card card)
    {
        if (StaticGameData._gameData.Unlocked.Any( o => o.Name.Equals(card.Name)))
            return true;
        return false;
    }

    public static void UnlockCard(Card cardName)
    {
        _gameData.Unlocked.Add(cardName);
    }

}
