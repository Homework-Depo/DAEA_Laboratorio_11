using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab11;

namespace Lab11.Controllers
{
  public class ProductController : Controller
  {
    private readonly DemoContext _context;

    public ProductController(DemoContext context)
    {
      _context = context;
    }

    // GET: Product
    public async Task<IActionResult> Index()
    {
      var activeProducts = _context.Products.Where(p => p.Active);
      return View(await activeProducts.ToListAsync());
    }

    // GET: Product/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Products
          .FirstOrDefaultAsync(m => m.ProductId == id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // GET: Product/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Product/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProductId,Name,Price,Active")] Product product)
    {
      if (ModelState.IsValid)
      {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(product);
    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Products.FindAsync(id);
      if (product == null)
      {
        return NotFound();
      }
      return View(product);
    }

    // POST: Product/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Price")] Product product)
    {
      if (id != product.ProductId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(product);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProductExists(product.ProductId))
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
      return View(product);
    }

    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Products
          .FirstOrDefaultAsync(m => m.ProductId == id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var product = await _context.Products.FindAsync(id);
      if (product == null)
      {
        return NotFound();
      }
      product.Active = false;

      _context.Products.Update(product);

      await _context.SaveChangesAsync();

      return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id)
    {
      return _context.Products.Any(e => e.ProductId == id);
    }
  }
}
