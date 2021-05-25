using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NewsProject.Crawler
{
    public class TSNNewsCrawler : ICrawl
    {
        public IEnumerable<NewsModel> Crawl(DateTime dateTime)
        {
            string homeUrl = "https://tsn.ua/news";

            ChromeOptions chromeOptions = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(homeUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            var elements = driver.FindElements(By.ClassName("c-card__link"));

            List<NewsModel> news = elements
                .Select(el => new NewsModel
                {
                    Title = el.Text,
                    Url = el.GetAttribute("href")
                   
                }).ToList();


            for (int i = 0; i < news.Count; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                var n = news[i];
                try
                {
                    driver.Navigate().GoToUrl(n.Url);
                    n.Description = driver.FindElement(By.CssSelector("meta[name^=description]")).GetAttribute("content");
                    var Autor = driver.FindElements(By.ClassName("c-author-links"));
                    var Autors = driver.FindElements(By.ClassName("c-author-dl"));
                    var s1 = Autors[0].FindElements(By.TagName("dd"));
                    var s111 = s1[0].FindElements(By.TagName("a"));
                    var s11123243 = Autors[0].FindElements(By.TagName("a"));
                    

                    // n.DateOfPublication = Convert.ToDateTime(driver.FindElement(By.CssSelector("meta[name^=description]").GetAttribute("datetime"));
                    //if (dateTime > n.DateOfPublication)
                    //    continue;
                    n.Keywords = driver.FindElement(By.CssSelector("meta[name^=keywords]")).GetAttribute("content").Split(',').ToList();

                }
                catch (Exception ex)
                {
                    //log exception
                }
                yield return n;
            }

            driver.Close();
        }

    }
}
