using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace AutoCore
{
    internal class WaitProvider : IWaitProvider
    {
        private readonly IWebDriver _driver;
        private readonly IWait<IWebDriver> _wait;
        private DefaultWait<IWebElement> _pollingWait;

        public WaitProvider(IWebDriver driver)
        {
            Contract.Requires(driver != null);

            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds("findTimeout".GetParsedValueByInt()));
        }

        public bool ExplicitWait(IWebElement element)
        {
            return _wait.Until(page => element.ElementVisibility(_wait) && element.ElementDisplayedOrEnabled(_wait));
        }

        public bool FluentWait(IWebElement element)
        {
            _pollingWait = new DefaultWait<IWebElement>(element);
            _pollingWait.Timeout = TimeSpan.FromSeconds("findTimeout".GetParsedValueByInt());
            _pollingWait.PollingInterval = TimeSpan.FromMilliseconds("pollingTime".GetParsedValueByInt());

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement e) =>
            {
                if (element.ElementVisibility(_wait) && element.ElementDisplayedOrEnabled(_wait))
                {
                    return true;
                }

                return false;
            });

            return _pollingWait.Until(waiter);
        }

        public void RawWait()
        {
            Task.Factory.StartNew(() =>
            {
                Task.Delay(TimeSpan.FromSeconds("processBufferTime".GetParsedValueByInt())).Wait();
            }).Wait();
        }
    }
}