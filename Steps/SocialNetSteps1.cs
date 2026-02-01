//using Microsoft.Playwright;
//using NUnit.Framework;
//using PlaySpec1.AppPages;
//using PlaySpec1.SpecHooks;
//using System.Text.RegularExpressions;




//namespace PlaySpec1.StepDefs3
//{
//    [Binding]
//    public class SocialNetSteps1
//    {

//        private readonly ScenarioContext _scenarioContext;
//        private readonly SharedContext _sharedContext;
//        private IPage _page;
//        private readonly DemoPage _demoPage;
//        private readonly LoginPage _loginPage;
//        //private readonly Config? _config;

 


//        public SocialNetSteps1(ScenarioContext scenarioContext, SharedContext sharedContext)
//        {
//            _scenarioContext = scenarioContext;
//            _sharedContext = sharedContext;
//            _page = WebHooks.Page!;

//            _demoPage = new DemoPage(_page);
//            _loginPage = new LoginPage(_page);
//            //_config = Hooks.Hooks.Config!;
//        }


//        [Given(@"user navigates to ""([^""]*)""")]
//        [When(@"user navigates to ""([^""]*)""")]
//        public async Task navStep1(string url)
//        {

//            await _page.GotoAsync(url);
//            Thread.Sleep(2000);
//            TestContext.WriteLine($"Thread-ID => {Thread.CurrentThread.ManagedThreadId}");
//            //TestContext.WriteLine($"Thread-ID=> {Task.CurrentId}");
            
//        }

//        [When(@"navigate to socialnetwork page")]
//        public async Task s1()
//        {
//            Thread.Sleep(2000);
//            await _demoPage.ClickFrontDemoBTN();
//            //await _page.Locator("//a[contains(text(),'Frontend Demo')]").ClickAsync();
//            Thread.Sleep(2000);

//            //var tabs = _page.Context.Pages; //.Browser;
//            //Console.WriteLine($"Total Tabs: {tabs.Count}"); 
            
//            var x = _page.Context;
//            Console.WriteLine(x);
//            Console.WriteLine(await _page.TitleAsync());

//            //await Assertions.Expect(_page.GetByText("Name")).ToHaveCountAsync(1);

//        }

//        [When(@"click on '(.*)' form feild and select year '(.*)'")]
//        public async Task selectDoB(string fieldName, string year)
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


//        [When(@"open new tab and navigate to ""([^""]*)""")]
//        public async Task OpenTab(string newURL)
//        {
//            _page = _sharedContext.SharedPageContext;
//            var newTab = await _page.Context.NewPageAsync();
//            await newTab.GotoAsync(newURL);
//            _sharedContext.SharedPageContext = newTab;
//        }


//        [When(@"^(?i)Switch to new tab")]
//        public async Task tabSwitch()
//        {
//            _page = await SwitchTabs("Welcome :", _page.Context);
//            _sharedContext.SharedPageContext = _page;
//        }

        

//        [When(@"click on 'dob' element and enter birtdate as ""([^""]*)""")]
//        public async Task stepDob(string birthDate)
//        {
//            _page = _sharedContext.SharedPageContext;

//            string[] birthString = birthDate.Split(" ");
//            Thread.Sleep(200);

//            string patternX = @"^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$";
//            bool isMatch5 = Regex.IsMatch(birthDate, patternX);
//            if (isMatch5)
//            { await SetUserDob(birthString[0], birthString[1], birthString[2]); }
//            else
//            { throw new Exception("Error => Enter DOB in correct format of : day monthname year (00 March 1983)"); }
//        }

//        public async Task SetUserDob(string _month, string _year)
//        {
//            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//            {
//                await _page.Locator(_loginPage._TXTLoc_BirthDate).ClickAsync();
//                Thread.Sleep(500);

//                await _page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { $"{_month}" });
//                Thread.Sleep(200);

//                await _page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { $"{_year}" });
//                Thread.Sleep(200);

//                var todayNum = DateTime.Today.Day; //.Now.ToString("d");
//                string _dayLocator = $"//td/a[@data-date='{todayNum}']";
//                await _page.Locator(_dayLocator).ClickAsync();
//                Thread.Sleep(1500);

