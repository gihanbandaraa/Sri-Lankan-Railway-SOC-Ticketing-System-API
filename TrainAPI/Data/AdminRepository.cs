using TrainAPI.Model;
namespace TrainAPI.Data
{
    public class AdminRepository
    {
        private AppDBContext _dbContext;

        public AdminRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateAdmin(Admin admin)
        {
            if (admin != null)
            {
                _dbContext.admins.Add(admin);
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
        public bool UpdateUser(Admin admin)
        {
            _dbContext.admins.Update(admin);
            return Save();
        }

        public bool IsValidUser(string username, string password)
        {
          
            return _dbContext.admins.Any(admin=> admin.Username == username && admin.Password == password);
        }
        public IEnumerable<Admin> GetAllAdmins()
        {
            return _dbContext.admins.ToList();
        }

        public bool RemoveBooking(Admin admin)
        {
            _dbContext.admins.Remove(admin);
            return Save();
        }
        public Admin GetAdmin(int id)
        {
            return _dbContext.admins.FirstOrDefault(user => user.UserID == id);
        }
    }
}
