using ClientWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using ClientWebApp.ViewModel;

namespace ClientWebApp.Services
{
    public class StatusService
    {
        //// _httpClient isn't exposed publicly
        private readonly HttpClient _httpClient;

        public StatusService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<SupportStatus>> GetStatuses()
        {
            List<SupportStatus> st;

            try
            {
                HttpResponseMessage res = await _httpClient.GetAsync("status/statuslist");

                res.EnsureSuccessStatusCode();

                var results = await res.Content.ReadAsStringAsync();
                st = JsonConvert.DeserializeObject<List<SupportStatus>>(results);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return st;
        }


        public async Task<SupportStatus> GetStatus(int? id)
        {
            SupportStatus st;
            try
            {
                var res = await _httpClient.GetAsync("status/" + id);

                res.EnsureSuccessStatusCode();

                var results = await res.Content.ReadAsStringAsync();
                st = JsonConvert.DeserializeObject<SupportStatus>(results);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return st;
        }


        public async Task<SupportStatus> SaveStatus(SupportStatus st)
        {
            SupportStatus results = new SupportStatus();
            try
            {
                var res = await _httpClient.PostAsJsonAsync("status", st);

                res.EnsureSuccessStatusCode();

                 results = await res.Content.ReadAsAsync<SupportStatus>();
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            return results;
        }


        public async Task EditStatus(int id, SupportStatus st)
        {
            try
            {
                var res = await _httpClient.PutAsJsonAsync("status/" + id, st);

                res.EnsureSuccessStatusCode();                
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteStatus(int id)
        {
            try
            {
                var res = await _httpClient.DeleteAsync("status/" + id);

                res.EnsureSuccessStatusCode();
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
        }
    }

}