//            }


//        }

//        public async Task SetUserDob(string _day, string _month, string _year)
//        {
//            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//            {
//                await _page.Locator(_loginPage._TXTLoc_BirthDate).ClickAsync();
//                Thread.Sleep(500);

//                await _page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { $"{_month}" });
//                Thread.Sleep(200);

//                await _page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { $"{_year}" });
//                Thread.Sleep(200);

//                //var todayNum = DateTime.Today.Day; //.Now.ToString("d");
//                string _dayLocator = $"//td/a[@data-date='{_day}']";
//                await _page.Locator(_dayLocator).ClickAsync();
//                Thread.Sleep(1500);

//            }
//        }


//        [When(@"click on '(.*)' form feild and select month '(.*)'")]
//        public async Task selectDoB2(string fieldName, string month)
//        {
//            _page = await SwitchTabs("Welcome :", _page.Context);
//            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//            {
//                await _page.Locator("[name=\"birthdate\"]").ClickAsync();
//            }

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
//            string birthvalue = await _page.Locator(_loginPage._TXTLoc_BirthDate).InputValueAsync();  // await _page.Locator("[name=\"birthdate\"]").InputValueAsync();
//            Console.WriteLine(birthvalue);

//            string validFormat = @"\d{2}/\d{2}/\d{4}";
//            bool isMatch3 = Regex.IsMatch(birthvalue, validFormat);
//            isMatch3.Should().BeTrue($"String {birthvalue} is in correct format of dd/MM/yyyy");
//            Console.WriteLine($"String {birthvalue} is in correct format of dd/MM/yyyy");

//            ////DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
//            //DateTime userDate = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);
//            //DateTime userDate1 = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);

//            //DateTime dt = DateTime.Parse("09/12/2009");

//            //Console.WriteLine(dt.ToString("dd/MM/yyyy"));

//            ////DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
//            //string x = string.Format("{0:dd/MM/yyyy}", birthvalue);
//            //Console.WriteLine($"Format1: {x}");

//            //Console.WriteLine($"Parsed: {birthvalue} DateTime1: {userDate}");
//            //string.Equals(birthvalue, x);
//            //if (string.Compare(birthvalue, x) == 0)
//            //{
//            //    Console.WriteLine("strings are valid");
//            //}
//        }

//        [When(@"enter new user data")]
//        public async Task enterdata1()
//        {
//            List<string> userList = new string[] { "Zulu", "Max","Mint"}.ToList<string>();
//            Random randNum = new Random();
//            int userName =randNum.Next(0, userList.Count);
//            int randValue = randNum.Next(1000, 2000);

//            string firstName = userList[userName];
//            string newUserName = $"{firstName}_{randValue}";
//            string newUserEmail = $"{newUserName}@yopmail.com";

//            await _page.Locator(_loginPage.TXTLoc_FirstName).ClickAsync();
//            await _page.Locator(_loginPage.TXTLoc_FirstName).FillAsync(firstName);
//            await _page.Locator(_loginPage.TXTLoc_LastName).FillAsync("Laaast");
//            await _page.Locator(_loginPage.TXTLoc_Email).FillAsync(newUserEmail);
//            await _page.Locator(_loginPage.TXTLoc_ReEmail).FillAsync(newUserEmail);
//            await _page.Locator(_loginPage.TXTLoc_UserName).FillAsync(newUserName);
//            await _page.Locator(_loginPage.TXTLoc_Password).FillAsync("Test@1234");
//            await _page.Locator(_loginPage.RDLoc_Gender).ClickAsync();
//            await _page.Locator(_loginPage.CKLoc_Agree).ClickAsync();

//            int id = Thread.CurrentThread.ManagedThreadId;
//            await _page.ScreenshotAsync(new() { Path = TestUtil.ScreenShotPath + $"newuser_{id}.png" });
//            await _page.Locator(_loginPage.BTNLoc_Submit).ClickAsync();
//            Thread.Sleep(15000);
//            if(await VerifyNewUserCreated())
//            {
//                _sharedContext.NEWUSEREMAIL = newUserEmail;
//            }
//        }

