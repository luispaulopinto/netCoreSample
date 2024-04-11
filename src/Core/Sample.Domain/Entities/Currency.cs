namespace Sample.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string CurrencySymbol { get; set; }

        public int? DefaultPositionNumber { get; set; }

        public string PaypalCurrencyCode { get; set; }
    }
}
