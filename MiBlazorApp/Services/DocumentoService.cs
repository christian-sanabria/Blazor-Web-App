using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MiBlazorApp.Models;

namespace MiBlazorApp.Services
{
    public class DocumentoService
    {
        private readonly HttpClient _httpClient;

        public DocumentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://mainserver.ziursoftware.com/");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "ae8bad44-7348-11ee-b962-0242ac120002");
        }

        public async Task<List<Documento>> ObtenerDocumentosAsync()
        {
            var documentos = await _httpClient.GetFromJsonAsync<List<Documento>>(
                "Ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos"
            );

            return documentos ?? new List<Documento>();
        }
    }
}
