using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
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

        //POST: Salary/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeID,SalaryStartDate,SalaryEndDate")] SalaryModel salary)
        {
            var pay = CalcSalary(salary);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Task", "Employee is already fully allocated");
            }

            return View(salary);
        }

        public int CalcSalary(SalaryModel model)
        {
            var salary = 0;
            var employeeId = model.EmployeeID;
            var salaryStart = model.SalaryStartDate;
            var salaryEnd = model.SalaryEndDate;

            var employeeCompletedTasks = _context.ActiveTasks.ToList()
                .Where(t => t.EmployeeID == employeeId && t.TaskStartDate.Date >= salaryStart.Date && t.TaskStartDate.Date <= salaryEnd.Date);

            foreach(ActiveTask task in employeeCompletedTasks)
            {
                var taskPay = task.TimeCompleted * task.EmployeeCurrentRate;
                salary = salary + taskPay;
            }

            return salary;
        }
    }
}
