using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Uksbs.Connect.AutomatedTests.SpecFlowFactory
{
    public class SeleniumDriver
    {
        public IWebDriver CreateDriver(bool headlessBrowser)
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            if (headlessBrowser)
            {
                chromeOptions.AddArguments("headless");
                chromeOptions.AcceptInsecureCertificates = true;
            }

              chromeOptions.AddArguments("--no-sandbox");
           // chromeOptions.AddArguments("--incognito");
            IWebDriver webDriver = new ChromeDriver(".", chromeOptions);

            return webDriver;
        }
    }
}
