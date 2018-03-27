using System.Collections.Generic;
using Domain.Infrastructure.Dtos;

namespace Domain.Representation
{
    public interface IDuckReadRepository
    {
        DuckRecord Get(string id);
        IEnumerable<DuckRecord> Get();
    }
}
