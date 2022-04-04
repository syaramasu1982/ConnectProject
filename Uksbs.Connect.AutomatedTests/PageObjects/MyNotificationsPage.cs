using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{

    public class MyNotificationsPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;
        private readonly string _notificationList = "//ul[contains(@id,'ui-id')]";

        public MyNotificationsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public NotificationCentre GetAllNotifications()
        {
            this.Find(By.XPath(_notificationList));
            NotificationCentre notificationCentre = null;

            if (this.IsElementPresent(By.XPath(_notificationList)))
            {
                IWebElement ulNotifications = WebDriver.FindElement(By.XPath(_notificationList));

                List<IWebElement> listItemsOfNotifications = new List<IWebElement>(ulNotifications.FindElements(By.TagName("li")));
                notificationCentre = new NotificationCentre();
                notificationCentre.Notifications = new List<Notification>();
                Notification notification = null;

                foreach (var listItem in listItemsOfNotifications)
                {

                    notification = new Notification();
                    IWebElement farLeftMainInfo = listItem.FindElement(By.ClassName("item-main-info"));
                    var infoParagraphs = farLeftMainInfo.FindElements(By.TagName("p"));


                    notification.Title = infoParagraphs[0].Text.Trim();

                    var DateAndFromWhom = infoParagraphs[1].Text.Split('|');
                    notification.DateWithDay = DateAndFromWhom[0].Trim();
                    notification.FromWhom = DateAndFromWhom[1].Trim();


                    notification.ElementId = listItem.GetAttribute("id");
                    IWebElement farRightAdditionalInfo = listItem.FindElement(By.CssSelector(".item-additional-info.oj-complete"));
                    infoParagraphs = farRightAdditionalInfo.FindElements(By.TagName("p"));
                    if (infoParagraphs.Count > 1)
                    {
                        notification.HeadsUpMessage = infoParagraphs[0].Text.Trim();
                        notification.Status = infoParagraphs[1].Text.Trim();
                    }
                    else if (infoParagraphs.Count == 1)
                    {
                        notification.HeadsUpMessage = string.Empty;
                        notification.Status = infoParagraphs[0].Text.Trim();
                    }
                    else
                    {
                        notification.HeadsUpMessage = string.Empty;
                        notification.Status = string.Empty;
                    }

                    notificationCentre.Notifications.Add(notification);
                }


            }

            return notificationCentre;
        }
    }

}
