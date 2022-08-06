using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProjectsRepository projectsRepository;

    public HomeController(ILogger<HomeController> logger, IProjectsRepository projectsRepository)
    {
        _logger = logger;
        this.projectsRepository = projectsRepository;
    }

    public IActionResult Index()
    {
        
        var projects = projectsRepository.GetProjects().Take(3).ToList();
        var model = new HomeIndexDTO() { Projects = projects };
        return View(model);
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

