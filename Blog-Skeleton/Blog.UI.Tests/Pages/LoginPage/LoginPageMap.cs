using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.Login
{
    public partial class LoginPage : BasePage
    {
        public IWebElement Header
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.ClassName("navbar-brand")));
            }
        }

        public IWebElement LogInLink
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.Id("loginLink")));
            }
        }



        public IWebElement LogInTitle
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.TagName("title")));
            }
        }

        public IWebElement EmailAdress
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.Id("Email")));
            }
        }

        public IWebElement Password
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.Id("Password")));
            }
        }

        public IWebElement RememberMeCheckBox
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.Id("RememberMe")));
            }
        }

        public IWebElement RememberMe
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/div/div/label")));
            }
        }

        public IWebElement LogInButton
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")));
            }
        }

        public IWebElement Hello
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
            }
        }

        public IWebElement LogOff
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")));
            }
        }

        public IWebElement NoEmailAddressOrInvalidEmailAddressFormat
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span")));
            }
        }

        public IWebElement InvalidLogInAttempt
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
            }
        }



        public IWebElement PasswordFieldRequired
        {
            get

            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span")));
            }
        }

        //Ilko
        public IWebElement LoginHeading
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//h2[contains(text(),'Log in')]")));
            }
        }


    }
}
