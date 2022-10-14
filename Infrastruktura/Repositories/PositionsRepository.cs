using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;


namespace Infrastruktura.Repositories
{
    public class PositionsRepository
    {
        private readonly EmployeesDbContext _context;

        public PositionsRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Positions>> GetPositionsRepository()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Positions> GetPositionsByIdRepository(int id)
        {
            var positions = await _context.Positions.FindAsync(id);
            return positions;
        }


        public async Task PutPositionsRepository(int id, Positions positions)
        {
           

            _context.Entry(positions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionsExist(id))
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "Wrong ID inserted");
                }
                
            }

           
        }
        private bool PositionsExist(int id)
        {
            return _context.Positions.Any(e => e.PositionId == id);
        }
        public async Task PostPositionsRepository(Positions positions)
        {
            _context.Positions.Add(positions);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePositionsRepository(int id)
        {
            
            var positions = await _context.Positions.FindAsync(id);
            
         
            var query =  _context.Employees.Any(e => e.PositionId == id);
            
            
            if (!query) 
            {
                _context.Positions.Remove(positions);
            }
            else
            {
                  
                  
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
