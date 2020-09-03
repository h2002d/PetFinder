using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.CategorySpecifications
{
    public class ParentCategorySpecification : CommonSpecification<Category>
    {
        public ParentCategorySpecification() : base(x => x.ParentId == null || x.ParentId == 0)
        {
        }
    }
}
