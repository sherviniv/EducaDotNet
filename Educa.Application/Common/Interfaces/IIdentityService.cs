using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using System.Threading.Tasks;

namespace Educa.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<DataResult<UserDto>> GetUserAsync(string userId);
        Task<ServerResult> CreateUserAsync(UserDto model);
        Task<ServerResult> UpdateUserAsync(UserDto model);
        Task<ServerResult> DeleteUserAsync(string userId);
        Task<DataResult<string>> LoginUserAsync(LoginDto model);
    }
}
