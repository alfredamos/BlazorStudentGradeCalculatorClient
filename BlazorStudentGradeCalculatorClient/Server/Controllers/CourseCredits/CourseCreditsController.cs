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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.CourseCredits
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCreditsController : ControllerBase
    {
        private readonly ICourseCreditRepository _courseCreditRepository;

        public CourseCreditsController(ICourseCreditRepository courseCreditRepository)
        {
            _courseCreditRepository = courseCreditRepository;
        }

        // GET: api/CourseCredits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseCredit>>> GetCourseCredits()
        {
            try
            {
                return Ok(await _courseCreditRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
        }

        // GET: api/CourseCredits/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseCredit>> GetCourseCredit(int id)
        {
            try
            {
                var courseCredit = await _courseCreditRepository.GetById(id);

                if (courseCredit == null)
                {
                    return NotFound($"Credit with Id = {id} not found.");
                }

                return courseCredit;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }

        }

        // PUT: api/CourseCredits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CourseCredit>> PutCourseCredit(int id, CourseCredit courseCredit)
        {
            try
            {
                if (id != courseCredit.CourseCreditID)
                {
                    return BadRequest("Id mismatch.");
                }

                var courseCreditToUpdate = await _courseCreditRepository.GetById(id);
                if (courseCreditToUpdate == null)
                {
                    return NotFound($"Credit with Id = {id} not found.");
                }

                return await _courseCreditRepository.UpdateEntity(courseCredit);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }


        // PUT: api/courseCredits/items
        [HttpPut("items")]
        public async Task<IActionResult> PutCourseCredits(List<CourseCredit> courseCredits)
        {
            try
            {
                if (courseCredits == null)
                {
                    return BadRequest("Invalid input");
                }

                await _courseCreditRepository.UpdateEntities(courseCredits);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/CourseCredits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseCredit>> PostCourseCredit(CourseCredit courseCredit)
        {
            try
            {
                if (courseCredit == null)
                {
                    return BadRequest("Invalid input");
                }

                var createdCourseCredit = await _courseCreditRepository.AddEntity(courseCredit);

                return CreatedAtAction(nameof(GetCourseCredit), new { id = createdCourseCredit.CourseCreditID }, createdCourseCredit);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }


        [HttpPost("multiple")]
        public async Task<IActionResult> PostCourseCredits(List<CourseCredit> courseCredits)
        {
            try
            {
                if (courseCredits == null)
                {
                    return BadRequest("Invalid input");
                }

                await _courseCreditRepository.AddEntities(courseCredits);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/CourseCredits/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CourseCredit>> DeleteCourseCredit(int id)
        {
            try
            {
                var courseCredit = await _courseCreditRepository.GetById(id);

                if (courseCredit == null)
                {
                    return NotFound($"Credit with Id = {id} not found.");
                }

                return await _courseCreditRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }
        }

        // GET: api/courseCredits/search/searchKey
        [HttpGet("search/{searchKey}")]
        public async Task<ActionResult<IEnumerable<CourseCredit>>> Search(string searchKey)
        {
            try
            {               
                return Ok(await _courseCreditRepository.Search(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }


        // GET: api/courseCredits/filter/searchKey/
        [HttpGet("lookup/{searchKey}")]
        public async Task<ActionResult<CourseCredit>> LookUp(string searchKey)
        {
            try
            {
                var courseCredit = await _courseCreditRepository.LookUp(searchKey);

                if (courseCredit == null)
                {
                    return NotFound($"Course details with SearchKey = {searchKey} not found");
                }

                return courseCredit;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }

        }
    }
}
