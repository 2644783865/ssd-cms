using CMS.BE;
using System;
using System.Collections.Generic;

namespace CMS.Core.Core
{
    public static class UserCredentials
    {
        static UserCredentials()
        {
            Roles = new List<Role>();
            Conferences = new List<BE.Conference>();
        }

        public static void Clear()
        {
            AccountId = -1;
            Username = String.Empty;
            ConferenceId = -1;
            Roles.Clear();
            Conferences.Clear();
            IsAuthor = false;
        }

        public static int AccountId { get; set; }

        public static string Username { get; set; }

        public static int ConferenceId { get; set; }

        public static List<BE.Conference> Conferences { get; set; }

        public static List<Role> Roles { get; set; }

        public static bool IsAuthor { get; set; } = false;
    }
}
