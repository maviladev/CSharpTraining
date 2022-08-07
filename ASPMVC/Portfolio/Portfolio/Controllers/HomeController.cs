using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProjectsRepository projectsRepository;
    private readonly ISendGridEmailService emailService;

    public HomeController(ILogger<HomeController> logger, IProjectsRepository projectsRepository, ISendGridEmailService emailService)
    {
        _logger = logger;
        this.projectsRepository = projectsRepository;
        this.emailService = emailService;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Este es un mensaje de log");
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

    public IActionResult Projects()
    {
        var projects = projectsRepository.GetProjects();
        return View(projects);
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact(ContactDTO data)
    {
        await emailService.Send(data);

        return RedirectToAction("ThankYou");
    }

    public IActionResult ThankYou()
    {

        return View();
    }
}

