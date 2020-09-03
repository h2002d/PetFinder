using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.ItemSpecifications
{
    public class ItemDetailsSingleSpecification : CommonSpecification<Item>
    {
        public ItemDetailsSingleSpecification(int Id) : base(x => x.Id == Id)
        {
            AddInclude(x => x.City);
            AddInclude(x => x.User);
            AddInclude(x => x.Category);
        }
    }
}
