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
    public static class SeedCustomers
    {
        //public static void SeedAllCustomers(AppDbContext _db)
        public static async Task SeedAllCustomers(IServiceProvider serviceProvider)
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



                Int32 intCustomersAdded = 0;
                String customerName = "Begin"; //helps to keep track of error on customers
                List<AppUser> Customers = new List<AppUser>();

                try
                {
                    AppUser r1 = new AppUser();
                    r1.Password = "bookworm";
                    r1.LastName = "Baker";
                    r1.FirstName = "Christopher";
                    r1.StreetAddress = "1898 Schurz Alley";
                    r1.City = "Austin";
                    r1.State = "TX";
                    r1.ZipCode = 78705;
                    r1.Email = "cbaker@example.com";
                    r1.UserName = "cbaker@example.com";
                    r1.PhoneNumber = "5725458641";
                    Customers.Add(r1);

                    AppUser r2 = new AppUser();
                    r2.Password = "potato";
                    r2.LastName = "Banks";
                    r2.FirstName = "Michelle";
                    r2.StreetAddress = "97 Elmside Pass";
                    r2.City = "Austin";
                    r2.State = "TX";
                    r2.ZipCode = 78712;
                    r2.Email = "banker@longhorn.net";
                    r2.UserName = "banker@longhorn.net";
                    r2.PhoneNumber = "9867048435";
                    Customers.Add(r2);

                    AppUser r3 = new AppUser();
                    r3.Password = "painting";
                    r3.LastName = "Broccolo";
                    r3.FirstName = "Franco";
                    r3.StreetAddress = "88 Crowley Circle";
                    r3.City = "Austin";
                    r3.State = "TX";
                    r3.ZipCode = 78786;
                    r3.Email = "franco@example.com";
                    r3.UserName = "franco@example.com";
                    r3.PhoneNumber = "6836109514";
                    Customers.Add(r3);

                    AppUser r4 = new AppUser();
                    r4.Password = "texas1";
                    r4.LastName = "Chang";
                    r4.FirstName = "Wendy";
                    r4.StreetAddress = "56560 Sage Junction";
                    r4.City = "Eagle Pass";
                    r4.State = "TX";
                    r4.ZipCode = 78852;
                    r4.Email = "wchang@example.com";
                    r4.UserName = "wchang@example.com";
                    r4.PhoneNumber = "7070911071";
                    Customers.Add(r4);

                    AppUser r5 = new AppUser();
                    r5.Password = "Anchorage";
                    r5.LastName = "Chou";
                    r5.FirstName = "Lim";
                    r5.StreetAddress = "60 Lunder Point";
                    r5.City = "Austin";
                    r5.State = "TX";
                    r5.ZipCode = 78729;
                    r5.Email = "limchou@gogle.com";
                    r5.UserName = "limchou@gogle.com";
                    r5.PhoneNumber = "1488907687";
                    Customers.Add(r5);

                    AppUser r6 = new AppUser();
                    r6.Password = "aggies";
                    r6.LastName = "Dixon";
                    r6.FirstName = "Shan";
                    r6.StreetAddress = "9448 Pleasure Avenue";
                    r6.City = "Georgetown";
                    r6.State = "TX";
                    r6.ZipCode = 78628;
                    r6.Email = "shdixon@aoll.com";
                    r6.UserName = "shdixon@aoll.com";
                    r6.PhoneNumber = "6899701824";
                    Customers.Add(r6);

                    AppUser r7 = new AppUser();
                    r7.Password = "hampton1";
                    r7.LastName = "Evans";
                    r7.FirstName = "Jim Bob";
                    r7.StreetAddress = "51 Emmet Parkway";
                    r7.City = "Austin";
                    r7.State = "TX";
                    r7.ZipCode = 78705;
                    r7.Email = "j.b.evans@aheca.org";
                    r7.UserName = "j.b.evans@aheca.org";
                    r7.PhoneNumber = "9986825917";
                    Customers.Add(r7);

                    AppUser r8 = new AppUser();
                    r8.Password = "longhorns";
                    r8.LastName = "Feeley";
                    r8.FirstName = "Lou Ann";
                    r8.StreetAddress = "65 Darwin Crossing";
                    r8.City = "Austin";
                    r8.State = "TX";
                    r8.ZipCode = 78704;
                    r8.Email = "feeley@penguin.org";
                    r8.UserName = "feeley@penguin.org";
                    r8.PhoneNumber = "3464121966";
                    Customers.Add(r8);

                    AppUser r9 = new AppUser();
                    r9.Password = "mustangs";
                    r9.LastName = "Freeley";
                    r9.FirstName = "Tesa";
                    r9.StreetAddress = "7352 Loftsgordon Court";
                    r9.City = "College Station";
                    r9.State = "TX";
                    r9.ZipCode = 77840;
                    r9.Email = "tfreeley@minnetonka.ci.us";
                    r9.UserName = "tfreeley@minnetonka.ci.us";
                    r9.PhoneNumber = "6581357270";
                    Customers.Add(r9);

                    AppUser r10 = new AppUser();
                    r10.Password = "onetime";
                    r10.LastName = "Garcia";
                    r10.FirstName = "Margaret";
                    r10.StreetAddress = "7 International Road";
                    r10.City = "Austin";
                    r10.State = "TX";
                    r10.ZipCode = 78756;
                    r10.Email = "mgarcia@gogle.com";
                    r10.UserName = "mgarcia@gogle.com";
                    r10.PhoneNumber = "3767347949";
                    Customers.Add(r10);

                    AppUser r11 = new AppUser();
                    r11.Password = "pepperoni";
                    r11.LastName = "Haley";
                    r11.FirstName = "Charles";
                    r11.StreetAddress = "8 Warrior Trail";
                    r11.City = "Austin";
                    r11.State = "TX";
                    r11.ZipCode = 78746;
                    r11.Email = "chaley@thug.com";
                    r11.UserName = "chaley@thug.com";
                    r11.PhoneNumber = "2198604221";
                    Customers.Add(r11);

                    AppUser r12 = new AppUser();
                    r12.Password = "raiders";
                    r12.LastName = "Hampton";
                    r12.FirstName = "Jeffrey";
                    r12.StreetAddress = "9107 Lighthouse Bay Road";
                    r12.City = "Austin";
                    r12.State = "TX";
                    r12.ZipCode = 78756;
                    r12.Email = "jeffh@sonic.com";
                    r12.UserName = "jeffh@sonic.com";
                    r12.PhoneNumber = "1222185888";
                    Customers.Add(r12);

                    AppUser r13 = new AppUser();
                    r13.Password = "jhearn22";
                    r13.LastName = "Hearn";
                    r13.FirstName = "John";
                    r13.StreetAddress = "59784 Pierstorff Center";
                    r13.City = "Liberty";
                    r13.State = "TX";
                    r13.ZipCode = 77575;
                    r13.Email = "wjhearniii@umich.org";
                    r13.UserName = "wjhearniii@umich.org";
                    r13.PhoneNumber = "5123071976";
                    Customers.Add(r13);

                    AppUser r14 = new AppUser();
                    r14.Password = "hickhickup";
                    r14.LastName = "Hicks";
                    r14.FirstName = "Anthony";
                    r14.StreetAddress = "932 Monica Way";
                    r14.City = "San Antonio";
                    r14.State = "TX";
                    r14.ZipCode = 78203;
                    r14.Email = "ahick@yaho.com";
                    r14.UserName = "ahick@yaho.com";
                    r14.PhoneNumber = "1211949601";
                    Customers.Add(r14);

                    AppUser r15 = new AppUser();
                    r15.Password = "ingram2015";
                    r15.LastName = "Ingram";
                    r15.FirstName = "Brad";
                    r15.StreetAddress = "4 Lukken Court";
                    r15.City = "New Braunfels";
                    r15.State = "TX";
                    r15.ZipCode = 78132;
                    r15.Email = "ingram@jack.com";
                    r15.UserName = "ingram@jack.com";
                    r15.PhoneNumber = "1372121569";
                    Customers.Add(r15);

                    AppUser r16 = new AppUser();
                    r16.Password = "toddy25";
                    r16.LastName = "Jacobs";
                    r16.FirstName = "Todd";
                    r16.StreetAddress = "7 Susan Junction";
                    r16.City = "New York";
                    r16.State = "NY";
                    r16.ZipCode = 10101;
                    r16.Email = "toddj@yourmom.com";
                    r16.UserName = "toddj@yourmom.com";
                    r16.PhoneNumber = "8543163836";
                    Customers.Add(r16);

                    AppUser r17 = new AppUser();
                    r17.Password = "something";
                    r17.LastName = "Lawrence";
                    r17.FirstName = "Victoria";
                    r17.StreetAddress = "669 Oak Junction";
                    r17.City = "Lockhart";
                    r17.State = "TX";
                    r17.ZipCode = 78644;
                    r17.Email = "thequeen@aska.net";
                    r17.UserName = "thequeen@aska.net";
                    r17.PhoneNumber = "3214163359";
                    Customers.Add(r17);

                    AppUser r18 = new AppUser();
                    r18.Password = "Password1";
                    r18.LastName = "Lineback";
                    r18.FirstName = "Erik";
                    r18.StreetAddress = "099 Luster Point";
                    r18.City = "Kingwood";
                    r18.State = "TX";
                    r18.ZipCode = 77325;
                    r18.Email = "linebacker@gogle.com";
                    r18.UserName = "linebacker@gogle.com";
                    r18.PhoneNumber = "2505265350";
                    Customers.Add(r18);

                    AppUser r19 = new AppUser();
                    r19.Password = "aclfest2017";
                    r19.LastName = "Lowe";
                    r19.FirstName = "Ernest";
                    r19.StreetAddress = "35473 Hansons Hill";
                    r19.City = "Beverly Hills";
                    r19.State = "CA";
                    r19.ZipCode = 90210;
                    r19.Email = "elowe@netscare.net";
                    r19.UserName = "elowe@netscare.net";
                    r19.PhoneNumber = "4070619503";
                    Customers.Add(r19);

                    AppUser r20 = new AppUser();
                    r20.Password = "nothinggood";
                    r20.LastName = "Luce";
                    r20.FirstName = "Chuck";
                    r20.StreetAddress = "4 Emmet Junction";
                    r20.City = "Navasota";
                    r20.State = "TX";
                    r20.ZipCode = 77868;
                    r20.Email = "cluce@gogle.com";
                    r20.UserName = "cluce@gogle.com";
                    r20.PhoneNumber = "7358436110";
                    Customers.Add(r20);

                    AppUser r21 = new AppUser();
                    r21.Password = "whatever";
                    r21.LastName = "MacLeod";
                    r21.FirstName = "Jennifer";
                    r21.StreetAddress = "3 Orin Road";
                    r21.City = "Austin";
                    r21.State = "TX";
                    r21.ZipCode = 78712;
                    r21.Email = "mackcloud@george.com";
                    r21.UserName = "mackcloud@george.com";
                    r21.PhoneNumber = "7240178229";
                    Customers.Add(r21);

                    AppUser r22 = new AppUser();
                    r22.Password = "snowsnow";
                    r22.LastName = "Markham";
                    r22.FirstName = "Elizabeth";
                    r22.StreetAddress = "8171 Commercial Crossing";
                    r22.City = "Austin";
                    r22.State = "TX";
                    r22.ZipCode = 78712;
                    r22.Email = "cmartin@beets.com";
                    r22.UserName = "cmartin@beets.com";
                    r22.PhoneNumber = "2495200223";
                    Customers.Add(r22);

                    AppUser r23 = new AppUser();
                    r23.Password = "whocares";
                    r23.LastName = "Martin";
                    r23.FirstName = "Clarence";
                    r23.StreetAddress = "96 Anthes Place";
                    r23.City = "Schenectady";
                    r23.State = "NY";
                    r23.ZipCode = 12345;
                    r23.Email = "clarence@yoho.com";
                    r23.UserName = "clarence@yoho.com";
                    r23.PhoneNumber = "4086179161";
                    Customers.Add(r23);

                    AppUser r24 = new AppUser();
                    r24.Password = "xcellent";
                    r24.LastName = "Martinez";
                    r24.FirstName = "Gregory";
                    r24.StreetAddress = "10 Northridge Plaza";
                    r24.City = "Austin";
                    r24.State = "TX";
                    r24.ZipCode = 78717;
                    r24.Email = "gregmartinez@drdre.com";
                    r24.UserName = "gregmartinez@drdre.com";
                    r24.PhoneNumber = "9371927523";
                    Customers.Add(r24);

                    AppUser r25 = new AppUser();
                    r25.Password = "mydogspot";
                    r25.LastName = "Miller";
                    r25.FirstName = "Charles";
                    r25.StreetAddress = "87683 Schmedeman Circle";
                    r25.City = "Austin";
                    r25.State = "TX";
                    r25.ZipCode = 78727;
                    r25.Email = "cmiller@bob.com";
                    r25.UserName = "cmiller@bob.com";
                    r25.PhoneNumber = "5954063857";
                    Customers.Add(r25);

                    AppUser r26 = new AppUser();
                    r26.Password = "spotmydog";
                    r26.LastName = "Nelson";
                    r26.FirstName = "Kelly";
                    r26.StreetAddress = "3244 Ludington Court";
                    r26.City = "Beaumont";
                    r26.State = "TX";
                    r26.ZipCode = 77720;
                    r26.Email = "knelson@aoll.com";
                    r26.UserName = "knelson@aoll.com";
                    r26.PhoneNumber = "8929209512";
                    Customers.Add(r26);

                    AppUser r27 = new AppUser();
                    r27.Password = "joejoejoe";
                    r27.LastName = "Nguyen";
                    r27.FirstName = "Joe";
                    r27.StreetAddress = "4780 Talisman Court";
                    r27.City = "San Marcos";
                    r27.State = "TX";
                    r27.ZipCode = 78667;
                    r27.Email = "joewin@xfactor.com";
                    r27.UserName = "joewin@xfactor.com";
                    r27.PhoneNumber = "9226301774";
                    Customers.Add(r27);

                    AppUser r28 = new AppUser();
                    r28.Password = "billyboy";
                    r28.LastName = "O'Reilly";
                    r28.FirstName = "Bill";
                    r28.StreetAddress = "4154 Delladonna Plaza";
                    r28.City = "Bergheim";
                    r28.State = "TX";
                    r28.ZipCode = 78004;
                    r28.Email = "orielly@foxnews.cnn";
                    r28.UserName = "orielly@foxnews.cnn";
                    r28.PhoneNumber = "2537646912";
                    Customers.Add(r28);

                    AppUser r29 = new AppUser();
                    r29.Password = "radgirl";
                    r29.LastName = "Radkovich";
                    r29.FirstName = "Anka";
                    r29.StreetAddress = "72361 Bayside Drive";
                    r29.City = "Austin";
                    r29.State = "TX";
                    r29.ZipCode = 78789;
                    r29.Email = "ankaisrad@gogle.com";
                    r29.UserName = "ankaisrad@gogle.com";
                    r29.PhoneNumber = "2182889379";
                    Customers.Add(r29);

                    AppUser r30 = new AppUser();
                    r30.Password = "meganr34";
                    r30.LastName = "Rhodes";
                    r30.FirstName = "Megan";
                    r30.StreetAddress = "76875 Hoffman Point";
                    r30.City = "Orlando";
                    r30.State = "FL";
                    r30.ZipCode = 32830;
                    r30.Email = "megrhodes@freserve.co.uk";
                    r30.UserName = "megrhodes@freserve.co.uk";
                    r30.PhoneNumber = "9532396075";
                    Customers.Add(r30);

                    AppUser r31 = new AppUser();
                    r31.Password = "ricearoni";
                    r31.LastName = "Rice";
                    r31.FirstName = "Eryn";
                    r31.StreetAddress = "048 Elmside Park";
                    r31.City = "South Padre Island";
                    r31.State = "TX";
                    r31.ZipCode = 78597;
                    r31.Email = "erynrice@aoll.com";
                    r31.UserName = "erynrice@aoll.com";
                    r31.PhoneNumber = "7303815953";
                    Customers.Add(r31);

                    AppUser r32 = new AppUser();
                    r32.Password = "alaskaboy";
                    r32.LastName = "Rodriguez";
                    r32.FirstName = "Jorge";
                    r32.StreetAddress = "01 Browning Pass";
                    r32.City = "Austin";
                    r32.State = "TX";
                    r32.ZipCode = 78744;
                    r32.Email = "jorge@noclue.com";
                    r32.UserName = "jorge@noclue.com";
                    r32.PhoneNumber = "3677322422";
                    Customers.Add(r32);

                    AppUser r33 = new AppUser();
                    r33.Password = "bunnyhop";
                    r33.LastName = "Rogers";
                    r33.FirstName = "Allen";
                    r33.StreetAddress = "844 Anderson Alley";
                    r33.City = "Canyon Lake";
                    r33.State = "TX";
                    r33.ZipCode = 78133;
                    r33.Email = "mrrogers@lovelyday.com";
                    r33.UserName = "mrrogers@lovelyday.com";
                    r33.PhoneNumber = "3911705385";
                    Customers.Add(r33);

                    AppUser r34 = new AppUser();
                    r34.Password = "dustydusty";
                    r34.LastName = "Saint-Jean";
                    r34.FirstName = "Olivier";
                    r34.StreetAddress = "1891 Docker Point";
                    r34.City = "Austin";
                    r34.State = "TX";
                    r34.ZipCode = 78779;
                    r34.Email = "stjean@athome.com";
                    r34.UserName = "stjean@athome.com";
                    r34.PhoneNumber = "7351610920";
                    Customers.Add(r34);

                    AppUser r35 = new AppUser();
                    r35.Password = "jrod2017";
                    r35.LastName = "Saunders";
                    r35.FirstName = "Sarah";
                    r35.StreetAddress = "1469 Upham Road";
                    r35.City = "Austin";
                    r35.State = "TX";
                    r35.ZipCode = 78720;
                    r35.Email = "saunders@pen.com";
                    r35.UserName = "saunders@pen.com";
                    r35.PhoneNumber = "5269661692";
                    Customers.Add(r35);

                    AppUser r36 = new AppUser();
                    r36.Password = "martin1234";
                    r36.LastName = "Sewell";
                    r36.FirstName = "William";
                    r36.StreetAddress = "1672 Oak Valley Circle";
                    r36.City = "Austin";
                    r36.State = "TX";
                    r36.ZipCode = 78705;
                    r36.Email = "willsheff@email.com";
                    r36.UserName = "willsheff@email.com";
                    r36.PhoneNumber = "1875727246";
                    Customers.Add(r36);

                    AppUser r37 = new AppUser();
                    r37.Password = "penguin12";
                    r37.LastName = "Sheffield";
                    r37.FirstName = "Martin";
                    r37.StreetAddress = "816 Kennedy Place";
                    r37.City = "Round Rock";
                    r37.State = "TX";
                    r37.ZipCode = 78680;
                    r37.Email = "sheffiled@gogle.com";
                    r37.UserName = "sheffiled@gogle.com";
                    r37.PhoneNumber = "1394323615";
                    Customers.Add(r37);

                    AppUser r38 = new AppUser();
                    r38.Password = "rogerthat";
                    r38.LastName = "Smith";
                    r38.FirstName = "John";
                    r38.StreetAddress = "0745 Golf Road";
                    r38.City = "Austin";
                    r38.State = "TX";
                    r38.ZipCode = 78760;
                    r38.Email = "johnsmith187@aoll.com";
                    r38.UserName = "johnsmith187@aoll.com";
                    r38.PhoneNumber = "6645937874";
                    Customers.Add(r38);

                    AppUser r39 = new AppUser();
                    r39.Password = "smitty444";
                    r39.LastName = "Stroud";
                    r39.FirstName = "Dustin";
                    r39.StreetAddress = "505 Dexter Plaza";
                    r39.City = "Sweet Home";
                    r39.State = "TX";
                    r39.ZipCode = 77987;
                    r39.Email = "dustroud@mail.com";
                    r39.UserName = "dustroud@mail.com";
                    r39.PhoneNumber = "6470254680";
                    Customers.Add(r39);

                    AppUser r40 = new AppUser();
                    r40.Password = "stewball";
                    r40.LastName = "Stuart";
                    r40.FirstName = "Eric";
                    r40.StreetAddress = "585 Claremont Drive";
                    r40.City = "Corpus Christi";
                    r40.State = "TX";
                    r40.ZipCode = 78412;
                    r40.Email = "estuart@anchor.net";
                    r40.UserName = "estuart@anchor.net";
                    r40.PhoneNumber = "7701621022";
                    Customers.Add(r40);

                    AppUser r41 = new AppUser();
                    r41.Password = "slowwind";
                    r41.LastName = "Stump";
                    r41.FirstName = "Peter";
                    r41.StreetAddress = "89035 Welch Circle";
                    r41.City = "Pflugerville";
                    r41.State = "TX";
                    r41.ZipCode = 78660;
                    r41.Email = "peterstump@noclue.com";
                    r41.UserName = "peterstump@noclue.com";
                    r41.PhoneNumber = "2181960061";
                    Customers.Add(r41);

                    AppUser r42 = new AppUser();
                    r42.Password = "tanner5454";
                    r42.LastName = "Tanner";
                    r42.FirstName = "Jeremy";
                    r42.StreetAddress = "4 Stang Trail";
                    r42.City = "Austin";
                    r42.State = "TX";
                    r42.ZipCode = 78702;
                    r42.Email = "jtanner@mustang.net";
                    r42.UserName = "jtanner@mustang.net";
                    r42.PhoneNumber = "9908469499";
                    Customers.Add(r42);

                    AppUser r43 = new AppUser();
                    r43.Password = "allyrally";
                    r43.LastName = "Taylor";
                    r43.FirstName = "Allison";
                    r43.StreetAddress = "726 Twin Pines Avenue";
                    r43.City = "Austin";
                    r43.State = "TX";
                    r43.ZipCode = 78713;
                    r43.Email = "taylordjay@aoll.com";
                    r43.UserName = "taylordjay@aoll.com";
                    r43.PhoneNumber = "7011918647";
                    Customers.Add(r43);

                    AppUser r44 = new AppUser();
                    r44.Password = "taylorbaylor";
                    r44.LastName = "Taylor";
                    r44.FirstName = "Rachel";
                    r44.StreetAddress = "06605 Sugar Drive";
                    r44.City = "Austin";
                    r44.State = "TX";
                    r44.ZipCode = 78712;
                    r44.Email = "rtaylor@gogle.com";
                    r44.UserName = "rtaylor@gogle.com";
                    r44.PhoneNumber = "8937910053";
                    Customers.Add(r44);

                    AppUser r45 = new AppUser();
                    r45.Password = "teeoff22";
                    r45.LastName = "Tee";
                    r45.FirstName = "Frank";
                    r45.StreetAddress = "3567 Dawn Plaza";
                    r45.City = "Austin";
                    r45.State = "TX";
                    r45.ZipCode = 78786;
                    r45.Email = "teefrank@noclue.com";
                    r45.UserName = "teefrank@noclue.com";
                    r45.PhoneNumber = "6394568913";
                    Customers.Add(r45);

                    AppUser r46 = new AppUser();
                    r46.Password = "tucksack1";
                    r46.LastName = "Tucker";
                    r46.FirstName = "Clent";
                    r46.StreetAddress = "704 Northland Alley";
                    r46.City = "San Antonio";
                    r46.State = "TX";
                    r46.ZipCode = 78279;
                    r46.Email = "ctucker@alphabet.co.uk";
                    r46.UserName = "ctucker@alphabet.co.uk";
                    r46.PhoneNumber = "2676838676";
                    Customers.Add(r46);

                    AppUser r47 = new AppUser();
                    r47.Password = "meow88";
                    r47.LastName = "Velasco";
                    r47.FirstName = "Allen";
                    r47.StreetAddress = "72 Harbort Point";
                    r47.City = "Navasota";
                    r47.State = "TX";
                    r47.ZipCode = 77868;
                    r47.Email = "avelasco@yoho.com";
                    r47.UserName = "avelasco@yoho.com";
                    r47.PhoneNumber = "3452909754";
                    Customers.Add(r47);

                    AppUser r48 = new AppUser();
                    r48.Password = "vinovino";
                    r48.LastName = "Vino";
                    r48.FirstName = "Janet";
                    r48.StreetAddress = "1 Oak Valley Place";
                    r48.City = "Boston";
                    r48.State = "MA";
                    r48.ZipCode = 02114;
                    r48.Email = "vinovino@grapes.com";
                    r48.UserName = "vinovino@grapes.com";
                    r48.PhoneNumber = "8567089194";
                    Customers.Add(r48);

                    AppUser r49 = new AppUser();
                    r49.Password = "gowest";
                    r49.LastName = "West";
                    r49.FirstName = "Jake";
                    r49.StreetAddress = "48743 Banding Parkway";
                    r49.City = "Marble Falls";
                    r49.State = "TX";
                    r49.ZipCode = 78654;
                    r49.Email = "westj@pioneer.net";
                    r49.UserName = "westj@pioneer.net";
                    r49.PhoneNumber = "6260784394";
                    Customers.Add(r49);

                    AppUser r50 = new AppUser();
                    r50.Password = "louielouie";
                    r50.LastName = "Winthorpe";
                    r50.FirstName = "Louis";
                    r50.StreetAddress = "96850 Summit Crossing";
                    r50.City = "Austin";
                    r50.State = "TX";
                    r50.ZipCode = 78730;
                    r50.Email = "winner@hootmail.com";
                    r50.UserName = "winner@hootmail.com";
                    r50.PhoneNumber = "3733971174";
                    Customers.Add(r50);

                    AppUser r51 = new AppUser();
                    r51.Password = "woodyman1";
                    r51.LastName = "Wood";
                    r51.FirstName = "Reagan";
                    r51.StreetAddress = "18354 Bluejay Street";
                    r51.City = "Austin";
                    r51.State = "TX";
                    r51.ZipCode = 78712;
                    r51.Email = "rwood@voyager.net";
                    r51.UserName = "rwood@voyager.net";
                    r51.PhoneNumber = "8433359800";
                    Customers.Add(r51);

                    //loop through repos
                    foreach (AppUser customer in Customers)
                    {
                        //set name of repo to help debug
                        customerName = customer.Email;

                        //see if repo exists in database
                        AppUser dbCustomer = _db.Users.FirstOrDefault(r => r.Email == customer.Email);

                        if (dbCustomer == null) //customer does not exist in database
                        {
                        //_db.Users.Add(customer);
                        //_db.SaveChanges();
                        var result = await _userManager.CreateAsync(customer, customer.Password);
                        if (result.Succeeded == false)
                        {
                            throw new Exception("This user can't be added - " + result.ToString());
                        }
                        _db.SaveChanges();
                        intCustomersAdded += 1;
                        }
                        else
                        {
                            dbCustomer.UserName = customer.Email;
                            dbCustomer.Password = customer.Password;
                            dbCustomer.LastName = customer.LastName;
                            dbCustomer.FirstName = customer.FirstName;
                            dbCustomer.StreetAddress = customer.StreetAddress;
                            dbCustomer.City = customer.City;
                            dbCustomer.State = customer.State;
                            dbCustomer.ZipCode = customer.ZipCode;
                            dbCustomer.Email = customer.Email;
                            dbCustomer.PhoneNumber = customer.PhoneNumber;
                            _db.Update(dbCustomer);
                            _db.SaveChanges();
                        }

                        
                        dbCustomer = _db.Users.FirstOrDefault(u => u.UserName == customer.UserName);

                        if (await _userManager.IsInRoleAsync(dbCustomer, "Customer") == false)
                        {
                            await _userManager.AddToRoleAsync(dbCustomer, "Customer");
                        }
                        _db.SaveChanges();
                    }


                }
                catch
                {
                    String msg = "Customers added:" + intCustomersAdded + "; Error on " + customerName;
                    throw new InvalidOperationException(msg);
                }
            }
        }
    }

