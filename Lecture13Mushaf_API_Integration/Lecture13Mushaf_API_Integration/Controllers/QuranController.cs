using Lecture13Mushaf_API_Integration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lecture13Mushaf_API_Integration.Controllers
{
    public class QuranController : Controller
    {
        private readonly QuranService _quranService;

        public QuranController(QuranService quranService)
        {
            _quranService = quranService;
        }

        public async Task<IActionResult> Index()
        {
            var surahs = await _quranService.GetAllSurahsAsync();
            return View(surahs);
        }

        public async Task<IActionResult> Read(int id)
        {
            var surahDetails = await _quranService.GetSurahDetailsAsync(id);
            if (surahDetails == null)
            {
                return NotFound();
            }
            return View(surahDetails);
        }
    }
}
