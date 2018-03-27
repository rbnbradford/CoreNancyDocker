using System.Collections.Generic;
using Domain.Domain;
using Domain.Infrastructure.Conversion;
using Domain.Records;

namespace Domain.Infrastructure.DuckRepositories
{
    public class MemoryDuckRepository : IDuckRepository
    {
        private readonly Dictionary<string, DuckRecord> _duckDictionary;
        private readonly IConverter<Duck, DuckRecord> _converter;

        public MemoryDuckRepository(Dictionary<string, DuckRecord> duckDictionary)
        {
            _duckDictionary = duckDictionary;
            _converter = new DuckRecordConverter();
        }

        public void Add(Duck duck)
        {
            _duckDictionary[duck.Id.ToString()] = _converter.Convert(duck);
        }

        public Duck Get(DuckId id)
        {
            if (!_duckDictionary.ContainsKey(id.ToString())) throw new NoDuckWithIdException(id.ToString());
            return _converter.Convert(_duckDictionary[id.ToString()]);
        }
    }
}
