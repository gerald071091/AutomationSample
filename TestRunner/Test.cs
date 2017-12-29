using AutoCore;
using NUnit.Framework;
using System.Configuration;
using System.Diagnostics;

namespace TestRunner
{
    [TestFixture]
    public class Test
    {
        public IBaseOperation _operation;
        public static Process _process;

        [OneTimeSetUp]
        public void Init()
        {
            _operation = PageInitialization.InitializeOperation("chrome");
        }

        [TearDown]
        public void CleanUp()
        {
            _operation.Quit();
            _process.EndSession("drivers".GetValue());
        }

        [Test]
        public void TestAutomation()
        {
            _operation.BrowseThisWebSite(ConfigurationManager.AppSettings["website"]);

            //LOL
            for (int i = 0; i < 100; i++)
            {
                _operation.ClickTheButton();
            }
            
        }
    }
}
