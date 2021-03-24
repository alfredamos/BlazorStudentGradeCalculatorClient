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
    public class OverallGradeService : IOverallGradeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/overallgrades";

        public OverallGradeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddEntities(List<OverallGrade> newEntities)
        {
            await _httpClient.PostJsonAsync($"{ _baseUrl}/multiple", newEntities);
        }

        public async Task<OverallGrade> AddEntity(OverallGrade newEntity)
        {
            return await _httpClient.PostJsonAsync<OverallGrade>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<OverallGrade>> GetAll()
        {
            return await _httpClient.GetJsonAsync<OverallGrade[]>(_baseUrl);
        }

        public async Task<OverallGrade> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<OverallGrade>($"{_baseUrl}/{id}");
        }

        public async Task<OverallGrade> LookUp(string search)
        {
            return await _httpClient.GetJsonAsync<OverallGrade>($"{_baseUrl}/lookup/{search}");
        }

        public async Task<IEnumerable<OverallGrade>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<OverallGrade[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task UpdateEntities(List<OverallGrade> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<OverallGrade> UpdateEntity(OverallGrade updatedEntity)
        {
            return await _httpClient.PutJsonAsync<OverallGrade>($"{_baseUrl}/{updatedEntity.OverallGradeID}", updatedEntity);
        }
    }
}
