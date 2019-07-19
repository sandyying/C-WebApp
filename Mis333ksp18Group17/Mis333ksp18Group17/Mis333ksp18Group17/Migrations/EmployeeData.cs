using System.Linq;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mis333ksp18Group17.Migrations
{
    public class AddEmployees
    {
        //public static AppDbContext db = new AppDbContext();

        public void SeedEmployees(AppDbContext db)
        {
            //create a user manager and a role manager to use for this method
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));

            //AppUser c0 = new AppUser();
            //c0.Number = 5001;
            //c0.LastName = "Baker";
            //c0.FirstName = "Christopher";
            //c0.MiddleInitial = "L.";
            //c0.Birthday = new System.DateTime(1949, 11, 23);
            //c0.Street = "1245 Lake Anchorage Blvd.";
            //c0.City = "Austin";
            //c0.State = "TX";
            //c0.ZipCode = "78705";
            //c0.SSN = "9075571146";
            //c0.PhoneNumber = "5125550180";
            //c0.PopcornPoints = 110;
            //c0.Email = "cbaker@example.com";
            //c0.UserName = "cbaker@example.com";


            //var result0 = UserManager.Create(c0, "hello1");
            //if (UserManager.IsInRole(c0.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c0.Id, "Customer");
            //}
            //db.SaveChanges();
            //c0 = db.Users.First(u => u.UserName == "cbaker@example.com");


            //AppUser c1 = new AppUser();
            //c1.Number = 5002;
            //c1.LastName = "Banks";
            //c1.FirstName = "Michelle";
            //c1.MiddleInitial = "Nah";
            //c1.Birthday = new System.DateTime(1962, 11, 27);
            //c1.Street = "1300 Tall Pine Lane";
            //c1.City = "Austin";
            //c1.State = "TX";
            //c1.ZipCode = "78712";
            //c1.SSN = "9042678873";
            //c1.PhoneNumber = "5125550183";
            //c1.PopcornPoints = 40;
            //c1.Email = "banker@longhorn.net";
            //c1.UserName = "banker@longhorn.net";


            //var result1 = UserManager.Create(c1, "potato");
            //if (UserManager.IsInRole(c1.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c1.Id, "Customer");
            //}
            //db.SaveChanges();
            //c1 = db.Users.First(u => u.UserName == "banker@longhorn.net");


            //AppUser c2 = new AppUser();
            //c2.Number = 5003;
            //c2.LastName = "Broccolo";
            //c2.FirstName = "Franco";
            //c2.MiddleInitial = "V";
            //c2.Birthday = new System.DateTime(1992, 10, 11);
            //c2.Street = "62 Browning Road";
            //c2.City = "Austin";
            //c2.State = "TX";
            //c2.ZipCode = "78704";
            //c2.SSN = "4155659699";
            //c2.PhoneNumber = "5125550128";
            //c2.PopcornPoints = 30;
            //c2.Email = "franco@example.com";
            //c2.UserName = "franco@example.com";


            //var result2 = UserManager.Create(c2, "painting");
            //if (UserManager.IsInRole(c2.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c2.Id, "Customer");
            //}
            //db.SaveChanges();
            //c2 = db.Users.First(u => u.UserName == "franco@example.com");


            //AppUser c3 = new AppUser();
            //c3.Number = 5004;
            //c3.LastName = "Chang";
            //c3.FirstName = "Wendy";
            //c3.MiddleInitial = "L";
            //c3.Birthday = new System.DateTime(1997, 5, 16);
            //c3.Street = "202 Bellmont Hall";
            //c3.City = "Round Rock";
            //c3.State = "TX";
            //c3.ZipCode = "78681";
            //c3.SSN = "9075943222";
            //c3.PhoneNumber = "5125550133";
            //c3.PopcornPoints = 0;
            //c3.Email = "wchang@example.com";
            //c3.UserName = "wchang@example.com";


            //var result3 = UserManager.Create(c3, "texas1");
            //if (UserManager.IsInRole(c3.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c3.Id, "Customer");
            //}
            //db.SaveChanges();
            //c3 = db.Users.First(u => u.UserName == "wchang@example.com");


            //AppUser c4 = new AppUser();
            //c4.Number = 5005;
            //c4.LastName = "Chou";
            //c4.FirstName = "Lim";
            //c4.MiddleInitial = "Nah";
            //c4.Birthday = new System.DateTime(1970, 4, 6);
            //c4.Street = "1600 Teresa Lane";
            //c4.City = "Austin";
            //c4.State = "TX";
            //c4.ZipCode = "78705";
            //c4.SSN = "8137724599";
            //c4.PhoneNumber = "5125550102";
            //c4.PopcornPoints = 40;
            //c4.Email = "limchou@gogle.com";
            //c4.UserName = "limchou@gogle.com";


            //var result4 = UserManager.Create(c4, "Anchorage");
            //if (UserManager.IsInRole(c4.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c4.Id, "Customer");
            //}
            //db.SaveChanges();
            //c4 = db.Users.First(u => u.UserName == "limchou@gogle.com");


            //AppUser c5 = new AppUser();
            //c5.Number = 5006;
            //c5.LastName = "Dixon";
            //c5.FirstName = "Shan";
            //c5.MiddleInitial = "D";
            //c5.Birthday = new System.DateTime(1984, 1, 12);
            //c5.Street = "234 Holston Circle";
            //c5.City = "Austin";
            //c5.State = "TX";
            //c5.ZipCode = "78712";
            //c5.SSN = "2052643255";
            //c5.PhoneNumber = "5125550146";
            //c5.PopcornPoints = 20;
            //c5.Email = "shdixon@aoll.com";
            //c5.UserName = "shdixon@aoll.com";


            //var result5 = UserManager.Create(c5, "pepperoni");
            //if (UserManager.IsInRole(c5.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c5.Id, "Customer");
            //}
            //db.SaveChanges();
            //c5 = db.Users.First(u => u.UserName == "shdixon@aoll.com");


            //AppUser c6 = new AppUser();
            //c6.Number = 5007;
            //c6.LastName = "Evans";
            //c6.FirstName = "Jim Bob";
            //c6.MiddleInitial = "Nah";
            //c6.Birthday = new System.DateTime(1959, 9, 9);
            //c6.Street = "506 Farrell Circle";
            //c6.City = "Georgetown";
            //c6.State = "TX";
            //c6.ZipCode = "78628";
            //c6.SSN = "2102565834";
            //c6.PhoneNumber = "5125550170";
            //c6.PopcornPoints = 50;
            //c6.Email = "j.b.evans@aheca.org";
            //c6.UserName = "j.b.evans@aheca.org";


            //var result6 = UserManager.Create(c6, "longhorns");
            //if (UserManager.IsInRole(c6.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c6.Id, "Customer");
            //}
            //db.SaveChanges();
            //c6 = db.Users.First(u => u.UserName == "j.b.evans@aheca.org");


            //AppUser c7 = new AppUser();
            //c7.Number = 5008;
            //c7.LastName = "Feeley";
            //c7.FirstName = "Lou Ann";
            //c7.MiddleInitial = "K";
            //c7.Birthday = new System.DateTime(2001, 1, 12);
            //c7.Street = "600 S 8th Street W";
            //c7.City = "Austin";
            //c7.State = "TX";
            //c7.ZipCode = "78746";
            //c7.SSN = "4062556749";
            //c7.PhoneNumber = "5125550105";
            //c7.PopcornPoints = 170;
            //c7.Email = "feeley@penguin.org";
            //c7.UserName = "feeley@penguin.org";


            //var result7 = UserManager.Create(c7, "aggies");
            //if (UserManager.IsInRole(c7.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c7.Id, "Customer");
            //}
            //db.SaveChanges();
            //c7 = db.Users.First(u => u.UserName == "feeley@penguin.org");


            //AppUser c8 = new AppUser();
            //c8.Number = 5009;
            //c8.LastName = "Freeley";
            //c8.FirstName = "Tesa";
            //c8.MiddleInitial = "P";
            //c8.Birthday = new System.DateTime(1991, 2, 4);
            //c8.Street = "4448 Fairview Ave.";
            //c8.City = "Horseshoe Bay";
            //c8.State = "TX";
            //c8.ZipCode = "78657";
            //c8.SSN = "6123255687";
            //c8.PhoneNumber = "5125550114";
            //c8.PopcornPoints = 160;
            //c8.Email = "tfreeley@minnetonka.ci.us";
            //c8.UserName = "tfreeley@minnetonka.ci.us";


            //var result8 = UserManager.Create(c8, "raiders");
            //if (UserManager.IsInRole(c8.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c8.Id, "Customer");
            //}
            //db.SaveChanges();
            //c8 = db.Users.First(u => u.UserName == "tfreeley@minnetonka.ci.us");


            //AppUser c9 = new AppUser();
            //c9.Number = 5010;
            //c9.LastName = "Garcia";
            //c9.FirstName = "Margaret";
            //c9.MiddleInitial = "L";
            //c9.Birthday = new System.DateTime(1991, 10, 2);
            //c9.Street = "594 Longview";
            //c9.City = "Austin";
            //c9.State = "TX";
            //c9.ZipCode = "78727";
            //c9.SSN = "4066593544";
            //c9.PhoneNumber = "5125550155";
            //c9.PopcornPoints = 10;
            //c9.Email = "mgarcia@gogle.com";
            //c9.UserName = "mgarcia@gogle.com";


            //var result9 = UserManager.Create(c9, "mustangs");
            //if (UserManager.IsInRole(c9.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c9.Id, "Customer");
            //}
            //db.SaveChanges();
            //c9 = db.Users.First(u => u.UserName == "mgarcia@gogle.com");


            //AppUser c10 = new AppUser();
            //c10.Number = 5011;
            //c10.LastName = "Haley";
            //c10.FirstName = "Charles";
            //c10.MiddleInitial = "E";
            //c10.Birthday = new System.DateTime(1974, 7, 10);
            //c10.Street = "One Cowboy Pkwy";
            //c10.City = "Austin";
            //c10.State = "TX";
            //c10.ZipCode = "78712";
            //c10.SSN = "2148475583";
            //c10.PhoneNumber = "5125550116";
            //c10.PopcornPoints = 40;
            //c10.Email = "chaley@thug.com";
            //c10.UserName = "chaley@thug.com";


            //var result10 = UserManager.Create(c10, "onetime");
            //if (UserManager.IsInRole(c10.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c10.Id, "Customer");
            //}
            //db.SaveChanges();
            //c10 = db.Users.First(u => u.UserName == "chaley@thug.com");


            //AppUser c11 = new AppUser();
            //c11.Number = 5012;
            //c11.LastName = "Hampton";
            //c11.FirstName = "Jeffrey";
            //c11.MiddleInitial = "T.";
            //c11.Birthday = new System.DateTime(2004, 3, 10);
            //c11.Street = "337 38th St.";
            //c11.City = "San Marcos";
            //c11.State = "TX";
            //c11.ZipCode = "78666";
            //c11.SSN = "9076978613";
            //c11.PhoneNumber = "5125550150";
            //c11.PopcornPoints = 150;
            //c11.Email = "jeffh@sonic.com";
            //c11.UserName = "jeffh@sonic.com";


            //var result11 = UserManager.Create(c11, "hampton1");
            //if (UserManager.IsInRole(c11.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c11.Id, "Customer");
            //}
            //db.SaveChanges();
            //c11 = db.Users.First(u => u.UserName == "jeffh@sonic.com");


            //AppUser c12 = new AppUser();
            //c12.Number = 5013;
            //c12.LastName = "Hearn";
            //c12.FirstName = "John";
            //c12.MiddleInitial = "B";
            //c12.Birthday = new System.DateTime(1950, 8, 5);
            //c12.Street = "4225 North First";
            //c12.City = "Austin";
            //c12.State = "TX";
            //c12.ZipCode = "78705";
            //c12.SSN = "5208965621";
            //c12.PhoneNumber = "5125550196";
            //c12.PopcornPoints = 0;
            //c12.Email = "wjhearniii@umich.org";
            //c12.UserName = "wjhearniii@umich.org";


            //var result12 = UserManager.Create(c12, "jhearn22");
            //if (UserManager.IsInRole(c12.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c12.Id, "Customer");
            //}
            //db.SaveChanges();
            //c12 = db.Users.First(u => u.UserName == "wjhearniii@umich.org");


            //AppUser c13 = new AppUser();
            //c13.Number = 5014;
            //c13.LastName = "Hicks";
            //c13.FirstName = "Anthony";
            //c13.MiddleInitial = "J";
            //c13.Birthday = new System.DateTime(2004, 12, 8);
            //c13.Street = "32 NE Garden Ln., Ste 910";
            //c13.City = "Austin";
            //c13.State = "TX";
            //c13.ZipCode = "78712";
            //c13.SSN = "7355788965";
            //c13.PhoneNumber = "5125550188";
            //c13.PopcornPoints = 60;
            //c13.Email = "ahick@yaho.com";
            //c13.UserName = "ahick@yaho.com";


            //var result13 = UserManager.Create(c13, "hickhickup");
            //if (UserManager.IsInRole(c13.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c13.Id, "Customer");
            //}
            //db.SaveChanges();
            //c13 = db.Users.First(u => u.UserName == "ahick@yaho.com");


            //AppUser c14 = new AppUser();
            //c14.Number = 5015;
            //c14.LastName = "Ingram";
            //c14.FirstName = "Brad";
            //c14.MiddleInitial = "S.";
            //c14.Birthday = new System.DateTime(2001, 9, 5);
            //c14.Street = "6548 La Posada Ct.";
            //c14.City = "New York";
            //c14.State = "NY";
            //c14.ZipCode = "10101";
            //c14.SSN = "9074678821";
            //c14.PhoneNumber = "5125550116";
            //c14.PopcornPoints = 20;
            //c14.Email = "ingram@jack.com";
            //c14.UserName = "ingram@jack.com";


            //var result14 = UserManager.Create(c14, "ingram2015");
            //if (UserManager.IsInRole(c14.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c14.Id, "Customer");
            //}
            //db.SaveChanges();
            //c14 = db.Users.First(u => u.UserName == "ingram@jack.com");


            //AppUser c15 = new AppUser();
            //c15.Number = 5016;
            //c15.LastName = "Jacobs";
            //c15.FirstName = "Todd";
            //c15.MiddleInitial = "L.";
            //c15.Birthday = new System.DateTime(1999, 1, 20);
            //c15.Street = "4564 Elm St.";
            //c15.City = "Austin";
            //c15.State = "TX";
            //c15.ZipCode = "78729";
            //c15.SSN = "9074653365";
            //c15.PhoneNumber = "5125550166";
            //c15.PopcornPoints = 170;
            //c15.Email = "toddj@yourmom.com";
            //c15.UserName = "toddj@yourmom.com";


            //var result15 = UserManager.Create(c15, "toddy25");
            //if (UserManager.IsInRole(c15.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c15.Id, "Customer");
            //}
            //db.SaveChanges();
            //c15 = db.Users.First(u => u.UserName == "toddj@yourmom.com");


            //AppUser c16 = new AppUser();
            //c16.Number = 5017;
            //c16.LastName = "Lawrence";
            //c16.FirstName = "Victoria";
            //c16.MiddleInitial = "M.";
            //c16.Birthday = new System.DateTime(2000, 4, 14);
            //c16.Street = "6639 Butterfly Ln.";
            //c16.City = "Beverly Hills";
            //c16.State = "CA";
            //c16.ZipCode = "90210";
            //c16.SSN = "9079457399";
            //c16.PhoneNumber = "5125550173";
            //c16.PopcornPoints = 130;
            //c16.Email = "thequeen@aska.net";
            //c16.UserName = "thequeen@aska.net";


            //var result16 = UserManager.Create(c16, "something");
            //if (UserManager.IsInRole(c16.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c16.Id, "Customer");
            //}
            //db.SaveChanges();
            //c16 = db.Users.First(u => u.UserName == "thequeen@aska.net");


            //AppUser c17 = new AppUser();
            //c17.Number = 5018;
            //c17.LastName = "Lineback";
            //c17.FirstName = "Erik";
            //c17.MiddleInitial = "W";
            //c17.Birthday = new System.DateTime(2003, 12, 2);
            //c17.Street = "1300 Netherland St";
            //c17.City = "Austin";
            //c17.State = "TX";
            //c17.ZipCode = "78758";
            //c17.SSN = "3032449976";
            //c17.PhoneNumber = "5125550167";
            //c17.PopcornPoints = 60;
            //c17.Email = "linebacker@gogle.com";
            //c17.UserName = "linebacker@gogle.com";


            //var result17 = UserManager.Create(c17, "Password1");
            //if (UserManager.IsInRole(c17.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c17.Id, "Customer");
            //}
            //db.SaveChanges();
            //c17 = db.Users.First(u => u.UserName == "linebacker@gogle.com");


            //AppUser c18 = new AppUser();
            //c18.Number = 5019;
            //c18.LastName = "Lowe";
            //c18.FirstName = "Ernest";
            //c18.MiddleInitial = "S";
            //c18.Birthday = new System.DateTime(1977, 12, 7);
            //c18.Street = "3201 Pine Drive";
            //c18.City = "New Braunfels";
            //c18.State = "TX";
            //c18.ZipCode = "78130";
            //c18.SSN = "7135344627";
            //c18.PhoneNumber = "5125550187";
            //c18.PopcornPoints = 20;
            //c18.Email = "elowe@netscare.net";
            //c18.UserName = "elowe@netscare.net";


            //var result18 = UserManager.Create(c18, "aclfest2017");
            //if (UserManager.IsInRole(c18.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c18.Id, "Customer");
            //}
            //db.SaveChanges();
            //c18 = db.Users.First(u => u.UserName == "elowe@netscare.net");


            //AppUser c19 = new AppUser();
            //c19.Number = 5020;
            //c19.LastName = "Luce";
            //c19.FirstName = "Chuck";
            //c19.MiddleInitial = "B";
            //c19.Birthday = new System.DateTime(1949, 3, 16);
            //c19.Street = "2345 Rolling Clouds";
            //c19.City = "Cactus";
            //c19.State = "TX";
            //c19.ZipCode = "79013";
            //c19.SSN = "9546983548";
            //c19.PhoneNumber = "5125550141";
            //c19.PopcornPoints = 180;
            //c19.Email = "cluce@gogle.com";
            //c19.UserName = "cluce@gogle.com";


            //var result19 = UserManager.Create(c19, "nothinggood");
            //if (UserManager.IsInRole(c19.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c19.Id, "Customer");
            //}
            //db.SaveChanges();
            //c19 = db.Users.First(u => u.UserName == "cluce@gogle.com");


            //AppUser c20 = new AppUser();
            //c20.Number = 5021;
            //c20.LastName = "MacLeod";
            //c20.FirstName = "Jennifer";
            //c20.MiddleInitial = "D.";
            //c20.Birthday = new System.DateTime(1947, 2, 21);
            //c20.Street = "2504 Far West Blvd.";
            //c20.City = "Marble Falls";
            //c20.State = "TX";
            //c20.ZipCode = "78654";
            //c20.SSN = "9074748138";
            //c20.PhoneNumber = "5125550185";
            //c20.PopcornPoints = 170;
            //c20.Email = "mackcloud@george.com";
            //c20.UserName = "mackcloud@george.com";


            //var result20 = UserManager.Create(c20, "whatever");
            //if (UserManager.IsInRole(c20.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c20.Id, "Customer");
            //}
            //db.SaveChanges();
            //c20 = db.Users.First(u => u.UserName == "mackcloud@george.com");


            //AppUser c21 = new AppUser();
            //c21.Number = 5022;
            //c21.LastName = "Markham";
            //c21.FirstName = "Elizabeth";
            //c21.MiddleInitial = "P.";
            //c21.Birthday = new System.DateTime(1972, 3, 20);
            //c21.Street = "7861 Chevy Chase";
            //c21.City = "Kissimmee";
            //c21.State = "FL";
            //c21.ZipCode = "34741";
            //c21.SSN = "9074579845";
            //c21.PhoneNumber = "5125550134";
            //c21.PopcornPoints = 100;
            //c21.Email = "cmartin@beets.com";
            //c21.UserName = "cmartin@beets.com";


            //var result21 = UserManager.Create(c21, "whocares");
            //if (UserManager.IsInRole(c21.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c21.Id, "Customer");
            //}
            //db.SaveChanges();
            //c21 = db.Users.First(u => u.UserName == "cmartin@beets.com");


            //AppUser c22 = new AppUser();
            //c22.Number = 5023;
            //c22.LastName = "Martin";
            //c22.FirstName = "Clarence";
            //c22.MiddleInitial = "A";
            //c22.Birthday = new System.DateTime(1992, 7, 19);
            //c22.Street = "87 Alcedo St.";
            //c22.City = "Austin";
            //c22.State = "TX";
            //c22.ZipCode = "78709";
            //c22.SSN = "9204955201";
            //c22.PhoneNumber = "5125550151";
            //c22.PopcornPoints = 130;
            //c22.Email = "clarence@yoho.com";
            //c22.UserName = "clarence@yoho.com";


            //var result22 = UserManager.Create(c22, "xcellent");
            //if (UserManager.IsInRole(c22.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c22.Id, "Customer");
            //}
            //db.SaveChanges();
            //c22 = db.Users.First(u => u.UserName == "clarence@yoho.com");


            //AppUser c23 = new AppUser();
            //c23.Number = 5024;
            //c23.LastName = "Martinez";
            //c23.FirstName = "Gregory";
            //c23.MiddleInitial = "R.";
            //c23.Birthday = new System.DateTime(1947, 5, 28);
            //c23.Street = "8295 Sunset Blvd.";
            //c23.City = "Red Rock";
            //c23.State = "TX";
            //c23.ZipCode = "78662";
            //c23.SSN = "9078746718";
            //c23.PhoneNumber = "5125550120";
            //c23.PopcornPoints = 20;
            //c23.Email = "gregmartinez@drdre.com";
            //c23.UserName = "gregmartinez@drdre.com";


            //var result23 = UserManager.Create(c23, "snowsnow");
            //if (UserManager.IsInRole(c23.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c23.Id, "Customer");
            //}
            //db.SaveChanges();
            //c23 = db.Users.First(u => u.UserName == "gregmartinez@drdre.com");


            //AppUser c24 = new AppUser();
            //c24.Number = 5025;
            //c24.LastName = "Miller";
            //c24.FirstName = "Charles";
            //c24.MiddleInitial = "R.";
            //c24.Birthday = new System.DateTime(1990, 10, 15);
            //c24.Street = "8962 Main St.";
            //c24.City = "South Padre Island";
            //c24.State = "TX";
            //c24.ZipCode = "78597";
            //c24.SSN = "9077458615";
            //c24.PhoneNumber = "5125550198";
            //c24.PopcornPoints = 20;
            //c24.Email = "cmiller@bob.com";
            //c24.UserName = "cmiller@bob.com";


            //var result24 = UserManager.Create(c24, "mydogspot");
            //if (UserManager.IsInRole(c24.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c24.Id, "Customer");
            //}
            //db.SaveChanges();
            //c24 = db.Users.First(u => u.UserName == "cmiller@bob.com");


            //AppUser c25 = new AppUser();
            //c25.Number = 5026;
            //c25.LastName = "Nelson";
            //c25.FirstName = "Kelly";
            //c25.MiddleInitial = "T";
            //c25.Birthday = new System.DateTime(1971, 7, 13);
            //c25.Street = "2601 Red River";
            //c25.City = "Disney";
            //c25.State = "OK";
            //c25.ZipCode = "74340";
            //c25.SSN = "9072926966";
            //c25.PhoneNumber = "5125550177";
            //c25.PopcornPoints = 110;
            //c25.Email = "knelson@aoll.com";
            //c25.UserName = "knelson@aoll.com";


            //var result25 = UserManager.Create(c25, "spotmydog");
            //if (UserManager.IsInRole(c25.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c25.Id, "Customer");
            //}
            //db.SaveChanges();
            //c25 = db.Users.First(u => u.UserName == "knelson@aoll.com");


            //AppUser c26 = new AppUser();
            //c26.Number = 5027;
            //c26.LastName = "Nguyen";
            //c26.FirstName = "Joe";
            //c26.MiddleInitial = "C";
            //c26.Birthday = new System.DateTime(1984, 3, 17);
            //c26.Street = "1249 4th SW St.";
            //c26.City = "Del Rio";
            //c26.State = "TX";
            //c26.ZipCode = "78841";
            //c26.SSN = "2023125897";
            //c26.PhoneNumber = "5125550174";
            //c26.PopcornPoints = 150;
            //c26.Email = "joewin@xfactor.com";
            //c26.UserName = "joewin@xfactor.com";


            //var result26 = UserManager.Create(c26, "joejoejoe");
            //if (UserManager.IsInRole(c26.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c26.Id, "Customer");
            //}
            //db.SaveChanges();
            //c26 = db.Users.First(u => u.UserName == "joewin@xfactor.com");


            //AppUser c27 = new AppUser();
            //c27.Number = 5028;
            //c27.LastName = "O'Reilly";
            //c27.FirstName = "Bill";
            //c27.MiddleInitial = "T";
            //c27.Birthday = new System.DateTime(1959, 7, 8);
            //c27.Street = "8800 Gringo Drive";
            //c27.City = "Austin";
            //c27.State = "TX";
            //c27.ZipCode = "78746";
            //c27.SSN = "3173450925";
            //c27.PhoneNumber = "5125550167";
            //c27.PopcornPoints = 190;
            //c27.Email = "orielly@foxnews.cnn";
            //c27.UserName = "orielly@foxnews.cnn";


            //var result27 = UserManager.Create(c27, "billyboy");
            //if (UserManager.IsInRole(c27.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c27.Id, "Customer");
            //}
            //db.SaveChanges();
            //c27 = db.Users.First(u => u.UserName == "orielly@foxnews.cnn");


            //AppUser c28 = new AppUser();
            //c28.Number = 5029;
            //c28.LastName = "Radkovich";
            //c28.FirstName = "Anka";
            //c28.MiddleInitial = "L";
            //c28.Birthday = new System.DateTime(1966, 5, 19);
            //c28.Street = "1300 Elliott Pl";
            //c28.City = "Austin";
            //c28.State = "TX";
            //c28.ZipCode = "78712";
            //c28.SSN = "3022345566";
            //c28.PhoneNumber = "5125550151";
            //c28.PopcornPoints = 120;
            //c28.Email = "ankaisrad@gogle.com";
            //c28.UserName = "ankaisrad@gogle.com";


            //var result28 = UserManager.Create(c28, "radgirl");
            //if (UserManager.IsInRole(c28.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c28.Id, "Customer");
            //}
            //db.SaveChanges();
            //c28 = db.Users.First(u => u.UserName == "ankaisrad@gogle.com");


            //AppUser c29 = new AppUser();
            //c29.Number = 5030;
            //c29.LastName = "Rhodes";
            //c29.FirstName = "Megan";
            //c29.MiddleInitial = "C.";
            //c29.Birthday = new System.DateTime(1965, 3, 12);
            //c29.Street = "4587 Enfield Rd.";
            //c29.City = "Austin";
            //c29.State = "TX";
            //c29.ZipCode = "78705";
            //c29.SSN = "9073744746";
            //c29.PhoneNumber = "5125550133";
            //c29.PopcornPoints = 190;
            //c29.Email = "megrhodes@freserve.co.uk";
            //c29.UserName = "megrhodes@freserve.co.uk";


            //var result29 = UserManager.Create(c29, "meganr34");
            //if (UserManager.IsInRole(c29.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c29.Id, "Customer");
            //}
            //db.SaveChanges();
            //c29 = db.Users.First(u => u.UserName == "megrhodes@freserve.co.uk");


            //AppUser c30 = new AppUser();
            //c30.Number = 5031;
            //c30.LastName = "Rice";
            //c30.FirstName = "Eryn";
            //c30.MiddleInitial = "M.";
            //c30.Birthday = new System.DateTime(1975, 4, 28);
            //c30.Street = "3405 Rio Grande";
            //c30.City = "Austin";
            //c30.State = "TX";
            //c30.ZipCode = "78785";
            //c30.SSN = "9073876657";
            //c30.PhoneNumber = "5125550196";
            //c30.PopcornPoints = 190;
            //c30.Email = "erynrice@aoll.com";
            //c30.UserName = "erynrice@aoll.com";


            //var result30 = UserManager.Create(c30, "ricearoni");
            //if (UserManager.IsInRole(c30.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c30.Id, "Customer");
            //}
            //db.SaveChanges();
            //c30 = db.Users.First(u => u.UserName == "erynrice@aoll.com");


            //AppUser c31 = new AppUser();
            //c31.Number = 5032;
            //c31.LastName = "Rodriguez";
            //c31.FirstName = "Jorge";
            //c31.MiddleInitial = "Nah";
            //c31.Birthday = new System.DateTime(1953, 12, 8);
            //c31.Street = "6788 Cotter Street";
            //c31.City = "Littlefield";
            //c31.State = "TX";
            //c31.ZipCode = "79339";
            //c31.SSN = "4158904374";
            //c31.PhoneNumber = "5125550141";
            //c31.PopcornPoints = 20;
            //c31.Email = "jorge@noclue.com";
            //c31.UserName = "jorge@noclue.com";


            //var result31 = UserManager.Create(c31, "jrod2017");
            //if (UserManager.IsInRole(c31.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c31.Id, "Customer");
            //}
            //db.SaveChanges();
            //c31 = db.Users.First(u => u.UserName == "jorge@noclue.com");


            //AppUser c32 = new AppUser();
            //c32.Number = 5033;
            //c32.LastName = "Rogers";
            //c32.FirstName = "Allen";
            //c32.MiddleInitial = "B.";
            //c32.Birthday = new System.DateTime(1973, 4, 22);
            //c32.Street = "4965 Oak Hill";
            //c32.City = "Austin";
            //c32.State = "TX";
            //c32.ZipCode = "78733";
            //c32.SSN = "9078752943";
            //c32.PhoneNumber = "5125550189";
            //c32.PopcornPoints = 100;
            //c32.Email = "mrrogers@lovelyday.com";
            //c32.UserName = "mrrogers@lovelyday.com";


            //var result32 = UserManager.Create(c32, "rogerthat");
            //if (UserManager.IsInRole(c32.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c32.Id, "Customer");
            //}
            //db.SaveChanges();
            //c32 = db.Users.First(u => u.UserName == "mrrogers@lovelyday.com");


            //AppUser c33 = new AppUser();
            //c33.Number = 5034;
            //c33.LastName = "Saint-Jean";
            //c33.FirstName = "Olivier";
            //c33.MiddleInitial = "M";
            //c33.Birthday = new System.DateTime(1995, 2, 19);
            //c33.Street = "255 Toncray Dr.";
            //c33.City = "Austin";
            //c33.State = "TX";
            //c33.ZipCode = "78755";
            //c33.SSN = "3434145678";
            //c33.PhoneNumber = "5125550152";
            //c33.PopcornPoints = 250;
            //c33.Email = "stjean@athome.com";
            //c33.UserName = "stjean@athome.com";


            //var result33 = UserManager.Create(c33, "bunnyhop");
            //if (UserManager.IsInRole(c33.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c33.Id, "Customer");
            //}
            //db.SaveChanges();
            //c33 = db.Users.First(u => u.UserName == "stjean@athome.com");


            //AppUser c34 = new AppUser();
            //c34.Number = 5035;
            //c34.LastName = "Saunders";
            //c34.FirstName = "Sarah";
            //c34.MiddleInitial = "J.";
            //c34.Birthday = new System.DateTime(1978, 2, 19);
            //c34.Street = "332 Avenue C";
            //c34.City = "Austin";
            //c34.State = "TX";
            //c34.ZipCode = "78701";
            //c34.SSN = "9073497810";
            //c34.PhoneNumber = "5125550146";
            //c34.PopcornPoints = 40;
            //c34.Email = "saunders@pen.com";
            //c34.UserName = "saunders@pen.com";


            //var result34 = UserManager.Create(c34, "penguin12");
            //if (UserManager.IsInRole(c34.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c34.Id, "Customer");
            //}
            //db.SaveChanges();
            //c34 = db.Users.First(u => u.UserName == "saunders@pen.com");


            //AppUser c35 = new AppUser();
            //c35.Number = 5036;
            //c35.LastName = "Sewell";
            //c35.FirstName = "William";
            //c35.MiddleInitial = "T.";
            //c35.Birthday = new System.DateTime(2004, 12, 23);
            //c35.Street = "2365 51st St.";
            //c35.City = "El Paso";
            //c35.State = "TX";
            //c35.ZipCode = "79953";
            //c35.SSN = "9074510084";
            //c35.PhoneNumber = "5125550192";
            //c35.PopcornPoints = 200;
            //c35.Email = "willsheff@email.com";
            //c35.UserName = "willsheff@email.com";


            //var result35 = UserManager.Create(c35, "alaskaboy");
            //if (UserManager.IsInRole(c35.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c35.Id, "Customer");
            //}
            //db.SaveChanges();
            //c35 = db.Users.First(u => u.UserName == "willsheff@email.com");


            //AppUser c36 = new AppUser();
            //c36.Number = 5037;
            //c36.LastName = "Sheffield";
            //c36.FirstName = "Martin";
            //c36.MiddleInitial = "J.";
            //c36.Birthday = new System.DateTime(1960, 5, 8);
            //c36.Street = "3886 Avenue A";
            //c36.City = "Balmorhea";
            //c36.State = "TX";
            //c36.ZipCode = "79718";
            //c36.SSN = "9075479167";
            //c36.PhoneNumber = "5125550131";
            //c36.PopcornPoints = 130;
            //c36.Email = "sheffiled@gogle.com";
            //c36.UserName = "sheffiled@gogle.com";


            //var result36 = UserManager.Create(c36, "martin1234");
            //if (UserManager.IsInRole(c36.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c36.Id, "Customer");
            //}
            //db.SaveChanges();
            //c36 = db.Users.First(u => u.UserName == "sheffiled@gogle.com");


            //AppUser c37 = new AppUser();
            //c37.Number = 5038;
            //c37.LastName = "Smith";
            //c37.FirstName = "John";
            //c37.MiddleInitial = "A";
            //c37.Birthday = new System.DateTime(1955, 6, 25);
            //c37.Street = "23 Hidden Forge Dr.";
            //c37.City = "Austin";
            //c37.State = "TX";
            //c37.ZipCode = "78760";
            //c37.SSN = "2838321888";
            //c37.PhoneNumber = "5125550190";
            //c37.PopcornPoints = 130;
            //c37.Email = "johnsmith187@aoll.com";
            //c37.UserName = "johnsmith187@aoll.com";


            //var result37 = UserManager.Create(c37, "smitty444");
            //if (UserManager.IsInRole(c37.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c37.Id, "Customer");
            //}
            //db.SaveChanges();
            //c37 = db.Users.First(u => u.UserName == "johnsmith187@aoll.com");


            //AppUser c38 = new AppUser();
            //c38.Number = 5039;
            //c38.LastName = "Stroud";
            //c38.FirstName = "Dustin";
            //c38.MiddleInitial = "P";
            //c38.Birthday = new System.DateTime(1967, 7, 26);
            //c38.Street = "1212 Rita Rd";
            //c38.City = "Austin";
            //c38.State = "TX";
            //c38.ZipCode = "78734";
            //c38.SSN = "2172346667";
            //c38.PhoneNumber = "5125550157";
            //c38.PopcornPoints = 90;
            //c38.Email = "dustroud@mail.com";
            //c38.UserName = "dustroud@mail.com";


            //var result38 = UserManager.Create(c38, "dustydusty");
            //if (UserManager.IsInRole(c38.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c38.Id, "Customer");
            //}
            //db.SaveChanges();
            //c38 = db.Users.First(u => u.UserName == "dustroud@mail.com");


            //AppUser c39 = new AppUser();
            //c39.Number = 5040;
            //c39.LastName = "Stuart";
            //c39.FirstName = "Eric";
            //c39.MiddleInitial = "D.";
            //c39.Birthday = new System.DateTime(1947, 12, 4);
            //c39.Street = "5576 Toro Ring";
            //c39.City = "Kyle";
            //c39.State = "TX";
            //c39.ZipCode = "78640";
            //c39.SSN = "9078178335";
            //c39.PhoneNumber = "5125550191";
            //c39.PopcornPoints = 170;
            //c39.Email = "estuart@anchor.net";
            //c39.UserName = "estuart@anchor.net";


            //var result39 = UserManager.Create(c39, "stewball");
            //if (UserManager.IsInRole(c39.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c39.Id, "Customer");
            //}
            //db.SaveChanges();
            //c39 = db.Users.First(u => u.UserName == "estuart@anchor.net");


            //AppUser c40 = new AppUser();
            //c40.Number = 5041;
            //c40.LastName = "Stump";
            //c40.FirstName = "Peter";
            //c40.MiddleInitial = "L";
            //c40.Birthday = new System.DateTime(1974, 7, 10);
            //c40.Street = "1300 Kellen Circle";
            //c40.City = "Philadelphia";
            //c40.State = "PA";
            //c40.ZipCode = "19123";
            //c40.SSN = "2084560903";
            //c40.PhoneNumber = "5125550136";
            //c40.PopcornPoints = 50;
            //c40.Email = "peterstump@noclue.com";
            //c40.UserName = "peterstump@noclue.com";


            //var result40 = UserManager.Create(c40, "slowwind");
            //if (UserManager.IsInRole(c40.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c40.Id, "Customer");
            //}
            //db.SaveChanges();
            //c40 = db.Users.First(u => u.UserName == "peterstump@noclue.com");


            //AppUser c41 = new AppUser();
            //c41.Number = 5042;
            //c41.LastName = "Tanner";
            //c41.FirstName = "Jeremy";
            //c41.MiddleInitial = "S.";
            //c41.Birthday = new System.DateTime(1944, 1, 11);
            //c41.Street = "4347 Almstead";
            //c41.City = "Austin";
            //c41.State = "TX";
            //c41.ZipCode = "78747";
            //c41.SSN = "9074590929";
            //c41.PhoneNumber = "5125550170";
            //c41.PopcornPoints = 190;
            //c41.Email = "jtanner@mustang.net";
            //c41.UserName = "jtanner@mustang.net";


            //var result41 = UserManager.Create(c41, "tanner5454");
            //if (UserManager.IsInRole(c41.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c41.Id, "Customer");
            //}
            //db.SaveChanges();
            //c41 = db.Users.First(u => u.UserName == "jtanner@mustang.net");


            //AppUser c42 = new AppUser();
            //c42.Number = 5043;
            //c42.LastName = "Taylor";
            //c42.FirstName = "Allison";
            //c42.MiddleInitial = "R.";
            //c42.Birthday = new System.DateTime(1990, 11, 14);
            //c42.Street = "467 Nueces St.";
            //c42.City = "Austin";
            //c42.State = "TX";
            //c42.ZipCode = "78712";
            //c42.SSN = "9074748452";
            //c42.PhoneNumber = "5125550160";
            //c42.PopcornPoints = 110;
            //c42.Email = "taylordjay@aoll.com";
            //c42.UserName = "taylordjay@aoll.com";


            //var result42 = UserManager.Create(c42, "allyrally");
            //if (UserManager.IsInRole(c42.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c42.Id, "Customer");
            //}
            //db.SaveChanges();
            //c42 = db.Users.First(u => u.UserName == "taylordjay@aoll.com");


            //AppUser c43 = new AppUser();
            //c43.Number = 5044;
            //c43.LastName = "Taylor";
            //c43.FirstName = "Rachel";
            //c43.MiddleInitial = "K.";
            //c43.Birthday = new System.DateTime(1976, 1, 18);
            //c43.Street = "345 Longview Dr.";
            //c43.City = "Austin";
            //c43.State = "TX";
            //c43.ZipCode = "78758";
            //c43.SSN = "9074907631";
            //c43.PhoneNumber = "5125550127";
            //c43.PopcornPoints = 160;
            //c43.Email = "rtaylor@gogle.com";
            //c43.UserName = "rtaylor@gogle.com";


            //var result43 = UserManager.Create(c43, "taylorbaylor");
            //if (UserManager.IsInRole(c43.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c43.Id, "Customer");
            //}
            //db.SaveChanges();
            //c43 = db.Users.First(u => u.UserName == "rtaylor@gogle.com");


            //AppUser c44 = new AppUser();
            //c44.Number = 5045;
            //c44.LastName = "Tee";
            //c44.FirstName = "Frank";
            //c44.MiddleInitial = "J";
            //c44.Birthday = new System.DateTime(1998, 9, 6);
            //c44.Street = "5590 Lavell Dr";
            //c44.City = "Austin";
            //c44.State = "TX";
            //c44.ZipCode = "78729";
            //c44.SSN = "2138765543";
            //c44.PhoneNumber = "5125550161";
            //c44.PopcornPoints = 70;
            //c44.Email = "teefrank@noclue.com";
            //c44.UserName = "teefrank@noclue.com";


            //var result44 = UserManager.Create(c44, "teeoff22");
            //if (UserManager.IsInRole(c44.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c44.Id, "Customer");
            //}
            //db.SaveChanges();
            //c44 = db.Users.First(u => u.UserName == "teefrank@noclue.com");


            //AppUser c45 = new AppUser();
            //c45.Number = 5046;
            //c45.LastName = "Tucker";
            //c45.FirstName = "Clent";
            //c45.MiddleInitial = "J";
            //c45.Birthday = new System.DateTime(1943, 2, 25);
            //c45.Street = "312 Main St.";
            //c45.City = "Round Rock";
            //c45.State = "TX";
            //c45.ZipCode = "78665";
            //c45.SSN = "9038471154";
            //c45.PhoneNumber = "5125550106";
            //c45.PopcornPoints = 150;
            //c45.Email = "ctucker@alphabet.co.uk";
            //c45.UserName = "ctucker@alphabet.co.uk";


            //var result45 = UserManager.Create(c45, "tucksack1");
            //if (UserManager.IsInRole(c45.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c45.Id, "Customer");
            //}
            //db.SaveChanges();
            //c45 = db.Users.First(u => u.UserName == "ctucker@alphabet.co.uk");


            //AppUser c46 = new AppUser();
            //c46.Number = 5047;
            //c46.LastName = "Velasco";
            //c46.FirstName = "Allen";
            //c46.MiddleInitial = "G";
            //c46.Birthday = new System.DateTime(1985, 9, 10);
            //c46.Street = "679 W. 4th";
            //c46.City = "Cedar Park";
            //c46.State = "TX";
            //c46.ZipCode = "78613";
            //c46.SSN = "3103985638";
            //c46.PhoneNumber = "5125550170";
            //c46.PopcornPoints = 0;
            //c46.Email = "avelasco@yoho.com";
            //c46.UserName = "avelasco@yoho.com";


            //var result46 = UserManager.Create(c46, "meow88");
            //if (UserManager.IsInRole(c46.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c46.Id, "Customer");
            //}
            //db.SaveChanges();
            //c46 = db.Users.First(u => u.UserName == "avelasco@yoho.com");


            //AppUser c47 = new AppUser();
            //c47.Number = 5048;
            //c47.LastName = "Vino";
            //c47.FirstName = "Janet";
            //c47.MiddleInitial = "E";
            //c47.Birthday = new System.DateTime(1985, 2, 7);
            //c47.Street = "189 Grape Road";
            //c47.City = "Lockhart";
            //c47.State = "TX";
            //c47.ZipCode = "78644";
            //c47.SSN = "8175643832";
            //c47.PhoneNumber = "5125550128";
            //c47.PopcornPoints = 160;
            //c47.Email = "vinovino@grapes.com";
            //c47.UserName = "vinovino@grapes.com";


            //var result47 = UserManager.Create(c47, "vinovino");
            //if (UserManager.IsInRole(c47.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c47.Id, "Customer");
            //}
            //db.SaveChanges();
            //c47 = db.Users.First(u => u.UserName == "vinovino@grapes.com");


            //AppUser c48 = new AppUser();
            //c48.Number = 5049;
            //c48.LastName = "West";
            //c48.FirstName = "Jake";
            //c48.MiddleInitial = "T";
            //c48.Birthday = new System.DateTime(1976, 1, 9);
            //c48.Street = "RR 3287";
            //c48.City = "Austin";
            //c48.State = "TX";
            //c48.ZipCode = "78705";
            //c48.SSN = "5938475244";
            //c48.PhoneNumber = "2025550170";
            //c48.PopcornPoints = 70;
            //c48.Email = "westj@pioneer.net";
            //c48.UserName = "westj@pioneer.net";


            //var result48 = UserManager.Create(c48, "gowest");
            //if (UserManager.IsInRole(c48.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c48.Id, "Customer");
            //}
            //db.SaveChanges();
            //c48 = db.Users.First(u => u.UserName == "westj@pioneer.net");


            //AppUser c49 = new AppUser();
            //c49.Number = 5050;
            //c49.LastName = "Winthorpe";
            //c49.FirstName = "Louis";
            //c49.MiddleInitial = "L";
            //c49.Birthday = new System.DateTime(1953, 4, 19);
            //c49.Street = "2500 Padre Blvd";
            //c49.City = "Austin";
            //c49.State = "TX";
            //c49.ZipCode = "78747";
            //c49.SSN = "2105650098";
            //c49.PhoneNumber = "2025550141";
            //c49.PopcornPoints = 150;
            //c49.Email = "winner@hootmail.com";
            //c49.UserName = "winner@hootmail.com";


            //var result49 = UserManager.Create(c49, "louielouie");
            //if (UserManager.IsInRole(c49.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c49.Id, "Customer");
            //}
            //db.SaveChanges();
            //c49 = db.Users.First(u => u.UserName == "winner@hootmail.com");


            //AppUser c50 = new AppUser();
            //c50.Number = 5051;
            //c50.LastName = "Wood";
            //c50.FirstName = "Reagan";
            //c50.MiddleInitial = "B.";
            //c50.Birthday = new System.DateTime(2002, 12, 28);
            //c50.Street = "447 Westlake Dr.";
            //c50.City = "Austin";
            //c50.State = "TX";
            //c50.ZipCode = "78753";
            //c50.SSN = "9074545242";
            //c50.PhoneNumber = "2025550128";
            //c50.PopcornPoints = 20;
            //c50.Email = "rwood@voyager.net";
            //c50.UserName = "rwood@voyager.net";


            //var result50 = UserManager.Create(c50, "woodyman1");
            //if (UserManager.IsInRole(c50.Id, "Customer") == false)
            //{
            //    UserManager.AddToRole(c50.Id, "Customer");
            //}
            //db.SaveChanges();
            //c50 = db.Users.First(u => u.UserName == "rwood@voyager.net");

            AppUser e0 = new AppUser();
            e0.LastName = "Jacobs";
            e0.FirstName = "Todd";
            e0.MiddleInitial = "L";
            e0.SSN = "341553365";
            e0.Birthday = new System.DateTime(1958, 4, 25);
            e0.Type = Type.Employee;
            e0.Street = "4564 Elm St.";
            e0.City = "Georgetown";
            e0.State = "TX";
            e0.ZipCode = "78628";
            e0.PhoneNumber = "9074653365";
            e0.Email = "t.jacobs@longhorncinema.com";
            e0.UserName = "t.jacobs@longhorncinema.com";


            var result0 = UserManager.Create(e0, "society");
            if (UserManager.IsInRole(e0.Id, "Employee") == false)
            {
                UserManager.AddToRole(e0.Id, "Employee");
            }
            db.SaveChanges();
            e0 = db.Users.First(u => u.UserName == "t.jacobs@longhorncinema.com");


            AppUser e1 = new AppUser();
            e1.LastName = "Rice";
            e1.FirstName = "Eryn";
            e1.MiddleInitial = "M";
            e1.SSN = "454776657";
            e1.Birthday = new System.DateTime(1959, 7, 2);
            e1.Type = Type.Manager;
            e1.Street = "3405 Rio Grande";
            e1.City = "Austin";
            e1.State = "TX";
            e1.ZipCode = "78746";
            e1.PhoneNumber = "9073876657";
            e1.Email = "e.rice@longhorncinema.com";
            e1.UserName = "e.rice@longhorncinema.com";


            var result1 = UserManager.Create(e1, "ricearoni");
            if (UserManager.IsInRole(e1.Id, "Employee") == false)
            {
                UserManager.AddToRole(e1.Id, "Employee");
            }
            db.SaveChanges();
            e1 = db.Users.First(u => u.UserName == "e.rice@longhorncinema.com");


            AppUser e2 = new AppUser();
            e2.LastName = "Ingram";
            e2.FirstName = "Brad";
            e2.MiddleInitial = "S";
            e2.SSN = "797348821";
            e2.Birthday = new System.DateTime(1962, 8, 25);
            e2.Type = Type.Employee;
            e2.Street = "6548 La Posada Ct.";
            e2.City = "Austin";
            e2.State = "TX";
            e2.ZipCode = "78705";
            e2.PhoneNumber = "9074678821";
            e2.Email = "b.ingram@longhorncinema.com";
            e2.UserName = "b.ingram@longhorncinema.com";


            var result2 = UserManager.Create(e2, "ingram45");
            if (UserManager.IsInRole(e2.Id, "Employee") == false)
            {
                UserManager.AddToRole(e2.Id, "Employee");
            }
            db.SaveChanges();
            e2 = db.Users.First(u => u.UserName == "b.ingram@longhorncinema.com");


            AppUser e3 = new AppUser();
            e3.LastName = "Taylor";
            e3.FirstName = "Allison";
            e3.MiddleInitial = "R";
            e3.SSN = "934778452";
            e3.Birthday = new System.DateTime(1964, 9, 2);
            e3.Type = Type.Employee;
            e3.Street = "467 Nueces St.";
            e3.City = "Austin";
            e3.State = "TX";
            e3.ZipCode = "78727";
            e3.PhoneNumber = "9074748452";
            e3.Email = "a.taylor@longhorncinema.com";
            e3.UserName = "a.taylor@longhorncinema.com";


            var result3 = UserManager.Create(e3, "nostalgic");
            if (UserManager.IsInRole(e3.Id, "Employee") == false)
            {
                UserManager.AddToRole(e3.Id, "Employee");
            }
            db.SaveChanges();
            e3 = db.Users.First(u => u.UserName == "a.taylor@longhorncinema.com");


            AppUser e4 = new AppUser();
            e4.LastName = "Martinez";
            e4.FirstName = "Gregory";
            e4.MiddleInitial = "R";
            e4.SSN = "463566718";
            e4.Birthday = new System.DateTime(1992, 3, 30);
            e4.Type = Type.Employee;
            e4.Street = "8295 Sunset Blvd.";
            e4.City = "Austin";
            e4.State = "TX";
            e4.ZipCode = "78712";
            e4.PhoneNumber = "9078746718";
            e4.Email = "g.martinez@longhorncinema.com";
            e4.UserName = "g.martinez@longhorncinema.com";


            var result4 = UserManager.Create(e4, "fungus");
            if (UserManager.IsInRole(e4.Id, "Employee") == false)
            {
                UserManager.AddToRole(e4.Id, "Employee");
            }
            db.SaveChanges();
            e4 = db.Users.First(u => u.UserName == "g.martinez@longhorncinema.com");


            AppUser e5 = new AppUser();
            e5.LastName = "Sheffield";
            e5.FirstName = "Martin";
            e5.MiddleInitial = "J";
            e5.SSN = "223449167";
            e5.Birthday = new System.DateTime(1996, 12, 29);
            e5.Type = Type.Employee;
            e5.Street = "3886 Avenue A";
            e5.City = "San Marcos";
            e5.State = "TX";
            e5.ZipCode = "78666";
            e5.PhoneNumber = "9075479167";
            e5.Email = "m.sheffield@longhorncinema.com";
            e5.UserName = "m.sheffield@longhorncinema.com";


            var result5 = UserManager.Create(e5, "longhorns");
            if (UserManager.IsInRole(e5.Id, "Employee") == false)
            {
                UserManager.AddToRole(e5.Id, "Employee");
            }
            db.SaveChanges();
            e5 = db.Users.First(u => u.UserName == "m.sheffield@longhorncinema.com");


            AppUser e6 = new AppUser();
            e6.LastName = "MacLeod";
            e6.FirstName = "Jennifer";
            e6.MiddleInitial = "D";
            e6.SSN = "775908138";
            e6.Birthday = new System.DateTime(1997, 6, 10);
            e6.Type = Type.Employee;
            e6.Street = "2504 Far West Blvd.";
            e6.City = "Austin";
            e6.State = "TX";
            e6.ZipCode = "78705";
            e6.PhoneNumber = "9074748138";
            e6.Email = "j.macleod@longhorncinema.com";
            e6.UserName = "j.macleod@longhorncinema.com";


            var result6 = UserManager.Create(e6, "smitty");
            if (UserManager.IsInRole(e6.Id, "Employee") == false)
            {
                UserManager.AddToRole(e6.Id, "Employee");
            }
            db.SaveChanges();
            e6 = db.Users.First(u => u.UserName == "j.macleod@longhorncinema.com");


            AppUser e7 = new AppUser();
            e7.LastName = "Tanner";
            e7.FirstName = "Jeremy";
            e7.MiddleInitial = "S";
            e7.SSN = "904440929";
            e7.Birthday = new System.DateTime(1970, 8, 12);
            e7.Type = Type.Employee;
            e7.Street = "4347 Almstead";
            e7.City = "Austin";
            e7.State = "TX";
            e7.ZipCode = "78712";
            e7.PhoneNumber = "9074590929";
            e7.Email = "j.tanner@longhorncinema.com";
            e7.UserName = "j.tanner@longhorncinema.com";


            var result7 = UserManager.Create(e7, "tanman");
            if (UserManager.IsInRole(e7.Id, "Employee") == false)
            {
                UserManager.AddToRole(e7.Id, "Employee");
            }
            db.SaveChanges();
            e7 = db.Users.First(u => u.UserName == "j.tanner@longhorncinema.com");


            AppUser e8 = new AppUser();
            e8.LastName = "Rhodes";
            e8.FirstName = "Megan";
            e8.MiddleInitial = "C";
            e8.SSN = "353904746";
            e8.Birthday = new System.DateTime(1970, 12, 18);
            e8.Type = Type.Employee;
            e8.Street = "4587 Enfield Rd.";
            e8.City = "Austin";
            e8.State = "TX";
            e8.ZipCode = "78729";
            e8.PhoneNumber = "9073744746";
            e8.Email = "m.rhodes@longhorncinema.com";
            e8.UserName = "m.rhodes@longhorncinema.com";


            var result8 = UserManager.Create(e8, "countryrhodes");
            if (UserManager.IsInRole(e8.Id, "Employee") == false)
            {
                UserManager.AddToRole(e8.Id, "Employee");
            }
            db.SaveChanges();
            e8 = db.Users.First(u => u.UserName == "m.rhodes@longhorncinema.com");


            AppUser e9 = new AppUser();
            e9.LastName = "Stuart";
            e9.FirstName = "Eric";
            e9.MiddleInitial = "F";
            e9.SSN = "363998335";
            e9.Birthday = new System.DateTime(1971, 3, 11);
            e9.Type = Type.Employee;
            e9.Street = "5576 Toro Ring";
            e9.City = "Austin";
            e9.State = "TX";
            e9.ZipCode = "78758";
            e9.PhoneNumber = "9078178335";
            e9.Email = "e.stuart@longhorncinema.com";
            e9.UserName = "e.stuart@longhorncinema.com";


            var result9 = UserManager.Create(e9, "stewboy");
            if (UserManager.IsInRole(e9.Id, "Employee") == false)
            {
                UserManager.AddToRole(e9.Id, "Employee");
            }
            db.SaveChanges();
            e9 = db.Users.First(u => u.UserName == "e.stuart@longhorncinema.com");


            AppUser e10 = new AppUser();
            e10.LastName = "Miller";
            e10.FirstName = "Charles";
            e10.MiddleInitial = "R";
            e10.SSN = "353308615";
            e10.Birthday = new System.DateTime(1972, 7, 20);
            e10.Type = Type.Employee;
            e10.Street = "8962 Main St.";
            e10.City = "Austin";
            e10.State = "TX";
            e10.ZipCode = "78709";
            e10.PhoneNumber = "9077458615";
            e10.Email = "c.miller@longhorncinema.com";
            e10.UserName = "c.miller@longhorncinema.com";


            var result10 = UserManager.Create(e10, "squirrel");
            if (UserManager.IsInRole(e10.Id, "Employee") == false)
            {
                UserManager.AddToRole(e10.Id, "Employee");
            }
            db.SaveChanges();
            e10 = db.Users.First(u => u.UserName == "c.miller@longhorncinema.com");


            AppUser e11 = new AppUser();
            e11.LastName = "Taylor";
            e11.FirstName = "Rachel";
            e11.MiddleInitial = "O";
            e11.SSN = "393412631";
            e11.Birthday = new System.DateTime(1972, 12, 20);
            e11.Type = Type.Manager;
            e11.Street = "345 Longview Dr.";
            e11.City = "Austin";
            e11.State = "TX";
            e11.ZipCode = "78746";
            e11.PhoneNumber = "9074512631";
            e11.Email = "r.taylor@longhorncinema.com";
            e11.UserName = "r.taylor@longhorncinema.com";


            var result11 = UserManager.Create(e11, "swansong");
            if (UserManager.IsInRole(e11.Id, "Employee") == false)
            {
                UserManager.AddToRole(e11.Id, "Employee");
            }
            db.SaveChanges();
            e11 = db.Users.First(u => u.UserName == "r.taylor@longhorncinema.com");


            AppUser e12 = new AppUser();
            e12.LastName = "Lawrence";
            e12.FirstName = "Victoria";
            e12.MiddleInitial = "Y";
            e12.SSN = "770097399";
            e12.Birthday = new System.DateTime(1973, 4, 28);
            e12.Type = Type.Employee;
            e12.Street = "6639 Butterfly Ln.";
            e12.City = "Austin";
            e12.State = "TX";
            e12.ZipCode = "78712";
            e12.PhoneNumber = "9079457399";
            e12.Email = "v.lawrence@longhorncinema.com";
            e12.UserName = "v.lawrence@longhorncinema.com";


            var result12 = UserManager.Create(e12, "lottery");
            if (UserManager.IsInRole(e12.Id, "Employee") == false)
            {
                UserManager.AddToRole(e12.Id, "Employee");
            }
            db.SaveChanges();
            e12 = db.Users.First(u => u.UserName == "v.lawrence@longhorncinema.com");


            AppUser e13 = new AppUser();
            e13.LastName = "Rogers";
            e13.FirstName = "Allen";
            e13.MiddleInitial = "H";
            e13.SSN = "700002943";
            e13.Birthday = new System.DateTime(1978, 6, 21);
            e13.Type = Type.Manager;
            e13.Street = "4965 Oak Hill";
            e13.City = "Austin";
            e13.State = "TX";
            e13.ZipCode = "78705";
            e13.PhoneNumber = "9078752943";
            e13.Email = "a.rogers@longhorncinema.com";
            e13.UserName = "a.rogers@longhorncinema.com";


            var result13 = UserManager.Create(e13, "evanescent");
            if (UserManager.IsInRole(e13.Id, "Employee") == false)
            {
                UserManager.AddToRole(e13.Id, "Employee");
            }
            db.SaveChanges();
            e13 = db.Users.First(u => u.UserName == "a.rogers@longhorncinema.com");


            AppUser e14 = new AppUser();
            e14.LastName = "Markham";
            e14.FirstName = "Elizabeth";
            e14.MiddleInitial = "K";
            e14.SSN = "101529845";
            e14.Birthday = new System.DateTime(1990, 5, 21);
            e14.Type = Type.Employee;
            e14.Street = "7861 Chevy Chase";
            e14.City = "Austin";
            e14.State = "TX";
            e14.ZipCode = "78785";
            e14.PhoneNumber = "9074579845";
            e14.Email = "e.markham@longhorncinema.com";
            e14.UserName = "e.markham@longhorncinema.com";


            var result14 = UserManager.Create(e14, "monty3");
            if (UserManager.IsInRole(e14.Id, "Employee") == false)
            {
                UserManager.AddToRole(e14.Id, "Employee");
            }
            db.SaveChanges();
            e14 = db.Users.First(u => u.UserName == "e.markham@longhorncinema.com");


            AppUser e15 = new AppUser();
            e15.LastName = "Baker";
            e15.FirstName = "Christopher";
            e15.MiddleInitial = "E";
            e15.SSN = "401661146";
            e15.Birthday = new System.DateTime(1993, 3, 16);
            e15.Type = Type.Employee;
            e15.Street = "1245 Lake Anchorage Blvd.";
            e15.City = "Cedar Park";
            e15.State = "TX";
            e15.ZipCode = "78613";
            e15.PhoneNumber = "9075571146";
            e15.Email = "c.baker@longhorncinema.com";
            e15.UserName = "c.baker@longhorncinema.com";


            var result15 = UserManager.Create(e15, "hecktour");
            if (UserManager.IsInRole(e15.Id, "Employee") == false)
            {
                UserManager.AddToRole(e15.Id, "Employee");
            }
            db.SaveChanges();
            e15 = db.Users.First(u => u.UserName == "c.baker@longhorncinema.com");


            AppUser e16 = new AppUser();
            e16.LastName = "Saunders";
            e16.FirstName = "Sarah";
            e16.MiddleInitial = "M";
            e16.SSN = "500987810";
            e16.Birthday = new System.DateTime(1997, 1, 5);
            e16.Type = Type.Employee;
            e16.Street = "332 Avenue C";
            e16.City = "Austin";
            e16.State = "TX";
            e16.ZipCode = "78733";
            e16.PhoneNumber = "9073497810";
            e16.Email = "s.saunders@longhorncinema.com";
            e16.UserName = "s.saunders@longhorncinema.com";


            var result16 = UserManager.Create(e16, "rankmary");
            if (UserManager.IsInRole(e16.Id, "Employee") == false)
            {
                UserManager.AddToRole(e16.Id, "Employee");
            }
            db.SaveChanges();
            e16 = db.Users.First(u => u.UserName == "s.saunders@longhorncinema.com");


            AppUser e17 = new AppUser();
            e17.LastName = "Sewell";
            e17.FirstName = "William";
            e17.MiddleInitial = "G";
            e17.SSN = "500830084";
            e17.Birthday = new System.DateTime(1986, 5, 25);
            e17.Type = Type.Manager;
            e17.Street = "2365 51st St.";
            e17.City = "Austin";
            e17.State = "TX";
            e17.ZipCode = "78755";
            e17.PhoneNumber = "9074510084";
            e17.Email = "w.sewell@longhorncinema.com";
            e17.UserName = "w.sewell@longhorncinema.com";


            var result17 = UserManager.Create(e17, "walkamile");
            if (UserManager.IsInRole(e17.Id, "Employee") == false)
            {
                UserManager.AddToRole(e17.Id, "Employee");
            }
            db.SaveChanges();
            e17 = db.Users.First(u => u.UserName == "w.sewell@longhorncinema.com");


            AppUser e18 = new AppUser();
            e18.LastName = "Mason";
            e18.FirstName = "Jack";
            e18.MiddleInitial = "L";
            e18.SSN = "1112223232";
            e18.Birthday = new System.DateTime(1986, 6, 6);
            e18.Type = Type.Employee;
            e18.Street = "444 45th St";
            e18.City = "Austin";
            e18.State = "TX";
            e18.ZipCode = "78701";
            e18.PhoneNumber = "9018833432";
            e18.Email = "j.mason@longhorncinema.com";
            e18.UserName = "j.mason@longhorncinema.com";


            var result18 = UserManager.Create(e18, "changalang");
            if (UserManager.IsInRole(e18.Id, "Employee") == false)
            {
                UserManager.AddToRole(e18.Id, "Employee");
            }
            db.SaveChanges();
            e18 = db.Users.First(u => u.UserName == "j.mason@longhorncinema.com");


            AppUser e19 = new AppUser();
            e19.LastName = "Jackson";
            e19.FirstName = "Jack";
            e19.MiddleInitial = "J";
            e19.SSN = "8889993434";
            e19.Birthday = new System.DateTime(1986, 10, 16);
            e19.Type = Type.Employee;
            e19.Street = "222 Main";
            e19.City = "Austin";
            e19.State = "TX";
            e19.ZipCode = "78760";
            e19.PhoneNumber = "9075554545";
            e19.Email = "j.jackson@longhorncinema.com";
            e19.UserName = "j.jackson@longhorncinema.com";


            var result19 = UserManager.Create(e19, "offbeat");
            if (UserManager.IsInRole(e19.Id, "Employee") == false)
            {
                UserManager.AddToRole(e19.Id, "Employee");
            }
            db.SaveChanges();
            e19 = db.Users.First(u => u.UserName == "j.jackson@longhorncinema.com");


            AppUser e20 = new AppUser();
            e20.LastName = "Nguyen";
            e20.FirstName = "Mary";
            e20.MiddleInitial = "J";
            e20.SSN = "7776665555";
            e20.Birthday = new System.DateTime(1988, 4, 5);
            e20.Type = Type.Employee;
            e20.Street = "465 N. Bear Cub";
            e20.City = "Austin";
            e20.State = "TX";
            e20.ZipCode = "78734";
            e20.PhoneNumber = "9075524141";
            e20.Email = "m.nguyen@longhorncinema.com";
            e20.UserName = "m.nguyen@longhorncinema.com";


            var result20 = UserManager.Create(e20, "landus");
            if (UserManager.IsInRole(e20.Id, "Employee") == false)
            {
                UserManager.AddToRole(e20.Id, "Employee");
            }
            db.SaveChanges();
            e20 = db.Users.First(u => u.UserName == "m.nguyen@longhorncinema.com");


            AppUser e21 = new AppUser();
            e21.LastName = "Barnes";
            e21.FirstName = "Susan";
            e21.MiddleInitial = "M";
            e21.SSN = "1112221212";
            e21.Birthday = new System.DateTime(1993, 2, 22);
            e21.Type = Type.Employee;
            e21.Street = "888 S. Main";
            e21.City = "Kyle";
            e21.State = "TX";
            e21.ZipCode = "78640";
            e21.PhoneNumber = "9556662323";
            e21.Email = "s.barnes@longhorncinema.com";
            e21.UserName = "s.barnes@longhorncinema.com";


            var result21 = UserManager.Create(e21, "rhythm");
            if (UserManager.IsInRole(e21.Id, "Employee") == false)
            {
                UserManager.AddToRole(e21.Id, "Employee");
            }
            db.SaveChanges();
            e21 = db.Users.First(u => u.UserName == "s.barnes@longhorncinema.com");


            AppUser e22 = new AppUser();
            e22.LastName = "Jones";
            e22.FirstName = "Lester";
            e22.MiddleInitial = "L";
            e22.SSN = "9099099999";
            e22.Birthday = new System.DateTime(1996, 6, 29);
            e22.Type = Type.Employee;
            e22.Street = "999 LeBlat";
            e22.City = "Austin";
            e22.State = "TX";
            e22.ZipCode = "78747";
            e22.PhoneNumber = "9886662222";
            e22.Email = "l.jones@longhorncinema.com";
            e22.UserName = "l.jones@longhorncinema.com";


            var result22 = UserManager.Create(e22, "kindly");
            if (UserManager.IsInRole(e22.Id, "Employee") == false)
            {
                UserManager.AddToRole(e22.Id, "Employee");
            }
            db.SaveChanges();
            e22 = db.Users.First(u => u.UserName == "l.jones@longhorncinema.com");


            AppUser e23 = new AppUser();
            e23.LastName = "Garcia";
            e23.FirstName = "Hector";
            e23.MiddleInitial = "W";
            e23.SSN = "4445554343";
            e23.Birthday = new System.DateTime(1997, 5, 13);
            e23.Type = Type.Employee;
            e23.Street = "777 PBR Drive";
            e23.City = "Austin";
            e23.State = "TX";
            e23.ZipCode = "78712";
            e23.PhoneNumber = "9221114444";
            e23.Email = "h.garcia@longhorncinema.com";
            e23.UserName = "h.garcia@longhorncinema.com";


            var result23 = UserManager.Create(e23, "instrument");
            if (UserManager.IsInRole(e23.Id, "Employee") == false)
            {
                UserManager.AddToRole(e23.Id, "Employee");
            }
            db.SaveChanges();
            e23 = db.Users.First(u => u.UserName == "h.garcia@longhorncinema.com");


            AppUser e24 = new AppUser();
            e24.LastName = "Silva";
            e24.FirstName = "Cindy";
            e24.MiddleInitial = "S";
            e24.SSN = "7776661111";
            e24.Birthday = new System.DateTime(1997, 12, 29);
            e24.Type = Type.Employee;
            e24.Street = "900 4th St";
            e24.City = "Austin";
            e24.State = "TX";
            e24.ZipCode = "78758";
            e24.PhoneNumber = "9221113333";
            e24.Email = "c.silva@longhorncinema.com";
            e24.UserName = "c.silva@longhorncinema.com";


            var result24 = UserManager.Create(e24, "arched");
            if (UserManager.IsInRole(e24.Id, "Employee") == false)
            {
                UserManager.AddToRole(e24.Id, "Employee");
            }
            db.SaveChanges();
            e24 = db.Users.First(u => u.UserName == "c.silva@longhorncinema.com");


            AppUser e25 = new AppUser();
            e25.LastName = "Lopez";
            e25.FirstName = "Marshall";
            e25.MiddleInitial = "T";
            e25.SSN = "2223332222";
            e25.Birthday = new System.DateTime(1996, 11, 4);
            e25.Type = Type.Employee;
            e25.Street = "90 SW North St";
            e25.City = "Austin";
            e25.State = "TX";
            e25.ZipCode = "78729";
            e25.PhoneNumber = "9234442222";
            e25.Email = "m.lopez@longhorncinema.com";
            e25.UserName = "m.lopez@longhorncinema.com";


            var result25 = UserManager.Create(e25, "median");
            if (UserManager.IsInRole(e25.Id, "Employee") == false)
            {
                UserManager.AddToRole(e25.Id, "Employee");
            }
            db.SaveChanges();
            e25 = db.Users.First(u => u.UserName == "m.lopez@longhorncinema.com");


            AppUser e26 = new AppUser();
            e26.LastName = "Larson";
            e26.FirstName = "Bill";
            e26.MiddleInitial = "B";
            e26.SSN = "5554443333";
            e26.Birthday = new System.DateTime(1999, 11, 14);
            e26.Type = Type.Employee;
            e26.Street = "1212 N. First Ave";
            e26.City = "Round Rock";
            e26.State = "TX";
            e26.ZipCode = "78665";
            e26.PhoneNumber = "9795554444";
            e26.Email = "b.larson@longhorncinema.com";
            e26.UserName = "b.larson@longhorncinema.com";


            var result26 = UserManager.Create(e26, "approval");
            if (UserManager.IsInRole(e26.Id, "Employee") == false)
            {
                UserManager.AddToRole(e26.Id, "Employee");
            }
            db.SaveChanges();
            e26 = db.Users.First(u => u.UserName == "b.larson@longhorncinema.com");

        }
    }
}