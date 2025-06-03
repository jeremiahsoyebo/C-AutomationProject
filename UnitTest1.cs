using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.automationexercise.com/");

    }

    [Test]
    // Test case to verify that a user can sign up for an account
    public void UserSignUp()
    {
        // Create an instance of the HomePage
        var homePage = new HomePage(driver);
        homePage.GoToLoginPage();

        // Create an instance of the LoginPage
        var loginPage = new LoginPage(driver);
        // Sign up for an account
        loginPage.SignUp("jebbytowntest", "jebtownhouset@gmail.com");
        // Enter the account info afterchoosing a username and an email
        loginPage.EnterAccountInfo(
            title: 1,
            password: "newpassword11",
            birthDay: 7,
            birthMonth: 12,
            birthYear: 2001,
            firstName: "Jebodiah",
            lastName: "Townhouse",
            address: "115 The Park",
            country: "United States",
            state: "TX",
            city: "Regularville",
            zipcode: "75002",
            mobileNumber: "555-0013"

            );
    }

    [Test]
    // Test Case to verify that a user can delete their account
    public void DeleteAccount()
    {
        var homePage = new HomePage(driver);
        homePage.GoToLoginPage();

        var loginPage = new LoginPage(driver);
        // Login into a valid account
        loginPage.Login("jeremiahsoyebowala@gmail.com", "newpassword11");
        // Delete the account
        homePage.DeleteAccount();

        Thread.Sleep(3000);
    }

    [Test]
    // Test case to verify that an invalid user cannot login
    public void VerifyInvalidUser()
    {
        var homePage = new HomePage(driver);
        homePage.GoToLoginPage();

        var loginPage = new LoginPage(driver);
        // Attempt to login with an invalid user
        loginPage.Login("jeremiahplockey@gmail.com", "newpassword11");

        // Verify that the error message is visible by checking the text inside the <p> tag
        var errorMessage = driver.FindElement(By.XPath("//p[contains(text(),'Your email or password is incorrect!')]"));
        Assert.IsTrue(errorMessage.Displayed, "Error message for incorrect login not displayed.");
    }

    [Test]
    public void LogoutUser()
    {
        var homePage = new HomePage(driver);
        homePage.GoToLoginPage();

        var loginPage = new LoginPage(driver);
        loginPage.Login("jebtownhouset@gmail.com", "newpassword11");

        homePage.Logout();
    }

    [Test]
    // Test to verify that a new user cannot be registered with an existing email
    public void RegisterExistingUser()
    {
        var homePage = new HomePage(driver);
        homePage.GoToLoginPage();

        // Create an instance of the LoginPage
        var loginPage = new LoginPage(driver);
        // Sign up for an account
        loginPage.SignUp("blooby", "jebtownhouset@gmail.com");

        // Verify that the error message is visible by checking the text inside the <p> tag
        var errorMessage = driver.FindElement(By.XPath("//p[contains(text(),'Email Address already exist!')]"));
        Assert.IsTrue(errorMessage.Displayed, "Error message for incorrect login not displayed.");
    }

    // Test Case 6: Contact us Form
    [Test]
    // Test to verify user can submit something to contact
    public void VerifyContactUsForm()
    {
        var homepage = new HomePage(driver);
        homepage.GoToContactPage();

        // Verify that the contact page message is visible by checking the text inside the <p> tag
        var confirmationMessage = driver.FindElement(By.XPath("//h2[contains(text(),'Get In Touch')]"));
        Assert.IsTrue(confirmationMessage.Displayed, "'GET IN TOUCH' text not displayed on the page.");

        var contactpage = new ContactPage(driver);
        contactpage.FillContactForm(
            name: "Bobby Bouche",
            email: "bobbyb@che.com",
            subject: "Test Inquiry",
            message: "Hello, I am just using this as a test and wanted to see if it works successfully." +
            "\nThanks,\nBobby Bouche",
            file: @"/Users/jeremiahsoyebo/Downloads/caesar.jpeg");

        // Accept the alert to confirm the submission of the contact form
        IAlert alert = driver.SwitchTo().Alert();
        alert.Accept();

        // Verify the inquiry was submitted successfully
        var successMessage = driver.FindElement(By.XPath("//div[contains(text(), 'Success! Your details have been submitted successfully.')]"));
        Assert.IsTrue(successMessage.Displayed, "Success message not displayed.");
    }

    // Test Case 7: Verify Test Cases Page
    [Test]
    // Test to verify that the Test Cases page can be seen successfully
    public void VerifyTestCasesPage()
    {
        // Navigate to the Test Cases Page
        var homepage = new HomePage(driver);
        homepage.GoToTestCasesPage();

        // Verify that the Test Cases page message is visible by checking the text inside the <p> tag
        var confirmationMessage = driver.FindElement(By.XPath("//b[contains(text(),'Test Cases')]"));
        Assert.IsTrue(confirmationMessage.Displayed, "'Test Cases' text not displayed on the page.");
    }

    // Test Case 8: Verify All Products and product detail page
    [Test]
    public void VerifyProductsPage()
    {
        // Navigate to the prodcuts page
        var homepage = new HomePage(driver);
        homepage.GoToProductsPage();

        // Verify that the Products page message is visible by checking the text inside the <p> tag
        var confirmationMessage = driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]"));
        Assert.IsTrue(confirmationMessage.Displayed, "'All Products' text not displayed on the page.");

        // Click on the first product
        var productpage = new ProductsPage(driver);
        productpage.ViewProduct(productNumber: 1);

        // Verify that the Products page message is visible by checking the text inside the <p> tag
        var itemMessage = driver.FindElement(By.XPath("//h2[contains(text(),'Blue Top')]"));
        Assert.IsTrue(itemMessage.Displayed, "'Blue Top' text not displayed on the page.");

    }

    // Test Case 9: Verify Search Products
    [Test]
    public void VerifyProductSearch()
    {
        // Store the product name in a variable
        string productName = "Top";

        // Navigate to the prodcuts page
        var homepage = new HomePage(driver);
        homepage.GoToProductsPage();

        // Verify that the Products page message is visible by checking the text inside the <p> tag
        var confirmationMessage = driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]"));
        Assert.IsTrue(confirmationMessage.Displayed, "'All Products' text not displayed on the page.");

        // Type in the desired product and search
        var productpage = new ProductsPage(driver);
        productpage.SearchProduct(product: productName);

        // Verify that the user has searched products
        var searchConfirmationMessage = driver.FindElement(By.XPath("//h2[contains(text(),'Searched Products')]"));
        Assert.IsTrue(searchConfirmationMessage.Displayed, "'Searched Products' text not displayed on the page.");

        // Verify that ALL Products relating to the product search are visible
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElements(By.XPath("//p[contains(text(),'Top')]")).Count > 0);

        var visibleProducts = driver.FindElements(By.XPath("//p[contains(text(),'Top')]"))
                                    .Where(e => e.Displayed).ToList();

        Assert.IsTrue(visibleProducts.Count > 0, "No visible matching products found.");
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}
