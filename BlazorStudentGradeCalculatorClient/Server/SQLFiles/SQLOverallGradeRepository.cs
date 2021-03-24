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
    public class SQLOverallGradeRepository : IOverallGradeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLOverallGradeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddEntities(List<OverallGrade> newEntities)
        {
            await _context.OverallGrades.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<OverallGrade> AddEntity(OverallGrade newEntity)
        {
            var overallGrade = await _context.OverallGrades.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return overallGrade.Entity;
        }

        public async Task<OverallGrade> DeleteEntity(int id)
        {
            var overallGradeToDelete = await _context.OverallGrades.FindAsync(id);

            if (overallGradeToDelete != null)
            {
                _context.OverallGrades.Remove(overallGradeToDelete);
                await _context.SaveChangesAsync();
            }

            return overallGradeToDelete;
        }

        public async Task<IEnumerable<OverallGrade>> GetAll()
        {
            return await _context.OverallGrades.ToListAsync();
        }

        public async Task<OverallGrade> GetById(int id)
        {
            return await _context.OverallGrades.
                         FirstOrDefaultAsync(x => x.OverallGradeID == id);
        }

        public async Task<OverallGrade> LookUp(string searchKey)
        {
            return await _context.OverallGrades.FirstOrDefaultAsync(x => x.SchoolIdNumber.Contains(searchKey) ||
                         x.StudentName.Contains(searchKey) || x.SubjectScoreInLetter.Contains(searchKey)
                         || x.SubjectName.Contains(searchKey));
        }

        public async Task<IEnumerable<OverallGrade>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.OverallGrades.ToListAsync();
            }

            return await _context.OverallGrades
                          .Where(x => x.StudentName.Contains(searchKey) ||
                          x.SubjectName.Contains(searchKey) || x.SubjectScoreInLetter
                          .Contains(searchKey) || x.SchoolIdNumber.Contains(searchKey)).ToListAsync();

        }

        public async Task UpdateEntities(List<OverallGrade> overallGrades)
        {
            _context.OverallGrades.UpdateRange(overallGrades);
            await _context.SaveChangesAsync();
        }

        public async Task<OverallGrade> UpdateEntity(OverallGrade updatedEntity)
        {
            var overallGrade = await _context.OverallGrades.FirstOrDefaultAsync(x => x.OverallGradeID == updatedEntity.OverallGradeID);

            _mapper.Map(updatedEntity, overallGrade);

            await _context.SaveChangesAsync();

            return overallGrade;
        }
    }
}
