using System.Net.Http.Json;
using MOERSitioWeb.DTOs;

namespace MOERSitioWeb.Services
{
    public class PedidoService
    {
        private readonly HttpClient _http;

        public PedidoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PedidoResponseDTO>> GetMisPedidos()
        {
            return await _http.GetFromJsonAsync<List<PedidoResponseDTO>>("api/pedidos/mis-pedidos")
                   ?? new List<PedidoResponseDTO>();
        }

        public async Task<HttpResponseMessage> CrearPedido(PedidoCreateDTO dto)
        {
            return await _http.PostAsJsonAsync("api/pedidos", dto);
        }
    }
}