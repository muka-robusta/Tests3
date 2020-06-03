using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace Auto
{
    
    public class Encoder
    {
        private IWebDriver _driver;
        
                public Encoder(IWebDriver driver)
                {
                    _driver = driver;
                    PageFactory.InitElements(driver, this);
                    // sha256Button = _driver.FindElement(By.XPath("//*[@id='index']/ul[1]/li[9]/a"));
                    // inputArea = _driver.FindElement(By.XPath("//*[@id='input']"));
                    // outputArea = _driver.FindElement(By.XPath("//*[@id='output']"));
                    // hashButton = _driver.FindElement(By.XPath("//*[@id='execute']"));
                    // checkButton = _driver.FindElement(By.XPath("//*[@id='auto-update']"));
                }
        
                [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[9]/a")] 
                public IWebElement sha256Button;
        
                [FindsBy(How = How.XPath, Using = "//*[@id='input']")]
                public IWebElement inputArea;
                
                [FindsBy(How = How.XPath, Using = "//*[@id='output']")]
                public IWebElement outputArea;
        
                [FindsBy(How = How.XPath, Using = "//*[@id='execute']")]
                public IWebElement hashButton;
        
                [FindsBy(How = How.XPath, Using = "//*[@id='auto-update']")]
                public IWebElement checkButton;
        
                public bool sha256TestPassed => outputArea.GetAttribute("value").Equals("3f7ed440f078bd06775b276636be0833014c4f07b9c306111ece75906b381b8d");
                
                public Encoder ClickButton(IWebElement buttonToClick)
                {
                    buttonToClick.Click();
                    return this;
                }
        
                public Encoder fillInputArea(IWebElement inputArea, string message_to_send)
                {
                    inputArea.SendKeys(message_to_send);
                    return this;
                }
        
    }
}