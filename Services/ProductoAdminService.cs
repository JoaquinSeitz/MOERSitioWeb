using System.Net.Http.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Forms;
using MOERSitioWeb.DTOs;

namespace MOERSitioWeb.Services;

public class ProductoAdminService
{
    private readonly HttpClient _http;
    public ProductoAdminService(HttpClient http) => _http = http;

    public async Task<List<ProductoResponseDTO>> GetTodosLosProductos()
        => await _http.GetFromJsonAsync<List<ProductoResponseDTO>>("api/productos/admin") ?? new();

    public async Task<HttpResponseMessage> CrearProducto(ProductoCreateDTO dto)
        => await _http.PostAsJsonAsync("api/productos", dto);

    public async Task<HttpResponseMessage> ActualizarProducto(int id, ProductoCreateDTO dto)
        => await _http.PutAsJsonAsync($"api/productos/{id}", dto);

    public async Task<HttpResponseMessage> CambiarEstado(int id)
        => await _http.PatchAsync($"api/productos/{id}/estado", null);

    public async Task<HttpResponseMessage> SubirImagen(int id, IBrowserFile archivo)
    {
        using var content = new MultipartFormDataContent();
        var stream = archivo.OpenReadStream(10 * 1024 * 1024); // Límite de 10MB
        var streamContent = new StreamContent(stream);
        streamContent.Headers.ContentType = new MediaTypeHeaderValue(archivo.ContentType);
        content.Add(streamContent, "archivo", archivo.Name);

        return await _http.PostAsync($"api/productos/{id}/imagen", content);
    }
}