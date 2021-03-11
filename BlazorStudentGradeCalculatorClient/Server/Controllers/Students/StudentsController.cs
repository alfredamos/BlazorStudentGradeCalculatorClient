using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorStudentGradeCalculatorClient.Server.Data;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using BlazorStudentGradeCalculatorClient.Server.Contracts;

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                return Ok(await _studentRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        // GET: api/Students/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);

                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }

        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> PutStudent(int id, Student student)
        {
            try
            {
                if (id != student.StudentID)
                {
                    return BadRequest("Id mismatch");
                }

                var studentToUpdate = await _studentRepository.GetById(id);

                if (studentToUpdate == null)
                {
                    return NotFound($"Student with Id = {id} not found.");
                }

                return await _studentRepository.UpdateEntity(student);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }
        }

        // PUT: api/Students/items
        [HttpPut("items")]
        public async Task<IActionResult> PutStudents(List<Student> students)
        {
            try
            {
                if (students == null)
                {
                    return BadRequest("Invalid input");
                }

                await _studentRepository.UpdateEntities(students);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Invalid input");
                }

                var createdStudent = await _studentRepository.AddEntity(student);

                return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.StudentID }, createdStudent);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
        }


        [HttpPost("multiple")]
        public async Task<IActionResult> PostStudents(List<Student> students)
        {
            try
            {
                if (students == null)
                {
                    return BadRequest("Invalid input");
                }

                await _studentRepository.AddEntities(students);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/Students/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await _studentRepository.GetById(id);

                if (studentToDelete == null)
                {
                    return NotFound($"Student with Id = {id} not found.");
                }

                return await _studentRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
        }

        // GET: api/Students/search/searchKey
        [HttpGet("search/{searchKey}")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string searchKey)
        {
            try
            {
                return Ok(await _studentRepository.Search(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

    }
}
