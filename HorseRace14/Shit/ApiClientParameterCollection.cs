using System.Collections;
using System.Collections.Generic;

namespace HorseRace14.Shit
{
    public class ApiClientParameterCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly List<KeyValuePair<string, string>> _collection;

        public ApiClientParameterCollection()
        {
            _collection = new List<KeyValuePair<string, string>>();
        }

        public void Add(string key, string value)
        {
            var keyValuePair = new KeyValuePair<string, string>(key, value);

            if (_collection.Contains(keyValuePair))
                return;

            _collection.Add(keyValuePair);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
