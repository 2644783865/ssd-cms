namespace CMS.BE.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
