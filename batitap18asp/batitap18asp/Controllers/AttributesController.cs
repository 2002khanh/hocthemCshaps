using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using batitap18asp.Models;
using Attribute = batitap18asp.Models.Attribute;

namespace batitap18asp.Controllers
{
    public class AttributesController : Controller
    {
        private readonly SanPhamDBgContext _context;

        public AttributesController(SanPhamDBgContext context)
        {
            _context = context;
        }

        // GET: Attributes
        public async Task<IActionResult> Index()
        {
              return _context.Attributes != null ? 
                          View(await _context.Attributes.ToListAsync()) :
                          Problem("Entity set 'SanPhamDBgContext.Attributes'  is null.");
        }

        // GET: Attributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attributes == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.AttributeId == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // GET: Attributes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttributeId,AttributeName,Quantity,Price,PriceSale")] Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attribute);
        }

        // GET: Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attributes == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }
            return View(attribute);
        }

        // POST: Attributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttributeId,AttributeName,Quantity,Price,PriceSale")] Attribute attribute)
        {
            if (id == attribute.AttributeId)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(attribute);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AttributeExists(attribute.AttributeId))
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
                return View(attribute);
            }
            return NotFound();
        }

        private bool AttributeExists(object attributeId)
        {
            throw new NotImplementedException();
        }

        // GET: Attributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attributes == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.AttributeId == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // POST: Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attributes == null)
            {
                return Problem("Entity set 'SanPhamDBgContext.Attributes'  is null.");
            }
            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute != null)
            {
                _context.Attributes.Remove(attribute);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeExists(int id)
        {
          return (_context.Attributes?.Any(e => e.AttributeId == id)).GetValueOrDefault();
        }
    }
}
