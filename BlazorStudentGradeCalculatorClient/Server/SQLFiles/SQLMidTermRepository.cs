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
    public class SQLMidTermRepository : IMidTermRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLMidTermRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MidTerm> AddEntity(MidTerm newEntity)
        {
            var examm = await _context.MidTerms.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return examm.Entity;
        }

        public async Task<MidTerm> DeleteEntity(int id)
        {
            var midTermToDelete = await _context.MidTerms.FindAsync(id);

            if (midTermToDelete != null)
            {
                _context.MidTerms.Remove(midTermToDelete);
                await _context.SaveChangesAsync();
            }

            return midTermToDelete;
        }

        public async Task<IEnumerable<MidTerm>> GetAll(string searchKey = null)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.MidTerms.Include(x => x.Score).ToListAsync();
            }

            return await _context.MidTerms.Include(x => x.Score).Where(ex =>
                         ex.SchoolIdNumber.Contains(searchKey) || ex.StudentName.Contains(searchKey) ||
                         ex.Score.SubjectName.Contains(searchKey) || ex.Score.SubjectScoreInLetter.Contains(searchKey)
                         ).ToListAsync();
        }

        public async Task<MidTerm> GetById(int id)
        {
            return await _context.MidTerms.Include(x => x.Score).FirstOrDefaultAsync(ex => ex.MidTermID == id);
        }

        public async Task<MidTerm> UpdateEntity(MidTerm updatedEntity)
        {
            var result = await _context.MidTerms.FirstOrDefaultAsync(ex => ex.MidTermID == updatedEntity.MidTermID);

            _mapper.Map(updatedEntity, result);

            await _context.SaveChangesAsync();

            return result;
        }

    }
}
