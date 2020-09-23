using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWallet.Models;

namespace VirtualWallet.Utilities
{
    public class RoleHelper
    {
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
        (new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool IsUserInRole(string userId, string roleName)
        {
            return userManager.IsInRole(userId, roleName);
        }

        public ICollection<string> ListUserRoles(string userId)
        {
            return userManager.GetRoles(userId);
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var result = userManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }

        public bool RemoveUserFromRole(string userId, string roleName)
        {
            var result = userManager.RemoveFromRole(userId, roleName);
            return result.Succeeded;
        }

        public bool UpdateUserRole(string userId, string roleName)
        {
            var currentRoles = ListUserRoles(userId);
            if(currentRoles.Count != 0)
            {
                foreach(var role in currentRoles)
                {
                    RemoveUserFromRole(userId, role);
                }
            }
            return AddUserToRole(userId, roleName);
           
        }

        public ICollection<ApplicationUser> UsersInRole(string roleName)
        {
            var resultList = new List<ApplicationUser>();
            var List = userManager.Users.ToList();
            foreach (var user in List)
            {
                if (IsUserInRole(user.Id, roleName))
                    resultList.Add(user);
            }
            return resultList;
        }

        public ICollection<ApplicationUser> UsersNotInRole(string roleName)
        {
            var resultList = new List<ApplicationUser>();
            var List = userManager.Users.ToList();
            foreach (var user in List)
            {
                if (!IsUserInRole(user.Id, roleName))
                    resultList.Add(user);
            }
            return resultList;
        }

        public ICollection<string> ListRoles()
        {
            var resultList = new List<string>();

            foreach (var role in db.Roles)
            {
                resultList.Add(role.Name);
            }

            return resultList;
        }
    }
}