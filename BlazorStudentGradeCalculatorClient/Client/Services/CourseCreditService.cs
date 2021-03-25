using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Services
{
    public class CourseCreditService : ICourseCreditService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/coursecredits";

        public CourseCreditService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddEntities(List<CourseCredit> newEntities)
        {
            await _httpClient.PostJsonAsync($"{ _baseUrl}/multiple", newEntities);
        }

        public async Task<CourseCredit> AddEntity(CourseCredit newEntity)
        {
            return await _httpClient.PostJsonAsync<CourseCredit>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<CourseCredit>> GetAll()
        {
            return await _httpClient.GetJsonAsync<CourseCredit[]>(_baseUrl);
        }

        public async Task<CourseCredit> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<CourseCredit>($"{_baseUrl}/{id}");
        }

        public async Task<CourseCredit> LookUp(string search)
        {
            return await _httpClient.GetJsonAsync<CourseCredit>($"{_baseUrl}/lookup/{search}"); ;
        }

        public async Task<IEnumerable<CourseCredit>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<CourseCredit[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task UpdateEntities(List<CourseCredit> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<CourseCredit> UpdateEntity(CourseCredit updatedEntity)
        {
            return await _httpClient.PutJsonAsync<CourseCredit>($"{_baseUrl}/{updatedEntity.CourseCreditID}", updatedEntity);
        }
    }
}
