using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common.Interfaces
{
    /// <summary>
    /// Interfaz de objeto genérico de retorno para operaciones
    /// </summary>
    public interface IOperationResult
    {
        /// <summary>
        /// Indica si la operación se realizó exitosamente
        /// </summary>
        bool Success { set; get; }

        /// <summary>
        /// Mensage del error en caso de haber
        /// </summary>
        string Message { set; get; }
    }
}
