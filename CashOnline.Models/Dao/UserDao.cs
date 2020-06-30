using CashOnline.Models.EF;
using System.Linq;

namespace CashOnline.Models.Dao
{

    public class UserDao
    {
        private readonly CashOnlineDbContext _dbContext = null;

        public UserDao()
        {
            _dbContext = new CashOnlineDbContext();
        }


        public long Insert(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string passWord)
        {
            var result = _dbContext.Users
                .Count(x => x.UserName == userName && x.Password == passWord);
            if (result > 0)
            {
                return true; ;
            }
            else
            {
                return false;
            }

        }
    }
}
