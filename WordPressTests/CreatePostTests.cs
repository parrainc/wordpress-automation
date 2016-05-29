using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class CreatePostTests : BaseClass
    {
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test Post Title, Again")
                .WithBody("Hi, This is the body of the post!")
                .Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test Post Title, Again", "Title did not match new post");

        }
    }
}
