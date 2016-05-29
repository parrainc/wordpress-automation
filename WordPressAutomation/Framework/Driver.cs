using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
namespace WordPressAutomation
{
    public class Driver
    {
        public static string BaseAddress {
            get {
                return "http://localhost/wordpress/";
            }
        }
        public static IWebDriver Instance { get; set; }

        public static void Initialize() {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            //Instance.Close();
        }

        internal static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) timeSpan.TotalSeconds * 1000);
        }
    }
}
