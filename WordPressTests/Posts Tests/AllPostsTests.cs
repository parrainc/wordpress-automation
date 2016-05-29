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

            PostCreator.CreatePost();

            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, 
                            ListPostsPage.CurrentPostsCount, 
                            "Count of posts did not increase"
                            );

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            ListPostsPage.TrashPostOnHover(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostsCount, "Couldn't Trash Post");
             
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            PostCreator.CreatePost();

            ListPostsPage.GoTo(PostType.Posts);

            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            ListPostsPage.TrashPostOnHover(PostCreator.PreviousTitle);
        }
    }
}
