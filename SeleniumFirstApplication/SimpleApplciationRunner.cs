using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApplication
{
    public class SimpleApplciationRunner // Classe principale che contiene il metodo Main
    {
        public static void Main(string[] args) // Punto di ingresso dell'applicazione
        {
            try
            {
                // Configura il driver utilizzando WebDriverManager per scaricare automaticamente il driver corretto
                new DriverManager().SetUpDriver(new FirefoxConfig());

                // Configura le opzioni per il browser Firefox
                FirefoxOptions options = new FirefoxOptions();
                options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe"; // Specifica il percorso eseguibile di Firefox

                // Inizializza il driver di Firefox con le opzioni configurate
                IWebDriver driver = new FirefoxDriver(options);
                driver.Manage().Window.Maximize(); // Massimizza la finestra del browser

                // Naviga alla pagina principale di GitHub
                driver.Navigate().GoToUrl("https://www.github.com");

                // Configura un'attesa esplicita per elementi che potrebbero richiedere tempo per caricarsi
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                // Definisce il termine di ricerca da utilizzare
                string serchInputSelector = "selenium";

                // Trova il campo di ricerca utilizzando un selettore CSS e lo clicca
                IWebElement searchbox = driver.FindElement(By.CssSelector(".search-input"));
                searchbox.Click();

                // Trova il campo di input per la ricerca e inserisce il termine di ricerca
                IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));
                searchInput.SendKeys(serchInputSelector); // Inserisce "selenium" nel campo di input
                searchInput.SendKeys(Keys.Enter); // Simula la pressione del tasto "Invio"

                // Recupera i risultati della ricerca come una lista di stringhe
                IList<string> actualItems = driver.FindElements(By.CssSelector("[data-testid='results-list'] > div"))
                    .Select(item => item.Text.ToLower()).ToList();

                // Filtra i risultati per verificare che contengano il termine di ricerca
                IList<string> expectedItems = actualItems.Where(item => item.Contains("serchInput Selector")).ToList();

                // Verifica che i risultati attesi corrispondano ai risultati effettivi
                Assert.That(expectedItems, Is.EqualTo(actualItems), "I risultati della ricerca non corrispondono a 'selenium'");

                // Chiude il driver (commentato per ora)
                //driver.Quit();
            }
            catch (Exception ex) // Gestisce eventuali eccezioni
            {
                // Stampa un messaggio di errore in caso di eccezione
                Console.WriteLine($"Errore durante il setup del driver: {ex.Message}");
            }
        }
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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                //IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("query-builder-test")));

                string serchInputSelector = "selenium";

                // Trova e interagisci con il campo di ricerca
                IWebElement searchbox = driver.FindElement(By.CssSelector(".search-input"));
                searchbox.Click();

                IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));

                // Inserisci "Selenium" nel campo di input
                searchInput.SendKeys(serchInputSelector);
                searchInput.SendKeys(Keys.Enter);

                IList<string> actualItems = driver.FindElements(By.CssSelector("[data-testid='results-list'] > div"))
                    .Select(item => item.Text.ToLower()).ToList();

                IList<string> expectedItems = actualItems.Where(item => item.Contains("serchInput Selector")).ToList();

                Assert.That(expectedItems, Is.EqualTo(actualItems), "I risultati della ricerca non corrispondono a 'selenium'");

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
