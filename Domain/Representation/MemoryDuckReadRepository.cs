using System.Collections.Generic;
using System.Linq;
using Domain.Infrastructure;
using Domain.Infrastructure.Dtos;

namespace Domain.Representation
{
    public class MemoryDuckReadRepository : IDuckReadRepository
    {
        private readonly Dictionary<string, DuckRecord> _duckDictionary;

        public MemoryDuckReadRepository(Dictionary<string, DuckRecord> duckDictionary)
        {
            _duckDictionary = duckDictionary;
        }

        public DuckRecord Get(string id)
        {
            if (!_duckDictionary.ContainsKey(id)) throw new NoDuckWithIdException(id);
            return _duckDictionary[id];
        }

        public IEnumerable<DuckRecord> Get()
        {
            return _duckDictionary.Select(kvp => kvp.Value);
        }
    }
}
