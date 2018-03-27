using Domain.Domain;

namespace Domain.ApplicationServices
{
    public class DuckService
    {
        private readonly IDuckRepository _duckRepository;

        public DuckService(IDuckRepository duckRepository)
        {
            _duckRepository = duckRepository;
        }

        public string CreateDuck(string name, int age)
        {
            var duck = Duck.Create(name, age);
            _duckRepository.Add(duck);
            return duck.Id.ToString();
        }
    }
}
