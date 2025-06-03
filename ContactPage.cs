using System;
using OpenQA.Selenium;

namespace AutomationProject
{
	public class ContactPage
	{
		private IWebDriver driver;

		public ContactPage(IWebDriver webDriver)
		{
			driver = webDriver;
		}

		private IWebElement Name => driver.FindElement(By.Name("name"));
        private IWebElement Email => driver.FindElement(By.Name("email"));
		private IWebElement Subject => driver.FindElement(By.Name("subject"));
        private IWebElement Message => driver.FindElement(By.Name("message"));
		private IWebElement SubmitButton => driver.FindElement(By.CssSelector("input[name='submit']"));
        private IWebElement FileUpload => driver.FindElement(By.CssSelector("input[type='file']"));


        public void FillContactForm(string name, string email, string subject, string message, string file)
		{
			// Fill out each respective part of the 'Contact Us' form
			Name.SendKeys(name);
			Email.SendKeys(email);
			Subject.SendKeys(subject);
			Message.SendKeys(message);
			FileUpload.SendKeys(file);

            // Submit the form
            SubmitButton.Click();
		}

    }
}

