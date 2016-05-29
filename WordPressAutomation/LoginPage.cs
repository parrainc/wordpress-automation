﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordPressAutomation
{
    public class LoginPage
    {

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "wp-login.php");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10))
                .Until(d => d.SwitchTo()
                    .ActiveElement()
                    .GetAttribute("id") == "user_login"
                 );
            
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }

    public class LoginCommand {
        private readonly string userName;
        private string password;

        public LoginCommand(string userName) {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password) {
            this.password = password;
            return this;
        }

        public void Login() {
            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            loginInput.SendKeys(userName);

            var passInput = Driver.Instance.FindElement(By.Id("user_pass"));
            passInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();
        }
    }
}
