using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Novir.PetFinder.Core.Services.Items;

namespace Novir.PetFinder.App.Controllers
{
    public class UserController : BaseController
    {
        private readonly IItemService _itemService;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(IItemService itemService, UserManager<IdentityUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Items()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var items = await _itemService.GetUserItems(user.Id);
            return View(items);
        }
    }
}
