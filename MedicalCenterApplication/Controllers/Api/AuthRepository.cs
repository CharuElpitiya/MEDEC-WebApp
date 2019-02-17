using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MedicalCenterApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MedicalCenterApplication.Controllers.Api
{
    public class AuthRepository : IDisposable
    {

        private readonly ApplicationDbContext _ctx;

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));

            Users user = new Users
            {
                UserName = userModel.UserName.ToLower(),
                Email = userModel.Email,
                PhoneNumber = userModel.Phone,
                Address = userModel.Address,
                Name = userModel.Name
            };
            
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!roleManager.RoleExists(userModel.Role))
            {
                await roleManager.CreateAsync(new IdentityRole(userModel.Role));
            }
            await _userManager.AddToRoleAsync(user.Id, userModel.Role);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<IList<string>> UserRoles(string userId)
        {
            IList<string> roles = await _userManager.GetRolesAsync(userId);

            return roles;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}