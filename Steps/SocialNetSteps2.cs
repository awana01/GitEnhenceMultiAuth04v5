//using Microsoft.Playwright;
//using PlaySpec1.AppPages;
//using PlaySpec1.SpecHooks;
//using System.Text;
//using System;
//using System.Text.RegularExpressions;
//using TechTalk.SpecFlow;

//namespace PlaySpec1.StepDef
//{
//    [Binding]
//    public class SocialNetSteps2
//    {
//        private readonly ScenarioContext _scenarioContext;
//        private readonly SharedContext _sharedContext;
//        private IPage _page;
//        private readonly DemoPage _demoPage;
//        private readonly LoginPage _loginPage;
       

       
//        public SocialNetSteps2(ScenarioContext scenarioContext, SharedContext sharedContext)
//        {
//            _scenarioContext = scenarioContext;
//            _sharedContext = sharedContext;
//            _page = WebHooks.Page!;
//            _loginPage = new LoginPage(_page);
//        }

//        //[When(@"click on 'dob' element and enter birtdate as ""([^""]*)""")]
//        //public async Task stepDob(string birthDate)
//        //{
//        //    _page = _sharedContext.SharedPageContext;

//        //    string[] birthString = birthDate.Split(" ");
//        //    Thread.Sleep(200);

//        //    string patternX = @"^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$";
//        //    bool isMatch5 = Regex.IsMatch(birthDate, patternX);
//        //    if (isMatch5)
//        //    {   await SetUserDob(birthString[0],birthString[1], birthString[2]);   }
//        //    else 
//        //    {   throw new Exception("Error => Enter DOB in correct format of : day monthname year (00 March 1983)");  }




//        //}

//        //public async Task SetUserDob(string _month,String _year)
//        //{
//        //    if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//        //    {
//        //        await _page.Locator(_loginPage._TXTLoc_BirthDate).ClickAsync();
//        //        Thread.Sleep(500);

//        //        await _page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { $"{_month}" });
//        //        Thread.Sleep(200);

//        //        await _page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { $"{_year}" });
//        //        Thread.Sleep(200);

//        //        var todayNum = DateTime.Today.Day; //.Now.ToString("d");
//        //        string _dayLocator = $"//td/a[@data-date='{todayNum}']";
//        //        await _page.Locator(_dayLocator).ClickAsync();
//        //        Thread.Sleep(1500);

//        //    }

            
//        //}

//        //public async Task SetUserDob(string _day, string _month, String _year)
//        //{
//        //    if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
//        //    {
//        //        await _page.Locator(_loginPage._TXTLoc_BirthDate).ClickAsync();
//        //        Thread.Sleep(500);

//        //        await _page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { $"{_month}" });
//        //        Thread.Sleep(200);

//        //        await _page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { $"{_year}" });
//        //        Thread.Sleep(200);

//        //        //var todayNum = DateTime.Today.Day; //.Now.ToString("d");
//        //        string _dayLocator = $"//td/a[@data-date='{_day}']";
//        //        await _page.Locator(_dayLocator).ClickAsync();
//        //        Thread.Sleep(1500);

//        //    }
//        //}

//            //[When(@"click on 'dob' element and enter birtdate as ""([^""]*)""")]
//            //public async Task enterDOB(string birthString)
//            //{

//            //    _page = _sharedContext.SharedPageContext;

//            //    await _page.Locator(_loginPage._TXTLoc_BirthDate).ClickAsync();
//            //    Thread.Sleep(3000);



//            //    string input1 = "ABC-1234";
//            //    string pattern1 = @"^[A-Z]{3}-\d{4}$";

//            //    string input2 = "example@example.com";
//            //    string pattern2 = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

//            //    string input3 = "abc-1234";
//            //    string pattern3 = @"^[a-z]{3}-\d{4}$";

//            //    string input4 = "12345";
//            //    bool isNumeric4 = int.TryParse(input4, out _);

//            //    //date string 1;
//            //    string input5 = "20 October 2000";
//            //    string pattern = @"^\d{2} (January|February|March|April|May|June|July|August|September|October|November|December) \d{4}$";
//            //    bool isMatch1 = Regex.IsMatch(input5, pattern);

//            //    if (isMatch1) { Console.WriteLine($"String {input5} is in correct format");  }

//            //    //date string 2
//            //    string input6 = "20 Jan. 2000"; // Change this to test other months
//            //    string pattern6 = @"^\d{2} (Jan\.|Feb\.|Mar\.|Apr\.|May\.|Jun\.|Jul\.|Aug\.|Sep\.|Oct\.|Nov\.|Dec\.) \d{4}$";
//            //    bool isMatch2 = Regex.IsMatch(input6, pattern6);
//            //    if (isMatch2) { Console.WriteLine($"String {input6} is in correct format"); }

//            //    //date string 2
//            //    string input7 = "20 June 2000"; // Change this to test other months
//            //    string pattern7 = @"^\d{2} (Jan\.|Feb\.|Mar\.|Apr\.|May\.|June|July|Aug\.|Sep\.|Oct\.|Nov\.|Dec\.) \d{4}$";
//            //    bool isMatch3 = Regex.IsMatch(input7, pattern7);
//            //    if (isMatch3) { Console.WriteLine($"String {input7} is in correct format"); }
//            //}

