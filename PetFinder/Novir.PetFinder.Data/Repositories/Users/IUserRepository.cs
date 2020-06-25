using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Users
{
    public interface IUserRepository : IDataRepository<UserEntity>
    {
    }
}
