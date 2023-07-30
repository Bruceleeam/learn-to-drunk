using System.Runtime.InteropServices.ComTypes;

public interface IDataStorageStrategy
{
    void SaveData(DataObject data);
    DataObject LoadData();
}