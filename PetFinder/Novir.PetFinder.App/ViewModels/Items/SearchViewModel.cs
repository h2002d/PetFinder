using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Items
{
    public class SearchViewModel
    {
        public string Query { get; set; }
        public int Category { get; set; }
        public int Color { get; set; }
        public int City { get; set; }
        public int? TypeId { get; set; }

    }
}
