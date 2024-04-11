namespace Sample.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name_enUS { get; set; }
        public string Name_esES { get; set; }
        public string Name_ptPT { get; set; }
        public string Name_ptBR { get; set; }

        public string CountryCode { get; set; }
        public string GeonameId { get; set; }
        public string CountryIsoCode { get; set; }
        public string ContinentIsoCode { get; set; }

        public Continent Continent { get; set; }

        public ICollection<State> States { get; } = [];
    }
}
