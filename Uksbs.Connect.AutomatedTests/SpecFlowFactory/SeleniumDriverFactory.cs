using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Uksbs.Connect.AutomatedTests.Common;

namespace Uksbs.Connect.AutomatedTests.SpecFlowFactory
{
    public class SeleniumContext
    {
        public SeleniumContext()
        {
            ConfigurationReader.Read();
            SeleniumDriver seleniumDriver = new SeleniumDriver();
            WebDriver = seleniumDriver.CreateDriver(Convert.ToBoolean(Settings.HeadlessBrowser));
            WebDriver.Manage().Window.Maximize();

        }

        public IWebDriver WebDriver { get; private set; }
    }
}
