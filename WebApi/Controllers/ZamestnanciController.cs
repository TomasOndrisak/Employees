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
    public class ZamestnanciController : ControllerBase
    {
        private readonly EmployeeService _context;

        public ZamestnanciController(EmployeeService context) //dependency injection na ZamestnanecService
        {
            _context = context;
        }

        // GET: api/Zamestnanci
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetZamestnanci()
        {
            var get = await _context.Get();
            return Ok(get);
            

        }

        // GET: api/Zamestnanci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetZamestnanci(int id)
        {
               var zamestnanciId = await _context.GetId(id);
                return Ok(zamestnanciId);
        }

                // GET: api/Zamestnanci/archivovany/true
        [HttpGet("archivovany/{Archivovany}")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetZamestnanciArchivovany(bool Archivovany)
        {
               var zamestnanciArch = await _context.GetArchived(Archivovany);
                return Ok(zamestnanciArch);
        }
        

        // PUT: api/Zamestnanci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Employees>> Put(int id, Employees zamestnanci)
        {
            
              await _context.Put(id, zamestnanci);
              return Ok();
            

        }
       

        // POST: api/Zamestnanci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employees>> PostZamestnanci(Employees zamestnanci)
        {
              
            if (zamestnanci.DateOfBirth < new DateTime(2004, 1, 1) && zamestnanci.DateOfEntry >= DateTime.Now.Date)
            {
              await _context.Post(zamestnanci);
              return Ok();
            }
              else return BadRequest();

        }

        // DELETE: api/Zamestnanci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> DeleteZamestnanci(int id, bool archivovat)
        {
              await _context.Delete(id, archivovat);
              return Ok();
        }
        //archivuj
        [HttpPut("/archivuj/{id}")]
        public async Task<ActionResult<Employees>> Archivuj(int id, Employees zamestnanci)
        {
            await _context.Archive(id, zamestnanci);
            return Ok();
        }
        
    }
}
