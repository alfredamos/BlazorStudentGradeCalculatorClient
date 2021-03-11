using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Search(string searchKey);
        Task<T> GetById(int id);
        Task<T> AddEntity(T newEntity);
        Task AddEntities(List<T> newEntities);
        Task<T> UpdateEntity(T updatedEntity);
        Task UpdateEntities(List<T> examms);
        Task<T> DeleteEntity(int id);
        
    }
}
