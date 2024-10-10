using Microsoft.AspNetCore.Mvc;
using ReceptionRegistrationWeb.Models;
using ReceptionRegistrationWeb.Models.ViewModels;

namespace ReceptionRegistrationWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly WebDbContext.WebDbContext _webDbContext;
        public AccountController(WebDbContext.WebDbContext webDbContext) 
        {
            _webDbContext = webDbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            try
            {
                var user = _webDbContext.tblAdmins.SingleOrDefault(t => t.Username == login.username && t.Password == login.password);
                if (user != null)
                {
                    HttpContext.Session.SetString("FullName", user.FullName);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("UserId", user.Id.ToString());

                    return RedirectToAction("CallRecorder", "Registration");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }

            return View(login);
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Admin admin)
        {
            try
            {
                if (admin != null)
                {
                    var checkUser = _webDbContext.tblAdmins.SingleOrDefault(t => t.Username == admin.Username);
                    if (checkUser != null)
                    {
                        return View(checkUser); //kullanıcı zaten var
                    }

                    var newuser = new Admin
                    {
                        FullName = admin.FullName,
                        Username = admin.Username,
                        Password = admin.Password,
                        WorkTask = admin.WorkTask,
                    };
                    _webDbContext.tblAdmins.Add(newuser);
                    await _webDbContext.SaveChangesAsync();
                    return RedirectToAction("Login");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(admin);
        }

    }
}
