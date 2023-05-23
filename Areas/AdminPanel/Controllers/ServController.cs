using Lumia.DAL;
using Lumia.Models;
using Lumia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Drawing;

namespace Lumia.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ServController : Controller
    {
        private readonly AppDbContext _context;

        public ServController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1,int take=3)
        {
            var Services = _context.Servs.Skip((page - 1) * take).Take(take).ToList();
            PaginateVM<Serv> paginate = new PaginateVM<Serv>()
            {
                Items=Services,
                CurrentPage=page,
                PageCount=GetPageCount(take)
            };
            return View(paginate);

        }
        private int GetPageCount(int take)
        {
            var SerCount = _context.Servs.Count();
            return (int)Math.Ceiling((decimal)SerCount / take);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Serv serv)
        {
            if (!ModelState.IsValid) return View();
            if(serv == null)
            {
                ModelState.AddModelError("", "Serv is null");
                return View();
            }
            await _context.AddAsync(serv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _context.Servs.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Serv serv)
        {
            Serv? exists =await _context.Servs.FirstOrDefaultAsync(x => x.Id == serv.Id);
            if(exists == null)
            {
                ModelState.AddModelError("", "Serv is null");
                return View();
            }
            exists.Icon = serv.Icon;
            exists.Title = serv.Title;
            exists.Description = serv.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Serv? serv = _context.Servs.FirstOrDefault(x => x.Id == id);
            _context.Servs.Remove(serv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
