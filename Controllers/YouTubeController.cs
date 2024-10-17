using Microsoft.AspNetCore.Mvc;
using YouTubeApiProject.Models;
using YouTubeApiProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class YouTubeController : Controller
{
    private readonly YouTubeApiService _youTubeApiService;

    public YouTubeController(YouTubeApiService youTubeApiService)
    {
        _youTubeApiService = youTubeApiService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string query)
    {
        var videos = await _youTubeApiService.SearchVideosAsync(query);
        return View(videos);
    }

    [HttpGet]
    public async Task<IActionResult> Trending()
    {
        var videos = await _youTubeApiService.GetTrendingVideosAsync();
        return View(videos);
    }

    [HttpGet]
    public IActionResult Channel()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Channel(string query)
    {
        var channels = await _youTubeApiService.SearchChannelVideosAsync(query);
        return View(channels);
    }
}
