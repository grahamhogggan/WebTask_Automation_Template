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
            driver.Navigate().GoToUrl("https://192.168.1.43/ui/apps/");
            Log("Opened Website Successfully");
                        Thread.Sleep(1000);

            var updateAllButtons = driver.FindElements(By.CssSelector("ixtest='update-all'][class='update-all-button mdc-button mat-mdc-button mat-unthemed mat-mdc-button-base ng-star-inserted']"));
            if(updateAllButtons.Any())
            {
                
            Log("update all button found");
            updateAllButtons.First().Click();
            Log("update all Button clicked");
            Thread.Sleep(1000);
            }
            else
            {
                Log("No update all Element");
            }
            var confirmButtons = driver.FindElements(By.CssSelector("ixtest='upgrade'][class='mdc-button mat-mdc-button mat-primary mat-mdc-button-base ng-star-inserted']"));
            if(confirmButtons.Any())
            {
            Log("Confirm button found");
            confirmButtons.First().Click();
            Log("Confirm button clicked");
            Thread.Sleep(1000);
            }
            else
            {
                Log("No Confirm Element");
            }
        }
        catch(Exception e)
        {
            Log($"You messed up: {e.Message}");
        }
        finally
        {
            driver.Quit();
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