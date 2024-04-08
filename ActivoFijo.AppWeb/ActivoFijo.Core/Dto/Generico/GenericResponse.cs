using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivoFijo.Core.Dto.Generico
{
    public class GenericResponse<T>
    {
        public T Item { get; set; }
        public ResponseStatus Status { get; set; }
    }
}
