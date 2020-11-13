using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Repositories;
using ILanguage.API.Domain.Services;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILanguage.API.Services
{
    public class AvailableScheduleService : IAvailableScheduleService
    {
        private readonly IAvailableScheduleRepository _availableScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AvailableScheduleService(IAvailableScheduleRepository availableScheduleRepository, IUnitOfWork unitOfWork)
        {
            _availableScheduleRepository = availableScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AvailableSchedule>> ListByUserIdAsync(int userId)
        {
            return await _availableScheduleRepository.ListByUserIdAsync(userId);
        }

        public async Task<AvailableScheduleResponse> GetByIdAsync(int id)
        {
            var existingAvailableSchedule = await _availableScheduleRepository.FindById(id);

            if (existingAvailableSchedule == null)
                return new AvailableScheduleResponse("AvailableSchedule not found");
            return new AvailableScheduleResponse(existingAvailableSchedule);
        }

        public async Task<AvailableScheduleResponse> SaveAsync(AvailableSchedule availableSchedule)
        {
            try
            {
                await _availableScheduleRepository.AddAsync(availableSchedule);
                await _unitOfWork.CompleteAsync();

                return new AvailableScheduleResponse(availableSchedule);
            }
            catch (Exception ex)
            {
                return new AvailableScheduleResponse($"An error ocurred while saving availableSchedule: {ex.Message}");
            }
        }

        public async Task<AvailableScheduleResponse> UpdateAsync(int userId, AvailableSchedule availableSchedule)
        {
            var existingAvailableSchedule = await _availableScheduleRepository.FindById(userId);
            if (existingAvailableSchedule == null)
                return new AvailableScheduleResponse("AvailableSchedule not found");

            existingAvailableSchedule.state = availableSchedule.state;

            try
            {
                _availableScheduleRepository.Update(existingAvailableSchedule);
                await _unitOfWork.CompleteAsync();

                return new AvailableScheduleResponse(existingAvailableSchedule);
            }
            catch (Exception ex)
            {
                return new AvailableScheduleResponse($"An error ocurred while updating availableSchedule: {ex.Message}");
            }
        }

        public async Task<AvailableScheduleResponse> DeleteAsync(int id)
        {
            var existingAvailableSchedule = await _availableScheduleRepository.FindById(id);

            if (existingAvailableSchedule == null)
                return new AvailableScheduleResponse("AvailableSchedule not found");

            try
            {
                _availableScheduleRepository.Remove(existingAvailableSchedule);
                await _unitOfWork.CompleteAsync();

                return new AvailableScheduleResponse(existingAvailableSchedule);
            }
            catch (Exception ex)
            {
                return new AvailableScheduleResponse($"An error ocurred while deleting availableSchedule: {ex.Message}");
            }
        }


    }
}
