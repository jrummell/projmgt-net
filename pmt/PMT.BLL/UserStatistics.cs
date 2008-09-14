namespace PMT.BLL
{
    public class UserStatistics
    {
        private readonly int _admins;
        private readonly int _clients;
        private readonly int _developers;
        private readonly int _managers;
        private readonly int _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStatistics"/> class.
        /// </summary>
        /// <param name="admins">The admins.</param>
        /// <param name="managers">The managers.</param>
        /// <param name="developers">The developers.</param>
        /// <param name="clients">The clients.</param>
        /// <param name="users">The users.</param>
        public UserStatistics(int admins, int managers, int developers, int clients, int users)
        {
            _admins = admins;
            _managers = managers;
            _developers = developers;
            _clients = clients;
            _users = users;
        }

        public int Users
        {
            get { return _users; }
        }

        public int Clients
        {
            get { return _clients; }
        }

        public int Developers
        {
            get { return _developers; }
        }

        public int Managers
        {
            get { return _managers; }
        }

        public int Admins
        {
            get { return _admins; }
        }
    }
}