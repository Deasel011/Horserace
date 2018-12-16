namespace HorseRace14.Shit
{
    public interface IStorage
    {
        string CreateDataStorage();
        T GetData<T>(string id);
        void SaveData(string id, object data);
        void DeleteData(string id);
    }
}
