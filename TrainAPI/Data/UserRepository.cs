using TrainAPI.Model;

namespace TrainAPI.Data
{
    public class UserRepository
    {
        private AppDBContext _dbContext;

        public UserRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public bool CreateUser(Users user)
        {
            if (user != null)
            {
                _dbContext.users.Add(user);
                return Save();
            }
            else
                return false;
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateUser(Users user)
        {
            _dbContext.users.Update(user);
            return Save();
        }

        public bool RemoveUser(Users user)
        {
            _dbContext.users.Remove(user);
            return Save();
        }

        public Users GetUser(int id)
        {
            return _dbContext.users.FirstOrDefault(user => user.UserID == id);
        }
        public bool IsNICAlreadyRegistered(string nic)
        {

            return _dbContext.users.Any(user => user.NIC == nic);
        }

        public bool IsValidUser(string username, string password)
        {

            return _dbContext.users.Any(user => user.Username == username && user.Password == password);
        }
        public IEnumerable<Users> GetAllUsers()
        {
            return _dbContext.users.ToList();
        }
    }
}
