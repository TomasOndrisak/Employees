using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastruktura.Repositories;
using Infrastruktura.Models;

namespace Application.Services
{
    public class LastPositionsService
    {
        private readonly LastPositionsRepository _lastPositionsRepository;

        public LastPositionsService(LastPositionsRepository lastPositionsRepository)
        {
            this._lastPositionsRepository = lastPositionsRepository;
        }

        public async Task <IEnumerable<LastPositions>> GetLastPositionsService()
        {
            return await _lastPositionsRepository.GetLastPositions();
        }

        public async Task <IEnumerable<LastPositions>> GetLastPositionsByIdService(int employeeId)
        {
            return await _lastPositionsRepository.GetLastPositionsById(employeeId);
        }
        public async Task PostLastPositionsService(LastPositions lastPositions)
        {
            await _lastPositionsRepository.PostLastPositions(lastPositions);
        }
        public async Task PutLastPositionsService(int id, LastPositions lastPositions)
        {
            await _lastPositionsRepository.PutLastPositions(id, lastPositions);
        }
        public async Task DeleteLastPositionsService(int id)
        {
            await _lastPositionsRepository.DeleteLastPositions(id);
        }

    }
}
