using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class CreatePostTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            #region Login
            LoginPage.GoTo();
            LoginPage.LoginAs("user")
                .WithPassword("admintoor")
                .Login();
            #endregion

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test Post Title")
                .WithBody("Hi, This is the body of the post!")
                .Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test Post Title", "Title did not match new post");

        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
