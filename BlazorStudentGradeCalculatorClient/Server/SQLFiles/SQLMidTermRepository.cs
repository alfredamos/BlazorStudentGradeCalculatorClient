﻿using AutoMapper;
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

        public async Task AddEntities(List<MidTerm> newEntities)
        {
            await _context.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<MidTerm>> GetAll()
        {           
            return await _context.MidTerms.ToListAsync();
          
        }

        public async Task<IEnumerable<MidTerm>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.MidTerms.ToListAsync();
            }

            return await _context.MidTerms.Where(ex =>
                         ex.SchoolIdNumber.Contains(searchKey) || ex.StudentName.Contains(searchKey) ||
                         ex.SubjectName.Contains(searchKey) || ex.SubjectScoreInLetter.Contains(searchKey)
                         ).ToListAsync();
        }

        public async Task<MidTerm> GetById(int id)
        {
            return await _context.MidTerms.FirstOrDefaultAsync(ex => ex.MidTermID == id);
        }

        public async Task<MidTerm> UpdateEntity(MidTerm updatedEntity)
        {
            var result = await _context.MidTerms.FirstOrDefaultAsync(ex => ex.MidTermID == updatedEntity.MidTermID);

            _mapper.Map(updatedEntity, result);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task UpdateEntities(List<MidTerm> midTerms)
        {
            _context.MidTerms.UpdateRange(midTerms);
            await _context.SaveChangesAsync();
        }

    }
}
