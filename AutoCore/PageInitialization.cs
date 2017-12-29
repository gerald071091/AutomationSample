using OpenQA.Selenium;

namespace AutoCore
{
    public static class PageInitialization
    {
        public static IBaseOperation InitializeOperation(string browser)
        {
            IWebDriver driver = PageConfiguration.Current(browser);
            IActionProvider action = new ActionProvider(driver);
            IBaseElement element = new Element();

            driver.Manage().Window.Maximize();
            return new Operation(driver, action, element);
        }
    }
}
