namespace CMS.BE.DTO
{
    public class AccommodationInfoDTO
    {
        public int AccommodationIntoId { get; set; }
        public int ConferenceId { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string City { get; set; }
        public string CityDesc { get; set; }
    }
}
