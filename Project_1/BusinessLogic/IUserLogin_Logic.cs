using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface IUserLogin_Logic
    {
        public bool UserLogin(string eMail, string pass , string id);
    }
}
