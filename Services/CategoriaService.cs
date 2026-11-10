using System.Net.Http.Json;
using MOERSitioWeb.DTOs;

namespace MOERSitioWeb.Services;

public class CategoriaService
{
    private readonly HttpClient _http;
    public CategoriaService(HttpClient http) => _http = http;

    public async Task<List<CategoriaResponseDTO>> GetCategoriasProductos()
        => await _http.GetFromJsonAsync<List<CategoriaResponseDTO>>("api/categorias/productos") ?? new();

    public async Task<List<CategoriaResponseDTO>> GetCategoriasServicios()
        => await _http.GetFromJsonAsync<List<CategoriaResponseDTO>>("api/categorias/servicios") ?? new();
}