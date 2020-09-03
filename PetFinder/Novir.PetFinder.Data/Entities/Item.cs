using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Entities
{
    public class Item : FinderDatabaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserEntity User { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Color { get; set; }
        public int CityId { get; set; }
        public int Type { get; set; }
        public City City { get; set; }
    }
}
