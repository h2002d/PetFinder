using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Users
{
    public class UserRepository : EFDataRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
