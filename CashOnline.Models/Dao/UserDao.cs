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
        public static int Login(string userName, string passWord)
        {
            var result = DbContext.Users
                .SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }

        }
    }
}
