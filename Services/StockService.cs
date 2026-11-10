using System.Net.Http.Json;
using MOERSitioWeb.DTOs;

namespace MOERSitioWeb.Services
{
    public class StockService
    {
        private readonly HttpClient _http;

        public StockService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> RegistrarIngreso(IngresoProductoRequestDTO dto)
        {
            return await _http.PostAsJsonAsync("api/ingresoproductos", dto);
        }
    }
}