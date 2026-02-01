using EnhenceMultiAuth04v4.Configurations;
using EnhenceMultiAuth04v4.Utils;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Pages
{
    public class SiteALoginPage : BasePage
    {
        public SiteALoginPage(IPage page) : base(page) { }

        public async Task Login(UserConfig user)
        {

            await Page.FillAsync("input[name='username']", user.Username!);
            await Page.FillAsync("input[name='password']", user.Password!);
            await Page.ClickAsync("button[type='submit']");
            await Page.WaitForSelectorAsync("span.oxd-userdropdown-tab", new PageWaitForSelectorOptions { Timeout=30_000});
            //await Page.WaitForURLAsync("**/dashboard**");
        }
    }

    public class SiteBLoginPage : BasePage
    {
        public SiteBLoginPage(IPage page) : base(page) { }

        public async Task Login(UserConfig user)
        {
            await Page.ClickAsync("a.btn.btn-primary");
            Thread.Sleep(2000);

            IPage _page = await ProjUtil.SwitchTab(Page, 1);
            await _page.ClickAsync("a.btn.btn-primary.btn-sm");
            await _page.FillAsync("input[name='username']", user.Username!);
            await _page.FillAsync("input[name='password']", user.Password!);
            await _page.ClickAsync("input[value='Login']");
            await _page.WaitForSelectorAsync("li.ossn-topbar-dropdown-menu", new PageWaitForSelectorOptions { Timeout = 15_000 });
            //await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }



        public async Task GeneralLogin(string userName,string pwd)
        {
            //await Page.ClickAsync("a.btn.btn-primary");
            //Thread.Sleep(2000);
            //IPage _page = await ProjUtil.SwitchTab(Page, 1);
            
            await Page.ClickAsync("a.btn.btn-primary.btn-sm");
            await Page.FillAsync("input[name='username']", userName!);
            await Page.FillAsync("input[name='password']", pwd!);
            await Page.ClickAsync("input[value='Login']");
            await Page.WaitForSelectorAsync("li.ossn-topbar-dropdown-menu", new PageWaitForSelectorOptions { Timeout = 15_000 });
            //await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }





    }
}
