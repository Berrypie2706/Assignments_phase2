using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment16.Data;
using Assignment16.Models;

namespace Assignment16.Controllers
{
    public class Task_1Controller : Controller
    {
        private readonly TasksDbContext _context;

        public Task_1Controller(TasksDbContext context)
        {
            _context = context;
        }

        // GET: Task_1
        public async Task<IActionResult> Index()
        {
              return _context.Task_1 != null ? 
                          View(await _context.Task_1.ToListAsync()) :
                          Problem("Entity set 'TasksDbContext.Task_1'  is null.");
        }

        // GET: Task_1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Task_1 == null)
            {
                return NotFound();
            }

            var task_1 = await _context.Task_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task_1 == null)
            {
                return NotFound();
            }

            return View(task_1);
        }

        // GET: Task_1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task_1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Discription,DueDate")] Task_1 task_1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task_1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task_1);
        }

        // GET: Task_1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task_1 == null)
            {
                return NotFound();
            }

            var task_1 = await _context.Task_1.FindAsync(id);
            if (task_1 == null)
            {
                return NotFound();
            }
            return View(task_1);
        }

        // POST: Task_1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Discription,DueDate")] Task_1 task_1)
        {
            if (id != task_1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task_1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Task_1Exists(task_1.Id))
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
            return View(task_1);
        }

        // GET: Task_1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task_1 == null)
            {
                return NotFound();
            }

            var task_1 = await _context.Task_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task_1 == null)
            {
                return NotFound();
            }

            return View(task_1);
        }

        // POST: Task_1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task_1 == null)
            {
                return Problem("Entity set 'TasksDbContext.Task_1'  is null.");
            }
            var task_1 = await _context.Task_1.FindAsync(id);
            if (task_1 != null)
            {
                _context.Task_1.Remove(task_1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Task_1Exists(int id)
        {
          return (_context.Task_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
