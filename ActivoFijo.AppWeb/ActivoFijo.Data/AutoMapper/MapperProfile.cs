
using ActivoFijo.Core.Dto.CAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ActivoFijo.Data.DataContext;

namespace ActivoFijo.Data.AutoMapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<EspecificoGastoDto, TBL_EspecificoGasto>();
        }
    }
}
