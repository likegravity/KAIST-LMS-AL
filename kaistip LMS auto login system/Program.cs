using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Windows.Forms;

namespace KaistIpLMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            ChromeOptions options = new ChromeOptions();

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            DateTime.Now.ToString("yyyy-MM-dd");
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            driver = new ChromeDriver(chromeDriverService, options);

            driver.Navigate().GoToUrl("https://talented.kaist.ac.kr:8443/home/login/homelogin.do");
            driver.FindElement(By.XPath("/html/body/div[1]/section/article[1]/div/div[3]/form/ul/li[1]/input")).SendKeys(File.ReadAllText("id.txt"));
            driver.FindElement(By.XPath("/html/body/div[1]/section/article[1]/div/div[3]/form/ul/li[2]/input")).SendKeys(File.ReadAllText("pw.txt"));
            driver.FindElement(By.XPath("/html/body/div[1]/section/article[1]/div/div[3]/form/div[1]/a")).Click();
            Thread.Sleep(1000);
            driver.Quit();
            MessageBox.Show(today + "로그인 성공.");


            /*foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.StartsWith("chromedriver"))

                {
                    process.Kill();

                }

            }
            */
            Thread.Sleep(1000);


        }
    }
}
