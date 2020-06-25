using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Novir.PetFinder.Data.Entities
{
    public class ItemImage: FinderDatabaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Source { get; set; }
    }
}
