using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Models
{
    public class RegistrationUser
    {
        private string еmail;
        private string fullName;
        private string password;
        private string confirmPassword;

        public RegistrationUser(String еmail,
                                String fullName,
                                String password,
                                String confirmPassword)
        {
            this.еmail = еmail;
            this.fullName = fullName;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }

        public string Еmail
        {
            get { return this.еmail; }
            set { this.еmail = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }


        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { this.confirmPassword = value; }
        }
    }
}
