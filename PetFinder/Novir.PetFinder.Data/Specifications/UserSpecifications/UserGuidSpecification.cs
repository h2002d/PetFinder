using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.UserSpecifications
{
    public class UserGuidSpecification : CommonSpecification<UserEntity>
    {
        public UserGuidSpecification(string Id) : base(x => x.Id == Id)
        {
        }
    }
}
