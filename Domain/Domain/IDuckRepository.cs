namespace Domain.Domain
{
    public interface IDuckRepository
    {
        void Add(Duck duck);
        Duck Get(DuckId id);
    }
}
