using EnhenceMultiAuth04v4.Pages;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhenceMultiAuth04V4.Pages
{
    public class SocialNewUserPage : BasePage
    {

        IPage _page;
        public SocialNewUserPage(IPage _page) : base(_page)
        {
            this._page = _page;
        }

        public readonly string _NewUser_BirthDate_TXT = "[name='birthdate']";
        public readonly string _NewUser_FirstName_TXT = "[name='firstname']";

        public readonly string _NewUser_LastName_TXT = "[name='lastname']";

        public readonly string _NewUser_Email_TXT = "[name='email']";
        public readonly string _NewUser_ReEmail_TXT = "[name='email_re']";
        public readonly string _NewUser_UserName_TXT = "[name='username']";
        public readonly string _NewUser_Password_TXT = "[name='password']";
        public readonly string _NewUser_Gender_CK = "//input[@name='gender'and @value='male']";
        public readonly string _NewUser_Agree_CK = "[name='gdpr_agree']";
        public readonly string _NewUser_Submit_BTN = "input#ossn-submit-button";

        
        public readonly string _NewUser_ResetPassword_BTN = "a.btn.btn-warning.btn-sm";
        public readonly string _NewUser_NewUserName_TXT = "[name='username']";
        public readonly string _NewUser_NewUserPassword_TXT = "[name='password']";
        public readonly string _NewUser_NewUserLogin_BTN = "input.btn.btn-primary.btn-sm";
        public readonly string _NewUser_Login_BTN = "a.btn.btn-primary.btn-sm";


        public async Task selectDate(IPage page, String day, String month, String year)
        {
            ILocator datePicker = page.Locator("#ui-datepicker-div");

            // Select month
            await datePicker.Locator(".ui-datepicker-month").SelectOptionAsync(month);       //.selectOption(month);

            // Select year
            await datePicker.Locator(".ui-datepicker-year").SelectOptionAsync(year);            //.selectOption(year);

            // Select day
            await datePicker.Locator("//td[@data-handler='selectDay']/a[text()='" + day + "']").ClickAsync();
        }



    }
}
