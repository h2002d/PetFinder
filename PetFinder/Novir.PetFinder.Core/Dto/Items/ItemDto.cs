﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Items
{
    public class ItemDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Color { get; set; }
        public int CityId { get; set; }
        public int Type { get; set; }

    }
}
