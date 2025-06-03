using System;
using OpenQA.Selenium;

namespace AutomationProject
{
	public class HomePage
	{
		private IWebDriver driver;
		public HomePage(IWebDriver webDriver)
		{
			driver = webDriver;
		}

		private IWebElement LoginButton => driver.FindElement(By.CssSelector("a[href='/login']"));
        private IWebElement LogoutButton => driver.FindElement(By.LinkText("Logout"));
        private IWebElement DeleteAccountButton => driver.FindElement(By.LinkText("Delete Account"));
		private IWebElement ContactUsButton => driver.FindElement(By.LinkText("Contact us"));
		private IWebElement TestCasesButton => driver.FindElement(By.LinkText("Test Cases"));
        private IWebElement ProductsButton => driver.FindElement(By.CssSelector("a[href='/products']"));


        public void GoToLoginPage()
		{
			LoginButton.Click();
		}

		public void GoToContactPage()
		{
			ContactUsButton.Click();
		}

		public void GoToTestCasesPage()
		{
			TestCasesButton.Click();
		}

		public void GoToProductsPage()
		{
			ProductsButton.Click();
		}

		public void DeleteAccount()
		{
			DeleteAccountButton.Click();
		}

		public void Logout()
		{
			LogoutButton.Click();
		}
	}
}

