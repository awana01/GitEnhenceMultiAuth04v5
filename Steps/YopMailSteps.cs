//using Microsoft.Playwright;
//using PlaySpec1.AppPages;
//using PlaySpec1.SpecHooks;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlaySpec1.StepDef
//{

//    [Binding]
//    public class YopMailSteps
//    {
//        private readonly ScenarioContext _scenarioContext;
//        private readonly SharedContext _sharedContext;
//        private IPage _page;
//        private readonly DemoPage _demoPage;
//        private readonly LoginPage _loginPage;

//        public YopMailSteps(ScenarioContext scenarioContext, SharedContext sharedContext)
//        {
//            _scenarioContext = scenarioContext;
//            _sharedContext = sharedContext;
//            _page = WebHooks.Page!;
//            _loginPage = new LoginPage(_page);
//        }

//        [When(@"go to (.*) yopmail inbox")]
//        public async Task yopInbox(string username)
//        {
//            if (_sharedContext.SharedPageContext == null)
//            {
//                Console.WriteLine("Page Context is null No Shared context:");
//            }
//            else
//            {
//                _page = _sharedContext.SharedPageContext;
                
//            }
//            if (username.Equals("newuser"))
//            {
//                Console.WriteLine(_sharedContext.NEWUSEREMAIL);
//                username = _sharedContext.NEWUSEREMAIL;
//            }


//            string _actURL = await verifyYopMail(username);
//            Console.WriteLine(_actURL);
//            _sharedContext.USERDATA= _actURL;

//            //_scenarioContext.StepContext.Add("USER", _actURL);
            
//            //string activationURL = null;
//            //await _page.Locator("//*[@id='login']").ClickAsync();
//            //await _page.Locator("//*[@id='login']").FillAsync("zulu1122");           //.FillAsync("zoya1122@yopmail.com");
//            //await _page.Locator("div#refreshbut").ClickAsync();
//            //var winHandle = _page.Context; //.CurrentWindowHandle;

//            //Thread.Sleep(1000);
//            //var mailBody = await _page.FrameLocator("iframe#ifmail").Locator("div#mail").TextContentAsync(); // _page.Frame("ifinbox");
//            //Console.WriteLine(mailBody);

//            //string[] strText2 = mailBody?.ToString().Split("\n");
//            //for (int i = 0; i < strText2.Length; i++)
//            //{
//            //    if (strText2[i].StartsWith("https://") && strText2[i].Contains("uservalidate/activate"))
//            //    {
//            //        activationURL = strText2[i];
//            //        Console.WriteLine(activationURL);
//            //        break;
//            //    }
//            //}
//            //await _page.GotoAsync(activationURL);
//            ////return activationURL;
//        }

//        [When(@"navigates to social network activation page")]
//        public async Task stp1()
//        {
//            string val = _sharedContext.USERDATA;
//            Console.WriteLine($"user name:" + val);
//            await _page.GotoAsync(val);
//            Thread.Sleep(2000);
//        }




//        public async Task<string> verifyYopMail(string yopmail)
//        {
//            //Thread.Sleep(300000);
//            string activationURL = null;
//            await _page.Locator("//*[@id='login']").ClickAsync();
//            await _page.Locator("//*[@id='login']").FillAsync(yopmail);           //.FillAsync("zoya1122@yopmail.com");
//            await _page.Locator("div#refreshbut").ClickAsync();
//            var winHandle = _page.Context; //.CurrentWindowHandle;

//            Thread.Sleep(1000);
//            var mailBody = await _page.FrameLocator("iframe#ifmail").Locator("div#mail").TextContentAsync(); // _page.Frame("ifinbox");
//            Console.WriteLine(mailBody);

//            string[] strText2 = mailBody?.ToString().Split("\n");
//            for (int i = 0; i < strText2.Length; i++)
//            {
//                if (strText2[i].StartsWith("https://") && strText2[i].Contains("uservalidate/activate"))
//                {
//                    activationURL = strText2[i];
//                    Console.WriteLine(activationURL);
//                    break;
//                }
//            }
//            //await _page.GotoAsync(activationURL);
//            return activationURL;
//        }


//    }
//}

///*
 
// public async Task<string> VerifyYopMail()
//        {
//          string activationURL = null;
//          await _page.Locator("//*[@id='login']").ClickAsync();
//          await _page.Locator("//*[@id='login']").FillAsync("zoya1122@yopmail.com");
//          await _page.Locator("div#refreshbut").ClickAsync();
//          var winHandle = _page.Context; //.CurrentWindowHandle;

//          Thread.Sleep(1000);
//          var frameInbox = await _page.FrameLocator("ifinbox") // _page.Frame("ifinbox");
//          Thread.Sleep(1000);
          
//                //driver.SwitchTo().Window(winHandle);
//                //Thread.Sleep(1000);
//            var frame2 = _page.Frame("ifmail");
//            //driver.SwitchTo().Frame("ifmail");
//            Thread.Sleep(1000);
//            string mailBody = frame2.Locator(By.XPath("//main[@class='yscrollbar']")).Text;

//            string[] strText2 = mailBody.ToString().Split("\n");
//            for (int i = 0; i < strText2.Length; i++)
//            {
//                if (strText2[i].StartsWith("https://") && strText2[i].Contains("uservalidate/activate"))
//                {
//                    activationURL = strText2[i];
//                    break;
//                }
//            }
//            return activationURL;
//            }
//        }
 
 
 
 
 
// */