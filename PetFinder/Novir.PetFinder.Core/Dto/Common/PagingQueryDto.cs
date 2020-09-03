using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Common
{
    public class PagingQueryDto
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
