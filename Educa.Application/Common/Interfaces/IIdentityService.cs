using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Educa.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ServerResult> CreateUserAsync(string userName, string password);

        Task<ServerResult> DeleteUserAsync(string userId);

        Task<JsonResult<string>> LoginUserAsync(LoginDto model);
    }
}
