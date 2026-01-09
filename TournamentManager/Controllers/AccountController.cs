using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TournamentManager.Data;
using TournamentManager.Models.Entities;
using TournamentManager.Models.ViewModel;
using TournamentManager.Services;
using System.Data;

namespace TournamentManager.Controllers
{
    public class AccountController(DbManager mgr, AccountService accountService) : Controller
    {
        private readonly DbManager _mgr = mgr;
        private readonly AccountService _accountService = accountService;

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var cmd = _mgr.BuildSP("pr_ReadUserAccount");
            _mgr.AddParameter(cmd, "Username", SqlDbType.VarChar, model.Username);
            var accounts = await _mgr.ExecuteReaderAsync<Account>(cmd);
            var account = accounts.FirstOrDefault();

            if (account == null)
            {
                ModelState.AddModelError("Username", "Invalid username.");
            }
            else if (!_accountService.VerifyPassword(account.PasswordHash, model.Password))
            {
                ModelState.AddModelError("Password", "Invalid password.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account?.Username ?? ""),
                new Claim(ClaimTypes.Role, account ?.Role ?? "")
            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = _mgr.BuildSP("pr_ReadUserAccount");
                _mgr.AddParameter(cmd, "Username", SqlDbType.VarChar, model.Username.Trim());
                var accounts = await _mgr.ExecuteReaderAsync<Account>(cmd);
                var account = accounts.FirstOrDefault();

                if (account != null)
                {
                    ModelState.AddModelError("Username", "Username already exist.");
                    return View(model);
                }

                string hashedPassword = _accountService.HashPassword(model.Password);

                cmd = _mgr.BuildSP("pr_CreateUserAccount");
                _mgr.AddParameter(cmd, "Username", SqlDbType.VarChar, model.Username.Trim());
                _mgr.AddParameter(cmd, "PasswordHash", SqlDbType.VarChar, hashedPassword);
                await _mgr.ExecuteNonQueryAsync(cmd);

                return RedirectToAction("Account", "Login");
            }

            return View();
        }

        [HttpPost, ActionName("Logout")]
        [Authorize(Roles = "SUPER,ADMIN")]
        public async Task<IActionResult> ConfirmedLogout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
