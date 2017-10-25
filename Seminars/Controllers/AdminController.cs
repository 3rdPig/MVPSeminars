using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Seminars.Models;
using Seminars.Models.ManageViewModels;
using Seminars.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Seminars.Models.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Seminars.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;
using Seminars.Models.AdminViewModels;

namespace Seminars.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IFileProvider _fileProvider;
        private readonly ApplicationDbContext _context;

        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public AdminController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IEmailSender emailSender,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          IFileProvider fileProvider,
          ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _urlEncoder = urlEncoder;
            _fileProvider = fileProvider;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Pages()
        {
            var pages = await _context.Pages.ToListAsync();

            if (pages == null)
            {
                throw new ApplicationException($"Unable to load pages. Check your connection.");
            }

            var model = new ManagePageViewModel
            {
                Pages = pages
            };

            return View(model);            
        }

        [HttpGet]
        public IActionResult PagesAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PagesAdd(AddPageViewModel _page)
        {
            var user = await _userManager.GetUserAsync(User);

            var page = new Page
            {
                Title = _page.Title,
                Url = _page.Url,
                Content = _page.Content,
                PubDate = DateTime.Now,
                Status = _page.Status
            };

            await _context.Pages.AddAsync(page);

            _context.SaveChanges();

            return RedirectToAction(nameof(Pages));

        }

        [HttpGet]        
        public async Task<IActionResult> PagesEdit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.SingleOrDefaultAsync(p => p.Id == id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PagesEdit(Guid id, [Bind("Id,Title,Content,Url,Status")] Page _page)
        {            
            _context.Pages.Update(_page);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Pages));

        }
    }
}