using System.Reflection;

namespace Domain.Infrastructure.Dtos.Conversion
{
    public abstract class ReflectionConverter<T1, T2> : IConverter<T1, T2>
    {
        public abstract T2 Convert(T1 dto);
        public abstract T1 Convert(T2 obj);

        protected static void SetPropety<T>(T instance, string propertyName, object value)
        {
            GetBackingField<T>(propertyName).SetValue(instance, value);
        }

        private static FieldInfo GetBackingField<T>(string propertyName)
        {
            return typeof(T).GetField(
                $"<{propertyName}>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
        }
    }
}
