using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Security;
using PMT.BLL;

namespace PMT.Web
{
    /// <summary>
    /// A <see cref="RoleProvider"/> implementation for Project Management.Net.
    /// </summary>
    /// <remarks>
    /// Since Project Management.Net users have only one role, and the ASP.Net default provider allows multiple roles, 
    /// I've created a custom <see cref="RoleProvider"/>.
    /// </remarks>
    public class PmtRoleProvider : RoleProvider
    {
        private readonly string[] _roleNames;
        private readonly UserService _userService = new UserService();

        /// <summary>
        /// Initializes a new instance of the <see cref="PmtRoleProvider"/> class.
        /// </summary>
        public PmtRoleProvider()
        {
            UserRole[] values = (UserRole[]) Enum.GetValues(typeof (UserRole));
            List<UserRole> list = new List<UserRole>(values);
            _roleNames = list.ConvertAll(role => role.ToString()).ToArray();
        }

        public override string ApplicationName
        {
            get { return "Project Management.Net"; }
            set { throw new NotSupportedException(); }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            if (roleName == null)
            {
                throw new ArgumentNullException("roleName");
            }

            UserRole role = (UserRole) Enum.Parse(typeof (UserRole), roleName);

            User user = _userService.GetByID(username);

            if (user == null)
            {
                return false;
            }

            return user.Role == role;
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            User user = _userService.GetByID(username);

            if (user == null)
            {
                return new string[0];
            }

            return new[] {user.Role.ToString()};
        }

        public override void CreateRole(string roleName)
        {
            throw new NotSupportedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotSupportedException();
        }

        public override bool RoleExists(string roleName)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException("roleName");
            }

            try
            {
                Enum.Parse(typeof (UserRole), roleName, true);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotSupportedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotSupportedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException("roleName");
            }

            Collection<User> users = _userService.GetByRole((UserRole) Enum.Parse(typeof (UserRole), roleName));
            return users.ToList().ConvertAll(user => user.Username).ToArray();
        }

        public override string[] GetAllRoles()
        {
            return _roleNames;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotSupportedException();
        }
    }
}