using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;

namespace Infrastruktura.Repositories
{
    public class ZamestnanecRepository
    {
        private readonly ZamestnanciContext _context;

        public ZamestnanecRepository(ZamestnanciContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zamestnanci>> GetZamestnanci()
        {
            var a = await _context.Zamestnanci.Include(e => e.Pozicie).ToListAsync();
            return a;

        }

        public async Task<Zamestnanci> GetZamestnanciId(int id)
        {
            var Zamestnanci = await _context.Zamestnanci.Include(e => e.Pozicie).FirstOrDefaultAsync(e => e.ZamestnanecId == id);
            return Zamestnanci;

        }
        // GET ARCHIVOVANY, NEARCHIVOVANY
        public async Task<IEnumerable<Zamestnanci>> GetArchivovany(bool Archivovany)
        {

            if (Archivovany)
            {
                var ArchivovanyZam = from zam in _context.Zamestnanci
                                     where zam.Archivovany == true
                                     select zam;

                return await ArchivovanyZam.Include(e => e.Pozicie).ToListAsync();
            }
            else
            {
                var ArchivovanyZam = from zam in _context.Zamestnanci
                                     where zam.Archivovany == false
                                     select zam;
                return await ArchivovanyZam.Include(e => e.Pozicie).ToListAsync();
            }




        }
        // arch nearch
        public async Task Archivuj(int id, Zamestnanci zamestnanci)
        {


            zamestnanci.Archivovany = true;
            _context.Entry(zamestnanci).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task Put(int id, Zamestnanci zamestnanci)
        {


            var zamestnanecPred = zamestnanci.PoziciaId;


            try
            {



                var zamestnanecPo = _context.Zamestnanci.Include(e => e.Pozicie).Where(q => q.ZamestnanecId == id).Select(x => x.PoziciaId).SingleOrDefault();
                
                _context.Entry(zamestnanci).State = EntityState.Modified;





                if (zamestnanecPred != zamestnanecPo)
                {
                    _context.Predoslepozicie.Add(new PredoslePozicie { ZamestnanecId = zamestnanci.ZamestnanecId, PoziciaId = zamestnanci.PoziciaId, DatumNastupu = zamestnanci.DatumNastupu, DatumUkoncenia = DateTime.Now });

                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamestnanciExists(id))
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "Nespravne ID");
                }
            }
        }

        private bool ZamestnanciExists(int id)
        {
            return _context.Zamestnanci.Any(e => e.ZamestnanecId == id);
        }

        public async Task PostZamestnanci(Zamestnanci zamestnanci)
        {
            DateTime StartDate = new DateTime(2004, 1, 1);
            DateTime StartNastupu = DateTime.Now.Date;
            
            if(zamestnanci.DatumNarodenia < StartDate && zamestnanci.DatumNastupu >= StartNastupu)
            {
                _context.Zamestnanci.Add(zamestnanci);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteZamestnanci(int id, bool archivovat)
        {

            var zamestnanci = await _context.Zamestnanci.FindAsync(id);

            if (archivovat)
            {
                zamestnanci.Archivovany = true;
            }
            else
            {
                _context.Zamestnanci.Remove(zamestnanci);
                var predosle = _context.Predoslepozicie.Where(x => x.ZamestnanecId == id).ToList();
                foreach(var Predosla in predosle)
                {
                    _context.Predoslepozicie.Remove(Predosla);
                }
            }

            await _context.SaveChangesAsync();
        }


    }
}
