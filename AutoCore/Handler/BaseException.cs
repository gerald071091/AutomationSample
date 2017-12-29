using OpenQA.Selenium;
using System;
using System.Reflection;

namespace AutoCore
{
    public static class BaseException
    {
        public static Exception Catch(this Exception ex, IWebDriver driver)
        {
            driver.Quit();

            if (ex is WebDriverException)
            {
                throw new Exception("Element is not visible/displayed or the request to the remote webdriver server has timed out", ex);
            }
            else if (ex is InvalidOperationException)
            {
                throw new Exception("The operation encounter an invalid process", ex);
            }
            else if (ex is TargetInvocationException)
            {
                throw new Exception("The object is not yet bounded and it is invoked by other process", ex);
            }
            else if (ex is TimeoutException)
            {
                throw new Exception("The operation has exceeded the given time for checking the object at runtime", ex);
            }
            else
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
