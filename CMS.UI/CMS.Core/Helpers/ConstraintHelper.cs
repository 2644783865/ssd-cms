using System.Text.RegularExpressions;

namespace CMS.Core.Helpers
{
    public class ConstraintHelper
    {
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^[0-9|\+|\s]*$");
            Match match = regex.Match(phoneNumber);
            return match.Success;
        }
    }
}
