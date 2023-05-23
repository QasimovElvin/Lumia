using Lumia.DAL;
using Lumia.Models;
using Lumia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lumia.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                Abouts = await _context.Abouts.FirstOrDefaultAsync(),
                Servs=await _context.Servs.Take(4).ToListAsync(),
                Sliders=await _context.Sliders.FirstOrDefaultAsync(),
                Teams=await _context.Teams.Take(3).ToListAsync(),
                WhatWeDos=await _context.Whatwedos.Take(3).ToListAsync(),
           };
            return View(vm);
        }

       
       
    }
}