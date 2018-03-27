using System.Reflection;

namespace Domain.Infrastructure.Conversion
{
    public class ReflectionReader<T> where T : class
    {
        public string AutoPropertyTemplate = "<{0}>k__BackingField";

        private readonly T _instance;

        private const BindingFlags FieldFlags = BindingFlags.Static |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance;

        public ReflectionReader(T instance) => _instance = instance;

        public TProp GetAutoPropety<TProp>(string propertyName)
        {
            return (TProp) typeof(T)
                .GetField(string.Format(AutoPropertyTemplate, propertyName), FieldFlags)
                .GetValue(_instance);
        }

        public TField GetField<TField>(string fieldName)
        {
            return (TField) typeof(T)
                .GetField(fieldName, FieldFlags)
                .GetValue(_instance);
        }
    }
}
