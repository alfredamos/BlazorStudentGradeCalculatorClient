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
    public class SQLScoreRepository : IScoreRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SQLScoreRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public async Task AddEntities(List<HWScore> newEntities)
        {
            await _context.HWScores.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<HWScore> AddEntity(HWScore newEntity)
        {
            var score = await _context.HWScores.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return score.Entity;
        }

        public async Task<HWScore> DeleteEntity(int id)
        {
            var scoreToDelete = await _context.HWScores.FindAsync(id);

            if (scoreToDelete != null)
            {
                _context.HWScores.Remove(scoreToDelete);
                await _context.SaveChangesAsync();
            }

            return scoreToDelete;
        }

        public async Task<IEnumerable<HWScore>> GetAll()
        {
            return await _context.HWScores.ToListAsync();
        }

        public async Task<HWScore> GetById(int id)
        {
            return await _context.HWScores.FindAsync(id);
        }

        public async Task<IEnumerable<HWScore>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.HWScores.ToListAsync();
            }

            return await _context.HWScores.Where(x => x.SubjectName.Contains(searchKey) ||
                         x.SubjectScoreInLetter.Contains(searchKey)).ToListAsync();
        }

        public async Task UpdateEntities(List<HWScore> scores)
        {
            _context.HWScores.UpdateRange(scores);
            await _context.SaveChangesAsync();
        }

        public async Task<HWScore> UpdateEntity(HWScore updatedEntity)
        {
            var result = await _context.HWScores.FirstOrDefaultAsync(x => x.HWScoreID == updatedEntity.HWScoreID);

            _mapper.Map(updatedEntity, result);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
