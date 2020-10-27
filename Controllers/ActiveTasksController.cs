using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.DataAccess;

namespace EmployeeManagement.Controllers
{
    public class ActiveTasksController : Controller
    {
        private readonly AppDbContext _context;

        public ActiveTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ActiveTasks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ActiveTasks.Include(a => a.Employee).Include(a => a.Task);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ActiveTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            setRoleList();
            var activeTask = await _context.ActiveTasks
                .Include(a => a.Employee)
                .Include(a => a.Task)
                .FirstOrDefaultAsync(m => m.WIPID == id);
            if (activeTask == null)
            {
                return NotFound();
            }

            return View(activeTask);
        }

        // GET: ActiveTasks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeEmail");
            ViewData["TaskID"] = new SelectList(_context.Tasks, "TaskID", "TaskDesc");
            setRoleList();
            return View();
        }

        // POST: ActiveTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WIPID,TaskID,EmployeeID,EmployeeCurrentRate,TaskStartDate,TaskEndDate,TimeCompleted")] ActiveTask activeTask)
        {
            if (ModelState.IsValid && maxDailyWorkHours(activeTask.EmployeeID, activeTask.TaskStartDate))
            {
                _context.Add(activeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeEmail", activeTask.EmployeeID);
            ViewData["TaskID"] = new SelectList(_context.Tasks, "TaskID", "TaskDesc", activeTask.TaskID);
            setRoleList();
            return View(activeTask);

        }

        // GET: ActiveTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            setRoleList();
            var activeTask = await _context.ActiveTasks.FindAsync(id);
            if (activeTask == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeEmail", activeTask.EmployeeID);
            ViewData["TaskID"] = new SelectList(_context.Tasks, "TaskID", "TaskDesc", activeTask.TaskID);
            setRoleList();
            return View(activeTask);
        }

        // POST: ActiveTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WIPID,TaskID,EmployeeID,EmployeeCurrentRate,TaskStartDate,TaskEndDate,TimeCompleted")] ActiveTask activeTask)
        {
            if (id != activeTask.WIPID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveTaskExists(activeTask.WIPID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeEmail", activeTask.EmployeeID);
            ViewData["TaskID"] = new SelectList(_context.Tasks, "TaskID", "TaskDesc", activeTask.TaskID);
            setRoleList();
            return View(activeTask);
        }

        // GET: ActiveTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeTask = await _context.ActiveTasks
                .Include(a => a.Employee)
                .Include(a => a.Task)
                .FirstOrDefaultAsync(m => m.WIPID == id);
            if (activeTask == null)
            {
                return NotFound();
            }

            return View(activeTask);
        }

        // POST: ActiveTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeTask = await _context.ActiveTasks.FindAsync(id);
            _context.ActiveTasks.Remove(activeTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveTaskExists(int id)
        {
            return _context.ActiveTasks.Any(e => e.WIPID == id);
        }

        private void setRoleList(int? EmployeeCurrentRate = null)
        {
            var roles = _context.Roles.ToList().Select(x =>
                       new SelectListItem()
                       {
                           Value = x.RoleRate.ToString(),
                           Text = x.RoleName,
                           Selected = x.RoleRate == EmployeeCurrentRate
                       });
            ViewBag.Roles = roles;
        }

        private bool maxDailyWorkHours(int employeeId, DateTime currentStartDate)
        {
            var activeEmployeeTaskIds = _context.ActiveTasks.ToList()
                .Where(t => t.EmployeeID == employeeId && t.TaskStartDate.DayOfYear == currentStartDate.DayOfYear)
                .Select(t => t.TaskID);    

            //var taskDurations = _context.Tasks?????????

            return true;
        }
    }
}
