using FluentValidation;
using HD_Veriler.Models;
using HD_Veriler.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using HD_Veriler.Helpers;
using Microsoft.EntityFrameworkCore;
using HD_Veriler.Validators;
using Microsoft.CodeAnalysis;

namespace HD_Veriler.Controllers
{
    public class ScoreController : Controller
    {
        #region tanımlamalar 
        private readonly IDependencyService _dependencyService;
        public ScoreController(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;

        }

        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region gösterme listeleme puan verme kısımları
        //PuanlamaSistemiIndex
        public async Task<IActionResult> PuanlamaSistemiIndex()
        {
            var departmen = await _dependencyService.GetDepartmanRepository().GetAllAsync();
            departmen = departmen.Where(d => d.Active).ToList(); // Sadece aktif departmanları filtrele

            return View(departmen);
        }

        public async Task<IActionResult> PersonelDetailsIndex(int departmanId)
        {

            var users = await _dependencyService.GetUserRepository().GetAllAsync();
            users = users.Where(u => u.DepartmanID == departmanId && u.Active);

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ScoreIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _dependencyService.GetUserRepository().GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound(); // Kullanıcı yoksa boş bir Score nesnesi döndürün
            }

            ViewBag.UserName = user.NameSurname;
            var sorular = await _dependencyService.GetQuestionRepository().GetAllAsync();
            sorular = sorular.Where(d => d.Active).ToList();
            ViewBag.Sorular = sorular;
            return View(new Score { UserID = user.UserID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScoreIndex(Score model)
        {
            // Formdan gelen UserID değerini manuel olarak Score modeline atayın


            if (ModelState.IsValid)
            {
                var scoreDTO = _dependencyService.GetMapper().Map<Score>(model);
                await _dependencyService.GetScoreRepository().AddAsync(scoreDTO);
                TempData["Message"] = "Puan Eklendi";
                return RedirectToAction(nameof(PersonelDetailsIndex));
            }

            TempData["Message"] = "Puan Eklenemedi";
            return View(model);
        }
        #endregion

        #region soru crud işlemleri

        public async Task<IActionResult> SoruIndex()
        {
            var soru = await _dependencyService.GetQuestionRepository().GetAllAsync();
            return View(soru);
        }
        

        [HttpGet]
        public IActionResult SoruCreate() 
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SoruCreate(UQuestion model)
        {
            if (ModelState.IsValid)
            {
                var soruDTO = _dependencyService.GetMapper().Map<UQuestion>(model);
                await _dependencyService.GetQuestionRepository().AddAsync(soruDTO);
                TempData["Message"] = "Soru Eklendi";
                return RedirectToAction(nameof(SoruIndex));
            }
            TempData["Message"] = "Soru Eklenemedi";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SoruEdit(int id)
        {
            var soru = await _dependencyService.GetQuestionRepository().GetByIdAsync(id);
            if (soru == null)
            {
                return NotFound();
            }
            return View(soru);
        }

        [HttpPost]
        public async Task<IActionResult> SoruEdit(UQuestion model)
        {
            if (ModelState.IsValid)
            {
                await _dependencyService.GetQuestionRepository().UpdateAsync(model);
                TempData["Message"] = "Soru Güncellendi";
                return RedirectToAction(nameof(SoruIndex));
            }
            TempData["Message"] = "Soru Güncellenemedi";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SoruDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var soru = await _dependencyService.GetQuestionRepository().GetByIdAsync(id.Value);
            if (soru == null)
            {
                return NotFound();
            }
            return View(soru);
        }
        [HttpPost,ActionName("SoruDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoruDelete(int id)
        {
            var soru = await _dependencyService.GetQuestionRepository().GetByIdAsync(id);
            if (soru == null)
            {
                TempData["Message"] = "Soru Silinemedi";
                return NotFound();
            }
            if (soru?.Active != null)
            {
                soru.Active = false;
                await _dependencyService.GetQuestionRepository().UpdateAsync(soru);
            }
            TempData["Message"] = "Soru Silindi";
            return RedirectToAction(nameof(SoruIndex));
        }

        public async Task<IActionResult> SoruDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var soru = await _dependencyService.GetQuestionRepository().GetByIdAsync(id.Value);
            if (soru == null)
            {
                return NotFound();
            }
            return View(soru);
        }





        #endregion
















    }
}
