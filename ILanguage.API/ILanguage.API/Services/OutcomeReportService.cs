using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Repositories;
using ILanguage.API.Domain.Services;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Services
{
    public class OutcomeReportService : IOutcomeReportService
    {
        private readonly IOutcomeReportRepository _outcomeReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OutcomeReportService(IOutcomeReportRepository outcomeReportRepository, IUnitOfWork unitOfWork)
        {
            _outcomeReportRepository = outcomeReportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OutcomeReport>> ListAsync()
        {
            return await _outcomeReportRepository.ListAsync();
        }

        public async Task<IEnumerable<OutcomeReport>> ListBySessionIdAsync(int sessionId)
        {
            return await _outcomeReportRepository.ListBySessionIdAsync(sessionId);
        }


        public async Task<OutcomeReportResponse> GetByIdAsync(int id)
        {
            var existingOutcomeReport = await _outcomeReportRepository.FindById(id);

            if (existingOutcomeReport == null)
                return new OutcomeReportResponse("OutcomeReport not found");
            return new OutcomeReportResponse(existingOutcomeReport);
        }


        public async Task<OutcomeReportResponse> SaveAsync(OutcomeReport outcomeReport)
        {
            try
            {
                await _outcomeReportRepository.AddAsync(outcomeReport);
                await _unitOfWork.CompleteAsync();

                return new OutcomeReportResponse(outcomeReport);
            }
            catch (Exception ex)
            {
                return new OutcomeReportResponse($"An error ocurred while saving outcomeReport: {ex.Message}");
            }
        }

        public async Task<OutcomeReportResponse> UpdateAsync(int id, OutcomeReport outcomeReport)
        {
            var existingOutcomeReport = await _outcomeReportRepository.FindById(id);
            if (existingOutcomeReport == null)
                return new OutcomeReportResponse("OutcomeReport not found");

            existingOutcomeReport.Description = outcomeReport.Description;

            try
            {
                _outcomeReportRepository.Update(existingOutcomeReport);
                await _unitOfWork.CompleteAsync();

                return new OutcomeReportResponse(existingOutcomeReport);
            }
            catch (Exception ex)
            {
                return new OutcomeReportResponse($"An error ocurred while updating OutcomeReport: {ex.Message}");
            }
        }


        public async Task<OutcomeReportResponse> DeleteAsync(int id)
        {
            var existingOutcomeReport = await _outcomeReportRepository.FindById(id);

            if (existingOutcomeReport == null)
                return new OutcomeReportResponse("OutcomeReport not found");

            try
            {
                _outcomeReportRepository.Remove(existingOutcomeReport);
                await _unitOfWork.CompleteAsync();

                return new OutcomeReportResponse(existingOutcomeReport);
            }
            catch (Exception ex)
            {
                return new OutcomeReportResponse($"An error ocurred while deleting outcomeReport: {ex.Message}");
            }
        }
    }
}
