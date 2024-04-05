using TrainAPI.Model;

namespace TrainAPI.Data
{
    public class BookedUserRepository
    {
        private AppDBContext _dbContext;

        public BookedUserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateBookedUser(BookedUsers users)
        {
            if (users != null)
            {
                _dbContext.BookedUsers.Add(users);
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
        public bool CheckIfExists(string trainId, string date, string nic)
        {
          
            return _dbContext.BookedUsers.Any(u => u.TrainId == trainId && u.Date == date && u.NIC == nic);
        }
    }
}
