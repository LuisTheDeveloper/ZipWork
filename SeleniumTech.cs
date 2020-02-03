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
                UrlPath = "https://confidentialPath.co.uk/browse/" + UrlPath;

                driver.Navigate().GoToUrl(UrlPath);

                System.Threading.Thread.Sleep(15000);

                IWebElement PageElements = driver.FindElement(By.ClassName("item-attachments"));
                var myAttach = PageElements.FindElements(By.TagName("li"));
                foreach (var item in myAttach)
                {
                    Console.WriteLine(item.Text);
                    Console.WriteLine(item.GetAttribute("data-downloadurl").ToString());
                    if (item.GetAttribute("data-downloadurl").ToString().StartsWith("application/zip:"))
                    {
                        item.Click();
                        System.Threading.Thread.Sleep(3000);
                        Console.WriteLine("Downloading File...");
                    }
                }
            }
        }

    }
}
