﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WordPressAutomation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            var menuPosts = Driver.Instance.FindElement(By.Id("menu-posts"));
            menuPosts.Click();

            var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));
            addNew.Click();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            var h = Driver.Instance.FindElement(By.ClassName("edit-slug"));
                return h.Text == "Edit";
        }

        public static string Title { 
            get {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            } 
        }
    }

    public class CreatePostCommand {
        private readonly string title;
        private string body;
        public CreatePostCommand(string title) {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body) {
            this.body = body;
            return this;
        }

        public void Publish() {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(1));

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }
    }
}
