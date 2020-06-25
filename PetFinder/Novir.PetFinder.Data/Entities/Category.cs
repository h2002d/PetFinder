﻿using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Novir.PetFinder.Data.Entities
{
    public class Category : FinderDatabaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}