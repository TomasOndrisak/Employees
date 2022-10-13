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
        private readonly LastPositionsService _context;

        public PredoslepozicieController(LastPositionsService context)
        {
            _context = context;
        }

        // GET: api/Predoslepozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LastPositions>>> GetPredoslepozicie()
        {
            var get = await _context.GetLastPositionsService();
           
            return Ok(get);

        }

        // GET: api/Predoslepozicie/5
        [HttpGet("{idZamestnanca}")]
        public async Task<ActionResult<IEnumerable<LastPositions>>> GetId(int idZamestnanca)
        {
            var Predoslepozicie = await _context.GetLastPositionsByIdService(idZamestnanca);

            return Ok(Predoslepozicie);

            
        }

    

        // PUT: api/Predoslepozicie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutPredoslepozicieControler(int id, LastPositions Predoslepozicie)
        {
            await _context.PutLastPositionsService(id, Predoslepozicie);

            
        }

        // POST: api/Predoslepozicie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostPredoslepozicie(LastPositions Predoslepozicie)
        {
            await _context.PostLastPositionsService(Predoslepozicie);

        }
        

        // DELETE: api/Predoslepozicie/5
        [HttpDelete("{id}")]
        public async Task DeletePredoslepozicie(int id)
        {
            await _context.DeleteLastPositionsService(id);

            
        }

        
    }
}
