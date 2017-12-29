using OpenQA.Selenium;

namespace AutoCore
{
    public interface IActionProvider
    {
        /// <summary>
        /// Action that redirect to a certain site
        /// </summary>
        /// <param name="url"></param>
        void RedirectTo(string url);

        /// <summary>
        /// Action that click the target element
        /// </summary>
        /// <param name="element"></param>
        void ClickToElement(IWebElement element);

        /// <summary>
        /// Action that clicks the first element to provide clicking action to the consecutive element
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        /// <param name="wait"></param>
        void ClickToElement(IWebElement firstElement, IWebElement secondElement);

        /// <summary>
        /// Action that type the provided value to element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        void TypeInputToElement(IWebElement element, string value);

        /// <summary>
        /// Action Quit that ends the driver browser and it's session
        /// </summary>
        void Quit();
    }
}
