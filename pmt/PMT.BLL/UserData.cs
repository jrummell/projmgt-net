using System;
using System.Collections.Generic;
using System.Text;
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;

namespace PMT.BLL
{
    public class UserData
    {
        private UsersTableAdapter taUsers;
        private UserInfoTableAdapter taUserInfo;
        private UserManagersTableAdapter taUserManagers;
        private UserProjectsTableAdapter taUserProjects;
        private CompleteUserInfoTableAdapter taCompleteUserInfo;

        public UserData()
        {
            taUsers = new UsersTableAdapter();
            taUserInfo = new UserInfoTableAdapter();
            taUserManagers = new UserManagersTableAdapter();
            taUserProjects = new UserProjectsTableAdapter();
            taCompleteUserInfo = new CompleteUserInfoTableAdapter();
        }
    
        /// <summary>
        /// Get a User by id
        /// </summary>
        /// <param name="id">user id</param>
        public User GetUser(int id)
        {
            return GetUser(id, null);
        }

        /// <summary>
        /// Get a User by username
        /// </summary>
        /// <param name="userName">username</param>
        public User GetUser(string userName)
        {
            return GetUser(0, userName);
        }

        /// <summary>
        /// Inserts a new User
        /// </summary>
        /// <returns>the inserted user's id</returns>
        public int InsertUser(User user)
        {
            // add to users and get new id
            int id = (int)taUsers.InsertUser(user.UserName, (short)user.GetRole(), (short)(user.Enabled ? 1 : 0), user.Password);
            // add user info
            taUserInfo.Insert(id, user.FirstName, user.LastName, user.Address, user.City,
                user.State, user.ZipCode, user.PhoneNumber, user.Email);

            return id;
        }

        /// <summary>
        /// Deletes a User by their id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>true if successfull</returns>
        public bool DeleteUser(int id)
        {
            int rows = taUsers.Delete(id);

            if (rows == 1)
            {
                rows = taUserInfo.Delete(id);

                if (rows == 1)
                {
                    taUserManagers.DeleteByUserID(id);
                    taUserProjects.DeleteByUserID(id);
                }
            }

            return rows == 1;
        }

        /// <summary>
        /// Updates a user by their id
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if sucessfull</returns>
        public bool UpdateUser(User user)
        {
            int rows = taUsers.Update(user.UserName, (short)user.GetRole(), (short)(user.Enabled ? 1:0),
                user.Password, user.ID, user.ID);

            if (rows == 1)
            {
                rows = taUserInfo.Update(user.ID, user.FirstName, user.LastName, user.Address,
                    user.City, user.State, user.ZipCode, user.PhoneNumber, user.Email, user.ID);
            }

            return rows == 1;
        }

        private User GetUser(int id, string userName)
        {
            User user = null;

            UsersDataSet.CompleteUserInfoDataTable dt;

            if (userName == null)
                dt = taCompleteUserInfo.GetCompleteUserInfoByID(id);
            else
                dt = taCompleteUserInfo.GetCompleteUserInfoByUserName(userName);

            if (dt.Rows.Count == 0)
                return null;

            UsersDataSet.CompleteUserInfoRow row = dt[0];

            user = User.CreateUser((UserRole)row.Role);
            user.ID = row.ID;
            user.UserName = row.UserName;
            user.Enabled = row.Enabled == 1 ? true : false;
            user.FirstName = row.FirstName;
            user.LastName = row.LastName;
            user.Email = row.Email;
            user.Address = row.Address;
            user.City = row.City;
            user.State = row.State;
            user.ZipCode = row.Zip;
            user.PhoneNumber = row.PhoneNumber;

            return user;
        }

        public bool AuthenticateUser(string username, string password)
        {
            return 1 == (int)taUsers.AuthenticateUser(username, password);
        }

        public bool UserNameExists(string username)
        {
            return taUsers.GetUserByUserName(username).Rows.Count != 0;
        }
    }
}
