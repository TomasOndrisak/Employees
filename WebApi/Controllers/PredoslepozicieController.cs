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
    public class PredoslepozicieController : ControllerBase
    {
        private readonly PredoslePozicieService _context;

        public PredoslepozicieController(PredoslePozicieService context)
        {
            _context = context;
        }

        // GET: api/Predoslepozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Predoslepozicie>>> GetPredoslepozicie()
        {
            var get = await _context.GetPredoslePozicieServ();
           
            return Ok(get);

        }

        // GET: api/Predoslepozicie/5
        [HttpGet("{idZamestnanca}")]
        public async Task<ActionResult<IEnumerable<Predoslepozicie>>> GetId(int idZamestnanca)
        {
            var Predoslepozicie = await _context.GetPredoslePozicieServ(idZamestnanca);

            return Ok(Predoslepozicie);

            
        }

    

        // PUT: api/Predoslepozicie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutPredoslepozicieControler(int id, Predoslepozicie Predoslepozicie)
        {
            await _context.PutPredoslePozicieServ(id, Predoslepozicie);

            
        }

        // POST: api/Predoslepozicie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostPredoslepozicie(Predoslepozicie Predoslepozicie)
        {
            await _context.PostPredoslePozicieServ(Predoslepozicie);

        }
        

        // DELETE: api/Predoslepozicie/5
        [HttpDelete("{id}")]
        public async Task DeletePredoslepozicie(int id)
        {
            await _context.DeletePredoslePozicieServ(id);

            
        }

        
    }
}
