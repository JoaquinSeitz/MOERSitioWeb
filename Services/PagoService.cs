using System.Net.Http.Json;
using MOERSitioWeb.DTOs;

namespace MOERSitioWeb.Services
{
    public class PagoService
    {
        private readonly HttpClient _http;

        public PagoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> RegistrarPago(PagoCreateDTO dto)
        {
            return await _http.PostAsJsonAsync("api/pagos", dto);
        }

        public async Task<List<MetodoPagoDTO>> GetMetodosPago()
        {
            return await _http.GetFromJsonAsync<List<MetodoPagoDTO>>("api/pagos/metodos")
                   ?? new List<MetodoPagoDTO>();
        }
    }
}