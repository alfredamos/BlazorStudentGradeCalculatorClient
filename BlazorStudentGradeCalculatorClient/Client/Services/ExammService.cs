using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
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

        public async Task AddEntities(List<Examm> newEntities)
        {            
            await _httpClient.PostJsonAsync($"{ _baseUrl}/multiple", newEntities);
        }

        public async Task<Examm> AddEntity(Examm newEntity)
        {
            return await _httpClient.PostJsonAsync<Examm>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {

            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Examm>> GetAll()
        {            
            return await _httpClient.GetJsonAsync<Examm[]>(_baseUrl);
        }

        public async Task<IEnumerable<Examm>> Search(string searchKey)
        {            
            return await _httpClient.GetJsonAsync<Examm[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Examm> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Examm>($"{_baseUrl}/{id}");
        }

        public async Task UpdateEntities(List<Examm> updatedEntities)
        {
            await _httpClient.PutJsonAsync($"{ _baseUrl}/items", updatedEntities);
        }

        public async Task<Examm> UpdateEntity(Examm updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Examm>($"{_baseUrl}/{updatedEntity.ExammID}", updatedEntity);
        }

    }
}
