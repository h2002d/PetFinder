using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Common
{
    public interface IDataRepository<T> : ICommonRepository<int, T>
        where T : FinderDatabaseEntity, new()
    {
    }
}
