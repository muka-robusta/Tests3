using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Auto
{
    public class Tests
    {
        
        private IWebDriver wdriver;
        private string url = "https://emn178.github.io/online-tools/sha256.html";

        [SetUp]
        public void TestInit()
        {
            var options = new FirefoxOptions();
            options.AddArgument("start-maximized");
            
            wdriver = new FirefoxDriver(options);
        }

        [TearDown]
        public void TestFinalize()
        {
            wdriver.Close();
        }

        [Test]
        public void CheckSHA256()
        {
            wdriver.Navigate().GoToUrl(url);
            
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Mellow");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals("3e5655f0e3ba95b45d77cc220df6926bd4a3e5a935ddfcbb1cbab8b8a27d298a"));
        }

        [Test]
        public void CheckSHA512()
        {
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/sha512.html");
            
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Mellow");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals("9ccca4bc30084d6f2ff4cc97ef106263fb3c6ed4b0101013743c75bf194b790518fc4c30864e12cba3f1b80c7eaa7c952ce2ee2c1676a651a4632b3d3a3aa5d7"));

        }

        [Test]
        public void CheckMD5()
        {
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/md5.html");
            
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Mellow");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals("328d8c22f21aee6648af506de11f9e1c"));
        }

        
        
        [Test]
        public void CheckBase64()
        {
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/base64_encode.html");
            
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Mellow");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            
            Assert.IsTrue(result.Equals("SGVsbG8sIE1lbGxvdw=="));
        }
        
        [Test]
        public void CheckKessak224()
        {
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/keccak_224.html");
            
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, mellow");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals("8885d33d8dca32c71ef6fe302b6548fe09b5cdd69ec1a5e5e7e7f248"));
        }

        [Test]
        public void CheckShake128()
        {
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/shake_128.html");
            
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Ilya");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals("097d9faaad12f671b49092eb848f4f29986e3cbb78b3bcac2311884c2a49a948"));
        }

        [Test]
        public void CheckChekbox()
        { 
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/sha512.html");
            wdriver.FindElement(By.XPath("//*[@id=\"auto-update\"]")).Click();
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Ilya");
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals(""));
        }
        
        [Test]
        public void CheckChekboxAndButton()
        { 
            wdriver.Navigate().GoToUrl("https://emn178.github.io/online-tools/sha512.html");
            wdriver.FindElement(By.XPath("//*[@id=\"auto-update\"]")).Click();
            wdriver.FindElement(By.XPath("//*[@id=\"input\"]")).SendKeys("Hello, Ilya");
            wdriver.FindElement(By.XPath("//*[@id=\"execute\"]")).Click();
            var result = wdriver.FindElement(By.XPath("//*[@id=\"output\"]")).GetAttribute("value");
            Assert.IsTrue(result.Equals("84386398ac7f8aae9e9127fc6dbff941928028b3673f90c8a681e95af63b1c615ff185a2966696ed937808c1c167e1cd69a80d01f886cfcd7c65bc675c3c0a8f"));
        }
        
        [Test]
        public void sha256Test()
        {
            var onlineToolsPage = new Encoder(wdriver);
            onlineToolsPage.ClickButton(onlineToolsPage.sha256Button);
            onlineToolsPage.fillInputArea(onlineToolsPage.inputArea,"nvdnsjjasn");
            onlineToolsPage.ClickButton(onlineToolsPage.checkButton);
            onlineToolsPage.ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.sha256TestPassed);
        }
        
        
    }
}