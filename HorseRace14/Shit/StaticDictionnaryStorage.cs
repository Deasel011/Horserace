using System.Collections.Generic;

namespace HorseRace14.Shit
{
    public static class StaticDictionnaryStorage
    {
        private static readonly Dictionary<int, object> InternalStorage = new Dictionary<int, object>();
        private static int _internalStorageIndex = 1;

        public static int CreateDataStorage()
        {
            return _internalStorageIndex++;
        }

        public static T GetData<T>(int id)
        {
            return (T)InternalStorage[id];
        }

        public static void SaveData(int id, object data)
        {
            InternalStorage[id] = data;
        }

        public static void DeleteData(int id)
        {
            InternalStorage.Remove(id);
        }
    }
}
