namespace CMS.BE.DTO
{
    public class BaseTimeEntity
    {
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string BuildingAddress { get; set; }
        public string RoomCode { get; set; }
        public string ChairmanName { get; set; }
    }
}
