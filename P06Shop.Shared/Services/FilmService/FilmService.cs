using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P06Shop.Shared;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.FilmService
{
    public class FilmService : IFilmService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public FilmService(HttpClient httpClient, AppSettings appSettings) //IOptions<AppSettings> appSettings
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<ServiceResponse<Film>> CreateFilmAsync(Film film)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BaseFilmEndpoint.Base_url + _appSettings.BaseFilmEndpoint.GetAllFilmsEndpoint, film);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Film>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteFilmAsync(int id)
        {
            // jesli uzyjemy / na poczatku to wtedy sciezka trakktowana jest od root czyli pomija czesc środkową adresu 
            // zazwyczaj unikamy stosowania / na poczatku 
            var s = _appSettings.BaseFilmEndpoint.Base_url + $"{id}";
            var response = await _httpClient.DeleteAsync(s);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return result;
        }

   


        //// skopiowane z postmana 
        //public async Task<ServiceResponse<List<Film>>> GetFilmsAsync()
        //{
        //    //var client = new HttpClient();   
        //    var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseFilmEndpoint.GetAllFilmsEndpoint);
        //    var response = await _httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();        
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json);
        //    return result;
        //}


        // alternatywny sposób pobierania danych 
        public async Task<ServiceResponse<List<Film>>> GetFilmsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_appSettings.BaseFilmEndpoint.GetAllFilmsEndpoint);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Film>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json)
                    ?? new ServiceResponse<List<Film>> { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Film>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Film>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }


        }

        public async Task<ServiceResponse<Film>> GetFilmByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseFilmEndpoint.Base_url + id.ToString());
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Film>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Film>>(json)
                ?? new ServiceResponse<Film> { Success = false, Message = "Deserialization failed" };

            result.Success = result.Success && result.Data != null;

            return result;
        }


        // wersja 1 
        //public async Task<ServiceResponse<Film>> UpdateFilmAsync(Film film)
        //{
        //    var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseFilmEndpoint.GetAllFilmsEndpoint, film);
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<Film>>(json);
        //    return result;
        //}

        // wersja 2 
        public async Task<ServiceResponse<Film>> UpdateFilmAsync(Film film)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseFilmEndpoint.Base_url + _appSettings.BaseFilmEndpoint.GetAllFilmsEndpoint, film);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Film>>();
            return result;
        }

        public async Task<ServiceResponse<List<Film>>> SearchFilmsAsync(string text, int page, int pageSize)
        {

            try
            {
                string searchUrl = string.IsNullOrWhiteSpace(text) ? "" : $"/{text}";
                var response = await _httpClient.GetAsync(_appSettings.BaseFilmEndpoint.Base_url + _appSettings.BaseFilmEndpoint.SearchFilmsEndpoint + searchUrl + $"/{page}/{pageSize}");
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Film>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json)
                    ?? new ServiceResponse<List<Film>> { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Film>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new ServiceResponse<List<Film>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }
    }
}
