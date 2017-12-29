using OpenQA.Selenium;
using System.Configuration;
using System.Diagnostics;

namespace AutoCore
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets the value of string key in configuration app settings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(this string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Get the parsed value by int of string key in configuration app settings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetParsedValueByInt(this string key)
        {
            return int.Parse(ConfigurationManager.AppSettings[key]);
        }

        /// <summary>
        /// Check if the namespace of element use at runtime is true with comparer provided
        /// </summary>
        /// <param name="element"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool IsElementTypeOfInstance(this IBaseElement element, string comparer)
        {
            return element.GetType().ToString().Contains(comparer);
        }

        /// <summary>
        /// Check if the processing method is equal with the comparer provided
        /// </summary>
        /// <param name="element"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool IsProcessingMethod(this IWebElement element, string comparer)
        {
            StackTrace frame = new StackTrace();
            foreach (var stack in frame.GetFrames())
            {
                if (stack.GetMethod().Name.Contains(comparer))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

