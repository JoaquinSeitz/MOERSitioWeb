using System.Net.Http.Json;
using MOERSitioWeb.DTOs;

namespace MOERSitioWeb.Services
{
    public class ServicioAdminService
    {
        private readonly HttpClient _http;

        public ServicioAdminService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ServicioResponseDTO>> GetServicios()
        {
            return await _http.GetFromJsonAsync<List<ServicioResponseDTO>>("api/servicios")
                   ?? new List<ServicioResponseDTO>();
        }

        public async Task<HttpResponseMessage> CrearServicio(ServicioCreateDTO dto)
        {
            return await _http.PostAsJsonAsync("api/servicios", dto);
        }

        public async Task<HttpResponseMessage> ActualizarServicio(int id, ServicioCreateDTO dto)
        {
            return await _http.PutAsJsonAsync($"api/servicios/{id}", dto);
        }

        public async Task<HttpResponseMessage> EliminarServicio(int id)
        {
            return await _http.DeleteAsync($"api/servicios/{id}");
        }
    }
}