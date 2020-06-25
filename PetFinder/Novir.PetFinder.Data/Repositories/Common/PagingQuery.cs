using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Common
{
    public class PagingQuery
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
