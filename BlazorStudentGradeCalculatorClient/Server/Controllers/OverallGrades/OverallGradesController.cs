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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.OverallGrades
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverallGradesController : ControllerBase
    {        
        private readonly IOverallGradeRepository _overallGradeRepository;

        public OverallGradesController(IOverallGradeRepository overallGradeRepository)
        {           
            _overallGradeRepository = overallGradeRepository;
        }

        // GET: api/OverallGrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OverallGrade>>> GetOverallGrades()
        {
            try
            {
                return Ok(await _overallGradeRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
        }

        // GET: api/OverallGrades/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OverallGrade>> GetOverallGrade(int id)
        {
            try
            {
                var overallGrade = await _overallGradeRepository.GetById(id);

                if (overallGrade == null)
                {
                    return NotFound($"OverallGrade with Id = {id} not found");
                }

                return overallGrade;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
            
        }

        // PUT: api/OverallGrades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<OverallGrade>> PutOverallGrade(int id, OverallGrade overallGrade)
        {
            try
            {
                if (id != overallGrade.OverallGradeID)
                {
                    return BadRequest($"Id mismatch");
                }
                var overallGradeToUpdate = await _overallGradeRepository.GetById(id);

                if (overallGradeToUpdate != null)
                {
                    return NotFound($"OverallGrade with Id = {id} not found.");
                }

                return await _overallGradeRepository.UpdateEntity(overallGrade);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }
            
        }


        // PUT: api/overallgrades/items
        [HttpPut("items")]
        public async Task<IActionResult> PutOverallGrades(List<OverallGrade> overallGrades)
        {
            try
            {
                if (overallGrades == null)
                {
                    return BadRequest("Invalid input");
                }

                await _overallGradeRepository.UpdateEntities(overallGrades);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/OverallGrades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OverallGrade>> PostOverallGrade(OverallGrade overallGrade)
        {
            try
            {
                if (overallGrade == null)
                {
                    return BadRequest("Invalid input");
                }
                var createdOverallGrade = await _overallGradeRepository.AddEntity(overallGrade);

                return CreatedAtAction("GetOverallGrade", new { id = createdOverallGrade.OverallGradeID }, createdOverallGrade);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
            
        }


        [HttpPost("multiple")]
        public async Task<IActionResult> PostOverallGrades(List<OverallGrade> overallGrades)
        {
            try
            {
                if (overallGrades == null)
                {
                    return BadRequest("Invalid input");
                }

                await _overallGradeRepository.AddEntities(overallGrades);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/OverallGrades/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OverallGrade>> DeleteOverallGrade(int id)
        {
            try
            {
                var overallGrade = await _overallGradeRepository.GetById(id);
                if (overallGrade == null)
                {
                    return NotFound($"OverallGrade with Id = {id} not found.");
                }
                return await _overallGradeRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }
                     
        }

        // GET: api/overallGrades/search/searchKey
        [HttpGet("search/{searchKey}")]
        public async Task<ActionResult<IEnumerable<OverallGrade>>> Search(string searchKey)
        {
            try
            {                
                return Ok(await _overallGradeRepository.Search(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }


        // GET: api/overallgrades/filter/searchKey/
        [HttpGet("lookup/{searchKey}")]
        public async Task<ActionResult<OverallGrade>> LookUp(string searchKey)
        {
            try
            {
                var overallGrade = await _overallGradeRepository.LookUp(searchKey);

                if (overallGrade == null)
                {
                    return NotFound($"OverallGrade with SearchKey = {searchKey} not found");
                }

                return overallGrade;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }

        }

    }
}
