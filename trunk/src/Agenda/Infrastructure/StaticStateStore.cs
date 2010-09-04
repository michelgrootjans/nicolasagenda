using System.Collections.Generic;

namespace Agendas.Infrastructure
{
    public class StaticStateStore : IStateStore
    {
        private readonly IDictionary<string, object> dictionary = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                return dictionary.ContainsKey(key)
                           ? dictionary[key]
                           : null;
            }
            set { dictionary[key] = value; }
        }
    }
}