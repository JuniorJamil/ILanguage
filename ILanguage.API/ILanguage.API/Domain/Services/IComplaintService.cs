using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services
{
    public interface IComplaintService
    {
        Task<IEnumerable<Complaint>> ListAsync();
        Task<ComplaintResponse> SaveAsync(Complaint complaint);

        Task<ComplaintResponse> UpdateAsync(int id, Complaint complaint);

        Task<ComplaintResponse> DeleteAsync(int id);



    }



}