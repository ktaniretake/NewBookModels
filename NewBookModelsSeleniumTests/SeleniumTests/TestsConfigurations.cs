using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NewBookModelsSeleniumTests.SeleniumTests
{
    public class TestsConfigurations
    {
        public IWebDriver _webDriver;
        public const string JS_DROP_FILE = "for(var b=arguments[0],k=arguments[1],l=arguments[2],c=b.ownerDocument,m=0;;){var e=b.getBoundingClientRect(),g=e.left+(ke.width2),h=e.top+(le.height2),f=c.elementFromPoint(g,h);if(f&&b.contains(f))break;if(1++m)throw b=Error('Element not interractable'),b.code=15,b;b.scrollIntoView({behavior'instant',block'center',inline'center'})}var a=c.createElement('INPUT');a.setAttribute('type','file');a.setAttribute('style','positionfixed;z-index2147483647;left0;top0;');a.onchange=function(){var b={effectAllowed'all',dropEffect'none',types['Files'],filesthis.files,setDatafunction(){},getDatafunction(){},clearDatafunction(){},setDragImagefunction(){}};window.DataTransferItemList&&(b.items=Object.setPrototypeOf([Object.setPrototypeOf({kind'file',typethis.files[0].type,filethis.files[0],getAsFilefunction(){return this.file},getAsStringfunction(b){var a=new FileReader;a.onload=function(a){b(a.target.result)};a.readAsText(this.file)}},DataTransferItem.prototype)],DataTransferItemList.prototype));Object.setPrototypeOf(b,DataTransfer.prototype);['dragenter','dragover','drop'].forEach(function(a){var d=c.createEvent('DragEvent');d.initMouseEvent(a,!0,!0,c.defaultView,0,0,0,g,h,!1,!1,!1,!1,0,null);Object.setPrototypeOf(d,null);d.dataTransfer=b;Object.setPrototypeOf(d,DragEvent.prototype);f.dispatchEvent(d)});a.parentElement.removeChild(a)};c.documentElement.appendChild(a);a.getBoundingClientRect();return a;";
        public WebDriverWait _wait;
        public IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _js = (IJavaScriptExecutor)_webDriver;

        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        public ClientAuthModel CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
            {
                { "email", $"{ DateTime.Now.ToString("hhmmss")}reeves@gmail.com" },
                { "first_name", Constants.FirstName },
                { "last_name", Constants.LastName },
                { "password", Constants.Password },
                { "phone_number", Constants.Phone }
            };


            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }
    }
}
