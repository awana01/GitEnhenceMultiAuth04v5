//using BoDi;
//using Microsoft.Playwright;
//using PlaySpec1.SpecHooks;
//using System.Collections.Generic;
//using System.Globalization;
//using TechTalk.SpecFlow.CommonModels;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;



//namespace PlaySpec1.StepDefs3
//{
//    [Binding]
//    public class SocialNetSteps3
//    {

//        private readonly ScenarioContext _scenarioContext;
//        private IPage _page;
//        //private readonly IPage _page;
//        //private readonly BasePage _basePage;
//        //private readonly Config? _config;

//        private string? _username;
//        private string? _password;
//        private string? _msg;


//        public SocialNetSteps3(ScenarioContext scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//            _page = WebHooks.Page!;
            
//            //_basePage = new BasePage(_page);
//            //_config = Hooks.Hooks.Config!;
//        }

        
//        [Given(@"user navigates to ""([^""]*)""")]
//        [When(@"user navigates to ""([^""]*)""")]
//        public async Task navStep1(string url)
//        {

//            await _page.GotoAsync(url);
//            Thread.Sleep(2000);
//        }

//        [When(@"navigate to socialnetwork page")]
//        public async Task s1()
//        {
//            Thread.Sleep(2000);
//            await _page.Locator("//a[contains(text(),'Frontend Demo')]").ClickAsync();
//            Thread.Sleep(2000);

//            //var tabs = _page.Context.Pages; //.Browser;
//            //Console.WriteLine($"Total Tabs: {tabs.Count}"); 
          
//            var x = _page.Context;
//            Console.WriteLine(x);
//            Console.WriteLine(await _page.TitleAsync());


//           // //IReadOnlyList<IPage> tabs = _page.Context.Pages;
//           //  await SwitchTabs("Open Source Social Network", _page.Context.Pages);
//           // //Thread.Sleep(2000);

//           // _page = _page.Context.Pages[1];

//           //// await _page.Context.Pages[1].BringToFrontAsync();

//           // await _page.Locator("[name=\"birthdate\"]").ClickAsync();
//           // await _page.Locator("//*[@class='ui-datepicker-month']").ClickAsync();




//        }

//        [When(@"click on '(.*)' form feild and select year '(.*)'")]
//        public async Task selectDoB(string fieldName,string year)
//        {
//            //IReadOnlyList<IPage> tabs = this._page.Context.Pages;
//            //"Welcome : Open Source Social Network"
//            _page = await SwitchTabs("Welcome :", _page.Context);
//            Thread.Sleep(2000);
            
//            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//            {
//                await _page.Locator("[name=\"birthdate\"]").ClickAsync();

                
//            }
//            await _page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { "2000" });
            
            
//            //Thread.Sleep(200);
//            //await _page.Locator("//*[@class='ui-datepicker-year']").ClickAsync();

//            //IReadOnlyList<ILocator> MonthOpts = await _page.Locator("select.ui-datepicker-year>option").AllAsync();

            
//            Thread.Sleep(2000);

//            //await MonthOpts[10].S            //.ScrollIntoViewIfNeededAsync(new(){ Timeout = 500 });
//            //await MonthOpts[10].ClickAsync();


//        }

        
        
//        [When(@"click on '(.*)' form feild and select month '(.*)'")]
//        public async Task selectDoB2(string fieldName, string month)
//        {
//            _page = await SwitchTabs("Welcome :", _page.Context);
//            //IReadOnlyList<IPage> tabs = this._page.Context.Pages;
//            //"Welcome : Open Source Social Network"
//            //_page = await SwitchTabs("Welcome :", _page.Context);
//            //Thread.Sleep(2000);

//            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//            {
//                await _page.Locator("[name=\"birthdate\"]").ClickAsync();


//            }


//            //await _page.Locator("[name=\"birthdate\"]").ClickAsync();
//            //Thread.Sleep(200);
//            //await _page.Locator("//*[@class='ui-datepicker-month']").ClickAsync();

//            //IReadOnlyList<ILocator> MonthOpts = await _page.Locator("select.ui-datepicker-month>option").AllAsync();

//            await _page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { "Jan." });
//            Thread.Sleep(2000);

//            //var culture = CultureInfo.GetCultureInfo("en-US");
//            //var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);

//            //foreach (string name in dateTimeInfo.AbbreviatedMonthNames)
//            //{
//            //    Console.WriteLine(name);
//            //}
            
            
//            var todayNum = DateTime.Today.Day; //.Now.ToString("d");
//            string _dayLocator = $"//td/a[@data-date='{todayNum}']";
//            await _page.Locator(_dayLocator).ClickAsync();
//            Thread.Sleep(1500);

