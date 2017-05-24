using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Models
{
    public class LoginUser
    {
        private string emailAddress;
        private string password;


        public LoginUser
            (
            String emailAddress,
            String password
            )
        {
            this.emailAddress = emailAddress;
            this.password = password;
        }

        public LoginUser()
        {
        }

        public string EmailAddress
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }


    }
}
