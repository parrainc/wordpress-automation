using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordPressAutomation
{
    public class Class1
    {
        public void Go() {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://google.com");
        }
    }
}
