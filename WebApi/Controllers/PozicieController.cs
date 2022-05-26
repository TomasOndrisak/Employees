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
        private readonly PozicieService _context;

        public PozicieController(PozicieService context)
        {
            _context = context;
        }

        // GET: api/Pozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pozicie>>> GetPozicie()
        {
            var get = await _context.GetPozicieService();
            return Ok(get);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozicie>> GetPozicie(int id)
        {
            var getId = await _context.GetPozicieService(id);
            return Ok(getId);
        }

        [HttpPut("{id}")]
        public async Task PutPozicie(int id, Pozicie pozicie)
        {
            await _context.PutPozicieService(id, pozicie);
           
        }

        [HttpPost]
        public async Task PostPozicie(Pozicie pozicie)
        {
           await _context.PostPozicieService(pozicie);
            
        }

        [HttpDelete]
        public async Task DeletePozicie(int id)
        {
            await _context.DeletePozicieService(id);
        }
        
    }
}
