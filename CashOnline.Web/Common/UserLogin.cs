using System;

namespace CashOnline.Web.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
    }
}
