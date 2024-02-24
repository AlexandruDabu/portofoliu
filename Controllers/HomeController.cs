using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Portofoliu.Models;
using Portofoliu.ViewModels;

namespace Portofoliu.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult SubmitForm(homeViewModel homeVM)
    {
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("alexandrufelix2020@gmail.com");
        mailMessage.To.Add("alexandrufelix2020@gmail.com");
        mailMessage.Subject = homeVM.subject;
        mailMessage.Body = $"Name: {homeVM.name}\nEmail: {homeVM.email}\nMessage: {homeVM.message}";
        
        using(var smtpClient = new SmtpClient("smtp.elasticemail.com"))
        {
            smtpClient.Port=2525;
            smtpClient.Credentials = new NetworkCredential("alexandrufelix2020@gmail.com","B843B1DA4C6B2844D699B01ABCEAAD75572D");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
        return RedirectToAction("Index");
    }
}
