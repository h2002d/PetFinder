using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Items
{
    public class SearchDto
    {
        public string Query { get; set; }
        public int Category { get; set; }
        public int Color { get; set; }
        public int City { get; set; }
        public int? Type { get; set; }

    }
}
