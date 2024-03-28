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
    public class HomeController : Controller
    {


		#region tanımlamalar ve index

		

		//public IActionResult Login()
  //      {
  //          return View();
  //      }

  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public async Task<IActionResult> Login(User user)
  //      {
  //          // ModelState doğrulamasını bypass et, doğrudan kullanıcı verileriyle işlem yap
  //          var context = DbContextHelper.CreateContext();
  //          User? usr = await context.Users.FirstOrDefaultAsync(u => u.EMail == user.EMail && u.Password == user.Password && u.Active == true);

  //          if (usr != null)
  //          {
  //              return RedirectToAction("Index");
  //          }
  //          else
  //          {
  //              ViewBag.error = "Bilgiler Yanlış";
  //          }

  //          return View();
  //      }



        //private readonly IRepository<ComputerDetail> _computerRepository;
        //private readonly IRepository<User> _userRepository;
        //private readonly IMapper _mapper;

        private readonly IDependencyService _dependencyService;

        //eski controller
        //public HomeController(/*IRepository<ComputerDetail> computerRepository, IRepository<User> userRepository, IMapper mapper*/IDependencyService dependencyService)
        //{
        //    //_computerRepository = computerRepository;
        //    //_userRepository = userRepository;
        //    //_mapper = mapper;
        //    _dependencyService = dependencyService;
        //}


        public HomeController(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;

        }

        public IActionResult Error404(int code)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> computerFill()
        {
            // var users = await _userRepository.GetAllAsync();
            var users = await _dependencyService.GetUserRepository().GetAllAsync();
            users = users.Where(d => d.Active).ToList();
            ViewData["userList"] = users
                .Select(k => new SelectListItem
                {
                    Text = k.NameSurname ?? "Belirtilmemiş",
                    Value = k.UserID.ToString()
                })
                .ToList();

            return View();
        }

        public async Task<IActionResult> departmentFill()
        {


            var department = await _dependencyService.GetDepartmanRepository().GetAllAsync();
            department = department.Where(d => d.Active).ToList(); // Sadece aktif departmanları filtrele
            ViewData["departmentList"] = department.Select(
                d => new SelectListItem
                {
                    Text = d.DepartmanName,
                    Value = d.DepartmanID.ToString()
                }).ToList();
            return View();
        }

        public async Task<IActionResult> laptopFill()
        {
            // var users = await _userRepository.GetAllAsync();
            var ınventoryLaptops = await _dependencyService.GetInventoryLaptopRepository().GetAllAsync();
            ınventoryLaptops = ınventoryLaptops.Where(d => d.Active).ToList();
            ViewData["laptopList"] = ınventoryLaptops
                .Select(k => new SelectListItem
                {
                    Text = k.BrandName ?? "Belirtilmemiş",
                    Value = k.InventoryId.ToString()
                })
                .ToList();

            return View();

        }

        public async Task<IActionResult> otherInventoryFill()
        {
            // var users = await _userRepository.GetAllAsync();
            var ınventories = await _dependencyService.GetOtherInventoryRepository().GetAllAsync();
            ınventories = ınventories.Where(d => d.Active).ToList();
            ViewData["otherList"] = ınventories
                .Select(k => new SelectListItem
                {
                    Text = k.BrandName ?? "Belirtilmemiş",
                    Value = k.OtherInventoryId.ToString()
                })
                .ToList();

            return View();
        }

        public async Task<IActionResult> RolFill()
        {
         
            var roles = await _dependencyService.GetRoleRepository().GetAllAsync();
            roles = roles.Where(d => d.Active).ToList();
            ViewData["rolesList"] = roles
                .Select(k => new SelectListItem
                {
                    Text = k.RolName ?? "Belirtilmemiş",
                    Value = k.RolID.ToString()
                })
                .ToList();

            return View();
        }

        #endregion

        #region //computer kodları


        public async Task<IActionResult> ComputerDetailsIndex()
        {
            //var computerDetails = await _computerRepository.GetAllAsync();


            var computerDetails = await _dependencyService.GetComputerRepository().GetAllAsync();
            return View("Computer/ComputerDetailsIndex", computerDetails);
        }

        [HttpGet]
        public async Task<IActionResult> ComputerCreate()
        {
            await computerFill();
            return View("Computer/ComputerCreate");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComputerCreate(ComputerDetail model)
        {
            if (ModelState.IsValid)
            {
                var computerDetailDTO = _dependencyService.GetMapper().Map<ComputerDetail>(model);
                await _dependencyService.GetComputerRepository().AddAsync(computerDetailDTO);
                TempData["Message"] = "Bilgisayar Eklendi";
                return RedirectToAction(nameof(ComputerDetailsIndex));
       
            }
            TempData["Message"] = "Bilgisayar Eklenemedi";
            await computerFill();
            return View("Computer/ComputerCreate",model);
        }

        public async Task<IActionResult> ComputerEdit(int id)
        {
            await computerFill();
            //var computerDetail = await _computerRepository.GetByIdAsync(id);
            var computerDetail = await _dependencyService.GetComputerRepository().GetByIdAsync(id);
            if (computerDetail == null)
            {
                return NotFound();
            }
            return View("Computer/ComputerEdit", computerDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComputerEdit(int id, ComputerDetail model)
        {
            await computerFill();

            if (ModelState.IsValid)
            {
                //await _computerRepository.UpdateAsync(model);
                await _dependencyService.GetComputerRepository().UpdateAsync(model);
                TempData["Message"] = "Bilgisayar Güncellendi";
                return RedirectToAction(nameof(ComputerDetailsIndex));
            }

            TempData["Message"] = "Bilgisayar Güncellenemedi";
            return View("Computer/ComputerEdit", model);
        }

        public async Task<IActionResult> ComputerDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var computerDetail = await _computerRepository.GetByIdAsync(id.Value);
            var computerDetail = await _dependencyService.GetComputerRepository().GetByIdAsync(id.Value);
            if (computerDetail == null)
            {
                return NotFound();
            }

            return View("Computer/ComputerDelete", computerDetail);
        }

        [HttpPost, ActionName("ComputerDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComputerDelete(int id)
        {
            //var computerDetail = await _computerRepository.GetByIdAsync(id);
            var computerDetail = await _dependencyService.GetComputerRepository().GetByIdAsync(id);
            if (computerDetail == null)
            {
                TempData["Message"] = "Bilgisayar Silinemedi";
                return NotFound();
            }

            if (computerDetail?.Active != null)
            {

                computerDetail.Active = false;
                // await _computerRepository.UpdateAsync(computerDetail);
                await _dependencyService.GetComputerRepository().UpdateAsync(computerDetail);
            }

            TempData["Message"] = "Bilgisayar Silindi";
            return RedirectToAction(nameof(ComputerDetailsIndex));
        }

        public async Task<IActionResult> ComputerDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var computerDetail = await _computerRepository.GetByIdAsync(id.Value);
            //var users = await _userRepository.GetByIdAsync(id.Value);
            var computerDetail = await _dependencyService.GetComputerRepository().GetByIdAsync(id.Value);
            var users = await _dependencyService.GetUserRepository().GetByIdAsync(id.Value);
            if (computerDetail == null)
            {
                return NotFound();
            }

            ViewBag.username = users?.NameSurname;
            return View("Computer/ComputerDetails", computerDetail);
        }

        #endregion

        #region //user kodları

        public async Task<IActionResult> KullanicilarIndex()
        {
            var userDetails = await _dependencyService.GetUserRepository().GetAllAsync();
            return View("Kullanıcılar/KullanicilarIndex", userDetails);
        }

        [HttpGet]
        public async Task<IActionResult> UserCreate()
        {
            await departmentFill();
            await RolFill();
            return View("Kullanıcılar/UserCreate");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate(User model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = _dependencyService.GetMapper().Map<User>(model);
                await _dependencyService.GetUserRepository().AddAsync(userDTO);
                TempData["Message"] = "Kullanıcı Eklendi";
                return RedirectToAction(nameof(KullanicilarIndex));
            }
            TempData["Message"] = "Kullanıcı Eklenemedi";
            await departmentFill();
            await RolFill();
            return View("Kullanıcılar/UserCreate",model);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(int id)
        {
            await departmentFill();
            await RolFill();
            var userDetail = await _dependencyService.GetUserRepository().GetByIdAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View("Kullanıcılar/UserEdit", userDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(User model)
        {
            await departmentFill();
            await RolFill();


            if (ModelState.IsValid)
            {
                

                await _dependencyService.GetUserRepository().UpdateAsync(model);
                TempData["Message"] = "Kullanıcı Güncellendi";
                return RedirectToAction(nameof(KullanicilarIndex));
            }
            TempData["Message"] = "Kullanıcı Güncellenemedi";
            return View("Kullanıcılar/UserEdit", model);
        }

        [HttpGet]
        public async Task<IActionResult> UserDelete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var user = await _dependencyService.GetUserRepository().GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View("Kullanıcılar/UserDelete", user);
        }

        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDelete(int id)
        {
            var user = await _dependencyService.GetUserRepository().GetByIdAsync(id);
            if (user == null)
            {
                TempData["Message"] = "Bilgisayar Silinemedi";
                return NotFound();
            }

            if (user?.Active != null)
            {
                user.EndDate = DateTime.UtcNow;
                user.Active = false;
                await _dependencyService.GetUserRepository().UpdateAsync(user);

            }
            TempData["Message"] = "Bilgisayar Silindi";
            return RedirectToAction(nameof(KullanicilarIndex));
        }

        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _dependencyService.GetUserRepository().GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.username = user?.NameSurname;
            return View("Kullanıcılar/UserDetails", user);
        }




        #endregion

        #region //monitör kodları

        public async Task<IActionResult> monitorIndex()
        {
            var monitorDetails = await _dependencyService.GetMonitorDetailRepository().GetAllAsync();
            return View("Monitor/monitorIndex", monitorDetails);
        }

        [HttpGet]
        public async Task<IActionResult> MonitorCreate()
        {
            await computerFill();
            return View("Monitor/MonitorCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MonitorCreate(MonitorDetail model)
        {
            if (ModelState.IsValid)
            {
                var monitorDTO = _dependencyService.GetMapper().Map<MonitorDetail>(model);
                await _dependencyService.GetMonitorDetailRepository().AddAsync(monitorDTO);
                TempData["Message"] = "Monitör Eklendi";
                return RedirectToAction(nameof(monitorIndex));
            }
            TempData["Message"] = "Monitör Eklenemedi";
            await computerFill();
            return View("Monitor/MonitorCreate",model);
        }

        [HttpGet]
        public async Task<IActionResult> MonitorEdit(int id)
        {
            await computerFill();
            var monitorDetail = await _dependencyService.GetMonitorDetailRepository().GetByIdAsync(id);
            if (monitorDetail == null)
            {
                return NotFound();
            }
            return View("Monitor/MonitorEdit", monitorDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MonitorEdit(MonitorDetail model)
        {
            await computerFill();
            if (ModelState.IsValid)
            {
                await _dependencyService.GetMonitorDetailRepository().UpdateAsync(model);
                TempData["Message"] = "Monitör Güncellendi";
                return RedirectToAction(nameof(monitorIndex));
            }
            TempData["Message"] = "Monitör Güncellenemedi";
            return View("Monitor/MonitorEdit", model);
        }


        [HttpGet]
        public async Task<IActionResult> MonitorDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var monitor = await _dependencyService.GetMonitorDetailRepository().GetByIdAsync(id.Value);
            if (monitor == null)
            {
                return NotFound();
            }
            return View("Monitor/MonitorDelete", monitor);
        }

        [HttpPost, ActionName("MonitorDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MonitorDelete(int id)
        {
            var monitor = await _dependencyService.GetMonitorDetailRepository().GetByIdAsync(id);
            if (monitor == null)
            {
                TempData["Message"] = "Monitör Silinemedi";
                return NotFound();
            }

            if (monitor?.Durum != null)
            {
                monitor.Durum = false;
                await _dependencyService.GetMonitorDetailRepository().UpdateAsync(monitor);

            }
            TempData["Message"] = "Monitör Silindi";
            return RedirectToAction(nameof(monitorIndex));
        }

        public async Task<IActionResult> MonitorDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var monitorDetails = await _dependencyService.GetMonitorDetailRepository().GetByIdAsync(id.Value);
            var user = await _dependencyService.GetUserRepository().GetByIdAsync(id.Value);
            if (monitorDetails == null)
            {
                return NotFound();
            }
            ViewBag.username = user?.NameSurname;
            return View("Monitor/MonitorDetails", monitorDetails);
        }

        #endregion

        #region //departman kodları

        public async Task<IActionResult> departmanIndex()
        {
            var departmen = await _dependencyService.GetDepartmanRepository().GetAllAsync();
            return View("Departman/departmanIndex", departmen);
        }

        [HttpGet]
        public IActionResult DepartmanCreate()
        {
            return View("Departman/DepartmanCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepartmanCreate(Departman model)
        {
            if (ModelState.IsValid)
            {
                var departmanDTO = _dependencyService.GetMapper().Map<Departman>(model);
                await _dependencyService.GetDepartmanRepository().AddAsync(departmanDTO);
                TempData["Message"] = "Departman Eklendi";
                return RedirectToAction(nameof(departmanIndex));
            }
            TempData["Message"] = "Departman Eklenemedi";
            return View("Departman/DepartmanCreate", model);
        }


        [HttpGet]
        public async Task<IActionResult> DepartmanEdit(int id)
        {
            var departman = await _dependencyService.GetDepartmanRepository().GetByIdAsync(id);
            if (departman == null)
            {
                return NotFound();
            }
            return View("Departman/DepartmanEdit", departman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepartmanEdit(Departman model)
        {
            if (ModelState.IsValid)
            {
                await _dependencyService.GetDepartmanRepository().UpdateAsync(model);
                TempData["Message"] = "Departman Güncellendi";
                return RedirectToAction(nameof(departmanIndex));
            }
            TempData["Message"] = "Departman Güncellenemedi";
            return View("Departman/DepartmanEdit", model);
        }


        [HttpGet]
        public async Task<IActionResult> DepartmanDelete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var departman = await _dependencyService.GetDepartmanRepository().GetByIdAsync(id.Value);
            if (departman == null)
            {
                return NotFound();
            }
            return View("Departman/DepartmanDelete", departman);
        }

        [HttpPost, ActionName("DepartmanDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepartmanDelete(int id)
        {
            var departman = await _dependencyService.GetDepartmanRepository().GetByIdAsync(id);
            if (departman == null)
            {
                TempData["Message"] = "Departman Silinemedi";
                return NotFound();
            }

            if (departman?.Active != null)
            {
                departman.Active = false;
                await _dependencyService.GetDepartmanRepository().UpdateAsync(departman);

            }
            TempData["Message"] = "Departman Silindi";
            return RedirectToAction(nameof(departmanIndex));
        }


        public async Task<IActionResult> DepartmanDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departman = await _dependencyService.GetDepartmanRepository().GetByIdAsync(id.Value);
            if (departman == null)
            {
                return NotFound();
            }
            ViewBag.username = departman?.DepartmanName;
            return View("Departman/DepartmanDetails", departman);
        }

        #endregion

        #region //envanter laptop kodları

        public async Task<IActionResult> envanterLaptopIndex()
        {
            var ınventoryLaptops = await _dependencyService.GetInventoryLaptopRepository().GetAllAsync();
            return View("Envanteraptop/envanterLaptopIndex", ınventoryLaptops);
        }

        [HttpGet]
        public IActionResult envanterLaptopCreate()
        {
            return View("Envanteraptop/envanterLaptopCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> envanterLaptopCreate(InventoryLaptop model)
        {
            if (ModelState.IsValid)
            {
                var envanterLaptopDTO = _dependencyService.GetMapper().Map<InventoryLaptop>(model);
                await _dependencyService.GetInventoryLaptopRepository().AddAsync(envanterLaptopDTO);
                TempData["Message"] = "Envanter Laptop Eklendi";
                return RedirectToAction(nameof(envanterLaptopIndex));
            }
            TempData["Message"] = "Envanter Laptop Eklenemedi";
            return View("Envanteraptop/envanterLaptopCreate",model);
        }


        [HttpGet]
        public async Task<IActionResult> envanterLaptopEdit(int id)
        {
            var ınventoryLaptops = await _dependencyService.GetInventoryLaptopRepository().GetByIdAsync(id);
            if (ınventoryLaptops == null)
            {
                return NotFound();
            }
            return View("Envanteraptop/envanterLaptopEdit", ınventoryLaptops);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> envanterLaptopEdit(InventoryLaptop model)
        {
            if (ModelState.IsValid)
            {
                await _dependencyService.GetInventoryLaptopRepository().UpdateAsync(model);
                TempData["Message"] = "Envanter Laptop Güncellendi";
                return RedirectToAction(nameof(envanterLaptopIndex));
            }
            TempData["Message"] = "Envanter Laptop Güncellenemedi";
            return View("Envanteraptop/envanterLaptopEdit", model);
        }


        [HttpGet]
        public async Task<IActionResult> envanterLaptopDelete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var ınventoryLaptops = await _dependencyService.GetInventoryLaptopRepository().GetByIdAsync(id.Value);
            if (ınventoryLaptops == null)
            {
                return NotFound();
            }
            return View("Envanteraptop/envanterLaptopDelete", ınventoryLaptops);
        }

        [HttpPost, ActionName("envanterLaptopDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> envanterLaptopDelete(int id)
        {
            var ınventoryLaptops = await _dependencyService.GetInventoryLaptopRepository().GetByIdAsync(id);
            if (ınventoryLaptops == null)
            {
                TempData["Message"] = "Envanter Laptop Silinemedi";
                return NotFound();
            }

            if (ınventoryLaptops?.Active != null)
            {
                ınventoryLaptops.Active = false;
                await _dependencyService.GetInventoryLaptopRepository().UpdateAsync(ınventoryLaptops);

            }
            TempData["Message"] = "Envanter Laptop Silindi";
            return RedirectToAction(nameof(envanterLaptopIndex));
        }


        public async Task<IActionResult> envanterLaptopDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ınventoryLaptops = await _dependencyService.GetInventoryLaptopRepository().GetByIdAsync(id.Value);
            if (ınventoryLaptops == null)
            {
                return NotFound();
            }
            ViewBag.username = ınventoryLaptops?.BrandName;
            return View("Envanteraptop/envanterLaptopDetails", ınventoryLaptops);
        }





        #endregion

        #region //diğer envanter kodları


        public async Task<IActionResult> envanterMalzemeIndex()
        {
            var otherInventories = await _dependencyService.GetOtherInventoryRepository().GetAllAsync();
            return View("EnvanterMalzeme/envanterMalzemeIndex", otherInventories);
        }

        [HttpGet]
        public async Task<IActionResult> envanterMalzemeCreate()
        {
            await computerFill();
            await departmentFill();
            return View("EnvanterMalzeme/envanterMalzemeCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> envanterMalzemeCreate(OtherInventory model)
        {
            if (ModelState.IsValid)
            {
                var otherInventoriesDTO = _dependencyService.GetMapper().Map<OtherInventory>(model);
                await _dependencyService.GetOtherInventoryRepository().AddAsync(otherInventoriesDTO);
                TempData["Message"] = "Envanter Eklendi";
                return RedirectToAction(nameof(envanterMalzemeIndex));
            }
            TempData["Message"] = "Envanter Eklenemedi";
            await computerFill();
            await departmentFill();
            return View("EnvanterMalzeme/envanterMalzemeCreate",model);
        }

        [HttpGet]
        public async Task<IActionResult> envanterMalzemeEdit(int id)
        {
            await computerFill();
            await departmentFill();
            var otherInventories = await _dependencyService.GetOtherInventoryRepository().GetByIdAsync(id);
            if (otherInventories == null)
            {
                return NotFound();
            }
            return View("EnvanterMalzeme/envanterMalzemeEdit", otherInventories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> envanterMalzemeEdit(OtherInventory model)
        {
            await computerFill();
            await departmentFill();
            if (ModelState.IsValid)
            {
                await _dependencyService.GetOtherInventoryRepository().UpdateAsync(model);
                TempData["Message"] = "Envanter Güncellendi";
                return RedirectToAction(nameof(envanterMalzemeIndex));
            }
            TempData["Message"] = "Envanter Güncellenemedi";
            return View("EnvanterMalzeme/envanterMalzemeEdit", model);
        }


        [HttpGet]
        public async Task<IActionResult> envanterMalzemeDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var otherInventories = await _dependencyService.GetOtherInventoryRepository().GetByIdAsync(id.Value);
            if (otherInventories == null)
            {
                return NotFound();
            }
            return View("EnvanterMalzeme/envanterMalzemeDelete", otherInventories);
        }

        [HttpPost, ActionName("envanterMalzemeDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> envanterMalzemeDelete(int id)
        {
            var otherInventories = await _dependencyService.GetOtherInventoryRepository().GetByIdAsync(id);
            if (otherInventories == null)
            {
                TempData["Message"] = "Envanter Silinemedi";
                return NotFound();
            }

            if (otherInventories?.Active != null)
            {

                otherInventories.Active = false;
                await _dependencyService.GetOtherInventoryRepository().UpdateAsync(otherInventories);

            }
            TempData["Message"] = "Envanter Silindi";
            return RedirectToAction(nameof(envanterMalzemeIndex));
        }

        public async Task<IActionResult> envanterMalzemeDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var otherInventories = await _dependencyService.GetOtherInventoryRepository().GetByIdAsync(id.Value);

            if (otherInventories == null)
            {
                return NotFound();
            }
            ViewBag.username = otherInventories?.BrandName;
            return View("EnvanterMalzeme/envanterMalzemeDetails", otherInventories);
        }

        #endregion

        #region //ekipman değişme kodları



        public async Task<IActionResult> DonanimDegismeIndex()
        {
            var changeEquipment = await _dependencyService.GetChangeEquipment().GetAllAsync();
            return View("DonanimDegisme/DonanimDegismeIndex", changeEquipment);
        }

        [HttpGet]
        public async Task<IActionResult> DonanimDegismeCreate()
        {
            await computerFill();
            return View("DonanimDegisme/DonanimDegismeCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DonanimDegismeCreate(ChangeEquipment model)
        {
            if (ModelState.IsValid)
            {
                var changeEquipmentDTO = _dependencyService.GetMapper().Map<ChangeEquipment>(model);
                await _dependencyService.GetChangeEquipment().AddAsync(changeEquipmentDTO);
                TempData["Message"] = "Donanım Değişme Eklendi";
                return RedirectToAction(nameof(DonanimDegismeIndex));
            }
            TempData["Message"] = "Donanım Değişme Eklenemedi";
            await computerFill();
            return View("DonanimDegisme/DonanimDegismeCreate",model);
        }

        [HttpGet]
        public async Task<IActionResult> DonanimDegismeEdit(int id)
        {
            await computerFill();
            var changeEquipment = await _dependencyService.GetChangeEquipment().GetByIdAsync(id);
            if (changeEquipment == null)
            {
                return NotFound();
            }
            return View("DonanimDegisme/DonanimDegismeEdit", changeEquipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DonanimDegismeEdit(ChangeEquipment model)
        {
            await computerFill();
            if (ModelState.IsValid)
            {
                await _dependencyService.GetChangeEquipment().UpdateAsync(model);
                TempData["Message"] = "Donanım Değişme Güncellendi";
                return RedirectToAction(nameof(DonanimDegismeIndex));
            }
            TempData["Message"] = "Donanım Değişme Güncellenemedi";
            return View("DonanimDegisme/DonanimDegismeEdit", model);
        }



        public async Task<IActionResult> DonanimDegismeDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var changeEquipment = await _dependencyService.GetChangeEquipment().GetByIdAsync(id.Value);
            var user = await _dependencyService.GetChangeEquipment().GetByIdAsync(id.Value);
            if (changeEquipment == null)
            {
                return NotFound();
            }
            ViewBag.username = user?.UserID;
            return View("DonanimDegisme/DonanimDegismeDetails", changeEquipment);
        }

        #endregion

        #region //emanet kodları

        public async Task<IActionResult> emanetIndex()
        {
            var entrusteds = await _dependencyService.GetEntrustedRepository().GetAllAsync();
            return View("Emanet/emanetIndex", entrusteds);
        }

        [HttpGet]
        public async Task<IActionResult> emanetCreate()
        {
            await computerFill();
            await laptopFill();
            await otherInventoryFill();
            return View("Emanet/emanetCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> emanetCreate(Entrusted model)
        {
            if (ModelState.IsValid)
            {
                var entrustedsDTO = _dependencyService.GetMapper().Map<Entrusted>(model);
                await _dependencyService.GetEntrustedRepository().AddAsync(entrustedsDTO);
                TempData["Message"] = "Emanet Eklendi";
                return RedirectToAction(nameof(emanetIndex));
            }
            TempData["Message"] = "Emanet Eklenemedi";
            await computerFill();
            await laptopFill();
            await otherInventoryFill();
            return View("Emanet/emanetCreate",model);
        }

        [HttpGet]
        public async Task<IActionResult> emanetEdit(int id)
        {
            await computerFill();
            await laptopFill();
            await otherInventoryFill();
            var entrusteds = await _dependencyService.GetEntrustedRepository().GetByIdAsync(id);
            if (entrusteds == null)
            {
                return NotFound();
            }
            return View("Emanet/emanetEdit", entrusteds);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> emanetEdit(Entrusted model)
        {
            await computerFill();
            await laptopFill();
            await otherInventoryFill();
            if (ModelState.IsValid)
            {
                await _dependencyService.GetEntrustedRepository().UpdateAsync(model);
                TempData["Message"] = "Emanet Güncellendi";
                return RedirectToAction(nameof(emanetIndex));
            }
            TempData["Message"] = "Emanet Güncellenemedi";
            return View("Emanet/emanetEdit", model);
        }


        [HttpGet]
        public async Task<IActionResult> emanetDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entrusted = await _dependencyService.GetEntrustedRepository().GetByIdAsync(id.Value);
            if (entrusted == null)
            {
                return NotFound();
            }
            return View("Emanet/emanetDelete", entrusted);
        }

        [HttpPost, ActionName("emanetDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> emanetDelete(int id)
        {
            var entrusted = await _dependencyService.GetEntrustedRepository().GetByIdAsync(id);
            if (entrusted == null)
            {
                TempData["Message"] = "Emanet Silinemedi";
                return NotFound();
            }

            if (entrusted?.Active != null)
            {
                entrusted.EndDate = DateTime.UtcNow;
                entrusted.Active = false;
                await _dependencyService.GetEntrustedRepository().UpdateAsync(entrusted);

            }
            TempData["Message"] = "Emanet Silindi";
            return RedirectToAction(nameof(emanetIndex));
        }


        public async Task<IActionResult> emanetDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entrusteds = await _dependencyService.GetEntrustedRepository().GetByIdAsync(id.Value);

            if (entrusteds == null)
            {
                return NotFound();
            }
            ViewBag.username = entrusteds?.EntrustedId;
            return View("Emanet/emanetDetails", entrusteds);
        }

        #endregion


        #region rol işlemleri

        //RolIndex
        [HttpGet]
        public async Task<IActionResult> RolIndex()
        {
            var rol = await _dependencyService.GetRoleRepository().GetAllAsync();
            return View(rol);
        }

        [HttpGet] 
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(Role model)
        {
            if (ModelState.IsValid)
            {
                var rolDTO = _dependencyService.GetMapper().Map<Role>(model);
                await _dependencyService.GetRoleRepository().AddAsync(rolDTO);
                TempData["Message"] = "Rol Eklendi";
                return RedirectToAction(nameof(RolIndex));
            }
            TempData["Message"] = "Rol Eklenemedi";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RolEdit(int id)
        {
            var rol = await _dependencyService.GetRoleRepository().GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost]
        public async Task<IActionResult> RolEdit(Role model)
        {
            if (ModelState.IsValid)
            {
                await _dependencyService.GetRoleRepository().UpdateAsync(model);
                TempData["Message"] = "Rol Güncellendi";
                return RedirectToAction(nameof(RolIndex));
            }
            TempData["Message"] = "Rol Güncellenemedi";
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> RolDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rol = await _dependencyService.GetRoleRepository().GetByIdAsync(id.Value);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost, ActionName("RolDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RolDelete(int id)
        {
            var rol = await _dependencyService.GetRoleRepository().GetByIdAsync(id);
            if (rol == null)
            {
                TempData["Message"] = "Rol Silinemedi";
                return NotFound();
            }
            if (rol?.Active != null)
            {
                rol.Active = false;
                await _dependencyService.GetRoleRepository().UpdateAsync(rol);
            }
            TempData["Message"] = "Rol Silindi";
            return RedirectToAction(nameof(RolIndex));
        }

        public async Task<IActionResult> RolDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rol = await _dependencyService.GetRoleRepository().GetByIdAsync(id.Value);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }



        #endregion










    }
}
