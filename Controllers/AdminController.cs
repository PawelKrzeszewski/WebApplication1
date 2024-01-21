using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        public IActionResult Edit(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            if (user == null)
            {
                return NotFound();
            }

            var availableRoles = _roleManager.Roles.Select(role => role.Name).ToList();
            var userRoles = _userManager.GetRolesAsync(user).Result.ToList();

            ViewBag.AvailableRoles = availableRoles;

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(IdentityUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Błąd edycji użytkownika.");
                    return View(model);
                }

                // Usuń stare role użytkownika
                var oldRoles = await _userManager.GetRolesAsync(user);
                var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, oldRoles);

                if (!removeRolesResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Błąd usuwania starych ról użytkownika.");
                    return View(model);
                }

                // Dodaj nowe role użytkownika
                var newRoles = await _userManager.GetRolesAsync(user);
                var addRolesResult = await _userManager.AddToRolesAsync(user, newRoles);

                if (!addRolesResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Błąd dodawania nowych ról użytkownika.");
                    return View(model);
                }

                return RedirectToAction("Index"); // Przekieruj na odpowiednią stronę po zapisaniu zmian
            }

            // Jeśli ModelState.IsValid jest false, zwróć formularz z błędami
            return View(model);
        }





    }

}
