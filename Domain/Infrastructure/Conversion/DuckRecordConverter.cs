using Domain.Domain;
using Domain.Records;

namespace Domain.Infrastructure.Conversion
{
    public class DuckRecordConverter : IConverter<Duck, DuckRecord>
    {
        public DuckRecord Convert(Duck entity)
        {
            var reader = new ReflectionReader<Duck>(entity);
            return new DuckRecord
            {
                Id = reader.GetAutoPropety<DuckId>("Id").ToString(),
                Name = reader.GetField<string>("_name"),
                Age = reader.GetField<int>("_age")
            };
        }

        public Duck Convert(DuckRecord record)
        {
            return new ReflectionBuilder<Duck>()
                .SetAutoPropety("Id", DuckId.FromExisiting(record.Id))
                .SetField("_name", record.Name)
                .SetField("_age", record.Age)
                .Instance;
        }
    }
}
