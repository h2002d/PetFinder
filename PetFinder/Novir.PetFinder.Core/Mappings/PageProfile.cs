using AutoMapper;
using Novir.PetFinder.Core.Dto.Common;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    public class PageProfile : Profile
    {
        public PageProfile()
        {
            CreateMap<PagingQueryDto, PagingQuery>();
            CreateMap<PagingQuery, PagingQueryDto>();
            CreateMap(typeof(PagingResultDto<>), typeof(PagingResult<>));
            CreateMap(typeof(PagingResult<>), typeof(PagingResultDto<>));
        }
    }
}
