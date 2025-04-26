using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

public class EmployeesController : Controller
{
    private readonly EmployeeDBContext _context;

    public EmployeesController(EmployeeDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _context.Employees
            .Include(e => e.Department)
            .ToListAsync();
        return View(employees);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var employee = await _context.Employees
            .Include(e => e.Department)
            .FirstOrDefaultAsync(m => m.EmployeeId == id);
        if (employee == null) return NotFound();
        return View(employee);
    }
}