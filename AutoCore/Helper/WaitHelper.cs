using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoCore
{
    public static class WaitHelper
    {
        /// <summary>
        /// Wait Helper for waiting the element to be displayed and enabled
        /// </summary>
        /// <param name="element"></param>
        /// <param name="wait"></param>
        /// <returns></returns>
        public static bool ElementDisplayedAndEnabled(this IWebElement element, IWait<IWebDriver> wait)
        {
            return wait.Until(page => element.Displayed && element.Enabled);
        }

        /// <summary>
        /// Wait Helper for waiting the element to be displayed or enabled
        /// </summary>
        /// <param name="element"></param>
        /// <param name="wait"></param>
        /// <returns></returns>
        public static bool ElementDisplayedOrEnabled(this IWebElement element, IWait<IWebDriver> wait)
        {
            return wait.Until(page => element.Displayed || element.Enabled);
        }

        /// <summary>
        /// Wait Helper for waiting the element to be visible
        /// </summary>
        /// <param name="element"></param>
        /// <param name="wait"></param>
        /// <returns></returns>
        public static bool ElementVisibility(this IWebElement element, IWait<IWebDriver> wait)
        {
            return wait.Until(page => element.Size.Width > 0 && element.Size.Height > 0);
        }
    }
}
