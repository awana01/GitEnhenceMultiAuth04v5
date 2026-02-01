using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Pages
{
    public abstract class BasePage
    {
        protected IPage Page;
        protected BasePage(IPage page) => Page = page;
    }
}
