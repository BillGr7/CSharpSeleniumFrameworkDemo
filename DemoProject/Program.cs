using System;
using TestFramework;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoProject
{
    public class Program : TestCore
    {
        public Program():base (BrowserType.CHROME, "https://qxf2.com/selenium-tutorial-main") { }

        [Test]
        public void Qxf2Test()
        {
            Assert.IsTrue(Browsers.getDriver.Title.Contains("Qxf2"));

            IWebElement formName = Browsers.getDriver.FindElement(By.XPath("//*[@id='name']"));
            formName.SendKeys("abc123");

            IWebElement formEmail = Browsers.getDriver.FindElement(By.XPath("//*[@id='myform']/div[2]/input"));
            formEmail.SendKeys("def456@ghi789.com");

            IWebElement formPhoneNumber = Browsers.getDriver.FindElement(By.XPath("//*[@id='phone']"));
            formPhoneNumber.SendKeys("1234567890");

            IWebElement formCheckbox = Browsers.getDriver.FindElement(By.XPath("//input[@type='checkbox']"));
            formCheckbox.Click();

            IWebElement formGender = Browsers.getDriver.FindElement(By.XPath("//button[@data-toggle='dropdown']"));
            formGender.Click();
            IWebElement selectMale = Browsers.getDriver.FindElement(By.XPath("//a[text()='Male']"));
            selectMale.Click();
            formGender.Click();
            IWebElement selectFemale = Browsers.getDriver.FindElement(By.XPath("//a[text()='Female']"));
            selectFemale.Click();

            //Uncomment for visual confirmation before submit
            //System.Threading.Thread.Sleep(3000);

            IWebElement formSubmit = Browsers.getDriver.FindElement(By.XPath("//*[@id='myform']/p/button"));
            formSubmit.Click();

            //Uncomment for visual confirmation after submit
            //System.Threading.Thread.Sleep(3000);
        }
        
    }
}
