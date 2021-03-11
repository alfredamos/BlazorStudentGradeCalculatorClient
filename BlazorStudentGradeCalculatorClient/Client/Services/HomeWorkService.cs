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

        public async Task AddEntities(List<HomeWork> newEntities)
        {
            await _httpClient.PostJsonAsync($"{_baseUrl}/multiple", newEntities);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<HomeWork>> GetAll()
        {
            return await _httpClient.GetJsonAsync<HomeWork[]>(_baseUrl);
        }

        public async Task<IEnumerable<HomeWork>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<HomeWork[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<HomeWork> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<HomeWork>($"{_baseUrl}/{id}");
        }

        public async Task UpdateEntities(List<HomeWork> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<HomeWork> UpdateEntity(HomeWork updatedEntity)
        {
            return await _httpClient.PutJsonAsync<HomeWork>($"{_baseUrl}/{updatedEntity.HomeWorkID}", updatedEntity);
        }
    }
}
