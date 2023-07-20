using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArtistMVC.Models;
using ArtistMVC.Repositories;
using ArtistMVC.ExternalAPIs;

namespace ArtistMVC.Controllers;

public class ArtistController : Controller
{
    public IActionResult Index(int id)
    {
        ArtistRepository repository = new ArtistRepository();
        List<ArtistModel> artists = repository.GetAll(id);
        return View(artists);
    }

    public IActionResult Description(string id)
    {
        ArtistApi api = new ArtistApi();
        string description = api.GetDescription(id);

        ViewBag.Description = description;
        ViewBag.ArtistId = id;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}