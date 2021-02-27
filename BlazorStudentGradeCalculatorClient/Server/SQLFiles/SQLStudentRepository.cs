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
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SQLStudentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Student> AddEntity(Student newEntity)
        {
            var student = await _context.Students.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return student.Entity;
        }

        public async Task<Student> DeleteEntity(int id)
        {
            var studentToDelete = await _context.Students.FindAsync(id);

            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
            }

            return studentToDelete;
        }

        public async Task<IEnumerable<Student>> GetAll(string searchKey = null)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await _context.Students.ToListAsync();
            }

            return await _context.Students.Include(st => st.Examm).Include(st => st.MidTerm)
                         .Include(st => st.HomeWork).Where(st => st.SchoolIdNumber.Contains(searchKey) ||
                         st.StudentName.Contains(searchKey) || st.Examm.Score.SubjectName.Contains(searchKey) ||
                         st.Examm.Score.SubjectScoreInLetter.Contains(searchKey) || 
                         st.HomeWork.Scores.Any(st => st.SubjectName.Contains(searchKey)) || 
                         st.HomeWork.Scores.Any(st => st.SubjectScoreInLetter.Contains(searchKey)) ||
                         st.MidTerm.Score.SubjectName.Contains(searchKey) || st.MidTerm.Score.SubjectScoreInLetter
                         .Contains(searchKey)).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.Include(st => st.Examm).Include(st => st.HomeWork).Include(st => st.MidTerm)
                         .FirstOrDefaultAsync(st => st.StudentID == id);
        }

        public async Task<Student> UpdateEntity(Student updatedEntity)
        {
            var result = await _context.Students.FirstOrDefaultAsync(st => st.StudentID == updatedEntity.StudentID);

            _mapper.Map(updatedEntity, result);

            result.Examm = updatedEntity.Examm;
            result.HomeWork = updatedEntity.HomeWork;
            result.MidTerm = updatedEntity.MidTerm;

            await _context.SaveChangesAsync();

            return result;

        }
    }
}
