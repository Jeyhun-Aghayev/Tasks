﻿using MassTransit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumSelenium.Data;
using Shared.Dto.Job;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SeleniumApplication.Consumer;

public class JobSearchConsumer : IConsumer<JobSearchDto>
{
    public Task Consume(ConsumeContext<JobSearchDto> context)
    {
        //throw new NotImplementedException();
        //TODO:findJobMethodu nu alan icerisine tasinacak
        return Task.CompletedTask;
    }
}
private static void FindJobs(string keyword, string url, SeleniumAppDbcontext context)
{
    new DriverManager().SetUpDriver(new ChromeConfig());

    using IWebDriver driver = new ChromeDriver();
    var jobs = new List<SeleniumSelenium.Models.Job>();

    try
    {
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("search__input")));
        searchInput.SendKeys(keyword);

        Thread.Sleep(2000);


        int previousItemCount = 0;
        int currentItemCount = 0;
        int maxAttempts = 5; // En fazla deneme sayısı
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            // 'list__scroller' sınıfına sahip div elementini kaydırıyoruz
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('scroller_desctop').scrollTop = document.getElementById('scroller_desctop').scrollHeight;");
            Thread.Sleep(3000); // Bekleme süresi, içeriklerin yüklenmesi için gerekli zaman tanır

            // Şu anki içerik sayısını kontrol ediyoruz
            previousItemCount = currentItemCount;
            currentItemCount = driver.FindElements(By.ClassName("list__item")).Count;

            // Eğer içerik sayısı artmıyorsa, döngüyü durdur
            if (currentItemCount == previousItemCount)
            {
                attempts++; // Deneme sayısını artırıyoruz
                if (attempts >= maxAttempts)
                {
                    break; // Maksimum deneme sayısına ulaşıldığında döngüden çık
                }
            }
            else
            {
                attempts = 0; // Yeni içerik yüklendiğinde deneme sayısını sıfırla
            }
        }

        var listItems = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("list__item")));

        Console.WriteLine(listItems.Count);
        foreach (var item in listItems)
        {
            if (item.GetAttribute("class").Contains("list__item--reklam"))
                continue;

            var anchor = item.FindElement(By.ClassName("list__item__text"));
            if (anchor == null)
                continue;

            var h3 = item.FindElement(By.ClassName("list__item__title"));

            var jobTitle = h3?.Text ?? string.Empty;
            var companyName = anchor.Text.Replace(jobTitle, "").Trim();

            var job = new SeleniumSelenium.Models.Job
            {
                KeyWord = keyword,
                Title = jobTitle,
                Url = anchor.GetAttribute("href"),
                CompanyName = companyName
            };

            jobs.Add(job);
        }

        context.Jobs.AddRange(jobs);
        context.SaveChanges();
    }
    catch (WebDriverException ex)
    {
        Console.WriteLine("An error occurred while navigating to the URL: " + ex.Message);
    }

    driver.Quit();
}

