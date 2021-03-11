using AutoMapper;
using BlazorStudentGradeCalculatorClient.Server.Contracts;
using BlazorStudentGradeCalculatorClient.Server.Data;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.SQLFiles
{
    public class SQLExammRepository : IExammRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLExammRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddEntities(List<Examm> newEntities)
        {
            await _context.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<Examm> AddEntity(Examm newEntity)
        {
            var examm = await _context.Examms.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return examm.Entity;
        }

        public async Task<Examm> DeleteEntity(int id)
        {
            var exammToDelete = await _context.Examms.FindAsync(id);

            if (exammToDelete != null)
            {
                _context.Examms.Remove(exammToDelete);
                await _context.SaveChangesAsync();
            }

            return exammToDelete;
        }

        public async Task<IEnumerable<Examm>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.Examms.ToListAsync();
            }

            return await _context.Examms.Where(ex =>
                         ex.SchoolIdNumber.Contains(searchKey) || ex.StudentName.Contains(searchKey) ||
                         ex.SubjectName.Contains(searchKey) || ex.SubjectScoreInLetter.Contains(searchKey)
                         ).ToListAsync();
        }

        public async Task<IEnumerable<Examm>> GetAll()
        {           
            return await _context.Examms.ToListAsync();
        
        }

        public async Task<Examm> GetById(int id)
        {
            return await _context.Examms.FirstOrDefaultAsync(ex => ex.ExammID == id);
        }

        public async Task<Examm> UpdateEntity(Examm updatedEntity)
        {          
            var result = await _context.Examms.FirstOrDefaultAsync(ex => ex.ExammID == updatedEntity.ExammID);

            _mapper.Map(updatedEntity, result);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task UpdateEntities(List<Examm> examms)
        {
            _context.Examms.UpdateRange(examms);
            await _context.SaveChangesAsync();
        }
    }
}
