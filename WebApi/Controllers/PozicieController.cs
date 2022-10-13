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
    public class PozicieController : ControllerBase
    {
        private readonly PositionsService _context;

        public PozicieController(PositionsService context)
        {
            _context = context;
        }

        // GET: api/Pozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positions>>> GetPozicie()
        {
            var get = await _context.GetPositionsService();
            return Ok(get);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Positions>> GetPozicie(int id)
        {
            var getId = await _context.GetPositionsService(id);
            return Ok(getId);
        }

        [HttpPut("{id}")]
        public async Task PutPozicie(int id, Positions pozicie)
        {
            await _context.PutPositionsService(id, pozicie);
           
        }

        [HttpPost]
        public async Task PostPozicie(Positions pozicie)
        {
           await _context.PostPositionsService(pozicie);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePozicie(int id)
        {
            await _context.DeletePositionsService(id);
            return Ok(id);
           
                  
        }
        
    }
}
