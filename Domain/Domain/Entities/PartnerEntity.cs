namespace Domain.Entities
{
    public class PartnerEntity : Entity
    {
        public string Company { get; set; }

        public string TradingName { get; set; }

        public string RegisterNumber { get; set; }

        public bool Active { get; set; }

        public bool IsHeadquarters { get; set; }
    }
}
