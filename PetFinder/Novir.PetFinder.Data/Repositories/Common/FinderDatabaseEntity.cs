using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Common
{
    public abstract class FinderDatabaseEntity
    {
        [Key]
        public int Id { get; set; }
        public FinderDatabaseEntity()
        {
        }
    }
}
