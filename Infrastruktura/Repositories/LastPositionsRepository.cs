using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;


namespace Infrastruktura.Repositories
{
 
    public class LastPositionsRepository
    {
        private readonly EmployeesDbContext _context;

        public LastPositionsRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        
        public async Task <IEnumerable<LastPositions>> GetLastPositions()
        {
            return await _context.LastPositions.Include(e => e.Positions).ToListAsync();

        }

 
        public async Task <IEnumerable<LastPositions>> GetLastPositionsById(int EmployeeId)
        {
            return  await _context.LastPositions.Include(e => e.Positions).Where(id => id.EmployeeId == EmployeeId).ToListAsync();
        }



        public async Task PutLastPositions(int id, LastPositions LastPositions)
        {
            _context.Entry(LastPositions).State = EntityState.Modified;
            await _context.SaveChangesAsync();    
        }


        public async Task PostLastPositions(LastPositions LastPositions)
        {
            _context.LastPositions.Add(LastPositions);
            await _context.SaveChangesAsync();

                   
        }
        public async Task DeleteLastPositions(int id)
        {
            var lastPositions = await _context.LastPositions.FindAsync(id);
            _context.LastPositions.Remove(lastPositions);
            await _context.SaveChangesAsync();
        }

        private bool LastPositionsExists(int id)
        {
            return _context.LastPositions.Any(e => e.EmployeeId == id);
        }
    }
}
