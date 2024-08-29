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

        public static StoreDto Mapping(Store store)
        {
            return new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Country = (CountryDto)store.Country,
                State = (StateDto)store.State,
                City = (CityDto)store.City,
                Image = store.Image
            };
        }

        public static List<StoreDto> Mapping(List<Store> store)
        {
            List<StoreDto> lstStoreDto = new List<StoreDto>();
            foreach (Store storeObj in store)
            {
                lstStoreDto.Add(Mapping(storeObj));
            }
            return lstStoreDto;
        }

        public static Store Mapping(StoreDto storeDto)
        {
            return new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Country = (Country)storeDto.Country,
                State = (State)storeDto.State,
                City = (City)storeDto.City,
                Image = storeDto.Image

            };
        }
        public static List<Store> Mapping(List<StoreDto> StoreDto)
        {
            List<Store> lstStore = new List<Store>();
            foreach (StoreDto storeDtoObj in StoreDto)
            {
                lstStore.Add(Mapping(storeDtoObj));
            }
            return lstStore;
        }


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
