namespace Sample.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string GeonameId { get; set; }

        public string CountryCode { get; set; }

        //Country_UID
        public string CountryId { get; set; }

        public string Admin1Code { get; set; }
        public string Admin2Code { get; set; }

        public Country Country { get; set; }

        public State State { get; set; }
    }
}
