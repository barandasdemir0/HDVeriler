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
        public async Task<IActionResult> ScoreIndex(List<int> QuestionIDs, List<string> Answers, List<int> Points, Score model)
        {
            if (ModelState.IsValid)
            {
                // Girilen soruların sayısını kontrol etmek
                if (QuestionIDs.Count != Answers.Count || QuestionIDs.Count != Points.Count)
                {
                    TempData["Message"] = "Soruların cevapları ve puanları eşleşmiyor.";
                    return View();
                }

                // Score nesnelerini oluşturmak için döngü
                List<Score> scores = new List<Score>();
                for (int i = 0; i < QuestionIDs.Count; i++)
                {
                    Score score = new Score
                    {
                        UserID = model.UserID, // Burada kullanıcı kimliği nasıl alınacaksa o şekilde atanmalıdır
                        QuestionID = QuestionIDs[i],
                        Answer = Answers[i],
                        Point = Points[i],
                        AnswerDate = DateTime.Now
                    };
                    scores.Add(score);
                }

                // Score nesnelerini ekleyin
                foreach (var score in scores)
                {
                    await _dependencyService.GetScoreRepository().AddAsync(score);
                }

                TempData["Message"] = "Puanlar Eklendi";
                return RedirectToAction(nameof(PersonelDetailsIndex));
            }

            TempData["Message"] = "Puanlar Eklenemedi";
            return View();
        }


        public async Task<IActionResult> ListScores(int? id, int? year, int? month)
        {
            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Score> scores;

            if (year != null && month != null)
            {
                // Belirli bir yıl ve ayda filtreleme yap
                scores = await _dependencyService.GetScoreRepository().GetAllAsync();
                scores = scores.Where(s => s.AnswerDate.Year == year && s.AnswerDate.Month == month && s.UserID == id).ToList();
            }
            else
            {
                // Kullanıcının tüm puanlarını al
                scores = await _dependencyService.GetScoreRepository().GetAllAsync();
                scores = scores.Where(s => s.UserID == id).ToList();
            }

            if (scores.Any())
            {
                return View(scores);
            }
            else
            {
                ViewBag.ErrorMessage = "Veri bulunamadı.";
                return View();
            }
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
