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
    public class LastPositionsController : ControllerBase
    {
        private readonly LastPositionsService _context;

        public LastPositionsController(LastPositionsService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LastPositions>>> GetLastPositons()
        {
            var get = await _context.GetLastPositionsService();
            return Ok(get);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<IEnumerable<LastPositions>>> GetLastPositionById(int employeeId)
        {
            var lastPositions = await _context.GetLastPositionsByIdService(employeeId);
            return Ok(lastPositions);   
        }

        [HttpPut("{id}")]
        public async Task PutPredoslepozicieControler(int id, LastPositions Predoslepozicie)
        {
            await _context.PutLastPositionsService(id, Predoslepozicie);
        }

        [HttpPost]
        public async Task PostLastPositions(LastPositions lastPositions)
        {
            await _context.PostLastPositionsService(lastPositions);

        }

        [HttpDelete("{id}")]
        public async Task DeleteLastPositions(int id)
        {
            await _context.DeleteLastPositionsService(id);            
        }
    }
}
