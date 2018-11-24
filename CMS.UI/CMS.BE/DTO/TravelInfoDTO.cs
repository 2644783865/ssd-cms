namespace CMS.BE.DTO
{
    class TravelInfoDTO
    {
        public int TravelInfoID { get; set; }
        public string Title { get; set; }
        public string AirportRoad { get; set; }
        public int AirportRoadTime { get; set; }
        public string RailwayRoad { get; set; }
        public int RailwayRoadTime { get; set; }
        public string TaxiNum { get; set; }
    }
}
