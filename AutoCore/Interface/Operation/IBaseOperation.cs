namespace AutoCore
{
    public interface IBaseOperation
    {
        /// <summary>
        /// Clicking the button as much as you can
        /// </summary>
        void ClickTheButton();

        /// <summary>
        /// Just type the value
        /// </summary>
        /// <param name="value"></param>
        void TypeTheValueInTextBox(string value);

        /// <summary>
        /// Browse this site
        /// </summary>
        /// <param name="value"></param>
        void BrowseThisWebSite(string url);

        /// <summary>
        /// Just Quit the operation
        /// </summary>
        void Quit();

        /// <summary>
        /// Switch back to main tab
        /// </summary>
        /// <returns></returns>
        void GoToDefaultTab();
    }
}
