using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordPressAutomation
{
    public class LeftNavigation
    {

        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "Add New");
                }
            }
        }

        public class Pages {
            public class AllPages {
                public static void Select() {
                    MenuSelector.Select("menu-pages");
                }
            }
        }

        public class MenuSelector {

            public static void Select(string topLevelMenuId) {
                Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();
            }
            public static void Select(string topLevelMenuId, string subMenuLinkText)
            {
                Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();
                Driver.Instance.FindElement(By.LinkText(subMenuLinkText)).Click();
            }
        }

    }
}
