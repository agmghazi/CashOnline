using CashOnline.Models.EF;
using System.Linq;

namespace CashOnline.Models.Dao
{

    public static class UserDao
    {
        private static readonly CashOnlineDbContext DbContext = null;

        static UserDao()
        {
            DbContext = new CashOnlineDbContext();
        }


        public static long Insert(User entity)
        {
            DbContext.Users.Add(entity);
            DbContext.SaveChanges();
            return entity.ID;
        }

        public static User GetById(string userName)
        {
            return DbContext.Users
                .SingleOrDefault(x => x.UserName == userName);
        }
        public static bool Login(string userName, string passWord)
        {
            var result = DbContext.Users
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
