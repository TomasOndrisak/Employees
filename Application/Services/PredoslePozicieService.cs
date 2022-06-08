using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Repositories;
using Infrastruktura.Models;

namespace Application.Services
{
    public class PredoslePozicieService
    {
        private readonly PredoslepozicieRepository _predoslepozicieRepository;

        public PredoslePozicieService(PredoslepozicieRepository predoslepozicieRepository)
        {
            this._predoslepozicieRepository = predoslepozicieRepository;
        }

        public async Task <IEnumerable<PredoslePozicie>> GetPredoslePozicieServ()
        {
            return await _predoslepozicieRepository.GetPredoslepozicie();
        }

        public async Task <IEnumerable<PredoslePozicie>> GetPredoslePozicieServ(int idZamestnanca)
        {
            return await _predoslepozicieRepository.GetPredoslepozicie(idZamestnanca);
        }
        public async Task PostPredoslePozicieServ(PredoslePozicie predoslepozicie)
        {
            await _predoslepozicieRepository.PostPredoslepozicie(predoslepozicie);
        }
        public async Task PutPredoslePozicieServ(int id, PredoslePozicie predoslepozicie)
        {
            await _predoslepozicieRepository.PutPredoslepozicie(id, predoslepozicie);
        }
        public async Task DeletePredoslePozicieServ(int id)
        {
            await _predoslepozicieRepository.DeletePredoslepozicie(id);
        }


    }
}
