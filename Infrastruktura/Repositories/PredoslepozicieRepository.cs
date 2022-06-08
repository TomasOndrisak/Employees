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
 
    public class PredoslepozicieRepository
    {
        private readonly ZamestnanciContext _context;

        public PredoslepozicieRepository(ZamestnanciContext context)
        {
            _context = context;
        }

        
        public async Task <IEnumerable<PredoslePozicie>> GetPredoslepozicie()
        {
            return await _context.Predoslepozicie.Include(e => e.Pozicie).ToListAsync();

        }

 
        public async Task <IEnumerable<PredoslePozicie>> GetPredoslepozicie(int idZamestnanca)
        {
            //return await _context.Predoslepozicie.Where(id => id.ZamestnanecId == idZamestnanca).ToListAsync();
            return  await _context.Predoslepozicie.Include(e => e.Pozicie).Where(id => id.ZamestnanecId == idZamestnanca).ToListAsync();
        }



        public async Task PutPredoslepozicie(int id, PredoslePozicie Predoslepozicie)
        {
            _context.Entry(Predoslepozicie).State = EntityState.Modified;
            await _context.SaveChangesAsync();    
        }


        public async Task PostPredoslepozicie(PredoslePozicie Predoslepozicie)
        {
            _context.Predoslepozicie.Add(Predoslepozicie);
            await _context.SaveChangesAsync();

                   
        }
        public async Task DeletePredoslepozicie(int id)
        {
            var Predoslepozicie = await _context.Predoslepozicie.FindAsync(id);
            _context.Predoslepozicie.Remove(Predoslepozicie);
            await _context.SaveChangesAsync();
        }

        private bool PredoslepozicieExists(int id)
        {
            return _context.Predoslepozicie.Any(e => e.ZamestnanecId == id);
        }
    }
}
