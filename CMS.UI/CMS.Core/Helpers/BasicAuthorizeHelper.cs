using System;
using System.Net.Http.Headers;
using System.Text;

namespace CMS.Core.Helpers
{
    public static class BasicAuthorizeHelper
    {
        public static readonly string credentialsJoined = AppSettings.BasicAPIUsername + ":" + AppSettings.BasicAPIPassword;

        public static readonly string credentialsInBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentialsJoined));

        public static AuthenticationHeaderValue generateAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("Basic", credentialsInBase64);
        }
    }
}
