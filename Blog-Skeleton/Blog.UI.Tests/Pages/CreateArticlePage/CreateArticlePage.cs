using System;
using OpenQA.Selenium;
using System.IO;
using System.Text;

namespace Blog.UI.Tests.Pages.CreateArticlePage
{
    public partial class CreateArticlePage : BasePage
    {
        public CreateArticlePage(IWebDriver driver) : base(driver)
        {

        }

        public void CreatePost(string title)
        {
            StringBuilder builder = new StringBuilder("Dummy Post: ");
            for (int i = 0; i < 10; i++)
            {
                builder.Append(GetRandomString()).Append(" ");
            }
            string content = builder.ToString();

            this.Type(this.titleField, title);
            this.Type(this.contentField, content);
            this.createBtn.Click();
        }
        
        public string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }
    }
}