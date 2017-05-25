using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TestStack.Seleno.Configuration;

namespace Blog.UI.Tests
{
    class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";

        static BrowserHost()
        {
            //Instance.Run("Blog", 10639);

            //var options = new ChromeOptions();
            //options.AddUserProfilePreference("credentials_enable_service", false);
            //options.AddUserProfilePreference("profile.password_manager_enabled", false);
                                   
            Instance.Run("Blog", 10639, w => w.WithRemoteWebDriver(() => new ChromeDriver()));
           
            RootUrl = Instance.Application.Browser.Url;



        }
    }
}