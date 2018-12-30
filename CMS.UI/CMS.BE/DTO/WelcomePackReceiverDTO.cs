namespace CMS.BE.DTO
{
    public class WelcomePackReceiverDTO
    {
        public int WelcomePackReceiverId { get; set; }
        public int ConferenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public bool GetGift { get; set; }
    }
}
