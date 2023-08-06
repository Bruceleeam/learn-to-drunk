using System.Runtime.InteropServices.ComTypes;

public interface IDataStorageStrategy
{
    void SaveData(GameData data);
    GameData LoadData();
}