using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class SalaryController : Controller
    {
        private readonly AppDbContext _context;

        public SalaryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ActiveTasks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ActiveTasks.Include(a => a.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Salary/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeEmail");
            return View();
        }
    }
}
