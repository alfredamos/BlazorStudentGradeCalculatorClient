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
    public class SQLCourseDetailsRepository : ICourseDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLCourseDetailsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddEntities(List<CourseDetail> newEntities)
        {
            await _context.CourseWeights.AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }
        
        public async Task<CourseDetail> AddEntity(CourseDetail newEntity)
        {
            var courseWeight = await _context.CourseWeights.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return courseWeight.Entity;
        }

        public async Task<CourseDetail> DeleteEntity(int id)
        {
            var courseWeightToDelete = await _context.CourseWeights.FindAsync(id);

            if (courseWeightToDelete != null)
            {
                _context.CourseWeights.Remove(courseWeightToDelete);
                await _context.SaveChangesAsync();
            }

            return courseWeightToDelete;
        }

        public async Task<IEnumerable<CourseDetail>> GetAll()
        {
            return await _context.CourseWeights.ToListAsync();
        }

        public async Task<CourseDetail> GetById(int id)
        {
            return await _context.CourseWeights.FindAsync(id);
        }

        public async Task<CourseDetail> LookUp(string searchKey)
        {
            return await _context.CourseWeights.FirstOrDefaultAsync(x => 
                         x.Category.Contains(searchKey) || x.Status.Contains(searchKey) ||
                         x.SubjectName.Contains(searchKey));
        }

        public async Task<IEnumerable<CourseDetail>> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.CourseWeights.ToListAsync();
            }

            return await _context.CourseWeights.Where(x => x.SubjectName.Contains(searchKey) ||
                         x.Category.Contains(searchKey) || x.Status.Contains(searchKey)).ToListAsync();
        }

        public async  Task UpdateEntities(List<CourseDetail> courseWeights)
        {
            _context.CourseWeights.UpdateRange(courseWeights);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseDetail> UpdateEntity(CourseDetail updatedEntity)
        {
            var result = await _context.CourseWeights.FirstOrDefaultAsync(x => x.CourseDetailID == updatedEntity.CourseDetailID);

            _mapper.Map(updatedEntity, result);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
