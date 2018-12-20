namespace CMS.BE.DTO
{
    public class BaseEntryEntity
    {
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string BuildingName { get; set; }
        public string RoomCode { get; set; }
        public string AccountName { get; set; }
    }
}
