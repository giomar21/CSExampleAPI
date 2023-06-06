using CS.Example.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common
{

    /// <summary>
    /// Objeto de salida estandar para procesos
    /// </summary>
    public class OperationResult : IOperationResult
    {
        /// <summary>
        /// Indica éxito o error en una operación
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Mensage de retorno en una operación
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Objeto genérico de salida estandar para procesos que contiene datos
    /// </summary>
    public class OperationResult<T> : IOperationResult
    {
        /// <summary>
        /// Datos de retorno, de tipo genérico
        /// </summary>
        public T Data { set; get; }
        /// <summary>
        /// Indica éxito o error en una operación
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Mensage de retorno en una operación
        /// </summary>
        public string Message { get; set; }
    }
}
