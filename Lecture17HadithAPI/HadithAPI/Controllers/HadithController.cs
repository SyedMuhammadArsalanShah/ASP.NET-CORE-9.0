
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HadithAPI.Controllers
{

    public class HadithController : Controller
    {
        private readonly HadithService _hadithService;

        public HadithController(HadithService hadithService)
        {
            _hadithService = hadithService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _hadithService.GetBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> Chapters(string bookSlug)
        {
            var chapters = await _hadithService.GetChaptersAsync(bookSlug);
            ViewBag.BookSlug = bookSlug;
            return View(chapters);
        }

        public async Task<IActionResult> Hadiths(string bookSlug, string chapter)
        {
            var hadiths = await _hadithService.GetHadithsAsync(bookSlug, chapter);
            return View(hadiths);
        }
    }
}
