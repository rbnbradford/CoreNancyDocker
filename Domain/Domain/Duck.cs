namespace Domain.Domain
{
    public class Duck
    {
        public DuckId Id { get; }
        private string _name;
        private int _age;

        private Duck(DuckId id, string name, int age)
        {
            Id = id;
            _name = name;
            _age = age;
        }

        public static Duck Create(string name, int age) => new Duck(DuckId.Generate(), name, age);
    }
}
