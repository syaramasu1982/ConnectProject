using OpenQA.Selenium;
using System;
using System.Threading;

namespace Uksbs.Connect.AutomatedTests.Common
{
    public static class ActionRunner
    {
        public static void RunWithRetries(Action action)
        {
            int tries = 1;
            int maxTries = 5;

            while (tries <= maxTries)
            {
                try
                {
                    action();

                    break;
                }
                catch (StaleElementReferenceException)
                {
                   
                }

                tries++;

                Thread.Sleep(1000);                
            }
        }
    }
}
