using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlennsHotrods2.Data;
using GlennsHotrods2.Models;

namespace GlennsHotrods2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.ServiceWriter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.ServiceWriter)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            ViewData["ServiceWriterId"] = new SelectList(_context.ServiceWriters, "ServiceWriterId", "Name");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,Contact,Phone1,Phone2,CreateDate,Email,ServiceWriterId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceWriterId"] = new SelectList(_context.ServiceWriters, "ServiceWriterId", "ServiceWriterId", customer.ServiceWriterId);
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["ServiceWriterId"] = new SelectList(_context.ServiceWriters, "ServiceWriterId", "Name", customer.ServiceWriterId);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,Contact,Phone1,Phone2,CreateDate,Email,ServiceWriterId")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["ServiceWriterId"] = new SelectList(_context.ServiceWriters, "ServiceWriterId", "ServiceWriterId", customer.ServiceWriterId);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.ServiceWriter)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult>CreateWorkOrder(int? id)
        {
            var customer = await _context.Customers.FindAsync(id);

            // Make a new workOrder
            WorkOrderViewModel worder = new WorkOrderViewModel();
            worder.CustomerId = customer.CustomerId;
            worder.PhoneNumber = customer.Phone1;
            worder.OrderDate = DateTime.Now;
                     

            // return to a View not yet created
            return View(worder);

        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkOrder(WorkOrderViewModel model)
        {
            //if not null
            if (ModelState.IsValid)
            {
                WorkOrder workorder = new WorkOrder();
                workorder.AssignedTo = model.AssignedTo;
                workorder.WorkDescription = model.WorkDescription;
                workorder.OrderDate = model.OrderDate;
                workorder.Completed = false;
                workorder.PhoneNumber = model.PhoneNumber;
                workorder.CustomerId = model.CustomerId;

                // add the workorder to the database
                _context.Add(workorder);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ShowWorkOrders));
            }
            

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditWorkOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.workOrders.FindAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
             return View(workOrder);
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkOrder(int id,  WorkOrder workOrder)
        {
            if (id != workOrder.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workOrder.WorkOrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ShowWorkOrders));
            }
             return View(workOrder);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteWorkOrders(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.workOrders.FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }
            public async Task<IActionResult> DetailsWorkOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.workOrders.Include(c => c.customer).FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }
        public async Task<IActionResult> ShowWorkOrders()
        {
            var WorkOrderList = _context.workOrders.Include(c => c.customer).Where(d => !d.Completed);
            return View(WorkOrderList);
        }
        [HttpPost, ActionName("DeleteWorkOrders")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedWorkOrders(int id)
        {
            var workOrder = await _context.workOrders.FindAsync(id);
            _context.workOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        private bool WorkOrderExists(int id)
        {
            return _context.workOrders.Any(e => e.WorkOrderId == id);
        }
    }
}
