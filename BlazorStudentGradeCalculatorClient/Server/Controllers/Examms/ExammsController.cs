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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.Examms
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExammsController : ControllerBase
    {        
        private readonly IExammRepository _exammRepository;

        public ExammsController(IExammRepository exammRepository)
        {            
            _exammRepository = exammRepository;
        }

        // GET: api/Examms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Examm>>> GetExamms()
        {
            try
            {
               
                return Ok(await _exammRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        // GET: api/Examms/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Examm>> GetExamm(int id)
        {
            try
            {
                var examm = await _exammRepository.GetById(id);

                if (examm == null)
                {
                    return NotFound();
                }

                return examm;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
            
        }

        // PUT: api/Examms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Examm>> PutExamm(int id, Examm examm)
        {
            try
            {
                if (id != examm.ExammID)
                {
                    return BadRequest("Id mismatch");
                }

                var exammToUpdate = await _exammRepository.GetById(id);

                if (exammToUpdate == null)
                {
                    return NotFound($"Examm with Id = {id} not found.");
                }

                return await _exammRepository.UpdateEntity(examm);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }
                        
        }

        // PUT: api/examms/items
        [HttpPut("items")]
        public async Task<IActionResult> PutExamms(List<Examm> examms)
        {
            try
            {
                if (examms == null)
                {
                    return BadRequest("Invalid input");
                }

                await _exammRepository.UpdateEntities(examms);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/Examms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Examm>> PostExamm(Examm examm)
        {
            try
            {
                if (examm == null)
                {
                    return BadRequest("Invalid input");
                }

                var createdExamm = await _exammRepository.AddEntity(examm);

                return CreatedAtAction(nameof(GetExamm), new { id = createdExamm.ExammID }, createdExamm);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
            
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> PostExamms(List<Examm> examms)
        {
            try
            {
                if (examms == null)
                {
                    return BadRequest("Invalid input");
                }

                await _exammRepository.AddEntities(examms);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/Examms/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Examm>> DeleteExamm(int id)
        {
            try
            {
                var exammToDelete = await _exammRepository.GetById(id);

                if (exammToDelete == null)
                {
                    return NotFound($"Examm with Id = {id} not found.");
                }

                return await _exammRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
            
        }

        // GET: api/Examms/search/searchKey
        [HttpGet("search/{searchKey}")]
        public async Task<ActionResult<IEnumerable<Examm>>> Search(string searchKey)
        {
            try
            {
                Console.WriteLine("In Controller : " + searchKey);
                return Ok(await _exammRepository.Search(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

    }
}