//        public async Task FillUserTextFeildData(bool RandomData=false,string? new_username=null)
//        {
//            string? firstName = null;
//            string? newUserName = null;
//            string? newUserEmail = null;
//            if (RandomData)
//            {
//                List<string> userList = new string[] { "Zulu", "Max", "Mint" }.ToList<string>();
//                Random randNum = new Random();
//                int userName = randNum.Next(0, userList.Count);
//                int randValue = randNum.Next(1000, 2000);

//                firstName = userList[userName];
//                newUserName = $"{firstName}{randValue}";
//                newUserEmail = $"{newUserName}@yopmail.com";
//            }
//            else
//            {
//                firstName = "Toon";
//                newUserName = $"{new_username}";
//                newUserEmail = $"{new_username}@yopmail.com";

//            }
//            await _page.Locator(_loginPage.TXTLoc_FirstName).ClickAsync();
//            await _page.Locator(_loginPage.TXTLoc_FirstName).FillAsync(firstName);
//            await _page.Locator(_loginPage.TXTLoc_LastName).FillAsync("Tester");
//            await _page.Locator(_loginPage.TXTLoc_Email).FillAsync(newUserEmail);
//            await _page.Locator(_loginPage.TXTLoc_ReEmail).FillAsync(newUserEmail);
//            await _page.Locator(_loginPage.TXTLoc_UserName).FillAsync(newUserName);
//            await _page.Locator(_loginPage.TXTLoc_Password).FillAsync("Test@1234");
//            await _page.Locator(_loginPage.RDLoc_Gender).ClickAsync();
//            await _page.Locator(_loginPage.CKLoc_Agree).ClickAsync();
//            //await _page.ScreenshotAsync(new() { Path = TestUtil.ScreenShotPath + $"newuser_{id}.png" });
//            //await _page.Locator(_loginPage.BTNLoc_Submit).ClickAsync();



//        }






        
//        public async Task<bool> VerifyNewUserCreated()
//        {
//            bool userResult = false;
//            if (await _page.Locator("div.ossn-message-done").IsVisibleAsync(new() { Timeout = 10000 }))
//            {
//                string? successMessage = await _page.Locator("div.ossn-message-done").TextContentAsync();
//                if(successMessage.Contains("Your account has been registered! We have sent you an account activation email. If you didn't receive the email, please check your spam/junk folder."))
//                {
//                    TestContext.WriteLine("User Created Sucessfully");
//                    userResult = true;
//                }
//                else
//                {
//                    throw new Exception("Failde: User Not created!!!");
//                }
//            }
//            return userResult;
            
//        }













//        [When(@"login with credentials using (.*) and (.*)")]
//        public async Task loginstep(string userName, string password)
//        {
//            _page = await SetNewPageContext();
            
//            await _page.Locator(_loginPage.BTNLoc_Login).ClickAsync();
//            await _page.Locator(_loginPage.TXTLoc_NewUserName).ClearAsync();
//            await _page.Locator(_loginPage.TXTLoc_NewUserName).FillAsync(_sharedContext.NEWUSEREMAIL);
//            await _page.Locator(_loginPage.TXTLoc_NewUserPassword).ClearAsync();
//            await _page.Locator(_loginPage.TXTLoc_NewUserPassword).FillAsync("Test@1234");
//            await _page.Locator(_loginPage.BTNLoc_NewUserLogin).ClickAsync();
//            Thread.Sleep(9000);
//            int id = Thread.CurrentThread.ManagedThreadId;
//            await _page.ScreenshotAsync(new() { Path = TestUtil.ScreenShotPath + $"newuuserlogin_{id}.png" });
//        }

//        public async Task<IPage> SetNewPageContext()
//        {
//            if (_sharedContext.SharedPageContext == null)
//            { Console.WriteLine("Page Context is null No Shared context:"); }
//            else
//            { _page = _sharedContext.SharedPageContext; }
//            return _page;
//        }


//        [When("verify email confirmation")]
//        public async Task verifyMail()
//        {

//        }
//        public async Task enterUserDOB(string birthData)
//        {

//        }
//        public async Task<IPage> SwitchTabs(string tabTitle, IBrowserContext BrowserCTX)
//        {
//            IPage? _page = null;
//            foreach (var tab in BrowserCTX.Pages)
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