using System;
using System.Collections.Generic;
using System.Text;

namespace ZipWork
{
    class SeleniumTech
    {

        public void TestNewCode()
        {
            using (var driver = new OpenQA.Selenium.Chrome.ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.google.com/");
                var searchBox = driver.FindElement(OpenQA.Selenium.By.XPath("//input[@class='gLFyf gsfi']"));
                searchBox.SendKeys("webdriver example c#");
                searchBox.SendKeys(OpenQA.Selenium.Keys.Return);



                System.Threading.Thread.Sleep(500);
                var searchDiv = driver.FindElement(OpenQA.Selenium.By.Id("search"));
                var firstlink = searchDiv.FindElement(OpenQA.Selenium.By.TagName("a"));
                firstlink.Click();



                System.Threading.Thread.Sleep(10000);



            }
        }

    }
}
