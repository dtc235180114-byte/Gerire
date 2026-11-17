
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gerire.Models;

public class gerireController : Controller
{
    private readonly GerireContext _context;

    public gerireController(GerireContext context)
    {
        _context = context;
    }

    // GET: GERIRES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.gerire.ToListAsync());
    }

    // GET: GERIRES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var gerire = await _context.gerire
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gerire == null)
        {
            return NotFound();
        }

        return View(gerire);
    }

    // GET: GERIRES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GERIRES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Movies")] gerire gerire)
    {
        if (ModelState.IsValid)
        {
            _context.Add(gerire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(gerire);
    }

    // GET: GERIRES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var gerire = await _context.gerire.FindAsync(id);
        if (gerire == null)
        {
            return NotFound();
        }
        return View(gerire);
    }

    // POST: GERIRES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Movies")] gerire gerire)
    {
        if (id != gerire.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(gerire);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerireExists(gerire.Id))
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
        return View(gerire);
    }

    // GET: GERIRES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var gerire = await _context.gerire
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gerire == null)
        {
            return NotFound();
        }

        return View(gerire);
    }

    // POST: GERIRES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var gerire = await _context.gerire.FindAsync(id);
        if (gerire != null)
        {
            _context.gerire.Remove(gerire);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GerireExists(int? id)
    {
        return _context.gerire.Any(e => e.Id == id);
    }
}
