using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Novir.PetFinder.Data.Entities
{
    public class ItemImage: FinderDatabaseEntity
    {
        public int ItemId { get; set; }
        public string Source { get; set; }
    }
}
