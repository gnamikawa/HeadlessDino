using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Linq;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

using System.Threading;


// Chromium Driver
// https://chromedriver.chromium.org/downloads
// https://chromedriver.storage.googleapis.com/index.html?path=86.0.4240.22/

namespace HeadlessDino {
    class Program {
        
        static void Main(string[] args) {

            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size( 616, 282 );

            try {
                driver.Navigate().GoToUrl("chrome://dino/");
            } catch( WebDriverException ) {
                // Result of a disconnection. Dino-run triggers this state.
            }

            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,0,15);
            var dinorun = driver.FindElementByTagName("body");
            dinorun.SendKeys(Keys.Space);

            Thread.Sleep(5000);

            //Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            Screenshot ss = ((ITakesScreenshot)dinorun).GetScreenshot();
            ss.SaveAsFile("screenshot.png");
        }
        
        //static Byte[] GetFrame( IWebElement e ) => ((ITakesScreenshot)e).GetScreenshot().AsByteArray;
    }
}