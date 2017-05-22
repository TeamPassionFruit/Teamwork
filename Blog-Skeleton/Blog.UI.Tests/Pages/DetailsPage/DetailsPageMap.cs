using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.DetailsPage
{
    public partial class DetailsPage
    {
        //Ilko
        public IWebElement EditButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.LinkText("Edit")));
            }
        }

        //Ilko
        public IWebElement DeleteButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.LinkText("Delete")));
            }
        }
    }
}
