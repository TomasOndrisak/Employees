using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastruktura.Models;
using Application.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly PositionsService _context;

        public PositionsController(PositionsService context)
        {
            _context = context;
        }

        // GET: api/Pozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positions>>> GetPositions()
        {
            var get = await _context.GetPositionsService();
            return Ok(get);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Positions>> GetPositionsById(int id)
        {
            var getId = await _context.GetPositionsService(id);
            return Ok(getId);
        }

        [HttpPut("{id}")]
        public async Task PutPositions(int id, Positions positions)
        {
            await _context.PutPositionsService(id, positions);
           
        }

        [HttpPost]
        public async Task PostPositions(Positions positions)
        {
           await _context.PostPositionsService(positions);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePositions(int id)
        {
            await _context.DeletePositionsService(id);
            return Ok(id);
           
                  
        }
        
    }
}
