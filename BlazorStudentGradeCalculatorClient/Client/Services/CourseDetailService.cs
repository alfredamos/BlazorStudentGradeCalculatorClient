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
    public class CourseDetailService : ICourseDetailService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/coursedetails";

        public CourseDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddEntities(List<CourseDetail> newEntities)
        {
            await _httpClient.PostJsonAsync($"{ _baseUrl}/multiple", newEntities);
        }

        public async Task<CourseDetail> AddEntity(CourseDetail newEntity)
        {
            return await _httpClient.PostJsonAsync<CourseDetail>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<CourseDetail>> GetAll()
        {
            return await _httpClient.GetJsonAsync<CourseDetail[]>(_baseUrl);
        }

        public async Task<CourseDetail> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<CourseDetail>($"{_baseUrl}/{id}");
        }

        public async Task<CourseDetail> LookUp(string search)
        {
            return await _httpClient.GetJsonAsync<CourseDetail>($"{_baseUrl}/lookup/{search}"); ;
        }

        public async Task<IEnumerable<CourseDetail>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<CourseDetail[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task UpdateEntities(List<CourseDetail> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<CourseDetail> UpdateEntity(CourseDetail updatedEntity)
        {
            return await _httpClient.PutJsonAsync<CourseDetail>($"{_baseUrl}/{updatedEntity.CourseDetailID}", updatedEntity);
        }
    }
}
