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
    public class SQLCourseCreditRepository : ICourseCreditRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLCourseCreditRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddEntities(List<CourseCredit> newEntities)
        {
            await _context.CourseCredits.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseCredit> AddEntity(CourseCredit newEntity)
        {
            var courseCredit = await _context.CourseCredits.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return courseCredit.Entity;
        }

        public async Task<CourseCredit> DeleteEntity(int id)
        {
            var courseCreditToDelete = await _context.CourseCredits.FindAsync(id);

            if (courseCreditToDelete != null)
            {
                _context.CourseCredits.Remove(courseCreditToDelete);
                await _context.SaveChangesAsync();
            }

            return courseCreditToDelete;
        }

        public async Task<IEnumerable<CourseCredit>> GetAll()
        {
            return await _context.CourseCredits.ToListAsync();
        }

        public async Task<CourseCredit> GetById(int id)
        {
            return await _context.CourseCredits.FindAsync(id);
        }

        public async Task<CourseCredit> LookUp(string searchKey)
        {
            return await _context.CourseCredits.FirstOrDefaultAsync(x =>
                         x.GradeLetter.Contains(searchKey));
        }

        public async Task<IEnumerable<CourseCredit>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.CourseCredits.ToListAsync();
            }

            return await _context.CourseCredits.Where(x => x.GradeLetter.Contains(searchKey)).ToListAsync();
        }

        public async Task UpdateEntities(List<CourseCredit> courseCredits)
        {
            _context.CourseCredits.UpdateRange(courseCredits);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseCredit> UpdateEntity(CourseCredit updatedEntity)
        {
            var result = await _context.CourseCredits.FirstOrDefaultAsync(x => x.CourseCreditID == updatedEntity.CourseCreditID);

            _mapper.Map(updatedEntity, result);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
