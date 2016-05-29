using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordPressAutomation;

namespace WordPressTests
{
    public class BaseClass
    {
        [TestInitialize]
        public void Init() {
            Driver.Initialize();
            #region login
            LoginPage.GoTo();
            LoginPage.LoginAs("user")
                        .WithPassword("admintoor")
                        .Login();
            #endregion

        }

        [TestCleanup]
        public void Cleanup() {
            Driver.Close();
        }
    }
}
