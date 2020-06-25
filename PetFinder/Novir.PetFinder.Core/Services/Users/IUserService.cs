using Novir.PetFinder.Core.Dto.Users;
using Novir.PetFinder.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Users
{
    public interface IUserService : ICommonService<int, UserDto>
    {
        Task<UserDto> GetByGuid(string id);
    }
}