//        }

//        [Then(@"verify birthdate should be in dd/mm/yyyy format")]
//        public async Task ValidFormat()
//        {
//            string birthvalue = await _page.Locator("[name=\"birthdate\"]").InputValueAsync(); 
//            Console.WriteLine(birthvalue);

//            //DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
//            DateTime userDate = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);
//            DateTime userDate1 = DateTime.ParseExact(birthvalue, "dd/MM/yyyy",null);
            
//            DateTime dt = DateTime.Parse("09/12/2009");

//            Console.WriteLine(dt.ToString("dd/MM/yyyy"));

//            //DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
//            string x = string.Format("{0:dd/MM/yyyy}", birthvalue);
//            Console.WriteLine($"Format1: {x}");

//            Console.WriteLine($"Parsed: {birthvalue} DateTime1: {userDate}");
//            string.Equals(birthvalue, x);
//            if (string.Compare(birthvalue, x) == 0)
//            {
//                Console.WriteLine("strings are valid");
//            }
//        }



//        [Given(@"some user ""([^""]*)"" string")]
//        public async Task ParseDate(string date1)
//        {
//            DateTime dat = DateTime.Parse(date1);
//            Console.WriteLine($"Parsed DateTime1: {dat}");

//            //var result1 = DateTime.ParseExact(date1, "d", null);
//            //var result2 = DateTime.ParseExact(date1, "d", CultureInfo.InvariantCulture);

//            DateTime userDate = DateTime.ParseExact(date1, "yyyy-mm-dd", null);

//            Console.WriteLine($"Parsed Exact DateTime1: {userDate}");
//            //Console.WriteLine($"Parsed Exact DateTime2: {result2}");
//        }

//        [Given(@"some user ""([^""]*)"" string2")]
//        public async Task ParseDate2(string date1)
//        {
//            DateTime dat = DateTime.Parse(date1);
//            Console.WriteLine($"Parsed DateTime1: {dat}");
//            Console.WriteLine($"Parsed DateTime1: {dat.ToString("dd/MM/yyyy")}");
//            ////var result1 = DateTime.ParseExact(date1, "d", null);
//            ////var result2 = DateTime.ParseExact(date1, "d", CultureInfo.InvariantCulture);

//            //DateTime userDate = DateTime.ParseExact(date1, "yyyy-mm-dd", null);

//            //Console.WriteLine($"Parsed Exact DateTime1: {userDate}");
//            ////Console.WriteLine($"Parsed Exact DateTime2: {result2}");
//        }








//        [When(@"print the format datetime")]
//        public async Task frmtDate()
//        {
//            // Get current DateTime. It can be any DateTime object in your code.
//            DateTime aDate = DateTime.Now;

//            // Format Datetime in different formats and display them
//            Console.WriteLine(aDate.ToString("MM/dd/yyyy"));
//            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
//            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
//            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
//            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
//            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
//            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
//            Console.WriteLine(aDate.ToString("MM/dd/yyyy HH:mm"));
//            Console.WriteLine(aDate.ToString("MM/dd/yyyy hh:mm tt"));
//            Console.WriteLine(aDate.ToString("MM/dd/yyyy H:mm"));
//            Console.WriteLine(aDate.ToString("MM/dd/yyyy h:mm tt"));
//            Console.WriteLine(aDate.ToString("MM/dd/yyyy HH:mm:ss"));
//            Console.WriteLine(aDate.ToString("MMMM dd"));
//            Console.WriteLine(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));
//            Console.WriteLine(aDate.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));
//            Console.WriteLine(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"));
//            Console.WriteLine(aDate.ToString("HH:mm"));
//            Console.WriteLine(aDate.ToString("hh:mm tt"));
//            Console.WriteLine(aDate.ToString("H:mm"));
//            Console.WriteLine(aDate.ToString("h:mm tt"));
//            Console.WriteLine(aDate.ToString("HH:mm:ss"));
//            Console.WriteLine(aDate.ToString("yyyy MMMM"));
//        }




//        public async Task<IPage> SwitchTabs(string tabTitle,IBrowserContext BrowserCTX)
//        {
//            IPage? _page = null;
//            foreach(var tab in BrowserCTX.Pages)
//            {
//                await tab.BringToFrontAsync();
//                string _tabTitle = await tab.TitleAsync();
//                Thread.Sleep(1000);
//                if (_tabTitle.StartsWith(tabTitle, StringComparison.OrdinalIgnoreCase))
//                {
//                    _page = tab;
//                }
//            }


//            return _page!;
//        }




//    }
//}