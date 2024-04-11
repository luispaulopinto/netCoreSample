namespace Sample.Domain.Entities
{
    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ISOCode { get; set; }

        public ICollection<Country> Countries { get; } = [];
    }
}
