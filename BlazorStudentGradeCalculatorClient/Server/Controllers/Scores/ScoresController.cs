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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.Scores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {       
        private readonly IScoreRepository _scoreRepository;

        public ScoresController(IScoreRepository scoreRepository)
        {           
            _scoreRepository = scoreRepository;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HWScore>>> GetHWScores()
        {
            try
            {
                return Ok(await _scoreRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
           

        }

        // GET: api/Scores/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HWScore>> GetHWScore(int id)
        {
            try
            {
                var hWScore = await _scoreRepository.GetById(id);

                if (hWScore == null)
                {
                    return NotFound($"Score with Id = {id} not found.");
                }

                return hWScore;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
           
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<HWScore>> PutHWScore(int id, HWScore hWScore)
        {
            try
            {
                if (id != hWScore.HWScoreID)
                {
                    return BadRequest();
                }

                var scoreToUpdate = await _scoreRepository.GetById(id);

                if (scoreToUpdate == null)
                {
                    return NotFound($"Score with Id = {id} not found.");
                }

                return await _scoreRepository.UpdateEntity(hWScore);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
           
        }


        // PUT: api/scores/items
        [HttpPut("items")]
        public async Task<IActionResult> PutHWScores(List<HWScore> scores)
        {
            try
            {
                if (scores == null)
                {
                    return BadRequest("Invalid input");
                }

                await _scoreRepository.UpdateEntities(scores);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HWScore>> PostHWScore(HWScore hWScore)
        {
            try
            {
                if (hWScore == null)
                {
                    return BadRequest("Invalid input");
                }
                var createdScore = await _scoreRepository.AddEntity(hWScore);

                return CreatedAtAction("GetHWScore", new { id = createdScore.HWScoreID }, createdScore);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data");
            }
            
        }


        // PUT: api/scores/multiple
        [HttpPost("multiple")]
        public async Task<IActionResult> PostHWScores(List<HWScore> scores)
        {
            try
            {
                if (scores == null)
                {
                    return BadRequest("Invalid input");
                }

                await _scoreRepository.AddEntities(scores);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/Scores/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HWScore>> DeleteHWScore(int id)
        {
            try
            {
                var hWScore = await _scoreRepository.GetById(id);
                if (hWScore == null)
                {
                    return NotFound($"Score with Id = {id} not found.");
                }
                return await _scoreRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
                     
        }

    }
}
