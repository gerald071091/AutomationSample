using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoCore
{
    public partial class Element : Attributes, IBaseElement
    {
        [FindsBy(How = How.Id, Using = CommonAttributes.ClickButtonAttr)]
        public IWebElement ClickTheFckingButton { get; set; }

        [FindsBy(How = How.Id, Using = CommonAttributes.SearchTextBoxAttr)]
        public IWebElement TypeTheFckingValueInTextBoxField { get; set; }
    }
}
