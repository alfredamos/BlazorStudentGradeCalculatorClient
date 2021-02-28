﻿using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/students";

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Student> AddEntity(Student newEntity)
        {
            return await _httpClient.PostJsonAsync<Student>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Student>> GetAll(string searchKey = null)
        {
            return await _httpClient.GetJsonAsync<Student[]>($"{_baseUrl}/{searchKey}");
        }

        public async Task<Student> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Student>($"{_baseUrl}/{id}");
        }

        public async Task<Student> UpdateEntity(Student updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Student>($"{_baseUrl}/{updatedEntity.StudentID}", updatedEntity);
        }
    }
}
