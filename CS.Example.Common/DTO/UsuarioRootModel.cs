using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common.DTO
{
    /// <summary>
    /// Modelo para la gestión del listado de Usuarios y la cantidad 
    /// </summary>
    public class UsuarioRootModel
    {
        public List<UsuarioModel>? Usuarios { get; set; }

        public int Count { get; set; }
    }
}
