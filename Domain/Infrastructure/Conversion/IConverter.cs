namespace Domain.Infrastructure.Conversion
{
    public interface IConverter<T1, T2>
    {
        T2 Convert(T1 entity);
        T1 Convert(T2 record);
    }
}
