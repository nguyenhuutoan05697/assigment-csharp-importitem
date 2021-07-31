using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNAssigment.Areas.Identity.Data;
using PRNAssigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRNAssigment.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly DBImportManagementContext _context;
        public SupplierController(DBImportManagementContext context)
        {
            _context = context;
        }

        // getList
        public IActionResult Index()
        {           
            return View(_context.Suppliers.ToList());
        }

        // GET Create
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //GET Supplier/Details/id
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Supplier s = _context.Suppliers.Find(id);
            if(s == null)
            {
                return NotFound();
            }

            return View(s);
        }

        //GET Supplier/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Supplier = _context.Suppliers.Find(id);
            if (Supplier == null)
            {
                return NotFound();
            }
            return View(Supplier);
        }

        //POST Update
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            int SuppID = supplier.SupplierID;
            string SuppName = supplier.SupplierName;
            Supplier Supplier = _context.Suppliers.Find(SuppID);
            if (ModelState.IsValid)
            {
                try
                {
                    
                    Supplier.SupplierName = SuppName;
                    _context.Update(Supplier);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierID))
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
            return View(Supplier);
        }

        //GET Supplier/Delete/id
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Supplier supplier = _context.Suppliers.Find(id);
            
            if(supplier == null)
            {
                return NotFound();
            }
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierID == id);
        }
    }
}
