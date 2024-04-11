namespace Sample.Domain.Entities
{
    public class State
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string GeonameId { get; set; }

        public string CountryCode { get; set; }
        public string Admin1Code { get; set; }

        public string CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; } = [];
    }
}
