using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Items
{
    public class ItemImageDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Source { get; set; }
    }
}
