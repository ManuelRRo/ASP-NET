using ActivoFijo.Core.Dto.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivoFijo.Core.Interfaces
{
    public interface IOperacion<T>
    {
        Task<GenericResponse<T>> Guardar(T item);
        Task<GenericResponse<T>> Actualizar(T item);
        Task<GenericResponse<T>> Eliminar(object id);
        Task<GenericResponse<T>> ObtenerPorId(object id);
    }
}
