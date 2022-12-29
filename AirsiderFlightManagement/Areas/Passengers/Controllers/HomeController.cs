using AirsiderFlightManagement.Data;
using Microsoft.AspNetCore.Mvc;
using AirsiderFlightManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AirsiderFlightManagement.Areas.Passengers.Controllers
{
    [Area("Passengers")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<Passenger> userManager;
        private readonly SignInManager<Passenger> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ApplicationDbContext db,
            UserManager<Passenger> userManager,
            SignInManager<Passenger> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(PassengerRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new Passenger
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.Phone,
                UserName = Guid.NewGuid().ToString().Replace("-", "")
            };
            var res = await userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                return View(model);
            }
            ModelState.AddModelError("", "Something Went Wrong...");
            return View(model);

        }

        [HttpGet]
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(PassengerLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByEmailAsync(model.Email); 
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Login Details");
                return View(model);
            }
            var res = await signInManager.PasswordSignInAsync(user, model.Password, true, true);
            if (res.Succeeded)
            {
                //var roles = await userManager.GetRolesAsync(user);
                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("index", "home", new { area = "Flights" });

                }
                else
                {
                    return RedirectToAction("index", "home", new { area = "" });

                }
            }
            ModelState.AddModelError("", "Invalid Username/Password");
            return RedirectToAction("index", "home", new { area = "" });

        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home", new { area = "" });
        }

        public async Task<IActionResult> GenerateData()
        {
            await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
            await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            var user = await userManager.GetUsersInRoleAsync("Admin");
            if (user.Count ==0l)
            {
                var appuser = new Passenger()
                {
                    FirstName ="Admin",
                    LastName ="User",
                    Email ="Admin@mail.com",
                    UserName="Admin"
                };
                var res = await userManager.CreateAsync(appuser, "Pass@123");
                await userManager.AddToRoleAsync(appuser, "Admin");
            }
            return Ok("Data generated");


        }
    }
}
