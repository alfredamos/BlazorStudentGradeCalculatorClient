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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.CourseDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {        
        private readonly ICourseDetailsRepository _courseDetailsRepository;

        public CourseDetailsController(ICourseDetailsRepository courseWeightRepository)
        {
            _courseDetailsRepository = courseWeightRepository;
        }

        // GET: api/CourseDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDetail>>> GetCourseWeights()
        {
            try
            {
                return Ok(await _courseDetailsRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
        }

        // GET: api/CourseDetails/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseDetail>> GetCourseWeight(int id)
        {
            try
            {
                var courseWeight = await _courseDetailsRepository.GetById(id);

                if (courseWeight == null)
                {
                    return NotFound($"weight with Id = {id} not found.");
                }

                return courseWeight;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
            
        }

        // PUT: api/CourseDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CourseDetail>> PutCourseWeight(int id, CourseDetail courseWeight)
        {
            try
            {
                if (id != courseWeight.CourseDetailID)
                {
                    return BadRequest("Id mismatch.");
                }

                var courseWeightToUpdate = await _courseDetailsRepository.GetById(id);
                if (courseWeightToUpdate == null)
                {
                    return NotFound($"weight with Id = {id} not found.");
                }

                return await _courseDetailsRepository.UpdateEntity(courseWeight);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }
           
        }


        // PUT: api/courseDetails/items
        [HttpPut("items")]
        public async Task<IActionResult> PutCourseWeights(List<CourseDetail> courseWeights)
        {
            try
            {
                if (courseWeights == null)
                {
                    return BadRequest("Invalid input");
                }

                await _courseDetailsRepository.UpdateEntities(courseWeights);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/CourseDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDetail>> PostCourseWeight(CourseDetail courseWeight)
        {
            try
            {
                if (courseWeight == null)
                {
                    return BadRequest("Invalid input");
                }

                var createdCourseWeight = await _courseDetailsRepository.AddEntity(courseWeight);

                return CreatedAtAction("GetCourseWeight", new { id = createdCourseWeight.CourseDetailID }, createdCourseWeight);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
            
        }


        [HttpPost("multiple")]
        public async Task<IActionResult> PostCourseWeights(List<CourseDetail> courseWeights)
        {
            try
            {
                if (courseWeights == null)
                {
                    return BadRequest("Invalid input");
                }

                await _courseDetailsRepository.AddEntities(courseWeights);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/CourseDetails/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CourseDetail>> DeleteCourseWeight(int id)
        {
            try
            {
                var courseWeight = await _courseDetailsRepository.GetById(id);

                if (courseWeight == null)
                {
                    return NotFound($"weight with Id = {id} not found.");
                }

                return await _courseDetailsRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }
        }

        // GET: api/coursedetails/search/searchKey
        [HttpGet("search/{searchKey}")]
        public async Task<ActionResult<IEnumerable<CourseDetail>>> Search(string searchKey)
        {
            try
            {
                Console.WriteLine("In Controller : " + searchKey);
                return Ok(await _courseDetailsRepository.Search(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }


        // GET: api/courseDetails/filter/searchKey/
        [HttpGet("lookup/{searchKey}")]
        public async Task<ActionResult<CourseDetail>> LookUp(string searchKey)
        {
            try
            {
                var courseDetail = await _courseDetailsRepository.LookUp(searchKey);

                if (courseDetail == null)
                {
                    return NotFound($"Course details with SearchKey = {searchKey} not found");
                }

                return courseDetail;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }

        }

    }
}
