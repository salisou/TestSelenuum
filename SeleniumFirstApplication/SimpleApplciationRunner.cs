using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApplication
{
    public class SimpleApplciationRunner
    {
        public static void Main(string[] args)
        {
            try
            {
                // Configura il driver
                new DriverManager().SetUpDriver(new FirefoxConfig());

                FirefoxOptions options = new FirefoxOptions();
                options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";

                IWebDriver driver = new FirefoxDriver(options);
                driver.Manage().Window.Maximize();

                // Naviga alla pagina principale
                driver.Navigate().GoToUrl("https://www.github.com");

                // Trova e interagisci con il campo di ricerca
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                //IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("query-builder-test")));

                // Trova e interagisci con il campo di ricerca
                IWebElement searchbox = driver.FindElement(By.CssSelector(".search-input"));
                searchbox.Click();

                IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));

                // Inserisci "Selenium" nel campo di input
                searchInput.SendKeys("Selenium");
                searchInput.SendKeys(Keys.Enter);

                // Chiudi il driver
                //driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il setup del driver: {ex.Message}");
            }
        }
    }
}
