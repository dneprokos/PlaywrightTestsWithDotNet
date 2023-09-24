using Microsoft.Playwright;

namespace PlaywrightTestsWithDotNet.Pages.CheckBoxesPage
{
    public class CheckBoxesPage : BasePage, ITestPage
    {
        private readonly ILocator _indeterminateCheckBox;
        private readonly ILocator _primaryCheckbox;
        private readonly ILocator _accentCheckbox;
        private readonly ILocator _warnCheckbox;
        private readonly ILocator _indeterminateCheckboxStatus;
        private readonly ILocator _primaryCheckboxStatus;
        private readonly ILocator _accentCheckboxStatus;
        private readonly ILocator _warnCheckboxStatus;

        public CheckBoxesPage(IPage page) : base(page)
        {
            _indeterminateCheckBox = Page.Locator("#mat-checkbox-1");
            _primaryCheckbox = Page.Locator("#mat-checkbox-2");
            _accentCheckbox = Page.Locator("#mat-checkbox-3");
            _warnCheckbox = Page.Locator("#mat-checkbox-4");
            _indeterminateCheckboxStatus = Page.Locator("#mat-checkbox-1-input");
            _primaryCheckboxStatus = Page.Locator("#mat-checkbox-2-input");
            _accentCheckboxStatus = Page.Locator("#mat-checkbox-3-input");
            _warnCheckboxStatus = Page.Locator("#mat-checkbox-4-input");
        }

        public async Task WaitUntilPageIsLoaded()
        {
            await Assert.Expect(_indeterminateCheckBox).ToBeAttachedAsync();
        }

        public async Task ClickCheckboxByName(CheckBoxNames name)
        {
            ILocator checkboxLocator;

            switch (name) 
            {
                case (CheckBoxNames.Indeterminate):
                    checkboxLocator = _indeterminateCheckBox;
                    break;
                case (CheckBoxNames.Primary):
                    checkboxLocator = _primaryCheckbox;
                    break;
                case (CheckBoxNames.Accent):
                    checkboxLocator = _accentCheckbox;
                    break;
                case (CheckBoxNames.Warn):
                    checkboxLocator = _warnCheckbox;
                    break;
                default: throw new ArgumentException($"No checkbox '{name}' implementation");
            }

            await checkboxLocator.ClickAsync();
        }

        public ILocator GetCheckboxStatusLocator(CheckBoxNames name)
        {
            ILocator checkboxLocator;
            switch (name)
            {
                case (CheckBoxNames.Indeterminate):
                    checkboxLocator = _indeterminateCheckboxStatus;
                    break;
                case (CheckBoxNames.Primary):
                    checkboxLocator = _primaryCheckboxStatus;
                    break;
                case (CheckBoxNames.Accent):
                    checkboxLocator = _accentCheckboxStatus;
                    break;
                case (CheckBoxNames.Warn):
                    checkboxLocator = _warnCheckboxStatus;
                    break;
                default: throw new ArgumentException($"No checkbox '{name}' implementation");
            }

            return checkboxLocator;
        }
    }

    public enum CheckBoxNames
    {
        Indeterminate,
        Primary,
        Accent,
        Warn
    }
}
