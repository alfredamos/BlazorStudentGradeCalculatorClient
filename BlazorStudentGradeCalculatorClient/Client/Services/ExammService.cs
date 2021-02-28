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
    public class ExammService : IExammService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/examms";

        public ExammService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Examm> AddEntity(Examm newEntity)
        {
            return await _httpClient.PostJsonAsync<Examm>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Examm>> GetAll(string searchKey = null)
        {
            return await _httpClient.GetJsonAsync<Examm[]>($"{_baseUrl}/{searchKey}");
        }

        public async Task<Examm> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Examm>($"{_baseUrl}/{id}");
        }

        public async Task<Examm> UpdateEntity(Examm updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Examm>($"{_baseUrl}/{updatedEntity.ExammID}", updatedEntity);
        }
    }
}
