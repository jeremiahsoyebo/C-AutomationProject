using System;
using OpenQA.Selenium;

namespace AutomationProject
{
	public class LoginPage
	{
		private IWebDriver driver;

		public LoginPage(IWebDriver webDriver)
		{
			driver = webDriver;
		}

        // Fields for logging in
        private IWebElement LoginEmail => driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
        private IWebElement LoginPassword => driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("input[data-qa='login-button']"));


        // Fields for signing up
        private IWebElement SignupNameInput => driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        private IWebElement SignupEmailInput => driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));

        // Fields for entering account information
        private IWebElement NameInput => driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement EmailInput => driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement SignupButton => driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
		private IWebElement Password => driver.FindElement(By.CssSelector("input[data-qa='password']"));
        private IWebElement BirthDay => driver.FindElement(By.CssSelector("select[data-qa='days']"));
        private IWebElement BirthMonth => driver.FindElement(By.CssSelector("select[data-qa='months']"));
        private IWebElement BirthYear => driver.FindElement(By.CssSelector("select[data-qa='years']"));
        private IWebElement FirstName => driver.FindElement(By.CssSelector("input[data-qa='first_name']"));
        private IWebElement LastName => driver.FindElement(By.CssSelector("input[data-qa='last_name']"));
        private IWebElement Address => driver.FindElement(By.CssSelector("input[data-qa='address']"));
        private IWebElement Country => driver.FindElement(By.CssSelector("select[data-qa='country']"));
        private IWebElement State => driver.FindElement(By.CssSelector("input[data-qa='state']"));
        private IWebElement City => driver.FindElement(By.CssSelector("input[data-qa='city']"));
        private IWebElement Zipcode => driver.FindElement(By.CssSelector("input[data-qa='zipcode']"));
        private IWebElement MobileNumber => driver.FindElement(By.CssSelector("input[data-qa='mobile_number']"));
        private IWebElement CreateAccount => driver.FindElement(By.CssSelector("button[data-qa='create-account']"));

        public void Login(string email, string password)
        {
            LoginEmail.SendKeys(email);
            LoginPassword.SendKeys(password);
            LoginButton.Click();
        }

        public void SignUp(string name, string email)
		{
			SignupNameInput.SendKeys(name);
			SignupEmailInput.SendKeys(email);
			SignupButton.Click();
		}

		public void EnterAccountInfo(int title, string password, int birthDay, int birthMonth, int birthYear, string address, string firstName, string lastName, string country, string state, string city, string zipcode, string mobileNumber, string name = null, string email = null)
		{
			// Find and click the radio button chosen by the user
			var genderRadio = driver.FindElement(By.Id($"id_gender{title}"));
			genderRadio.Click();
			
            Password.SendKeys(password);
			// Find the click the dropdown for the day of birth
			BirthDay.Click();
			// Click the day from the dropdown
            driver.FindElement(By.CssSelector($"option[value='{birthDay}']")).Click();
            // Find the click the dropdown for the month of birth
            BirthMonth.Click();
            // Click the month from the dropdown
            driver.FindElement(By.CssSelector($"option[value='{birthMonth}']")).Click();
            // Find the click the dropdown for the year of birth
            BirthYear.Click();
            // Click the year from the dropdown
            driver.FindElement(By.CssSelector($"option[value='{birthYear}']")).Click();
            // Fill in the first and last name, then address
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Address.SendKeys(address);
            Country.Click();
            driver.FindElement(By.CssSelector($"option[value='{country}']")).Click();
            State.SendKeys(state);
            City.SendKeys(city);
            Zipcode.SendKeys(zipcode);
            MobileNumber.SendKeys(mobileNumber);

            // Create the account
            CreateAccount.Click();

            Thread.Sleep(3000);
        }
    }
}

