using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WCLWebAPI.Client.IServicesInterface;
using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels.System.Roles;
using WCLWebAPI.Server.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using WCLWebAPI.Server.Constants;

namespace WCLWebAPI.Client.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClientServiceInterface _userApiClient;
        private readonly IRoleApiClientServiceInterface _roleApiClient;

        public UserController(IUserApiClientServiceInterface userApiClientServiceInterface, IRoleApiClientServiceInterface roleApiClientServiceInterface)
        {
            _userApiClient = userApiClientServiceInterface;
            _roleApiClient = roleApiClientServiceInterface;
        }

        public async Task<IActionResult> Index()
        {
            
            var data = await _userApiClient.GetUsersAsync();
            //if (TempData["result"] != null)
            //{
            //    ViewBag.SuccessMsg = TempData["result"];
            //}
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userApiClient.GetByIdAsync(id);
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.RegisterUserAsync(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = Messages.N_User_SCC_Added;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetByIdAsync(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserUpdateRequest()
                {
                    Dob = user.Dob,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Id = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.UpdateUserAsync(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = Messages.U_User_SCC;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View(new UserDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.DeleteAsync(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = Messages.R_User_SCC;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> RoleAssign(Guid id)
        {
            var roleAssignRequest = await GetRoleAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.RoleAssignAsync(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = Messages.U_Permissions_SCC;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetRoleAssignRequest(request.Id);

            return View(roleAssignRequest);
        }

        private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid id)
        {
            var userObj = await _userApiClient.GetByIdAsync(id);
            var roleObj = await _roleApiClient.GetAllAsync();
            var roleAssignRequest = new RoleAssignRequest();
            foreach (var role in roleObj.ResultObj)
            {
                roleAssignRequest.Roles.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = userObj.ResultObj.Roles.Contains(role.Name)
                });
            }
            return roleAssignRequest;
        }
    }
}
