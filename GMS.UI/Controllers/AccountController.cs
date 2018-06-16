using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using GMS.Data.Context;
using GMS.Data.Identity;
using System.Web.Mvc;
using System.Web;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using GMS.UI.ViewModels;
using System;

namespace GMS.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var usuario = await UserManager.FindByNameAsync(model.UserName);

                if (usuario != null)
                {
                    var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);

                    if (result == SignInStatus.Success)
                    {
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            returnUrl = Url.Action("Index", "Home");
                        }

                        return Redirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário ou Senha incorretos!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário não encontrado!");
                }
            }

            return View("Login", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByEmail(model.Email);
                if(user == null)
                {
                    var _user = new ApplicationUser
                    {
                        Email = model.Email,
                        UserName = model.Username,
                    };

                    try
                    {
                        var result = await UserManager.CreateAsync(_user, model.Password);
                        if (result.Succeeded)
                        {
                            await SignInManager.SignInAsync(_user, isPersistent: false, rememberBrowser: false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View(model);
                        }
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Register", "Account");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");

                }
            }
            return View(model);
        }


        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            set
            {
                SignInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected GMSContext Context
        {
            get
            {
                return HttpContext.GetOwinContext().Get<GMSContext>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}