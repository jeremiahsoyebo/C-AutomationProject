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

		public void GoToLoginPage()
		{
			LoginButton.Click();
		}
	}
}

