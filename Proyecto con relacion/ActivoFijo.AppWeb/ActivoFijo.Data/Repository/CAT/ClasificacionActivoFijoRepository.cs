using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivoFijo.Core.Dto.CAT;
using ActivoFijo.Core.Dto.Generico;
using ActivoFijo.Core.Interfaces;
using ActivoFijo.Data.DataContext;
using AutoMapper;

namespace ActivoFijo.Data.Repository.CAT
{
    public class ClasificacionActivoFijoRepository: IOperacion<ClasificacionActivoFijoDto>
    {
        private readonly IMapper map;
        private readonly ActivoFijoModel db;

        public ClasificacionActivoFijoRepository(IMapper _map, ActivoFijoModel _db)
        {
            map = _map ?? throw new ArgumentException(nameof(_map));
            db = _db ?? throw new ArgumentException(nameof(_db));
        }

        public async Task<GenericResponse<ClasificacionActivoFijoDto>> Guardar(ClasificacionActivoFijoDto item)
        {
            GenericResponse<ClasificacionActivoFijoDto> response;
            try
            {
                var entity = map.Map<TBL_ClasificacionActivoFijo>(item);
                db.TBL_ClasificacionActivoFijo.Add(entity);
                await db.SaveChangesAsync();
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Item = item,
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"
                    }
                };
            }catch (Exception ex) 
            {
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = $"{ex.Message} {ex.InnerException?.Message}"
                    }
                };
            }
            return response;
        }

        public async Task<GenericResponse<ClasificacionActivoFijoDto>> Actualizar(ClasificacionActivoFijoDto item)
        {
            GenericResponse<ClasificacionActivoFijoDto> response;
            try
            {
                TBL_ClasificacionActivoFijo usr = map.Map<TBL_ClasificacionActivoFijo>(item);
                db.Entry(usr).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Item = item,
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"
                    }
                };
            }catch (Exception ex)
            {
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = $"{ex.Message} {ex.InnerException?.Message}"
                    }
                };
            }

            return response;
        }

        public async Task<GenericResponse<ClasificacionActivoFijoDto>> Eliminar(object id)
        {
            GenericResponse<ClasificacionActivoFijoDto> response;
            try
            {
                var entity = await db.TBL_ClasificacionActivoFijo.FindAsync(Convert.ToInt32(id));
                db.TBL_ClasificacionActivoFijo.Remove(entity);
                await db.SaveChangesAsync();
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Item = map.Map<ClasificacionActivoFijoDto>(entity),
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"
                    }
                };
            }catch (Exception ex)
            {
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = $"{ex.Message} {ex.InnerException?.Message}"
                    }
                };
            }
            return response;
        }

        public async Task<GenericResponse<ClasificacionActivoFijoDto>> ObtenerPorId(object id)
        {
            GenericResponse<ClasificacionActivoFijoDto> response;
            try
            {
                var item = map.Map<ClasificacionActivoFijoDto>(await db.TBL_ClasificacionActivoFijo.FindAsync(Convert.ToInt32(id)));
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Item = item,
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"
                    }
                };
            }
            catch (Exception ex)
            {
                response = new GenericResponse<ClasificacionActivoFijoDto>()
                {
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = $"{ex.Message} {ex.InnerException?.Message}"
                    }
                };

            }

            return response;
        }
    }
}
