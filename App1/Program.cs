using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.IO;

public class Program
{
    static string logsPath = System.AppDomain.CurrentDomain.BaseDirectory+"/DebugLogs.txt";
    public static void Main(string[] args)
    {
        Log("\n***************************\nSession Started: "+SystemClock.Instance.Now);
        IWebDriver driver = new ChromeDriver();
        try{
            driver.Navigate().GoToUrl("https://www.github.com/login");
            Log("Opened Website Successfully");
                        Thread.Sleep(2000);

            IWebElement userNameField  = driver.FindElement(By.Id("login_field"));
            userNameField.SendKeys("USERNAME");
            IWebElement passwordField  = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("PASSWORD");
            IWebElement sendButton = driver.FindElement(By.Name("commit"));
            sendButton.Click();
           
        }
        catch(Exception e)
        {
            Log($"You messed up: {e.Message}");
        }
        finally
        {
            //driver.Quit();
        }
    }
    private static void Log(string msg)
    {
        string dat = "";
        if(File.Exists(logsPath))
        {
        dat = File.ReadAllText(logsPath);
        }
        
        dat+="\n"+msg;
        File.WriteAllText(logsPath,dat);
    }
}