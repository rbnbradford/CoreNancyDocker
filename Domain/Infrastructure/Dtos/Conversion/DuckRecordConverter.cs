using System.Runtime.Serialization;
using Domain.Domain;

namespace Domain.Infrastructure.Dtos.Conversion
{
    public class DuckRecordConverter : ReflectionConverter<DuckRecord, Duck>
    {
        public override Duck Convert(DuckRecord dto)
        {
            var duck = FormatterServices.GetUninitializedObject(typeof(Duck)) as Duck;
            SetPropety(duck, "Id", DuckId.FromExisiting(dto.Id));
            SetPropety(duck, "Name", dto.Name);
            SetPropety(duck, "Age", dto.Age);
            return duck;
        }

        public override DuckRecord Convert(Duck obj)
        {
            return new DuckRecord {Id = obj.Id.ToString(), Name = obj.Name, Age = obj.Age};
        }
    }
}
