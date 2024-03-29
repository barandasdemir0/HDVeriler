using HD_Veriler.Models;
using HD_Veriler.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HD_Veriler.Controllers
{
    public class ProjeController : Controller
    {
        #region tanımlamalar 
        private readonly IDependencyService _dependencyService;
        public ProjeController(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;

        }

        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region Proje kategori işlemleri


        [HttpGet]
        public async Task<IActionResult> ProjectCategoryIndex()
        {
            var projectCategories = await _dependencyService.GetProjectCategoryRepository().GetAllAsync();
            return View(projectCategories);
        }

        [HttpGet]
        public IActionResult ProjectCategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProjectCategoryCreate(ProjectCategory model)
        {
            if (ModelState.IsValid)
            {
                var projectCategoryDTO = _dependencyService.GetMapper().Map<ProjectCategory>(model);
                await _dependencyService.GetProjectCategoryRepository().AddAsync(projectCategoryDTO);
                TempData["Message"] = "Kategori Eklendi";
                return RedirectToAction(nameof(ProjectCategoryIndex));
            }
            TempData["Message"] = "Kategori Eklenemedi";
            return View( model);
        }

        [HttpGet]
        public async Task<IActionResult> ProjectCategoryEdit(int id)
        {
            var projectCategories = await _dependencyService.GetProjectCategoryRepository().GetByIdAsync(id);
            if (projectCategories == null)
            {
                return NotFound();
            }
            return View( projectCategories);
        }

        [HttpPost]
        public async Task<IActionResult> ProjectCategoryEdit(ProjectCategory model)
        {
            if (ModelState.IsValid)
            {
                await _dependencyService.GetProjectCategoryRepository().UpdateAsync(model);
                TempData["Message"] = "Kategori Güncellendi";
                return RedirectToAction(nameof(ProjectCategoryIndex));
            }
            TempData["Message"] = "Kategori Güncellenemedi";
            return View( model);
        }


        [HttpGet]
        public async Task<IActionResult> ProjectCategoryDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projectCategories = await _dependencyService.GetProjectCategoryRepository().GetByIdAsync(id.Value);
            if (projectCategories == null)
            {
                return NotFound();
            }
            return View( projectCategories);
        }

        [HttpPost, ActionName("ProjectCategoryDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectCategoryDelete(int id)
        {
            var projectCategories = await _dependencyService.GetProjectCategoryRepository().GetByIdAsync(id);
            if (projectCategories == null)
            {
                TempData["Message"] = "Kategori Silinemedi";
                return NotFound();
            }
            if (projectCategories?.Active != null)
            {
                projectCategories.Active = false;
                await _dependencyService.GetProjectCategoryRepository().UpdateAsync(projectCategories);
            }
            TempData["Message"] = "Kategori Silindi";
            return RedirectToAction(nameof(ProjectCategoryIndex));
        }

        public async Task<IActionResult> ProjectCategoryDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projectCategories = await _dependencyService.GetProjectCategoryRepository().GetByIdAsync(id.Value);
            if (projectCategories == null)
            {
                return NotFound();
            }
            return View( projectCategories);
        }



        #endregion

    }
}
