using System.Collections.Generic;
using Domain.Records;

namespace Domain.Representation
{
    public interface IDuckReadRepository
    {
        DuckRecord Get(string id);
        IEnumerable<DuckRecord> Get();
    }
}
