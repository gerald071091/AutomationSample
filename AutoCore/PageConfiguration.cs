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
                            InternetExplorerOptions ieOptions = new InternetExplorerOptions{
                                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                                EnablePersistentHover = false,
                                RequireWindowFocus = false,
                                IgnoreZoomLevel = true,
                                EnsureCleanSession = true
                            };
                            
                            return new InternetExplorerDriver(ieOptions);
                        }
                    },
                    {"chrome", () =>
                        {
                            string pathToAdBlockerExtension = @"C:\Users\GeraldG\AppData\Local\Google\Chrome\User Data\Default\Extensions\bkkbcggnhapdmkeljlodobbkopceiche\4.0.6.1_0";
                            ChromeOptions chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("test-type");
                            chromeOptions.AddArgument("--load-extension=" + pathToAdBlockerExtension);
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
