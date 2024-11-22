using EmployeeDetailsWebAppMVCCore.Data;
using EmployeeDetailsWebAppMVCCore.Models;
using EmployeeDetailsWebAppMVCCore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsWebAppMVCCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EmployeeDbContext DbContext { get; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                id = Guid.NewGuid(),
                firstName = viewModel.firstName,
                lastName = viewModel.lastName,
                salary = viewModel.salary,
                eMail = viewModel.eMail,
                joiningDate = viewModel.joiningDate,
                project = viewModel.project
            };
            await dbContext.Employees.AddAsync(employee);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContext.Employees.FindAsync(viewModel.id);
            if (employee is not null)
            {
                employee.firstName = viewModel.firstName;
                employee.lastName = viewModel.lastName;
                employee.salary = viewModel.salary;
                employee.eMail = viewModel.eMail;
                employee.joiningDate = viewModel.joiningDate;
                employee.project = viewModel.project;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List","Employees");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel)
        {
            var employee = await dbContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == viewModel.id);

            if(employee is not null)
            {
                dbContext.Employees.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
    }
}
