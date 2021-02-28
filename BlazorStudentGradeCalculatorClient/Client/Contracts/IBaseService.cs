using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Contracts
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string searchKey = null);
        Task<T> GetById(int id);
        Task<T> AddEntity(T newEntity);
        Task<T> UpdateEntity(T updatedEntity);
        Task DeleteEntity(int id);

    }
}
