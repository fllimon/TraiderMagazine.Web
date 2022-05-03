using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TraiderMagazine.Web.Models;
using TraiderMagazine.Web.Models.Dto;
using TraiderMagazine.Web.Services.IServices;

namespace TraiderMagazine.Web.Services
{
    public class BaseServise : IBaseService
    {
        public BaseServise(IHttpClientFactory clientFactory)
        {
            Response = new ResponseDto();
            HttpClient = clientFactory;
        }

        public ResponseDto Response { get; set; }

        public IHttpClientFactory HttpClient { get; set; }  

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("TraderApi");
                HttpRequestMessage request = new HttpRequestMessage();
                request.Headers.Add("Accept", "application/json");
                request.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                        Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }

                HttpResponseMessage response = null;

                switch (apiRequest.Type)
                {
                    case MetaData.ApiType.POST:
                        request.Method = HttpMethod.Post;
                        break;
                    case MetaData.ApiType.PUT:
                        request.Method = HttpMethod.Put;
                        break;
                    case MetaData.ApiType.DELETE:
                        request.Method = HttpMethod.Delete;
                        break;
                    default:
                        request.Method = HttpMethod.Get;
                        break;
                }

                response = await client.SendAsync(request);

                var apiContent = await response.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error",
                    Errors = new List<string> { ex.ToString() }
                };

                var result = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(result);
                
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
