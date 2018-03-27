using System.Reflection;
using System.Runtime.Serialization;

namespace Domain.Infrastructure.Conversion
{
    public class ReflectionBuilder<T> where T : class
    {
        public string AutoPropertyTemplate = "<{0}>k__BackingField";

        public T Instance { get; }

        private const BindingFlags FieldFlags = BindingFlags.Static |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance;

        public static ReflectionBuilder<T> Initialise() => new ReflectionBuilder<T>();

        public ReflectionBuilder() => Instance = FormatterServices.GetUninitializedObject(typeof(T)) as T;

        public ReflectionBuilder<T> SetAutoPropety(string propertyName, object value)
        {
            typeof(T)
                .GetField(string.Format(AutoPropertyTemplate, propertyName), FieldFlags)
                .SetValue(Instance, value);
            return this;
        }

        public ReflectionBuilder<T> SetField(string fieldName, object value)
        {
            typeof(T)
                .GetField(fieldName, FieldFlags)
                .SetValue(Instance, value);
            return this;
        }
    }
}
