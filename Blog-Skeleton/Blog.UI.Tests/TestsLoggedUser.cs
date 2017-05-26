using Blog.UI.Tests.Pages.ArticleDetailsPage;
using Blog.UI.Tests.Pages.CreateArticlePage;
using Blog.UI.Tests.Pages.DeleteArticlePage;
using Blog.UI.Tests.Pages.EditArticlePage;
using Blog.UI.Tests.Pages.HomePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Blog.UI.Tests
{
    [TestFixture]
    class TestsLoggedUser
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string pathToProject = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string filename = pathToProject + ConfigurationManager.AppSettings["RelativeLogs"]
                                    + "\\" + TestContext.CurrentContext.Test.Name;
                string filenameTxt = filename + ".txt";
                if (File.Exists(filenameTxt))
                {
                    File.Delete(filenameTxt);
                }
                File.WriteAllText(filenameTxt, TestContext.CurrentContext.Test.FullName + Environment.NewLine
                                            + TestContext.CurrentContext.Result.Message + Environment.NewLine);

                string filenameJpg = filename + ".jpg";
                if (File.Exists(filenameJpg))
                {
                    File.Delete(filenameJpg);
                }
                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filenameJpg, ScreenshotImageFormat.Jpeg);
            }
            
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void LoggedUserShouldCreatePost()
        {   
            //Arange
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.CheckForLogin(this.driver);
          
            //Act
            homePage.Click(homePage.createLink);
            var createArticlePage = new CreateArticlePage(this.driver);
            createArticlePage.CreatePost("DummyTitle");
                                    
            //Assert
            homePage.AssertBlogPostTitle("DummyTitle");
            homePage.logoutLink.Click();
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void LoggedUserShouldEditOwnPost()
        {
            //Arange
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.CheckForLogin(this.driver);

            //Act
            homePage.Click(homePage.createLink);
            var createArticlePage = new CreateArticlePage(this.driver);
            createArticlePage.CreatePost("DummyTitle");
            homePage.Click(homePage.blogPostsTitle);
            var articleDetailsPage = new ArticleDetailsPage(this.driver);
            articleDetailsPage.Click(articleDetailsPage.editBtn);
            var editArticlePage = new EditArticlePage(this.driver);
            editArticlePage.ChangePostTitle("NewPostTitle");

            //Assert
            homePage.AssertBlogPostTitleNew("NewPostTitle");
            homePage.logoutLink.Click();
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void LoggedUserShouldNotEditOthersPost()
        {
            //Arange
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.CheckForLogin(this.driver);

            //Act
            homePage.Click(homePage.blogPostsTitleOther);
            var articleDetailsPage = new ArticleDetailsPage(this.driver);
            articleDetailsPage.Click(articleDetailsPage.editBtn);
            var error = driver.FindElement(By.XPath("//*[@id='content']/div[1]/h3")).Displayed;

            //Assert
            Assert.AreEqual(true, error);
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void LoggedUserShouldDeleteOwnPost()
        {
            //Arange
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.CheckForLogin(this.driver);

            //Act
            homePage.Click(homePage.createLink);
            var createArticlePage = new CreateArticlePage(this.driver);
            createArticlePage.CreatePost("DummyTitleDelete");
            homePage.Click(homePage.blogPostsTitleDelete);
            var articleDetailsPage = new ArticleDetailsPage(this.driver);
            articleDetailsPage.Click(articleDetailsPage.deleteBtn);
            var deleteArticlePage = new DeleteArticlePage(this.driver);
            deleteArticlePage.deleteBtn.Click();

            //Assert
            homePage.AssertBlogPostTitleDelete("DummyTitleDelete");
            homePage.logoutLink.Click();
        }


    }
}
