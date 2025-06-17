# C-AutomationProject
<h2>UI Automation Project using C# with Selenium Webdriver</h2>

<h3>Just to practice testing with Selenium in a different language.</h3>
<h4>Test cases are from automationexercise.com</h4>

## CI/CD Integration

This project is integrated with Jenkins. The Jenkinsfile defines the pipeline that installs dependencies, builds the test framework, runs tests, and publishes the results. Test runs are triggered on new commits or PRs.

Example stages:
- Checkout
- Install dependencies
- Run tests using NUnit
- Publish HTML or XML reports
