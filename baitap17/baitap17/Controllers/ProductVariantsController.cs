using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using baitap17.Models;

namespace baitap17.Controllers
{
    public class ProductVariantsController : Controller
    {
        private readonly SanPhamDbContext _context;

        public ProductVariantsController(SanPhamDbContext context)
        {
            _context = context;
        }

        // GET: ProductVariants
        public async Task<IActionResult> Index()
        {
            var sanPhamDbContext = _context.ProductVariants.Include(p => p.Product);
            return View(await sanPhamDbContext.ToListAsync());
        }

        // GET: ProductVariants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductVariants == null)
            {
                return NotFound();
            }

            var productVariant = await _context.ProductVariants
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.VariantId == id);
            if (productVariant == null)
            {
                return NotFound();
            }

            return View(productVariant);
        }

        // GET: ProductVariants/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "SanPhamId", "SanPhamId");
            return View();
        }

        // POST: ProductVariants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VariantId,ProductId,ScreenSize,Ram,Storage,Cpu,Color,Price")] ProductVariant productVariant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productVariant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "SanPhamId", "SanPhamId", productVariant.ProductId);
            return View(productVariant);
        }

        // GET: ProductVariants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductVariants == null)
            {
                return NotFound();
            }

            var productVariant = await _context.ProductVariants.FindAsync(id);
            if (productVariant == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "SanPhamId", "SanPhamId", productVariant.ProductId);
            return View(productVariant);
        }

        // POST: ProductVariants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VariantId,ProductId,ScreenSize,Ram,Storage,Cpu,Color,Price")] ProductVariant productVariant)
        {
            if (id != productVariant.VariantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productVariant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductVariantExists(productVariant.VariantId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "SanPhamId", "SanPhamId", productVariant.ProductId);
            return View(productVariant);
        }

        // GET: ProductVariants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductVariants == null)
            {
                return NotFound();
            }

            var productVariant = await _context.ProductVariants
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.VariantId == id);
            if (productVariant == null)
            {
                return NotFound();
            }

            return View(productVariant);
        }

        // POST: ProductVariants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductVariants == null)
            {
                return Problem("Entity set 'SanPhamDbContext.ProductVariants'  is null.");
            }
            var productVariant = await _context.ProductVariants.FindAsync(id);
            if (productVariant != null)
            {
                _context.ProductVariants.Remove(productVariant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductVariantExists(int id)
        {
          return (_context.ProductVariants?.Any(e => e.VariantId == id)).GetValueOrDefault();
        }
    }
}
