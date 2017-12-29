using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace AutoCore
{
    public static class PageConfiguration
    {
        public static IWebDriver Current(string browser)
        {
            try
            {

                IDictionary<string, Func<IWebDriver>> setDriver = new Dictionary<string, Func<IWebDriver>>
                {
                    {"ie", () =>
                        {
                            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                            ieOptions.EnablePersistentHover = false;
                            ieOptions.RequireWindowFocus = false;
                            ieOptions.IgnoreZoomLevel = true;
                            ieOptions.EnsureCleanSession = true;
                            return new InternetExplorerDriver(ieOptions);
                        }
                    },
                    {"chrome", () =>
                        {
                            ChromeOptions chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("test-type");
                            return new ChromeDriver(chromeOptions);
                        }
                    },
                    {"firefox", () =>
                        {
                            return new FirefoxDriver();
                        }
                    }
                };

                return setDriver[browser]();
            }
            catch (WebDriverException ex)
            {
                throw new Exception(string.Format("{0}", ex));
            }
        }
    }
}
