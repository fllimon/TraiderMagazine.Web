using TraiderMagazine.Web.Models;
using TraiderMagazine.Web.Models.Dto;

namespace TraiderMagazine.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto Response { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
