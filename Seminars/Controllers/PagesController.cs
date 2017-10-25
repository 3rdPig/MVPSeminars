using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seminars.Data;
using Seminars.Models;
using Microsoft.AspNetCore.Authorization;

namespace Seminars.Controllers
{
    [AllowAnonymous]
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pages/Details/5
        [HttpGet]
        [Route("{url}")]
        public async Task<IActionResult> Details(string url)
        {
            var page = await _context.Pages
                .SingleOrDefaultAsync(m => m.Url == url);

            if (page == null)
            {
                return RedirectToRoute(url);
            }

            return View(page);
        }

        
    }
}
