using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Entities
{
    public class Subscriber : FinderDatabaseEntity
    {
        public string Email { get; set; }
    }
}
