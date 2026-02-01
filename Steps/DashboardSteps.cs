using Allure.Net.Commons;
using Microsoft.Playwright;
using EnhenceMultiAuth04v4.Utils;
using Reqnroll;


namespace EnhenceMultiAuth04v4.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly IPage _page;

        public DashboardSteps(ScenarioContext ctx) => _page = ctx.Get<IPage>();

        [Given(@"I open dashboard")]
        public async Task OpenDashboard()
        {
            await _page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index",new PageGotoOptions() {Timeout=20_000 });
        }

        [Then(@"I should see admin widgets")]
        public async Task ValidateWidgets()
        {
            await _page.GetByText("PIM").IsVisibleAsync();
            Thread.Sleep(5000);
            //Assert.True(await _page.IsVisibleAsync("#adminPanel"));
        }


        [When(@"clik on PIM link")]
        public async Task clickPIMLink() {
            await _page.Locator("ul.oxd-main-menu>li:nth-child(2)").ClickAsync(new LocatorClickOptions { Timeout=20_000});
        }

        [When(@"click on {string} menu on dashboard")]
        public async Task Fun1(string menuItem)
        {
            //case string.Equals("admin", menuItem, StringComparison.OrdinalIgnoreCase):
            
            switch (menuItem)
            {
                case "Admin":
                    await _page.Locator("ul.oxd-main-menu>li:nth-child(1)").ClickAsync(new LocatorClickOptions { Timeout = 20_000 });
                    break;
                case "PIM":
                    await _page.Locator("ul.oxd-main-menu>li:nth-child(2)").ClickAsync(new LocatorClickOptions { Timeout = 20_000 });
                    break;
                case "Leave":
                    await _page.Locator("ul.oxd-main-menu>li:nth-child(3)").ClickAsync(new LocatorClickOptions { Timeout = 20_000 });

                    break;
                default:
                    throw new Exception("");
            }

        }


        
        [Then(@"user navigates to PIM page")]
        public async Task PIMPageVerify()
        {
            await _page.WaitForURLAsync("**/pim/viewEmployeeList", new PageWaitForURLOptions { Timeout = 30_000 });
            await _page.WaitForSelectorAsync("span.oxd-userdropdown-tab", new PageWaitForSelectorOptions { Timeout = 30_000 });

            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded, new PageWaitForLoadStateOptions { Timeout = 25_000 });
            AllureApi.AddAttachment("Screenshot2", "image/png", await ProjUtil.CaptureScreenshotBytes(_page, "admin.png"));

        }

        [Then(@"Verify success full navigation to admin page")]
        public async Task VerifyAdminPage()
        {
            await _page.WaitForURLAsync("**/admin/viewSystemUsers", new PageWaitForURLOptions { Timeout = 30_000 });
            await _page.WaitForSelectorAsync("span.oxd-userdropdown-tab", new PageWaitForSelectorOptions { Timeout = 30_000 });

            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded, new PageWaitForLoadStateOptions { Timeout = 25_000 });
            AllureApi.AddAttachment("Screenshot2", "image/png", await ProjUtil.CaptureScreenshotBytes(_page, "admin.png"));

        }

        public async Task VerifyNavigationPage(string request_url)
        {
            await _page.WaitForURLAsync("**/admin/viewSystemUsers", new PageWaitForURLOptions { Timeout = 30_000 });
            //await ProjUtil.CaptureScreenshotBytes(_page, "admin.png");

            //AllureLifecycle.Instance.AddAttachment("Screenshot on failure", "image/png", screenshotBytes);
            AllureApi.AddAttachment("Screenshot1", "image/png", await ProjUtil.CaptureScreenshotBytes(_page, "admin.png"));



        }



    }
}
