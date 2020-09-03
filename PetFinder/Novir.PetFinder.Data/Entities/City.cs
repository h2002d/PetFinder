using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Novir.PetFinder.Data.Entities
{
    public class City : FinderDatabaseEntity
    {
        public string Name { get; set; }
        public string Name_EN { get; set; }
        public string Name_RU { get; set; }
    }
}
