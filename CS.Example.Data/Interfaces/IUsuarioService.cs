using CS.Example.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Data.Interfaces
{
    /// <summary>
    /// Interface para la gestión de Usuarios
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        ///  Devuelve la lista de Usuarios en función al paginado y texto de búsqueda
        /// </summary>
        /// <param name="initRow"></param>
        /// <param name="finishRow"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        List<Model.Usuario> Get(int initRow, int finishRow, string? word);

        /// <summary>
        /// Devuelve la cantidad de Usuarios en función texto de búsqueda
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        int GetCount(string? word);

        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Usuario? Create(Usuario usuario);

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Usuario? Update(Usuario usuario);

        /// <summary>
        /// Eliminado lógico de un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        bool Delete(Guid idUsuario);
    }
}
