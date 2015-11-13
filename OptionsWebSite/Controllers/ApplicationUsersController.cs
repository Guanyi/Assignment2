using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptionsWebSite.Models;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace OptionsWebSite.Controllers
{
    public class UserIndexViewModel
    {
        public ApplicationUser User { get; set; }
        public IdentityRole Role { get; set; }
        public UserIndexViewModel() { }
    }

    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            List<UserIndexViewModel> userListWithRole = new List<UserIndexViewModel>();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userList = db.Users.ToList();
            foreach (var user in userList)
            {
                //"userRoles" contains all the records in AspNetUserRoles table. AspNetUserRoles only has 2 columns represent
                //the many to many relation between AspNetUses table and AspNetRoles table. The combination of the 2 columns
                //is the primary key of AspNetUserRoles table. Each columns is also a foreign key references to AspNetUser
                //and AspNetRoles.
                //
                //userRole is an record in the AspNetUserRoles table. userRole only has 2 fields, UserId and RoleId
                ICollection<IdentityUserRole> userRoles = user.Roles.ToList();
                foreach(var userRole in userRoles)
                {
                    // var role is the real record in AspNetRoles table which has the role name
                    var role = roleManager.FindById(userRole.RoleId);
                    userListWithRole.Add( new UserIndexViewModel { User = user, Role = role } );
                }
            }
            return View(userListWithRole);
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser user = userManager.FindById(id);


            //var x = roleManager.FindById(user.Roles.FirstOrDefault().RoleId);
            //userManager
            //IEnumerable<SelectListItem> roleDropDownListItems = db.ApplicationRole.Select(r => new SelectListItem { Value = r.Id, Text = r.Name });

            //IEnumerable<SelectListItem> roleDropDownListItems = db.Roles.Select(r => new SelectListItem { Value = r.Id, Text = r.Name });
            //ViewBag.OptionList = new SelectList(db.Options.Where(o => o.IsActive == true).OrderBy(o => o.Title), "OptionId", "Title");
            var rolesForDropDownList = new SelectList(db.ApplicationRole, "Id", "Name");
            //var role = roleManager.FindById(user.Roles.FirstOrDefault());
            foreach (var item in rolesForDropDownList)
            {
                if (item.Value == user.Roles.FirstOrDefault().RoleId)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.roleList = rolesForDropDownList;
            //ViewBag.roleList = new SelectList(db.ApplicationRole, "Id", "Name");  //roleDropDownListItems;
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser applicationUser, string RoleId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                //In Asp.Net, it is allowed to have a user in multiple roles, but in this assignment, we assume user can only
                //in one role, so each time to change the user role by submitting the dropdown list, we add the user to a new
                //role and then remove the user from the previous role.

                //We have to add "applicationUser" to a new role first, then remove it from the previous role. The order of operation is important.
                //The problem is that when this [HttpPost] method gets submission, the "applicationUser" variable has no Roles
                //in its role list, so there is no way we can remove the current role. However after we add a new role to the
                //"applicationUser", then the "applicationUser" gets 2 roles in its Role list. This is weird, so we have to add the role, then
                // foreach through the role list to compare the role item, and remove the one which is different from the new role.

                //get the new role name from its id, then add user to this role
                var newRoleName = roleManager.FindById(RoleId).Name;
                userManager.AddToRole(applicationUser.Id, newRoleName);

                //When the code execution get here, the applicationUser.Roles has 2 role items inside.
                foreach (var role in applicationUser.Roles.ToList())
                {
                    if(role.RoleId != RoleId)
                    {
                        var roleName = roleManager.FindById(role.RoleId).Name;
                        userManager.RemoveFromRole(applicationUser.Id, roleName);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}