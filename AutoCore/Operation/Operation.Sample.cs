using OpenQA.Selenium;

namespace AutoCore
{
    public partial class Operation : PageBaseFactory, IBaseOperation
    {
        public Operation(IWebDriver driver, IActionProvider action, IBaseElement element)
            : base(driver, action, element)
        {

        }

        public void ClickTheButton()
        {
            _action.ClickToElement(_element.ClickTheFckingButton);
        }

        public void TypeTheValueInTextBox(string value)
        {
            _action.TypeInputToElement(_element.TypeTheFckingValueInTextBoxField, value);
        }

        public void BrowseThisWebSite(string url)
        {
            _action.RedirectTo(url);
        }

        public void Quit()
        {
            _action.Quit();
        }

        
    }
}
