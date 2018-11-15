namespace CMS.API.BLL.Models.Authentication
{
    public class ChangePasswordModel : LoginModel
    {
        public string NewPassword { get; set; }
    }
}