using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        try{
            driver.Navigate().GoToUrl("https://testpages.herokuapp.com/styled/basic-html-form-test.html");
            Console.WriteLine("Opened Succesfully");
                        Thread.Sleep(1000);

            var buttons = driver.FindElements(By.CssSelector("input[name='submitbutton'][value='submit']"));
            if(buttons.Any())
            {
            Console.WriteLine("submit button found");
            buttons.First().Click();
            Console.WriteLine("Button clicked");
            Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("No Such Element");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"You messed up: {e.Message}");
        }
        finally
        {
            driver.Quit();
        }
    }
}