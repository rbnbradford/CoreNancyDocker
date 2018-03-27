namespace Domain.Infrastructure.Dtos.Conversion
{
    public interface IConverter<T1, T2>
    {
        T2 Convert(T1 dto);
        T1 Convert(T2 obj);
    }
}
