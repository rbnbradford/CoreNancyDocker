namespace Domain.Domain
{
    public class Duck
    {
        public DuckId Id { get; }
        public string Name { get; }
        public int Age { get; }

        private Duck(DuckId id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public static Duck Create(string name, int age) => new Duck(DuckId.Generate(), name, age);
    }
}
