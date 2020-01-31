using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ZipWork
{
    class SeleniumTech
    {

        public void TestNewCode(string UrlPath)
        {
            
            using (var driver = new OpenQA.Selenium.Chrome.ChromeDriver())
            {
                UrlPath = "https://classifiedwebpath/" + UrlPath;

                driver.Navigate().GoToUrl(UrlPath);

                System.Threading.Thread.Sleep(5000);
                
                //var WebElemAttach = driver.FindElement(OpenQA.Selenium.By.ClassName("item-attachments"));

                IWebElement PageElements = driver.FindElement(By.ClassName("item-attachments"));
                var myAttach = PageElements.FindElements(By.TagName("li"));
                foreach (var item in myAttach)
                {
                    Console.WriteLine(item.Text);
                    item.Click();
                    Console.WriteLine("Downloading File...");
                    System.Threading.Thread.Sleep(2000);
                }

                System.Threading.Thread.Sleep(500);
                var searchDiv = driver.FindElement(OpenQA.Selenium.By.Id("search"));
                var firstlink = searchDiv.FindElement(OpenQA.Selenium.By.TagName("a"));
                firstlink.Click();


    
                System.Threading.Thread.Sleep(10000);
                


            }
        }

    }
}
