using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWallet.Models;

namespace VirtualWallet.Utilities
{
    public class UserHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleHelper roleHelper = new RoleHelper();

        public string GetUserEmail(string userId)
        {
            return db.Users.Find(userId).UserName;
        }

        public string GetFullName(string userId)
        {
            var user = db.Users.Find(userId);
            return user.FullName;
        }

        public string LastNameFirst(string userId)
        {
            var user = db.Users.Find(userId); ;
            var firstName = user.FirstName;
            var lastName = user.LastName;
            return lastName + " " + firstName;

        }
        public string GetAvatarPath(string userId)
        {
            var user = db.Users.Find(userId);
            return user.AvatarPath;
        }
    }
}