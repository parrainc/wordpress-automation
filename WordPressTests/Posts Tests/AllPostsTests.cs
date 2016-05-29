using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordPressAutomation;

namespace WordPressTests.Posts_Tests
{
    [TestClass]
    public class AllPostsTests : BaseClass
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added Post show up, Title")
                        .WithBody("Body of the new added post")
                        .Publish();

            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, 
                            ListPostsPage.CurrentPostsCount, 
                            "Count of posts did not increase"
                            );

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Added Post show up, Title"));

            ListPostsPage.TrashPostOnHover("Added Post show up, Title");
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostsCount, "Couldn't Trash Post");
             
        }
    }
}
