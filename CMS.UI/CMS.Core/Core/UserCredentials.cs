using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.Core.Core
{
    public static class UserCredentials
    {
        static UserCredentials()
        {
            Roles = new List<RoleDTO>();
            Conferences = new List<ConferenceDTO>();
        }

        public static void Clear()
        {
            AccountId = -1;
            Username = string.Empty;
            ConferenceId = -1;
            Roles.Clear();
            Conferences.Clear();
            IsAuthor = false;
        }

        public static int AccountId { get; set; }

        public static string Username { get; set; }

        public static int ConferenceId { get; set; }

        public static List<ConferenceDTO> Conferences { get; set; }

        public static List<RoleDTO> Roles { get; set; }

        public static bool IsAuthor { get; set; } = false;
    }
}
