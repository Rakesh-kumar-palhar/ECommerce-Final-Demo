namespace ECommerce_Final_Demo.Model.DTO
{
    public class StoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CountryDto Country { get; set; }
        public StateDto State { get; set; }
        public CityDto City { get; set; }
        public string? Image { get; set; }
       
    }
    public enum CountryDto
    {
        USA,
        India
    }

    public enum StateDto
    {
        California,
        Chicago,
        Maharashtra,
        Ahmedabad
    }

    public enum CityDto
    {
        LosAngeles,
        Toronto,
        Mumbai,
        AnandNagar
    }
}
