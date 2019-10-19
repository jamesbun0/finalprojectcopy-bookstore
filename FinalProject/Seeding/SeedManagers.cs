using FinalProject.Models;
using FinalProject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace FinalProject.Seeding
{
	public static class SeedManagers
	{
        //public static void SeedAllManagers(AppDbContext _db)
        public static async Task SeedAllManagers(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();

            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (await _roleManager.RoleExistsAsync("Manager") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            if (await _roleManager.RoleExistsAsync("Employee") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }


            Int32 intManagersAdded = 0;
			String managerName = "Begin"; //helps to keep track of error on Managers
			List<AppUser> Managers = new List<AppUser>();

			try
			{
				AppUser r1 = new AppUser();
				r1.Password = "dewey4";
				r1.LastName = "Baker";
				r1.FirstName = "Christopher";
				r1.StreetAddress = "1245 Lake Libris Dr.";
				r1.City = "Cedar Park";
				r1.State = "TX";
				r1.ZipCode = 78613;
				r1.Email = "c.baker@bevosbooks.com";
				r1.UserName = "c.baker@bevosbooks.com";
				r1.PhoneNumber = "3395325649";
				Managers.Add(r1);

				AppUser r2 = new AppUser();
				r2.Password = "arched";
				r2.LastName = "Rice";
				r2.FirstName = "Eryn";
				r2.StreetAddress = "3405 Rio Grande";
				r2.City = "Austin";
				r2.State = "TX";
				r2.ZipCode = 78746;
				r2.Email = "e.rice@bevosbooks.com";
				r2.UserName = "e.rice@bevosbooks.com";
				r2.PhoneNumber = "2706602803";
				Managers.Add(r2);

				AppUser r3 = new AppUser();
				r3.Password = "lottery";
				r3.LastName = "Rogers";
				r3.FirstName = "Allen";
				r3.StreetAddress = "4965 Oak Hill";
				r3.City = "Austin";
				r3.State = "TX";
				r3.ZipCode = 78705;
				r3.Email = "a.rogers@bevosbooks.com";
				r3.UserName = "a.rogers@bevosbooks.com";
				r3.PhoneNumber = "4139645586";
				Managers.Add(r3);

				AppUser r4 = new AppUser();
				r4.Password = "offbeat";
				r4.LastName = "Sewell";
				r4.FirstName = "William";
				r4.StreetAddress = "2365 51st St.";
				r4.City = "Austin";
				r4.State = "TX";
				r4.ZipCode = 78755;
				r4.Email = "w.sewell@bevosbooks.com";
				r4.UserName = "w.sewell@bevosbooks.com";
				r4.PhoneNumber = "7224308314";
				Managers.Add(r4);

				AppUser r5 = new AppUser();
				r5.Password = "landus";
				r5.LastName = "Taylor";
				r5.FirstName = "Rachel";
				r5.StreetAddress = "345 Longview Dr.";
				r5.City = "Austin";
				r5.State = "TX";
				r5.ZipCode = 78746;
				r5.Email = "r.taylor@bevosbooks.com";
				r5.UserName = "r.taylor@bevosbooks.com";
				r5.PhoneNumber = "9071236087";
				Managers.Add(r5);

				//loop through repos
				foreach (AppUser manager in Managers)
				{
					//set name of repo to help debug
					managerName = manager.Email;

					//see if repo exists in database
					AppUser dbManager = _db.Users.FirstOrDefault(r => r.Email == manager.Email);

					if (dbManager == null) //manager does not exist in database
					{
                        //_db.Users.Add(manager);
                        //_db.SaveChanges();
                        var result = await _userManager.CreateAsync(manager, manager.Password);
                        if (result.Succeeded == false)
                        {
                            throw new Exception("This user can't be added - " + result.ToString());
                        }
                        _db.SaveChanges();
                        intManagersAdded += 1;
					}
					else
					{
						dbManager.Password = manager.Password;
						dbManager.LastName = manager.LastName;
						dbManager.FirstName = manager.FirstName;
						dbManager.StreetAddress = manager.StreetAddress;
						dbManager.City = manager.City;
						dbManager.State = manager.State;
						dbManager.ZipCode = manager.ZipCode;
						dbManager.Email = manager.Email;
						dbManager.PhoneNumber = manager.PhoneNumber;
						_db.Update(dbManager);
						_db.SaveChanges();
					}

                    dbManager = _db.Users.FirstOrDefault(u => u.UserName == manager.UserName);

                    if (await _userManager.IsInRoleAsync(dbManager, "Manager") == false)
                    {
                        await _userManager.AddToRoleAsync(dbManager, "Manager");
                    }
                    _db.SaveChanges();
                }
			}
			catch
			{
				String msg = "Managers added:" + intManagersAdded + "; Error on " + managerName;
				throw new InvalidOperationException(msg);
			}
		}
	}
}
