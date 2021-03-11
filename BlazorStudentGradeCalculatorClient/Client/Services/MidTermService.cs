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
    public class MidTermService : IMidTermService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/midterms";

        public MidTermService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<MidTerm> AddEntity(MidTerm newEntity)
        {
            return await _httpClient.PostJsonAsync<MidTerm>(_baseUrl, newEntity);
        }

        public async Task AddEntities(List<MidTerm> newEntities)
        {
            await _httpClient.PostJsonAsync($"{_baseUrl}/multiple", newEntities);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<MidTerm>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<MidTerm[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<IEnumerable<MidTerm>> GetAll()
        {
            return await _httpClient.GetJsonAsync<MidTerm[]>(_baseUrl);
        }

        public async Task<MidTerm> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<MidTerm>($"{_baseUrl}/{id}");
        }

        public async Task UpdateEntities(List<MidTerm> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<MidTerm> UpdateEntity(MidTerm updatedEntity)
        {
            return await _httpClient.PutJsonAsync<MidTerm>($"{_baseUrl}/{updatedEntity.MidTermID}", updatedEntity);
        }
    }
}
