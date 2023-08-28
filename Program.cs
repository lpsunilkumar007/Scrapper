using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Set up ChromeDriver
IWebDriver driver = new ChromeDriver();

// Navigate to the demo website
driver.Navigate().GoToUrl("https://bstackdemo.com/");

// Create a list to store the item details
List<string[]> items = new List<string[]>();

// Add your scraping logic here

// Find elements that contain the product details
IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.ClassName("shelf-item"));

// Loop through the product elements and extract the desired information
foreach (IWebElement productElement in productElements)
{
    // Extract the name and price of the product
    string name = productElement.FindElement(By.ClassName("shelf-item__title")).Text;
    string price = productElement.FindElement(By.ClassName("val")).Text;

    // Add the item details to the list
    items.Add(new string[] { name, price });
}
// Saving extracted data in CSV file

string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "items.csv");

using (StreamWriter writer = new StreamWriter(csvFilePath))
{
    // Write the CSV header
    writer.WriteLine("Name,Price");
    // Write the item details
    foreach (string[] item in items)
    {
        writer.WriteLine(string.Join(",", item));
    }
}

// Close the browser
driver.Quit();
