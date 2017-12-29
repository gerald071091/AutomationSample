using OpenQA.Selenium;

namespace AutoCore
{
    public interface IWaitProvider
    {
        /// <summary>
        /// This wait will try to find element again and again until it finds it or until
        /// the final timer runs out
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool FluentWait(IWebElement element);

        /// <summary>
        /// This wait will try to find the element until the final timer runs out
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool ExplicitWait(IWebElement element);

        /// <summary>
        /// This wait will Provide a raw delay time before proceeding to another process
        /// </summary>
        void RawWait();
    }
}
