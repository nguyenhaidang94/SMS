using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using WEB.Context;
using Newtonsoft.Json;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthenticationController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public AuthenticationController()
        {
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
        }

        //
        // GET: /Authentication/
        public ActionResult Index()
        {
            ViewBag.listRoles = JsonConvert.SerializeObject(_db.Roles.Select(x=>x.Name));
            return View();
        }

        //
        // GET: /Authentication/
        public async Task<ActionResult> CreateUser()
        {
            //Get the list of Roles
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> CreateUser(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = userViewModel.Email, Email = userViewModel.Email };
                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                    return View();

                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View();
        }

        /// <summary>
        /// Get list of User
        /// </summary>
        /// <returns>List User in Json</returns>
        [HttpPost]
        public async Task<JsonResult> Read()
        {
            try
            {
                List<UserManageViewModel> models = new List<UserManageViewModel>();
                IEnumerable<ApplicationUser> users = _db.Users;
                IEnumerable<ApplicationRole> roles = _db.Roles;
                

                foreach (ApplicationUser user in users)
                {
                    var userRoles = await _userManager.GetRolesAsync(user.Id);
                    models.Add(new UserManageViewModel(){
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.UserName,
                        RolesList = userRoles.ToList()
                    });
                }

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Get list of inactive User
        /// </summary>
        /// <returns>List inactive User in Json</returns>
        [HttpPost]
        public JsonResult ReadInactive()
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update KhoiLop to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Update(string models)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<UserManageViewModel>>(models);

                if (items != null)
                {
                    foreach (UserManageViewModel item in items)
                    {
                        var user = await UserManager.FindByIdAsync(item.Id);
                        if (user == null)
                        {
                            return Json(null);
                        }

                        user.UserName = item.Email;
                        user.Email = item.Email;
                        List<string> allRoles = _db.Roles.Select(m=>m.Name).ToList();
                        var userRoles = await UserManager.GetRolesAsync(user.Id);

                        var result = await UserManager.AddToRolesAsync(user.Id, item.RolesList.Except(userRoles).ToArray<string>());
                        if (!result.Succeeded)
                        {
                            return Json(result.Errors.First());
                        }
                        result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(item.RolesList).ToArray<string>());
                        if (!result.Succeeded)
                        {
                            return Json(result.Errors.First());
                        }
                    }
                }
                return Json(items);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set KhoiLop to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Destroy(string models)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<UserManageViewModel>>(models);

                if (items != null)
                {
                    foreach (UserManageViewModel item in items)
                    {
                        var user = await UserManager.FindByIdAsync(item.Id);
                        if (user == null)
                        {
                            return Json(new { error ="Không tìm thấy người dùng" });
                        }
                        var result = await UserManager.DeleteAsync(user);
                        if (!result.Succeeded)
                        {
                            return Json(result.Errors.First());
                        }
                    }
                }
                return Json(items);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Add new KhoiLop in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string models)
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        #region quan ly role
        //
        // GET: /Authentication/
        public ActionResult QuanLyRole()
        {
            return View();
        }

        /// <summary>
        /// Get list of Role
        /// </summary>
        /// <returns>List Role in Json</returns>
        [HttpPost]
        public JsonResult ReadRole()
        {
            try
            {
                var rolesList = new List<RoleViewModel>();
                foreach (var role in _db.Roles)
                {
                    var roleModel = new RoleViewModel(role);
                    rolesList.Add(roleModel);
                }

                return Json(rolesList);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update Role to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateRole(string models)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<RoleViewModel>>(models);

                foreach (RoleViewModel item in items)
                {
                    var role = _db.Roles.First(r => r.Name == item.OriginalRoleName);
                    role.Name = item.RoleName;
                    role.Description = item.Description;
                    _db.Entry(role).State = EntityState.Modified;
                    _db.SaveChanges();
                }

                return Json(items);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set Role to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DestroyRole(string models)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<RoleViewModel>>(models);

                foreach (RoleViewModel item in items)
                {
                    var role = _db.Roles.First(r => r.Name == item.OriginalRoleName);
                    UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
                    _db.DeleteRole(_db, UserManager, role.Id);
                }

                return Json(items);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }


        /// <summary>
        /// Add new Role in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateRole(string models)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<RoleViewModel>>(models);

                foreach (RoleViewModel item in items)
                {
                    var role = new ApplicationRole(item.RoleName, item.Description);

                    if (_db.RoleExists(RoleManager, item.RoleName))
                    {
                        return Json(new { error = "Role đã tồn tại" });
                    }
                    else
                    {
                        _db.CreateRole(RoleManager, item.RoleName, item.Description);
                    }
                }

                return Json(items);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }
        #endregion

        /// <summary>
        /// override function Dispose
        /// Dispose _UnitOfWork
        /// </summary>
        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
	}
}