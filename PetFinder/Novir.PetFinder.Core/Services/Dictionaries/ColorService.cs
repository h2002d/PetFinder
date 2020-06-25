using AutoMapper;
using Novir.PetFinder.Core.Dto.Dictionaries;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using Novir.PetFinder.Data.Repositories.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Services.Dictionaries
{
    public class ColorService : CommonService<Color, ColorDto>, IColorService
    {
        public ColorService(IColorRepository commonRepository, IMapper mapper) : base(commonRepository, mapper)
        {
        }
    }
}
