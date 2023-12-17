using Microsoft.AspNetCore.Mvc;

namespace DotNetWorkspace.SignalR.WebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
