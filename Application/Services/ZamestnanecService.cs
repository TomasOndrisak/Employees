 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Models;
using Infrastruktura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class ZamestnanecService
    {
        //DI
        private readonly ZamestnanecRepository zamestnanecRepository;
        public ZamestnanecService(ZamestnanecRepository zamestnanecRepository)
        {
            this.zamestnanecRepository = zamestnanecRepository;
        }
        //DI

        //GET FUNGUJE
        public Task <IEnumerable<Zamestnanci>> Get() {

            return zamestnanecRepository.GetZamestnanci();
        }
        public async Task<ActionResult<Zamestnanci>> GetId(int id)
        {
            return await zamestnanecRepository.GetZamestnanciId(id);
        }
        //GET FUNGUJE

        //PUT FUNGUJE
        public async Task Put(int id, Zamestnanci zamestnanci)
        {
             await zamestnanecRepository.Put(id, zamestnanci);

        }
        //PUT FUNGUJE

        //POST FUNGUJE
        public async Task PostZamestnanci(Zamestnanci zamestnanci)
        {
           await zamestnanecRepository.PostZamestnanci(zamestnanci);
           
        }
        //POST

        //DELETE
        public async Task DeleteZamestnanci(int id, bool archivovat)
        {
             await zamestnanecRepository.DeleteZamestnanci(id, archivovat);

        }
        //DELETE


        public async Task <IEnumerable<Zamestnanci>> GetArch(bool Archivovany)
        {
            return await zamestnanecRepository.GetArchivovany(Archivovany);
        }
        //archivuj
        public async Task Archivuj(int id, Zamestnanci zamestnanci)
        {
            await zamestnanecRepository.Archivuj(id,zamestnanci);
        }
       

    }

       

        
}   
