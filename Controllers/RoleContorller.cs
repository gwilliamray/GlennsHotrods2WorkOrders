using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;  // This allows me to use the userManager and the roleManager
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlennsHotrods2.Controllers
{
    // Now only a Admin can run these methods
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleMgr,
                              UserManager<IdentityUser> userMgr)
        {
            userManager = userMgr;
            roleManager = roleMgr;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        // Create and add a Admin user who is part of the admin role
        public async Task<IActionResult> AddAdmin()
        {
            bool roleExist;

            roleExist = await roleManager.RoleExistsAsync("Admin");  // Check and see if we already have a Admin Role

            if(!roleExist) 
            {
                // Create a new role
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                // Create a new Admin user
                var user = new IdentityUser();
                user.UserName = "AdminUser@Glenns.com";  // the default set up user name is the same as email address
                user.Email = "AdminUser@Glenns.com";     // go ahead and set the email to the same

                // Assign a password
                string userPWD = "Gray@2803";   // This should fit the rules of a strong password

                // Create the user with the password
                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if(chkUser.Succeeded)
                {
                    // now add the user to the role
                    var result1 = await userManager.AddToRoleAsync(user, "Admin"); // Add to Admin role
                    ViewBag.Message = "User and Role Created!";
                }
                else
                {
                    ViewBag.Message = "Problem creating  the user or role";
                }

            }  // if role exists
            else
            {
                ViewBag.Message = "That role already exists";
            }
            return View();
        }
    }
}
