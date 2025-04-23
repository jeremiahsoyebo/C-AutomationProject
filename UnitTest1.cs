using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        loginPage.SignUp("jeremiahsoyebo", "jeremiahsoyebotest@gmail.com");
        // Enter the account info afterchoosing a username and an email
        loginPage.EnterAccountInfo(
            title: 1,
            password: "newpassword11",
            birthDay: 7,
            birthMonth: 12,
            birthYear: 2001,
            firstName: "Jebodiah",
            lastName: "Townhouse",
            address: "110 The Park",
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
        loginPage.Login("jeremiahsoyebotest@gmail.com", "newpassword11");
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}
