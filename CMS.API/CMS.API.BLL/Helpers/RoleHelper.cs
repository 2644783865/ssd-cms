using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Helpers
{
    public static class RoleHelper
    {
        public static IEnumerable<RoleDTO> FilterRolesForHRManagerToAssign(List<RoleDTO> roles)
        {
            var allowedRoles = new List<string>()
            {
                Properties.RoleResources.AwardsCoordinator,
                Properties.RoleResources.ConferenceStaffMember,
                Properties.RoleResources.InformationStaff,
                Properties.RoleResources.Presenter,
                Properties.RoleResources.Reviewer,
                Properties.RoleResources.SessionChair,
                Properties.RoleResources.WelcomePackStaff,
                Properties.RoleResources.Editor
            };

            foreach (var allowedRole in allowedRoles)
            {
                yield return roles.Find(role => role.Name.Equals(allowedRole));
            }
        }
    }
}
