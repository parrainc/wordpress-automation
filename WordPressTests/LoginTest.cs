﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class LoginTest
    {

        [TestInitialize]
        public void Init() {
            Driver.Initialize();
        }

        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("user")
                .WithPassword("admintoor")
                .Login();
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");

        }

        [TestCleanup]
        public void Cleanup() {
            Driver.Close();
        }
    }
}
