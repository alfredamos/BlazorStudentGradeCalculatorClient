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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.MidTerms
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidTermsController : ControllerBase
    {
        private readonly IMidTermRepository _midTermRepository;

        public MidTermsController(IMidTermRepository midTermRepository)
        {
            _midTermRepository = midTermRepository;
        }


        // GET: api/MidTerms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MidTerm>>> GetMidTerms(string searchKey = null)
        {
            try
            {
                return Ok(await _midTermRepository.GetAll(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        // GET: api/MidTerms/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MidTerm>> GetMidTerm(int id)
        {
            try
            {
                var midTerm = await _midTermRepository.GetById(id);

                if (midTerm == null)
                {
                    return NotFound();
                }

                return midTerm;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        // PUT: api/MidTerms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MidTerm>> PutMidTerm(int id, MidTerm midTerm)
        {
            try
            {
                if (id != midTerm.MidTermID)
                {
                    return BadRequest("Id mismatch");
                }

                var midTermToUpdate = await _midTermRepository.GetById(id);

                if (midTermToUpdate == null)
                {
                    return NotFound($"MidTerm with Id = {id} not found.");
                }

                return await _midTermRepository.UpdateEntity(midTerm);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/MidTerms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MidTerm>> PostMidTerm(MidTerm midTerm)
        {
            try
            {
                if (midTerm == null)
                {
                    return BadRequest("Invalid input");
                }

                var createdMidTerm = await _midTermRepository.AddEntity(midTerm);

                return CreatedAtAction(nameof(GetMidTerm), new { id = createdMidTerm.MidTermID }, createdMidTerm);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
        }

        // DELETE: api/MidTerms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MidTerm>> DeleteMidTerm(int id)
        {
            try
            {
                var midTermToDelete = await _midTermRepository.GetById(id);

                if (midTermToDelete == null)
                {
                    return NotFound($"MidTerm with Id = {id} not found.");
                }

                return await _midTermRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
        }

    }
}
