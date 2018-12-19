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
            Account = null;
            Username = string.Empty;
            Conference = null;
            Roles.Clear();
            Conferences.Clear();
            Author = null;
        }

        public static AccountDTO Account { get; set; }

        public static string Username { get; set; }

        public static ConferenceDTO Conference { get; set; }

        public static List<ConferenceDTO> Conferences { get; set; }

        public static List<RoleDTO> Roles { get; set; }

        public static AuthorDTO Author { get; set; } = null;
    }
}
