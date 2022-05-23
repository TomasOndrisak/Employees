﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Repositories;
using Infrastruktura.Models;


namespace Infrastruktura.Repositories
{
    public class PozicieRepository
    {
        private readonly ZamestnanciContext _context;

        public PozicieRepository(ZamestnanciContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Pozicie>> GetPozicieRepo()
        {
            return await _context.Pozicie.ToListAsync();
        }

        public async Task<Pozicie> GetPozicieRepo(int id)
        {
            var pozicie = await _context.Pozicie.FindAsync(id);
            return pozicie;
        }


        public async Task PutPozicieRepo(int id, Pozicie pozicie)
        {
           

            _context.Entry(pozicie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozicieExists(id))
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "Nespravne ID");
                }
                
            }

           
        }
        private bool PozicieExists(int id)
        {
            return _context.Pozicie.Any(e => e.PoziciaId == id);
        }
        public async Task PostPozicieRepo(Pozicie pozicie)
        {
            _context.Pozicie.Add(pozicie);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePozicieRepo(int id)
        {
            
            var pozicie = await _context.Pozicie.FindAsync(id);
            
         /*  var query = from q in _context.Zamestnanci
                        where q.IdPozicie==id
                        select q;
        */
            var qeuryy =  _context.Zamestnanci.Any(e => e.IdPozicie == id);
            
            
            if (!qeuryy) 
            {
                _context.Pozicie.Remove(pozicie);
            }
            else
            {
                  throw new ArgumentOutOfRangeException(nameof(id), "Poziciu nemozes zmazat pretoze je priradena zamestnancovi");
            }
            
            await _context.SaveChangesAsync();
        }


        /*   
         *   Predosle
         *   
         *   public async Task<IActionResult> PutPozicie(int id, Pozicie pozicie)
             {
                 if (id != pozicie.Id)
                 {
                     return BadRequest();
                 }

                 _context.Entry(pozicie).State = EntityState.Modified;

                 try
                 {
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!PozicieExists(id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }

                 return NoContent();
             }*/
        /*

        public async Task<ActionResult<Pozicie>> PostPozicie(Pozicie pozicie)
        {
            _context.Pozicie.Add(pozicie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPozicie", new { id = pozicie.Id }, pozicie);
        }
        public async Task<IActionResult> DeletePozicie(int id)
        {
            var pozicie = await _context.Pozicie.FindAsync(id);
            if (pozicie == null)
            {
                return NotFound();
            }

            _context.Pozicie.Remove(pozicie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PozicieExists(int id)
        {
            return _context.Pozicie.Any(e => e.Id == id);
        }*/
    }
}
