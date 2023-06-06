using CS.Example.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Establece un OperationResult como éxito
        /// Se puede incluir un mensaje de forma opcional 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static dynamic ToSuccess(this IOperationResult op, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg)) op.Message = msg;
            op.Success = true;
            return op;
        }

        /// <summary>
        /// Establece un OperationResult como error
        /// Se puede incluir un mensaje de forma opcional 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static dynamic ToError(this IOperationResult op, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg)) op.Message = msg;
            op.Success = false;
            return op;
        }

    }
}
