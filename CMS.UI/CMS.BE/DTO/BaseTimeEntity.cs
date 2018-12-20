namespace CMS.BE.DTO
{
    public class BaseTimeEntity
    {
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string RoomCode { get; set; }
        public string ChairName { get; set; }
    }
}
