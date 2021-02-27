using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string searchKey = null);
        Task<T> GetById(int id);
        Task<T> AddEntity(T newEntity);
        Task<T> UpdateEntity(T updatedEntity);
        Task<T> DeleteEntity(int id);
        
    }
}
