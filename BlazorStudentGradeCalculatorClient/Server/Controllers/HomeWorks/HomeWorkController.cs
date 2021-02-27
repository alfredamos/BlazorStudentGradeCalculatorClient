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

namespace BlazorStudentGradeCalculatorClient.Server.Controllers.HomeWorks
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {
        private readonly IHomeWorkRepository _homeWorkRepository;

        public HomeWorkController(IHomeWorkRepository homeWorkRepository)
        {
            _homeWorkRepository = homeWorkRepository;
        }


        // GET: api/HomeWork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeWork>>> GetHomeWorks(string searchKey = null)
        {
            try
            {
                return Ok(await _homeWorkRepository.GetAll(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        // GET: api/HomeWork/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HomeWork>> GetHomeWork(int id)
        {
            try
            {
                var homeWork = await _homeWorkRepository.GetById(id);

                if (homeWork == null)
                {
                    return NotFound();
                }

                return homeWork;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        // PUT: api/HomeWork/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<HomeWork>> PutHomeWork(int id, HomeWork homeWork)
        {
            try
            {
                if (id != homeWork.HomeWorkID)
                {
                    return BadRequest("Id mismatch");
                }

                var homeWorkToUpdate = await _homeWorkRepository.GetById(id);

                if (homeWorkToUpdate == null)
                {
                    return NotFound($"Home Work with Id = {id} not found.");
                }

                return await _homeWorkRepository.UpdateEntity(homeWork);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

        }

        // POST: api/HomeWork
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HomeWork>> PostHomeWork(HomeWork homeWork)
        {
            try
            {
                if (homeWork == null)
                {
                    return BadRequest("Invalid input");
                }

                var createdHomeWork = await _homeWorkRepository.AddEntity(homeWork);

                return CreatedAtAction(nameof(GetHomeWork), new { id = createdHomeWork.HomeWorkID }, createdHomeWork);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

        }

        // DELETE: api/HomeWork/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HomeWork>> DeleteHomeWork(int id)
        {
            try
            {
                var homeWorkToDelete = await _homeWorkRepository.GetById(id);

                if (homeWorkToDelete == null)
                {
                    return NotFound($"Examm with Id = {id} not found.");
                }

                return await _homeWorkRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }
        }

    }
}
