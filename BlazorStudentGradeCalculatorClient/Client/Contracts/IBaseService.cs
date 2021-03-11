using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Contracts
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Search(string searchKey);
        Task<T> GetById(int id);
        Task<T> AddEntity(T newEntity);
        Task AddEntities(List<T> newEntities);
        Task<T> UpdateEntity(T updatedEntity);
        Task UpdateEntities(List<T> updatedEntities);
        Task DeleteEntity(int id);

    }
}
