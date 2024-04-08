using ActivoFijo.Core.Dto.CAT;
using ActivoFijo.Core.Dto.Generico;
using ActivoFijo.Core.Interfaces;
using ActivoFijo.Data.DataContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivoFijo.Data.Repository.CAT
{
    public class EspecificoGastoRepository: IOperacion<EspecificoGastoDto>
    {
        private readonly IMapper map;
        private readonly ActivoFijoModel db;

        public EspecificoGastoRepository(IMapper _map, ActivoFijoModel _db)
        {
            map = _map ?? throw new ArgumentNullException(nameof(_map));
            db = _db ?? throw new ArgumentNullException(nameof(_db));
        }

        public async Task<GenericResponse<EspecificoGastoDto>> Guardar(EspecificoGastoDto item)
        {
            GenericResponse<EspecificoGastoDto> response;
            try
            {
                var entity = map.Map<TBL_EspecificoGasto>(item);
                db.TBL_EspecificoGasto.Add(entity);
                await db.SaveChangesAsync();

                response = new GenericResponse<EspecificoGastoDto>()
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
                response = new GenericResponse<EspecificoGastoDto>()
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

        public async Task<GenericResponse<EspecificoGastoDto>> Actualizar(EspecificoGastoDto item)
        {
            GenericResponse<EspecificoGastoDto> response;
            try
            {
                TBL_EspecificoGasto usr = map.Map<TBL_EspecificoGasto>(item);
                db.Entry(usr).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                response = new GenericResponse<EspecificoGastoDto>()
                {
                    Item = item,
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"   
                    }
                };
            }catch(Exception ex)
            {
                response = new GenericResponse<EspecificoGastoDto>()
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

        public async Task<GenericResponse<EspecificoGastoDto>> Eliminar(object id)
        {
            GenericResponse<EspecificoGastoDto> response;
            try
            {
                var entity = await db.TBL_EspecificoGasto.FindAsync(Convert.ToInt32(id));
                db.TBL_EspecificoGasto.Remove(entity);
                await db.SaveChangesAsync();
                response = new GenericResponse<EspecificoGastoDto>()
                {
                    Item = map.Map<EspecificoGastoDto>(entity),
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"
                    }
                };

            }catch(Exception ex)
            {
                response = new GenericResponse<EspecificoGastoDto>()
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

        public async Task<GenericResponse<EspecificoGastoDto>> ObtenerPorId(object id)
        {
            GenericResponse<EspecificoGastoDto> response;
            try
            {
                var item = map.Map<EspecificoGastoDto>(await db.TBL_EspecificoGasto.FindAsync(Convert.ToInt32(id)));
                response = new GenericResponse<EspecificoGastoDto>()
                {
                    Item = item,
                    Status = new ResponseStatus()
                    {
                        HttpCode = System.Net.HttpStatusCode.OK,
                        Message = "OK"
                    }
                };
            }catch(Exception ex)
            {
                response = new GenericResponse<EspecificoGastoDto>()
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
