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
    public class ScoreService : IScoreService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/scores";

        public ScoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddEntities(List<HWScore> newEntities)
        {
            await _httpClient.PostJsonAsync($"{ _baseUrl}/multiple", newEntities);
        }

        public async Task<HWScore> AddEntity(HWScore newEntity)
        {
            return await _httpClient.PostJsonAsync<HWScore>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<HWScore>> GetAll()
        {
            return await _httpClient.GetJsonAsync<HWScore[]>(_baseUrl);
        }

        public async Task<HWScore> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<HWScore>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<HWScore>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<HWScore[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task UpdateEntities(List<HWScore> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<HWScore> UpdateEntity(HWScore updatedEntity)
        {
            return await _httpClient.PutJsonAsync<HWScore>($"{_baseUrl}/{updatedEntity.HomeWorkID}", updatedEntity);
        }
    }
}
