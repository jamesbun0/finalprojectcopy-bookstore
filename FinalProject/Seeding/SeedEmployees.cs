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
	public static class SeedEmployees
	{
        //public static void SeedAllEmployees(AppDbContext _db)
        public static async Task SeedAllEmployees(IServiceProvider serviceProvider)
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
            
			Int32 intEmployeesAdded = 0;
			String employeeName = "Begin"; //helps to keep track of error on employees
			List<AppUser> Employees = new List<AppUser>();

			try
			{
				AppUser r1 = new AppUser();
				r1.Password = "smitty";
				r1.LastName = "Barnes";
				r1.FirstName = "Susan";
				r1.StreetAddress = "888 S. Main";
				r1.City = "Kyle";
				r1.State = "TX";
				r1.ZipCode = 78640;
				r1.Email = "s.barnes@bevosbooks.com";
				r1.UserName = "s.barnes@bevosbooks.com";
				r1.PhoneNumber = "9636389416";
				Employees.Add(r1);

				AppUser r2 = new AppUser();
				r2.Password = "squirrel";
				r2.LastName = "Garcia";
				r2.FirstName = "Hector";
				r2.StreetAddress = "777 PBR Drive";
				r2.City = "Austin";
				r2.State = "TX";
				r2.ZipCode = 78712;
				r2.Email = "h.garcia@bevosbooks.com";
				r2.UserName = "h.garcia@bevosbooks.com";
				r2.PhoneNumber = "4547135738";
				Employees.Add(r2);

				AppUser r3 = new AppUser();
				r3.Password = "changalang";
				r3.LastName = "Ingram";
				r3.FirstName = "Brad";
				r3.StreetAddress = "6548 La Posada Ct.";
				r3.City = "Austin";
				r3.State = "TX";
				r3.ZipCode = 78705;
				r3.Email = "b.ingram@bevosbooks.com";
				r3.UserName = "b.ingram@bevosbooks.com";
				r3.PhoneNumber = "5817343315";
				Employees.Add(r3);

				AppUser r4 = new AppUser();
				r4.Password = "rhythm";
				r4.LastName = "Jackson";
				r4.FirstName = "Jack";
				r4.StreetAddress = "222 Main";
				r4.City = "Austin";
				r4.State = "TX";
				r4.ZipCode = 78760;
				r4.Email = "j.jackson@bevosbooks.com";
				r4.UserName = "j.jackson@bevosbooks.com";
				r4.PhoneNumber = "8241915317";
				Employees.Add(r4);

				AppUser r5 = new AppUser();
				r5.Password = "approval";
				r5.LastName = "Jacobs";
				r5.FirstName = "Todd";
				r5.StreetAddress = "4564 Elm St.";
				r5.City = "Georgetown";
				r5.State = "TX";
				r5.ZipCode = 78628;
				r5.Email = "t.jacobs@bevosbooks.com";
				r5.UserName = "t.jacobs@bevosbooks.com";
				r5.PhoneNumber = "2477822475";
				Employees.Add(r5);

				AppUser r6 = new AppUser();
				r6.Password = "society";
				r6.LastName = "Jones";
				r6.FirstName = "Lester";
				r6.StreetAddress = "999 LeBlat";
				r6.City = "Austin";
				r6.State = "TX";
				r6.ZipCode = 78747;
				r6.Email = "l.jones@bevosbooks.com";
				r6.UserName = "l.jones@bevosbooks.com";
				r6.PhoneNumber = "4764966462";
				Employees.Add(r6);

				AppUser r7 = new AppUser();
				r7.Password = "tanman";
				r7.LastName = "Larson";
				r7.FirstName = "Bill";
				r7.StreetAddress = "1212 N. First Ave";
				r7.City = "Round Rock";
				r7.State = "TX";
				r7.ZipCode = 78665;
				r7.Email = "b.larson@bevosbooks.com";
				r7.UserName = "b.larson@bevosbooks.com";
				r7.PhoneNumber = "3355258855";
				Employees.Add(r7);

				AppUser r8 = new AppUser();
				r8.Password = "longhorns";
				r8.LastName = "Lawrence";
				r8.FirstName = "Victoria";
				r8.StreetAddress = "6639 Bookworm Ln.";
				r8.City = "Austin";
				r8.State = "TX";
				r8.ZipCode = 78712;
				r8.Email = "v.lawrence@bevosbooks.com";
				r8.UserName = "v.lawrence@bevosbooks.com";
				r8.PhoneNumber = "7511273054";
				Employees.Add(r8);

				AppUser r9 = new AppUser();
				r9.Password = "swansong";
				r9.LastName = "Lopez";
				r9.FirstName = "Marshall";
				r9.StreetAddress = "90 SW North St";
				r9.City = "Austin";
				r9.State = "TX";
				r9.ZipCode = 78729;
				r9.Email = "m.lopez@bevosbooks.com";
				r9.UserName = "m.lopez@bevosbooks.com";
				r9.PhoneNumber = "7477907070";
				Employees.Add(r9);

				AppUser r10 = new AppUser();
				r10.Password = "fungus";
				r10.LastName = "MacLeod";
				r10.FirstName = "Jennifer";
				r10.StreetAddress = "2504 Far West Blvd.";
				r10.City = "Austin";
				r10.State = "TX";
				r10.ZipCode = 78705;
				r10.Email = "j.macleod@bevosbooks.com";
				r10.UserName = "j.macleod@bevosbooks.com";
				r10.PhoneNumber = "2621216845";
				Employees.Add(r10);

				AppUser r11 = new AppUser();
				r11.Password = "median";
				r11.LastName = "Markham";
				r11.FirstName = "Elizabeth";
				r11.StreetAddress = "7861 Chevy Chase";
				r11.City = "Austin";
				r11.State = "TX";
				r11.ZipCode = 78785;
				r11.Email = "e.markham@bevosbooks.com";
				r11.UserName = "e.markham@bevosbooks.com";
				r11.PhoneNumber = "5028075807";
				Employees.Add(r11);

				AppUser r12 = new AppUser();
				r12.Password = "decorate";
				r12.LastName = "Martinez";
				r12.FirstName = "Gregory";
				r12.StreetAddress = "8295 Sunset Blvd.";
				r12.City = "Austin";
				r12.State = "TX";
				r12.ZipCode = 78712;
				r12.Email = "g.martinez@bevosbooks.com";
				r12.UserName = "g.martinez@bevosbooks.com";
				r12.PhoneNumber = "1994708542";
				Employees.Add(r12);

				AppUser r13 = new AppUser();
				r13.Password = "rankmary";
				r13.LastName = "Mason";
				r13.FirstName = "Jack";
				r13.StreetAddress = "444 45th St";
				r13.City = "Austin";
				r13.State = "TX";
				r13.ZipCode = 78701;
				r13.Email = "j.mason@bevosbooks.com";
				r13.UserName = "j.mason@bevosbooks.com";
				r13.PhoneNumber = "1748136441";
				Employees.Add(r13);

				AppUser r14 = new AppUser();
				r14.Password = "kindly";
				r14.LastName = "Miller";
				r14.FirstName = "Charles";
				r14.StreetAddress = "8962 Main St.";
				r14.City = "Austin";
				r14.State = "TX";
				r14.ZipCode = 78709;
				r14.Email = "c.miller@bevosbooks.com";
				r14.UserName = "c.miller@bevosbooks.com";
				r14.PhoneNumber = "8999319585";
				Employees.Add(r14);

				AppUser r15 = new AppUser();
				r15.Password = "ricearoni";
				r15.LastName = "Nguyen";
				r15.FirstName = "Mary";
				r15.StreetAddress = "465 N. Bear Cub";
				r15.City = "Austin";
				r15.State = "TX";
				r15.ZipCode = 78734;
				r15.Email = "m.nguyen@bevosbooks.com";
				r15.UserName = "m.nguyen@bevosbooks.com";
				r15.PhoneNumber = "8716746381";
				Employees.Add(r15);

				AppUser r16 = new AppUser();
				r16.Password = "walkamile";
				r16.LastName = "Rankin";
				r16.FirstName = "Suzie";
				r16.StreetAddress = "23 Dewey Road";
				r16.City = "Austin";
				r16.State = "TX";
				r16.ZipCode = 78712;
				r16.Email = "s.rankin@bevosbooks.com";
				r16.UserName = "s.rankin@bevosbooks.com";
				r16.PhoneNumber = "5239029525";
				Employees.Add(r16);

				AppUser r17 = new AppUser();
				r17.Password = "ingram45";
				r17.LastName = "Rhodes";
				r17.FirstName = "Megan";
				r17.StreetAddress = "4587 Enfield Rd.";
				r17.City = "Austin";
				r17.State = "TX";
				r17.ZipCode = 78729;
				r17.Email = "m.rhodes@bevosbooks.com";
				r17.UserName = "m.rhodes@bevosbooks.com";
				r17.PhoneNumber = "1232139514";
				Employees.Add(r17);

				AppUser r18 = new AppUser();
				r18.Password = "nostalgic";
				r18.LastName = "Saunders";
				r18.FirstName = "Sarah";
				r18.StreetAddress = "332 Avenue C";
				r18.City = "Austin";
				r18.State = "TX";
				r18.ZipCode = 78733;
				r18.Email = "s.saunders@bevosbooks.com";
				r18.UserName = "s.saunders@bevosbooks.com";
				r18.PhoneNumber = "9036349587";
				Employees.Add(r18);

				AppUser r19 = new AppUser();
				r19.Password = "evanescent";
				r19.LastName = "Sheffield";
				r19.FirstName = "Martin";
				r19.StreetAddress = "3886 Avenue A";
				r19.City = "San Marcos";
				r19.State = "TX";
				r19.ZipCode = 78666;
				r19.Email = "m.sheffield@bevosbooks.com";
				r19.UserName = "m.sheffield@bevosbooks.com";
				r19.PhoneNumber = "9349192978";
				Employees.Add(r19);

				AppUser r20 = new AppUser();
				r20.Password = "stewboy";
				r20.LastName = "Silva";
				r20.FirstName = "Cindy";
				r20.StreetAddress = "900 4th St";
				r20.City = "Austin";
				r20.State = "TX";
				r20.ZipCode = 78758;
				r20.Email = "c.silva@bevosbooks.com";
				r20.UserName = "c.silva@bevosbooks.com";
				r20.PhoneNumber = "4874328170";
				Employees.Add(r20);

				AppUser r21 = new AppUser();
				r21.Password = "instrument";
				r21.LastName = "Stuart";
				r21.FirstName = "Eric";
				r21.StreetAddress = "5576 Toro Ring";
				r21.City = "Austin";
				r21.State = "TX";
				r21.ZipCode = 78758;
				r21.Email = "e.stuart@bevosbooks.com";
				r21.UserName = "e.stuart@bevosbooks.com";
				r21.PhoneNumber = "1967846827";
				Employees.Add(r21);

				AppUser r22 = new AppUser();
				r22.Password = "hecktour";
				r22.LastName = "Tanner";
				r22.FirstName = "Jeremy";
				r22.StreetAddress = "4347 Almstead";
				r22.City = "Austin";
				r22.State = "TX";
				r22.ZipCode = 78712;
				r22.Email = "j.tanner@bevosbooks.com";
				r22.UserName = "j.tanner@bevosbooks.com";
				r22.PhoneNumber = "5923026779";
				Employees.Add(r22);

				AppUser r23 = new AppUser();
				r23.Password = "countryrhodes";
				r23.LastName = "Taylor";
				r23.FirstName = "Allison";
				r23.StreetAddress = "467 Nueces St.";
				r23.City = "Austin";
				r23.State = "TX";
				r23.ZipCode = 78727;
				r23.Email = "a.taylor@bevosbooks.com";
				r23.UserName = "a.taylor@bevosbooks.com";
				r23.PhoneNumber = "7246195827";
				Employees.Add(r23);

				//loop through repos
				foreach (AppUser employee in Employees)
				{
					//set name of repo to help debug
					employeeName = employee.Email;

					//see if repo exists in database
					AppUser dbEmployee = _db.Users.FirstOrDefault(r => r.Email == employee.Email);

					if (dbEmployee == null) //customer does not exist in database
					{
                        //_db.Users.Add(employee);
                        //_db.SaveChanges();
                        var result = await _userManager.CreateAsync(employee, employee.Password);
                        if (result.Succeeded == false)
                        {
                            throw new Exception("This user can't be added - " + result.ToString());
                        }
                        _db.SaveChanges();
                        intEmployeesAdded += 1;
					}
					else
					{
						dbEmployee.Password = employee.Password;
						dbEmployee.LastName = employee.LastName;
						dbEmployee.FirstName = employee.FirstName;
						dbEmployee.StreetAddress = employee.StreetAddress;
						dbEmployee.City = employee.City;
						dbEmployee.State = employee.State;
						dbEmployee.ZipCode = employee.ZipCode;
						dbEmployee.Email = employee.Email;
						dbEmployee.PhoneNumber = employee.PhoneNumber;
						_db.Update(dbEmployee);
						_db.SaveChanges();
					}

                    dbEmployee = _db.Users.FirstOrDefault(u => u.UserName == employee.UserName);

                    if (await _userManager.IsInRoleAsync(dbEmployee, "Employee") == false)
                    {
                        await _userManager.AddToRoleAsync(dbEmployee, "Employee");
                    }
                    _db.SaveChanges();
                }
			}
			catch
			{
				String msg = "Employees added:" + intEmployeesAdded + "; Error on " + employeeName;
				throw new InvalidOperationException(msg);
			}
		}
	}
}
