using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Repositories;
using ILanguage.API.Domain.Services;
using ILanguage.API.Domain.Services.Communication;
using ILanguage.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ResourceService(IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
        {
            _resourceRepository = resourceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _resourceRepository.ListAsync();
        }

        public async Task<IEnumerable<Resource>> ListBySessionIdAsync(int sessionId)
        {
            return await _resourceRepository.ListBySessionIdAsync(sessionId);
        }


        public async Task<ResourceResponse> GetByIdAsync(int id)
        {
            var existingResource = await _resourceRepository.FindById(id);

            if (existingResource == null)
                return new ResourceResponse("Resource not found");
            return new ResourceResponse(existingResource);
        }


        public async Task<ResourceResponse> SaveAsync(Resource resource)
        {
            try
            {
                await _resourceRepository.AddAsync(resource);
                await _unitOfWork.CompleteAsync();

                return new ResourceResponse(resource);
            }
            catch (Exception ex)
            {
                return new ResourceResponse($"An error ocurred while saving resource: {ex.Message}");
            }
        }

        public async Task<ResourceResponse> UpdateAsync(int id, Resource resource)
        {
            var existingResource = await _resourceRepository.FindById(id);
            if (existingResource == null)
                return new ResourceResponse("Resource not found");

            existingResource.Description = resource.Description;

            try
            {
                _resourceRepository.Update(existingResource);
                await _unitOfWork.CompleteAsync();

                return new ResourceResponse(existingResource);
            }
            catch (Exception ex)
            {
                return new ResourceResponse($"An error ocurred while updating Resource: {ex.Message}");
            }
        }


        public async Task<ResourceResponse> DeleteAsync(int id)
        {
            var existingResource = await _resourceRepository.FindById(id);

            if (existingResource == null)
                return new ResourceResponse("Resource not found");

            try
            {
                _resourceRepository.Remove(existingResource);
                await _unitOfWork.CompleteAsync();

                return new ResourceResponse(existingResource);
            }
            catch (Exception ex)
            {
                return new ResourceResponse($"An error ocurred while deleting resource: {ex.Message}");
            }
        }
    }
}
