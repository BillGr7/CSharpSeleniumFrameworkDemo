using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public enum BrowserType
    {
        CHROME,
        IE,
        FIREFOX
    }

    //This abstract class is meant to be inherited by a class in which the test case will be run
    [TestFixture]
    public abstract class TestCore
    {
        BrowserType browser;    //the browser we'll be using for the test
        string baseURL;         //the starting url

        /*This constructor is meant to be set in inherited classes, which will setup the environment for the test case.
         Example:
         public Foo():base (BrowserType.CHROME, "http://www.google.com")  { }
         */
        public TestCore(BrowserType type, string url)
        {
            browser = type;
            baseURL = url;
        }
        [OneTimeSetUp]
        public void startTest()
        {
            Browsers.Init(browser, baseURL);
        }

        [OneTimeTearDown]
        public void endTest()
        {
            Browsers.Close();
        }
        
        //This class is for handling browser management.
        public class Browsers
        {
            private static IWebDriver webDriver;
            
            public static void Init(BrowserType browser, string baseURL)
            {
                switch (browser)
                {
                    case BrowserType.CHROME:
                        webDriver = new ChromeDriver();
                        break;
                    case BrowserType.IE:
                        webDriver = new InternetExplorerDriver();
                        break;
                    case BrowserType.FIREFOX:
                        webDriver = new FirefoxDriver();
                        break;
                }
                webDriver.Manage().Window.Maximize();
                Goto(baseURL);
            }
            public static string Title
            {
                get { return webDriver.Title; }
            }
            public static IWebDriver getDriver
            {
                get { return webDriver; }
            }
            public static void Goto(string url)
            {
                webDriver.Url = url;
            }
            public static void Close()
            {
                webDriver.Quit();
            }
        }

    }
}