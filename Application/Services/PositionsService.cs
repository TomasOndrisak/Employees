using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastruktura.Models;
using Infrastruktura.Repositories;

namespace Application.Services
{
    public class PositionsService
    {
        private readonly PositionsRepository _positionsRepository;

        public PositionsService(PositionsRepository PositionsRepository)
        {
            this._positionsRepository = PositionsRepository;
        }
        public async Task<IEnumerable<Positions>> GetPositionsService()
        {
             return await _positionsRepository.GetPositionsRepository();
        }

        public async Task<Positions> GetPositionsService(int id)
        {
            return await _positionsRepository.GetPositionsByIdRepository(id);
        }
        public async Task PostPositionsService(Positions positions)
        {
            await _positionsRepository.PostPositionsRepository(positions);
        }
        public async Task PutPositionsService(int id, Positions positions)
        {
            await _positionsRepository.PutPositionsRepository(id, positions);
        }
        public async Task DeletePositionsService(int id)
        {
            await _positionsRepository.DeletePositionsRepository(id);
        }

    }
}
