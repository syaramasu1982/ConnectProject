using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection.Metadata;
using System.Threading;
using NHibernate.Mapping;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;

namespace Uksbs.Connect.AutomatedTests.Common
{
    public class BasePage : IDisposable
    {
        private bool _disposed;
        public IJavaScriptExecutor JavaScript { get; set; }
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            JavaScript = (IJavaScriptExecutor)WebDriver;
        }

        protected IWebDriver WebDriver { get; }

        /// <summary>
        ///  This method will wait explicitly for the entire page to be loaded
        /// </summary>
        public void LoadEntirePage()
        {
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.LongWaitTime));
            wait.Until((webDriver) => JavaScript.ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void Click(By locator)
        {
            WaitUntilClickable(locator);
            try
            {
                Action click = () =>
                {
                    Find(locator).Click();
                };

                ActionRunner.RunWithRetries(click);

                Thread.Sleep(1000);
            }
            catch
            {
                var click = Find(locator);
                IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                js.ExecuteScript("arguments[0].click();", click);
            }

        }

        public void ClickAndWait(By locator1, By locator2)
        {
            Action click = () =>
            {
                Find(locator1).Click();
                Thread.Sleep(250);
                Find(locator2);
            };

            ActionRunner.RunWithRetries(click);

            Thread.Sleep(1000);

        }
        public void Type(string inputText, By locator)
        {
            try
            {
                Find(locator).Clear();
                Find(locator).SendKeys(inputText);
            }
            catch
            {
                Find(locator).SendKeys(inputText);
            }
            
        }
        public void TypeDate(string inputText, By locator)
        {
            Find(locator).Clear();
            Find(locator).SendKeys(inputText);
            Find(locator).SendKeys(Keys.Escape);
        }

        public void ClickEscape(By locator)
        {
            Find(locator).SendKeys(Keys.Escape);
        }
        public void ClickEnter(By locator)
        {
            Find(locator).SendKeys(Keys.Enter);
        }
        public void ClickTab(By locator)
        {
            Find(locator).SendKeys(Keys.Tab);
        }
        public void PressKeyDown(By locator)
        {
            Find(locator).SendKeys(Keys.ArrowDown);
        }
        public void TypeSearchClick(string inputText, By locator)
        {
            Action selectDropDown = () =>
            {
               // Find(locator).Clear();
                Find(locator).SendKeys(inputText);
                Thread.Sleep(1000);
                Find(locator).SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                Find(locator).SendKeys(Keys.Enter);
                //  Find(locator).SendKeys(Keys.Escape);
            };

            ActionRunner.RunWithRetries(selectDropDown);

            Thread.Sleep(2000);
        }
        public void TypeSearchSelect(string inputText, By locator)
        {

            Action selectDropDown = () =>
            {
                Find(locator).Clear();
                Find(locator).SendKeys(inputText);
                Thread.Sleep(1000);
                Find(locator).SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                Find(locator).SendKeys(Keys.Enter);
                Find(locator).SendKeys(Keys.Tab);
            };

            ActionRunner.RunWithRetries(selectDropDown);

            Thread.Sleep(2000);
        }
        public void ClearAndType(string inputText, By locator)
        {

            Action clearAndType = () =>
            {
                Find(locator).Clear();
                Find(locator).SendKeys(inputText);
                //  Find(locator).SendKeys(Keys.Escape);
            };

            ActionRunner.RunWithRetries(clearAndType);

            Thread.Sleep(2000);
        }
        public void TypeMultiSearchClick(string inputText, By locator)
        {
            Thread.Sleep(1000);
            Find(locator).Click();
            Find(locator).SendKeys(inputText);
            Thread.Sleep(3000);
            Find(locator).SendKeys(Keys.ArrowDown);
            Find(locator).SendKeys(Keys.Enter);
            Find(locator).SendKeys(Keys.Escape);
        }

        public IWebElement Find(By locator)
        {
            IWebElement result = null;

            Action getWebElement = () => {

                //var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));

                //wait.Until(w => w.FindElement(locator));
                WaitUntilVisible(locator);

                result = WebDriver.FindElement(locator);
            };

            ActionRunner.RunWithRetries(getWebElement);

            return result;
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            ReadOnlyCollection<IWebElement> result = null;

            Action getWebElements = () => {

                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));

                wait.Until(w => w.FindElements(locator));

                result = WebDriver.FindElements(locator);
            };

            ActionRunner.RunWithRetries(getWebElements);

            return result;
        }
        public bool IsElementExists(By element)
        {
            try
            {
                WebDriver.FindElement(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsElementPresent(By element)
        {
            bool elementFound = false;

            try
            {
                LoadEntirePage();

                var result = FindExists(element);
                if(result!= null)
                {
                    elementFound = true;
                }
                
            }
            catch (Exception)
            {
             
            }

            return elementFound;
        }
        public IWebElement FindExists(By locator)
        {
            IWebElement result = null;

            Action getWebElement = () => {

                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
                wait.Until(w => w.FindElement(locator));

                if (!WebDriver.FindElement(locator).Size.IsEmpty && WebDriver.FindElement(locator).Displayed)
                {
                    result = WebDriver.FindElement(locator);
                }

            };

            ActionRunner.RunWithRetries(getWebElement);

            return result;
        }

       

        public void Navigate(string url)
        {

            Thread.Sleep(3000);

            WebDriver.Navigate().GoToUrl(url);
        }

        public void VerifyTitle(string pageTitle)
        {
            if (!pageTitle.Equals(WebDriver.Title, StringComparison.InvariantCulture))
            {
                throw new InvalidOperationException("This page is not " + pageTitle + ". The title is: " + WebDriver.Title);
            }
        }

        public void ClickConfirmationOkDialog()
        {
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
            wait.Until(ExpectedConditions.AlertIsPresent());
            WebDriver.SwitchTo().Alert().Accept();
        }

        public void ClickConfirmationCancelDialog()
        {
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
            wait.Until(ExpectedConditions.AlertIsPresent());
            WebDriver.SwitchTo().Alert().Dismiss();
        }
        public string CaptureAlerMessageFromDialog()
        {
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
            wait.Until(ExpectedConditions.AlertIsPresent());
            string result;
            result = WebDriver.SwitchTo().Alert().Text;
            return result;
        }

        public void Hover(By locator)
        {
            Actions builder = new Actions(WebDriver);
            builder.MoveToElement(WebDriver.FindElement(locator)).Click().Build().Perform();
        }

        public void SelectFromDropdown(string text, By locator)
        {
            Action selectDropDown = () =>
            {
                var selectDropDown = Find(locator);
                var selectElement = new SelectElement(selectDropDown);
                selectElement.SelectByText(text);
            };

            ActionRunner.RunWithRetries(selectDropDown);

            Thread.Sleep(2000);
        }
        public void SelectFromDropdownByIndex(int index, By locator)
        {
            Action selectDropDown = () =>
            {
                var selectDropDown = Find(locator);
                var selectElement = new SelectElement(selectDropDown);
                selectElement.SelectByIndex(index);
            };

            ActionRunner.RunWithRetries(selectDropDown);

            Thread.Sleep(2000);
        }

        public bool ElementHasClass(By locator, string val)
        {
            bool hasClass = false;

            string classStr = string.Empty;

            Action getClassStr = () => {

                classStr = WebDriver.FindElement(locator).GetAttribute("class");
            };

            ActionRunner.RunWithRetries(getClassStr);

            var splitClassStrArray = classStr.Split(' ');

            for (var i = 0; i < splitClassStrArray.Length; i++)
            {
                if (splitClassStrArray[i] == val)
                {
                    hasClass = true;
                }
            }

            return hasClass;
        }

        public void VerifyErrorMessage(string errorMsg, By locator) => Assert.True(Find(locator).Text.Contains(errorMsg, StringComparison.InvariantCulture));

        public void VerifySelectedText(string text, By locator)
        {
            IWebElement selectElement = WebDriver.FindElement(locator);
            SelectElement selectedValue = new SelectElement(selectElement);
            string selectedText = selectedValue.SelectedOption.Text;
            Assert.True(text == selectedText);
        }

        public string FindElementXPath(string xPath)
        {
            string result = "notFound";

            Action getWebElement = () =>
            {
                result = this.WebDriver.FindElement(By.XPath(xPath)).Text;
            };

            ActionRunner.RunWithRetries(getWebElement);

            return result;
        }


        public void SearchFromDropdown(By locator)
        {
            Action selectDropDown = () => {

                var selectDropdown = Find(locator);
                selectDropdown.Click();

            };

            ActionRunner.RunWithRetries(selectDropDown);

            Thread.Sleep(2000);
        }


        public bool AlertIsPresent()
        {
            bool alertIsPresent = false;

            try
            {
                WebDriver.SwitchTo().Alert();

                alertIsPresent = true;
            }
            catch (NoAlertPresentException)
            {
                // Handled
            }

            return alertIsPresent;
        }
        
        public string CreateScreenshot(string scenarioTitle)
        {

            string screenshotsFolder = @"/TestResults/Reports/images/";
            //     string uuid = Guid.NewGuid().ToString();                

            var artifactDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + screenshotsFolder;
            string fileName = artifactDirectory + scenarioTitle.Replace(" ", string.Empty);

            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);

            Screenshot screen = ((ITakesScreenshot)WebDriver).GetScreenshot();
            screen.SaveAsFile(fileName + ".png", ScreenshotImageFormat.Png);

            return fileName;

        }

        public bool WaitForNewWindow(int timeout)
        {
            bool flag = false;
            int counter = 0;
            while (!flag)
            {
                try
                {
                    string winId = WebDriver.WindowHandles[1];

                    if (winId.Length > 1)
                    {
                        flag = true;
                        return flag;
                    }
                    Thread.Sleep(1000);
                    counter++;
                    if (counter > timeout){
                        return flag;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return flag;
        }

    

        private void WaitUntilClickable(By locator)
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitUntilVisible(By locator)
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
        private void LongWaitUntilClickable(By locator)
        {
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.LongWaitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implements dispose logic
        /// </summary>
        /// <param name="disposing">Should be true if Dispose is being called by the finalizer versus the IDisposable.Dispose() implementation.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose(), OK to use any private object references

                    WebDriver.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
