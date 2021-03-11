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
    public class SQLHomeWorkRepository : IHomeWorkRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLHomeWorkRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<HomeWork> AddEntity(HomeWork newEntity)
        {
            var examm = await _context.HomeWorks.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return examm.Entity;
        }

        public async Task AddEntities(List<HomeWork> newEntities)
        {
            await _context.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeWork> DeleteEntity(int id)
        {
            var homeWorkToDelete = await _context.HomeWorks.FindAsync(id);

            if (homeWorkToDelete != null)
            {
                _context.HomeWorks.Remove(homeWorkToDelete);
                await _context.SaveChangesAsync();
            }

            return homeWorkToDelete;
        }

        public async Task<IEnumerable<HomeWork>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.HomeWorks.ToListAsync();
            }

            return await _context.HomeWorks.Include(ex => ex.Scores).Where(ex =>
                         ex.SchoolIdNumber.Contains(searchKey) || ex.StudentName.Contains(searchKey) ||
                         ex.Scores.Any(hw => hw.SubjectName.Contains(searchKey)) || ex.Scores.Any(hw =>
                         hw.SubjectScoreInLetter.Contains(searchKey))).ToListAsync();

        }

        public async Task<IEnumerable<HomeWork>> GetAll()
        {            
            return await _context.HomeWorks.ToListAsync();            
        }

        public async Task<HomeWork> GetById(int id)
        {
            return await _context.HomeWorks.Include(ex => ex.Scores).FirstOrDefaultAsync(ex => ex.HomeWorkID == id);
        }

        public async Task<HomeWork> UpdateEntity(HomeWork updatedEntity)
        {
            var result = await _context.HomeWorks.FirstOrDefaultAsync(ex => ex.HomeWorkID == updatedEntity.HomeWorkID);

            _mapper.Map(updatedEntity, result);

            result.Scores = updatedEntity.Scores;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task UpdateEntities(List<HomeWork> homeWorks)
        {
            _context.HomeWorks.UpdateRange(homeWorks);
            await _context.SaveChangesAsync();
        }
    }
}
