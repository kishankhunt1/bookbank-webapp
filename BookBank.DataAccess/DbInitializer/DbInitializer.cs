using BookBank.Models;
using BookBank.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Intializer()
        {
            // migration if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
                
            }
            catch(Exception ex)
            {

            }


            // create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Individual)).GetAwaiter().GetResult();


                // if roles are not created, then we will create admin user as well 
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin123@gmail.com",
                    Email = "Admin123@gmail.com",
                    Name = "Admin",
                    PhoneNumber = "7874580988",
                    StreetAddress = "Rajdeep Society, Street no. 3, Blok no. 204, Near Shiv Complex.",
                    State = "Gujarat",
                    PostalCode = "360005",
                    City = "Rajkot"
                }, "Admin123@").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "Admin123@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
