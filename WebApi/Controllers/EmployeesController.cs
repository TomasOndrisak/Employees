using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;
using Infrastruktura.Repositories;
using Application.Services;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _context;

        public EmployeesController(EmployeeService context) //dependency injection to EmployeeService
        {
            _context = context;
        }
           
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            var get = await _context.Get();
            return Ok(get);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployeesById(int id)
        {
               var employeesId = await _context.GetId(id);
                return Ok(employeesId);
        }

                // GET: api/Zamestnanci/archivovany/true
        [HttpGet("archived/{archived}")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetArchivedEmployees(bool archived)
        {
               var archivedEmployee = await _context.GetArchived(archived);
                return Ok(archivedEmployee);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Employees>> Put(int id, Employees employees)
        {
            
              await _context.Put(id, employees);
              return Ok();
        }
       
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees employees)
        {
              
            if (employees.DateOfBirth < new DateTime(2004, 1, 1) && employees.DateOfEntry >= DateTime.Now.Date)
            {
              await _context.Post(employees);
              return Ok();
            }
            
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployee(int id, bool archive)
        {
              await _context.Delete(id, archive);
              return Ok();
        }

        [HttpPut("/archive/{id}")]
        public async Task<ActionResult<Employees>> Archivuj(int id, Employees employees)
        {
            await _context.Archive(id, employees);
            return Ok();
        }
        
    }
}
