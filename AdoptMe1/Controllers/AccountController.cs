using AdoptMe1.Models;
using AdoptMe1.Repositories;
using Azure.Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace AdoptMe1.Controllers
{
    public class AccountController : Controller
    {
        private IRepository _repository;
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly IdentityRole adminRole;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            adminRole = new IdentityRole()
            {
                Name = "Administrators"
            };
            _repository = repository;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            try
            {
                IdentityUser role = new IdentityUser
                {
                    UserName = "Danny"
                };
                if (ModelState.IsValid)
                {
                    var res = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("HomePage", "Home");
                    }
                    //bool confirmd = await _repository!.PasswordConfirm(user.Password);
                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("HomePage", "Home");
            }         
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Login newUser)
        {
            try
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = newUser.UserName
                };
                bool PasswordConfirmd = _repository.PasswordConfirm(newUser.Password);
                if (PasswordConfirmd == true)
                {
                    var result = await _userManager.CreateAsync(user, newUser.Password);
                    await _roleManager.CreateAsync(adminRole);
                    if (result.Succeeded)
                        await _userManager.AddToRoleAsync(user, adminRole.Name);

                    if (result.Succeeded)
                        if(newUser.isAdmin != true)
                            return RedirectToAction("HomePage", "Home");
                        else
                            return RedirectToAction("AdminPage", "Admin");
                    return View();
                }
                return View();
            }           
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
