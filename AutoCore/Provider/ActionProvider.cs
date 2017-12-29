using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics.Contracts;

namespace AutoCore
{
    public class ActionProvider : IActionProvider
    {
        private readonly IWebDriver _driver;
        private readonly IWaitProvider _wait;
        private readonly Actions _action;

        public ActionProvider(IWebDriver driver)
        {
            Contract.Requires(driver != null);

            _driver = driver;
            _action = new Actions(_driver);
            _wait = new WaitProvider(_driver);
        }

        public void ClickToElement(IWebElement element)
        {
            try
            {
                _wait.ExplicitWait(element);

                element.Click();
            }
            catch (Exception ex)
            {
                ex.Catch(_driver);
            }
        }

        public void ClickToElement(IWebElement parentElem, IWebElement childElem)
        {
            try
            {
                _wait.ExplicitWait(parentElem);
                parentElem.Click();

                _wait.ExplicitWait(childElem);
                childElem.Click();
            }
            catch (Exception ex)
            {
                ex.Catch(_driver);
            }
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void RedirectTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void TypeInputToElement(IWebElement element, string value)
        {
            try
            {
                _wait.ExplicitWait(element);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception ex)
            {
                ex.Catch(_driver);
            }
        }
    }
}
