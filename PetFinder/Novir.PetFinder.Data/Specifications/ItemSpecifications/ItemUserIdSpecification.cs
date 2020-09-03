using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.ItemSpecifications
{
    public class ItemUserIdSpecification : CommonSpecification<Item>
    {
        public ItemUserIdSpecification(string userId) : base(x => x.UserId.Equals(userId))
        {
        }
    }
}
