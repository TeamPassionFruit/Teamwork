using System;
using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.EditArticlePage
{
    public partial class EditArticlePage : BasePage
    {
        public EditArticlePage(IWebDriver driver) : base(driver)
        {

        }

        public void ChangePostTitle(string newTitle)
        {
            this.Type(this.postTitle, newTitle);
            this.editBtn.Click();
        }
    }
}