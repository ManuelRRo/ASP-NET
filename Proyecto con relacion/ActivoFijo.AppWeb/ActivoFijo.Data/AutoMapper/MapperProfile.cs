
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
            // Tabla TBL_ClasificacionActivoFijo
            CreateMap<ClasificacionActivoFijoDto, TBL_ClasificacionActivoFijo>()
                .ForMember(d => d.TBL_EspecificoGasto, m => m.Ignore())
                .ReverseMap();
            // Fin

            // Tabla TBL_EspecificoGasto
            CreateMap<EspecificoGastoDto, TBL_EspecificoGasto>()
                .ForMember(d => d.TBL_ClasificacionActivoFijos, m => m.Ignore())
                .ReverseMap();
            // Fin
        }
    }
}
