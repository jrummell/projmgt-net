using System;
using System.Collections.Generic;

namespace PMT.BLL
{
    public class UserStatistics
    {
        private readonly int _newUsers;
        private readonly IDictionary<UserRole, int> _roleCounts;
        private readonly int _totalUsers;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStatistics"/> class.
        /// </summary>
        /// <param name="roleCounts">The role counts.</param>
        /// <param name="totalUsers">The total users.</param>
        /// <param name="newUsers">The new users.</param>
        internal UserStatistics(IDictionary<UserRole, int> roleCounts, int totalUsers, int newUsers)
        {
            if (roleCounts == null)
            {
                throw new ArgumentNullException("roleCounts");
            }
            _roleCounts = roleCounts;
            _totalUsers = totalUsers;
            _newUsers = newUsers;
        }

        /// <summary>
        /// Gets the total users.
        /// </summary>
        /// <value>The total users.</value>
        public int TotalUsers
        {
            get { return _totalUsers; }
        }

        /// <summary>
        /// Gets the new users.
        /// </summary>
        /// <value>The new users.</value>
        public int NewUsers
        {
            get { return _newUsers; }
        }

        /// <summary>
        /// Gets the role counts.
        /// </summary>
        /// <value>The role counts.</value>
        public IDictionary<UserRole, int> RoleCounts
        {
            get { return _roleCounts; }
        }
    }
}