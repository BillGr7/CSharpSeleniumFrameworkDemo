using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    abstract class TestClass //abstract class to be inherited by other tests
    {
        public IWebDriver driver; //drive for the browser being used        

        [SetUp]
        abstract public void StartBrowser();

        [Test]
        public virtual void Test() //base test to confirm setup of subsequent classes
        {
            driver.Url = "http://www.google.com";
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
    
    class ChromeTestClass : TestClass
    {
        public static string chromeDriverPath = "G:\\Visual Studio 2019 projects\\DemoProject"; //replace this path with location of chromedriver.exe

        [SetUp]
        override public void StartBrowser()
        {
            driver = new ChromeDriver(chromeDriverPath);            
        }
    }
    class FirefoxTestClass : TestClass
    {
        //public static string chromeDriverPath = "G:\\Visual Studio 2019 projects\\DemoProject"; //replace this path with location of chromedriver.exe

        [SetUp]
        override public void StartBrowser()
        {
            driver = new FirefoxDriver();
        }
    }

    class Qxf2FormTest_Chrome : ChromeTestClass
    {
        [Test]
        override public void Test()
        {
            driver.Url = "https://qxf2.com/selenium-tutorial-main";
            
            IWebElement formName = driver.FindElement(By.XPath("//*[@id='name']"));
            formName.SendKeys("abc123");

            IWebElement formEmail = driver.FindElement(By.XPath("//*[@id='myform']/div[2]/input"));
            formEmail.SendKeys("def456@ghi789.com");

            IWebElement formPhoneNumber = driver.FindElement(By.XPath("//*[@id='phone']"));
            formPhoneNumber.SendKeys("1234567890");

            IWebElement formCheckbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            formCheckbox.Click();

            IWebElement formGender = driver.FindElement(By.XPath("//button[@data-toggle='dropdown']"));
            formGender.Click();
            IWebElement selectMale = driver.FindElement(By.XPath("//a[text()='Male']"));
            selectMale.Click();
            formGender.Click();
            IWebElement selectFemale = driver.FindElement(By.XPath("//a[text()='Female']"));
            selectFemale.Click();

            //Uncomment for visual confirmation before submit
            //System.Threading.Thread.Sleep(3000);
            
            IWebElement formSubmit = driver.FindElement(By.XPath("//*[@id='myform']/p/button"));
            formSubmit.Click();
            
            //Uncomment for visual confirmation after submit
            //System.Threading.Thread.Sleep(3000);
        }
    }
}