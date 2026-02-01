using Allure.Net.Commons;
using EnhenceMultiAuth04v4.Pages;
using EnhenceMultiAuth04v4.Utils;
using EnhenceMultiAuth04V4.Pages;
using Microsoft.Playwright;
using Reqnroll;
using Serilog;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static Microsoft.Playwright.Assertions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EnhenceMultiAuth04v4.Steps
{
    [Binding]
    public sealed class SocialNetworkSteps
    {
        private readonly IPage _page;
        private IPage tabs;
        public SocialNetworkSteps(ScenarioContext ctx) => _page = ctx.Get<IPage>();

        [Given("user navigates to {string}")]
        public async Task GivenUserNavigatesTo(string p0)
        {
            await _page.GotoAsync(p0, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
        }

        [Given("user on demo page")]
        public async Task f1()
        {
            Thread.Sleep(5000);
            //await _page.GotoAsync(p0, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
            //await _page.ClickAsync("a.btn.btn-primary");
            //await ProjUtil.SwitchTab(_page, 1);
        }

        [When("click on front end demo button")]
        public async Task WhenClickOnFrontEndDemoButton()
        {
            await _page.ClickAsync("a.btn.btn-primary");
            await ProjUtil.SwitchTab(_page, 1);
            //tabs = (IPage)ProjUtil.SwitchTab(_page, 1);
            //await tabs.BringToFrontAsync();

        }

        [Then("new tab is open")]
        public async Task ThenNewTabIsOpen()
        {
            Console.WriteLine($"New Tab title: {_page.TitleAsync()}");

            //await Expect(_page.GetByTestId("status")).ToHaveTextAsync("Submitted");
        }

        [When("enter username and password")]
        public async Task WhenEnterUsernameAndPassword()
        {
            Console.WriteLine("enter username and password");
        }

        [When("click on login button")]
        public async Task WhenClickOnLoginButton()
        {
            await tabs.ClickAsync("btn.btn-primary.btn-sm");
        }

        [Then("user navigates to social network dashboard")]
        public async Task ThenUserNavigatesToSocialNetworkDashboard()
        {
            Thread.Sleep(7000);
        }

    }


    [Binding]
    public class SocialNewUser
    {

        private readonly IPage _page;
        private readonly SocialNewUserPage socialNewUserPage;
        private readonly ScenarioContext _scenarioContext;

        public SocialNewUser(ScenarioContext ctx) {
            _scenarioContext = ctx;
            _page = ctx.Get<IPage>();
            socialNewUserPage = new SocialNewUserPage(_page);
        }

        [Given(@"user on soacial home page")]
        public async Task f0()
        {
            await _page.GotoAsync("https://demo.opensource-socialnetwork.org/");
        
        }


        [When(@"enter all feilds")]
        public async Task f1()
        {

            int rand = new Random().Next(1000,2000);
            string firstName = Faker.Name.First();
            string userName = firstName + rand;
            string userEmail = userName + "@yopmail.com";

            _scenarioContext["NewUserEmail"] = userEmail;

            await _page.Locator(socialNewUserPage._NewUser_FirstName_TXT).FillAsync(firstName);
            await _page.Locator(socialNewUserPage._NewUser_LastName_TXT).FillAsync(Faker.Name.Last());
            await _page.Locator(socialNewUserPage._NewUser_NewUserName_TXT).FillAsync(userName);
            await _page.Locator(socialNewUserPage._NewUser_NewUserPassword_TXT).FillAsync("Test@1234");
            await _page.Locator(socialNewUserPage._NewUser_Email_TXT).FillAsync(userEmail);
            await _page.Locator(socialNewUserPage._NewUser_ReEmail_TXT).FillAsync(userEmail);
            await _page.Locator(socialNewUserPage._NewUser_Gender_CK).ClickAsync();
            

            await _page.Locator(socialNewUserPage._NewUser_BirthDate_TXT).ClickAsync();
            //await _page.Locator(socialNewUserPage._NewUser_BirthDate_TXT).FillAsync("02/02/2000");

            await socialNewUserPage.selectDate(_page, "3", "Feb.", "2000");

            await _page.Locator(socialNewUserPage._NewUser_Agree_CK).ClickAsync();

            _scenarioContext["Step1"] = "Hello World From Step1";

            Thread.Sleep(1500);
            
        }

        [When(@"click on submit button")]
        public async Task f2()
        {
            Console.WriteLine($"Step 2: {_scenarioContext.Get<string>("Step1")}");
            await _page.Locator(socialNewUserPage._NewUser_Submit_BTN).ClickAsync();
            Thread.Sleep(2000);
            await Assertions.Expect(_page.Locator("div.ossn-message-done")).ToContainTextAsync("Your account has been registered! We have sent you an account activation email.");


        }

        [When(@"verify new user email")]
        public async Task verifynewuserEmail()
        {
            IPage mailPage = await ProjUtil.OpenNewTab(_page);
            await mailPage.GotoAsync("https://yopmail.com",new PageGotoOptions { WaitUntil=WaitUntilState.DOMContentLoaded});
            await mailPage.ClickAsync("input#login");
            
            string newMail = _scenarioContext.Get<string>("NewUserEmail");
            Console.WriteLine(newMail);

            await mailPage.FillAsync("input#login", newMail);
            await mailPage.ClickAsync("button[title='Check Inbox @yopmail.com']");
            Thread.Sleep(5000);

            IReadOnlyList<string> mailContent = await mailPage.FrameLocator("iframe#ifmail").Locator("div#mail").AllTextContentsAsync();
            Console.WriteLine(mailContent);
            Console.WriteLine(mailContent.Count);


            string? mailContent2 = await mailPage.FrameLocator("iframe#ifmail").Locator("div#mail").TextContentAsync();

            Console.WriteLine(mailContent2);

            string[] x = mailContent2.Split("\n");
            Console.WriteLine("Total Len: " + x.Length);
            Console.WriteLine("Validation URL: " + x[2]);

            Log.Information("New User Email: " + newMail);

            var lines = mailContent2.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string thirdLine = lines[2];
            Console.WriteLine("Activation URL: "+thirdLine);

            IPage ActivationPage = await ProjUtil.OpenNewTab(_page);
            await ActivationPage.GotoAsync(thirdLine);
            
            Thread.Sleep(5000);
            Console.WriteLine("Project Base Directory" + ProjUtil.ProjectBaseDirectory);
            Console.WriteLine("Project Base Directory" + ProjUtil.getBaseDirectory);

            IReadOnlyList<IPage> _validationPage =  _page.Context.Pages;
            await _validationPage[2].BringToFrontAsync();
            //Thread.Sleep(6000);
            //await _validationPage[2].PauseAsync();

            //await Assertions.Expect(_validationPage[2].Locator("div.ossn-system-messages-inner")).ToContainTextAsync("The account has been validated!");
            await _validationPage[2].CloseAsync();



        }

        [When(@"login with new user")]
        public async Task f3()
        {
            string newMail = _scenarioContext.Get<string>("NewUserEmail");
            await _page.BringToFrontAsync();
            await new SiteBLoginPage(_page).GeneralLogin(newMail, "Test@1234");
            Thread.Sleep(5000);
            AllureApi.AddAttachment("Screenshot2", "image/png", await ProjUtil.CaptureScreenshotBytes(_page, "admin.png"));

            ProjUtil.RegisterLog("Hello World!!!");
        }








    }












}