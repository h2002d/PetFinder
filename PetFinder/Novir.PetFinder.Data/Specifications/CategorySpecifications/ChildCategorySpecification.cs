using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.CategorySpecifications
{
    public class ChildCategorySpecification : CommonSpecification<Category>
    {
        public ChildCategorySpecification(int id) : base(x => x.ParentId == id)
        {
        }
    }
}