//            [When(@"dateformat input1 is ""([^""]*)""")]
//            public async Task dateFormat1(string dateString)
//            {
//            //"20 Jan. 2000"
//            //date string 2
//            string input7 = dateString; //"20 June 2000"; // Change this to test other months
//            string pattern7 = @"^\d{2} (Jan\.|Feb\.|Mar\.|Apr\.|May\.|June|July|Aug\.|Sep\.|Oct\.|Nov\.|Dec\.) \d{4}$";
//            bool isMatch3 = Regex.IsMatch(input7, pattern7);
//            if (isMatch3) { Console.WriteLine($"String {input7} is in correct format"); }
//            else { Console.WriteLine($"String {input7} is not in correct format"); }


//            string pattern8 = @"^\d{2} (Jan\.|Feb\.|(Mar\.|March)|Apr\.|May\.|June|July|Aug\.|Sep\.|Oct\.|Nov\.|Dec\.) \d{4}$";
//            bool isMatch4 = Regex.IsMatch(input7, pattern8);
//            if (isMatch4) { Console.WriteLine($"String {input7} is in correct format"); }
//            else { Console.WriteLine($"Error: String {input7} is not in correct format"); }

//            string pattern9 = @"^(\d{1}|\d{2}) (Jan\.|Feb\.|(Mar\.|March)|Apr\.|May\.|June|July|Aug\.|Sep\.|Oct\.|Nov\.|Dec\.) \d{4}$";
//            bool isMatch5 = Regex.IsMatch(input7, pattern9);
//            if (isMatch5) { Console.WriteLine($"String {input7} is in correct format"); }
//            else { Console.WriteLine($"Error: String {input7} is not in correct format"); }

//        }

//        [When(@"dateformat input2 is ""([^""]*)""")]
//        public async Task format2(string dateString)
//        {
//            string patternX = @"^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$";
//            bool isMatch5 = Regex.IsMatch(dateString, patternX);
//            if (isMatch5)
//            {
//                string[] dateData = dateString.Split(" ");
//                Console.WriteLine($"Date Data split: {dateData[0]} -- {dateData[1]} -- {dateData[2]}");
//                Console.WriteLine($"String {dateString} is in correct format");

//                switch (dateData[1])
//                {
//                    case "January":
//                    case "Jan.":
//                    case "Jan":
//                        Console.WriteLine($"January is found");
                        


//                        break;

//                    case "February":
//                    case "Feb.":
//                    case "Feb":
//                        Console.WriteLine($"February is found");
//                        break;
//                    case "March":
//                    case "Mar.":
//                    case "Mar":
//                        Console.WriteLine($"March is found");
//                        break;

//                    case "April":
//                    case "Apr.":
//                    case "Apr":
//                        Console.WriteLine($"April is found");
//                        break;

//                    case "May":
//                        Console.WriteLine($"May is found");
//                        break;

//                    case "June":
//                    case "Jun.":
//                    case "Jun":
//                        Console.WriteLine($"June is found");
//                        break;

//                    case "July":
//                    case "Jul.":
//                    case "Jul":
//                        Console.WriteLine($"July is found");
//                        break;

//                    case "August":
//                    case "Aug.":
//                    case "Aug":
//                        Console.WriteLine($"August is found");
//                        break;

//                    case "September":
//                    case "Sep.":
//                    case "Sept.":
//                    case "Sept":
//                        Console.WriteLine($"September is found");
//                        break;
                        
//                    case "October":
//                    case "Oct.":
//                    case "Oct":
//                        Console.WriteLine($"October is found");
//                        break;

//                    case "November":
//                    case "Nov.":
//                    case "Nov":
//                        Console.WriteLine($"November is found");
//                        break;

//                    case "December":
//                    case "Dec.":
//                    case "Dec":
//                        Console.WriteLine($"December is found");
//                        break;

//                }

//            }
//            else { 
//                Console.WriteLine($"Error: String {dateString} is not in correct format"); 
//            }
            
//        }


//        //[When(@"dateformat input3 (.*)")]
//        //public async Task frmtx1(string dateString1)
//        //{
//        //    Console.WriteLine(dateString1);
//        //    string patternX = @"^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$";
//        //    bool isMatch5 = Regex.IsMatch(dateString, patternX);
//        //    if (isMatch5) { Console.WriteLine($"String {dateString} is in correct format"); }
//        //    else { Console.WriteLine($"Error: String {dateString} is not in correct format"); }

//        //    return $"String {dateString} is in correct format";
//        //}



//        //[StepArgumentTransformation(@"^dob as ^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$")]
//        //public async Task<string> UserDob(string dateString)
//        //{
//        //    string patternX = @"^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$";
//        //    bool isMatch5 = Regex.IsMatch(dateString, patternX);
//        //    if (isMatch5) { Console.WriteLine($"String {dateString} is in correct format"); }
//        //    else { Console.WriteLine($"Error: String {dateString} is not in correct format"); }

//        //    return $"String {dateString} is in correct format";
//        //}



//        // 
//    }
//    }