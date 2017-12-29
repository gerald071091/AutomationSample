using OpenQA.Selenium;
using System;
using System.IO;
using System.Linq;

namespace AutoCore
{
    public static class ActionHelper
    {
        private static readonly StringComparer _defaultComparer = StringComparer.InvariantCultureIgnoreCase;
        private static readonly string[] _selected = new[] { "true", "selected" };
        private static readonly string[] _checked = new[] { "true", "checked" };

        /// <summary>
        /// Action Helper that define if the element is selected.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsSelected(this IWebElement element)
        {
            string attribute = element.GetAttribute("selected");
            return _selected.Contains(attribute, _defaultComparer);
        }

        /// <summary>
        /// Action Helper that define if the element ic checked.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsChecked(this IWebElement element)
        {
            string attribute = element.GetAttribute("checked");
            return _checked.Contains(attribute, _defaultComparer);
        }

        /// <summary>
        /// Action Helper for taking a screenshot.
        /// </summary>
        /// <param name="driver"></param>
        public static void TakeScreenShot(this IWebDriver driver)
        {
            try
            {
                Screenshot screenies = ((ITakesScreenshot)driver).GetScreenshot();
                string fileName = string.Format("Fail_{0}.jpg", DateTime.Now.ToString("s").Replace(":", string.Empty));
                string path = AppDomain.CurrentDomain.BaseDirectory ?? AppDomain.CurrentDomain.RelativeSearchPath;
                screenies.SaveAsFile(Path.Combine(path, fileName), ScreenshotImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
