using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var projects = GetProjects().Take(3).ToList();
        var model = new HomeIndexDTO() { Projects = projects };
        return View(model);
    }

    private List<ProjectDTO> GetProjects()
    {
        return new List<ProjectDTO>()
        {
            new ProjectDTO
            {
                Title = "Amazon",
                Desciption = "Description Amazon",
                Link = "https://amazon.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Google",
                Desciption = "Description google",
                Link = "https://google.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Reddit",
                Desciption = "Description reddit",
                Link = "https://reddit.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Facebook",
                Desciption = "Description facebook",
                Link = "https://facebook.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Steam",
                Desciption = "Description steam",
                Link = "https://steam.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            }
        };
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
}

