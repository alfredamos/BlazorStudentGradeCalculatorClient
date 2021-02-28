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
    public class HomeWorkService : IHomeWorkService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/homework";

        public HomeWorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HomeWork> AddEntity(HomeWork newEntity)
        {
            return await _httpClient.PostJsonAsync<HomeWork>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<HomeWork>> GetAll(string searchKey = null)
        {
            return await _httpClient.GetJsonAsync<HomeWork[]>($"{_baseUrl}/{searchKey}");
        }

        public async Task<HomeWork> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<HomeWork>($"{_baseUrl}/{id}");
        }

        public async Task<HomeWork> UpdateEntity(HomeWork updatedEntity)
        {
            return await _httpClient.PutJsonAsync<HomeWork>($"{_baseUrl}/{updatedEntity.HomeWorkID}", updatedEntity);
        }
    }
}
