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
    public void UserSignUp()
    {
        var homePage = new HomePage(driver);
        homePage.GoToLoginPage();

        var loginPage = new LoginPage(driver);
        loginPage.SignUp("jeremiahsoyebo", "jeremiahsoyebowala@gmail.com");
        loginPage.EnterAccountInfo(
            title: 1,
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

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}
