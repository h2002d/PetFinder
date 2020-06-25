using AutoMapper;
using Novir.PetFinder.Core.Dto.Users;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using Novir.PetFinder.Data.Repositories.Users;
using Novir.PetFinder.Data.Specifications.UserSpecifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Users
{
    public class UserService : CommonService<UserEntity, UserDto>, IUserService
    {
        private readonly IUserRepository _commonRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository commonRepository, IMapper mapper) : base(commonRepository, mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByGuid(string id)
        {
            return _mapper.Map<UserDto>(await _commonRepository.GetSingleBySpec(new UserGuidSpecification(id)));
        }
    }
}
