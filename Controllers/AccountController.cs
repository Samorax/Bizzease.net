using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication_Webease_.Services.DAL;
using WebApplication_Webease_.Models;
using WebApplication_Webease_.ViewModels.Account;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using WebApplication_Webease_.Services;


namespace WebApplication_Webease_.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILogger _Logger;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        private IMailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser>SignInManager, ILoggerFactory loggerFactory, IMailSender emailSender)
        {
            _UserManager = manager;
            _SignInManager = SignInManager;
            _Logger = loggerFactory.CreateLogger<AccountController>();
            _emailSender = emailSender;
            
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email };
                var result = await _UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    await _emailSender.SendMessage(model.Email, "Confirm your account",
                        $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

                    await _SignInManager.SignInAsync(user, isPersistent: false);
                    var User = _UserManager.FindByEmailAsync(model.Email);
                    RedirectToAction(nameof(DashBoardController.Index),new { customerId = User.Id } );
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(model);
        }

        private static void EnsureDatabaseCreated(IdentityContext context)
        {
            context.Database.EnsureCreated();
        }

        private void AddErrors(IdentityResult result)
        {

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model,string returnUrl=null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = _UserManager.FindByEmailAsync(model.Email);
                    RedirectToAction(nameof(DashBoardController.Index),new { customerId = user.Id });
                }

                if (result.IsLockedOut)
                {
                   
                    return View("LockOut");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt");
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await _SignInManager.SignOutAsync();
            _Logger.LogInformation(6, "User Logged out");
            return RedirectToAction(nameof(AccountController.LogIn));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword() => View();
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await _UserManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View(nameof(AccountController.ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                var code = await _UserManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action(nameof(AccountController.ResetPassword), "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendMessage(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return View(nameof(AccountController.ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            var result = await _UserManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        

    }
}
