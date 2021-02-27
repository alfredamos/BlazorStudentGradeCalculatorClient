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

        public async Task<IEnumerable<Examm>> GetAll(string searchKey = null)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.Examms.ToListAsync();
            }

            return await _context.Examms.Include(ex => ex.Score).Where(ex =>
                         ex.SchoolIdNumber.Contains(searchKey) || ex.StudentName.Contains(searchKey) ||
                         ex.Score.SubjectName.Contains(searchKey) || ex.Score.SubjectScoreInLetter.Contains(searchKey)
                         ).ToListAsync();
        }

        public async Task<Examm> GetById(int id)
        {
            return await _context.Examms.Include(ex => ex.Score).FirstOrDefaultAsync(ex => ex.ExammsID == id);
        }

        public async Task<Examm> UpdateEntity(Examm updatedEntity)
        {
            var result = await _context.Examms.FirstOrDefaultAsync(ex => ex.ExammsID == updatedEntity.ExammsID);

            _mapper.Map(updatedEntity, result);

            result.Score = updatedEntity.Score;

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
