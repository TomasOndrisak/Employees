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
        private readonly ZamestnanecService _context;

        public ZamestnanciController(ZamestnanecService context) //dependency injection na ZamestnanecService
        {
            _context = context;
        }

        // GET: api/Zamestnanci
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zamestnanci>>> GetZamestnanci()
        {
            var get = await _context.Get();
            return Ok(get);
            

        }

        // GET: api/Zamestnanci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zamestnanci>> GetZamestnanci(int id)
        {
               var zamestnanciId = await _context.GetId(id);
                return Ok(zamestnanciId);
        }

                // GET: api/Zamestnanci/archivovany/true
        [HttpGet("archivovany/{Archivovany}")]
        public async Task<ActionResult<IEnumerable<Zamestnanci>>> GetZamestnanciArchivovany(bool Archivovany)
        {
               var zamestnanciArch = await _context.GetArch(Archivovany);
                return Ok(zamestnanciArch);
        }
        

        // PUT: api/Zamestnanci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task Put(int id, Zamestnanci zamestnanci)
        {
              await _context.Put(id, zamestnanci);
        }
       

        // POST: api/Zamestnanci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostZamestnanci(Zamestnanci zamestnanci)
        {
              await _context.PostZamestnanci(zamestnanci);
        }

        // DELETE: api/Zamestnanci/5
        [HttpDelete("{id}")]
        public async Task DeleteZamestnanci(int id, bool archivovat)
        {
              await _context.DeleteZamestnanci(id, archivovat);
        }
        //archivuj
        [HttpPut("/archivuj/{id}")]
        public async Task Archivuj(int id, Zamestnanci zamestnanci)
        {
            await _context.Archivuj(id, zamestnanci);
        }
        
    }
}
