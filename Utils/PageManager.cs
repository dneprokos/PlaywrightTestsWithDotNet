using Microsoft.Playwright;

namespace PlaywrightTestsWithDotNet.Utils
{
    public class PageManager
    {
        private readonly IPage[] pages;
        private readonly Stack<IPage> availablePages;

        public PageManager(IBrowser browser, int maxPages)
        {
            if (maxPages <= 0)
            {
                throw new ArgumentException("Max pages must be greater than zero.");
            }

            pages = new IPage[maxPages];
            availablePages = new Stack<IPage>(maxPages);

            for (int i = 0; i < maxPages; i++)
            {
                pages[i] = browser.NewPageAsync().Result;
                availablePages.Push(pages[i]);
            }
        }

        public IPage GetPage()
        {
            lock (availablePages)
            {
                if (availablePages.Count > 0)
                {
                    return availablePages.Pop();
                }
                else
                {
                    throw new InvalidOperationException("No available pages in the stack.");
                }
            }
        }

        public void ReleasePage(IPage page)
        {
            lock (availablePages)
            {
                if (page != null)
                {
                    availablePages.Push(page);
                }
            }
        }
    }
}
