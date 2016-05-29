﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
namespace WordPressAutomation
{
    public class Driver
    {
        public static string BaseAddress {
            get {
                return "http://localhost/wordpress/";
            }
        }
        public static IWebDriver Instance { get; set; }

        public static void Initialize() {
            Instance = new FirefoxDriver();
            TurnOnWait();
        }

        public static void Close()
        {
            Instance.Close();
        }

        internal static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) timeSpan.TotalSeconds * 1000);
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }
    }
}
