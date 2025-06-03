using System;
using OpenQA.Selenium;
namespace AutomationProject
{
	public class ProductsPage
	{
		private IWebDriver driver;
        private IJavaScriptExecutor js;

        public ProductsPage(IWebDriver webDriver)
		{
			driver = webDriver;
            this.js = (IJavaScriptExecutor)driver;
        }

		private IWebElement SearchBar => driver.FindElement(By.Id("search_product"));
		private IWebElement SearchButton => driver.FindElement(By.Id("submit_search"));

		public void ViewProduct(int productNumber) {

            js.ExecuteScript("window.scrollBy(0, 500);");

            IWebElement ViewProductButton = driver.FindElement(By.CssSelector($"a[href='/product_details/{productNumber}']"));

			ViewProductButton.Click();

		}

		public void SearchProduct(string product)
		{
			// Type the product into the search bar
			SearchBar.SendKeys(product);

			// Click the search button
			SearchButton.Click();

            // Scroll down after the search
            js.ExecuteScript("window.scrollBy(0, 500);");
        }
	}
}

