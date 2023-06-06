using CS.Example.Data.Interfaces;
using CS.Example.Data.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Data.Services
{
    /// <summary>
    /// Servicio para la gestión de Usuarios
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public UsuarioService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Eliminado lógico de un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool Delete(Guid idUsuario)
        {
            using (var context = new SqlConnection(_configuration.GetConnectionString("CSTestDB")))
            {
                var result = context.ExecuteScalar<int>("SP_DELETE_USUARIO",
                 new { IdUsuario = idUsuario },
                 commandType: System.Data.CommandType.StoredProcedure);

                return result == 0;
            }
        }

        /// <summary>
        /// Devuelve la lista de Usuarios en función al paginado y texto de búsqueda
        /// </summary>
        /// <param name="initRow"></param>
        /// <param name="finishRow"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<Model.Usuario> Get(int initRow, int finishRow, string? word)
        {
            using (var context = new SqlConnection(_configuration.GetConnectionString("CSTestDB")))
            {
                var result = context.Query<Model.Usuario>("SP_SELECT_USUARIOS",
                 new { word, initRow, finishRow },
                 commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        /// <summary>
        /// Devuelve la cantidad de Usuarios en función texto de búsqueda
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetCount(string? word)
        {
            using (var context = new SqlConnection(_configuration.GetConnectionString("CSTestDB")))
            {
                var result = context.Query<int>("SP_SELECT_USUARIOS_COUNT",
                 new { word },
                 commandType: System.Data.CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario? Create(Usuario usuario)
        {
            if (usuario == null)
            {
                return usuario;
            }

            usuario.IdUsuario = Guid.NewGuid();

            using (var context = new SqlConnection(_configuration.GetConnectionString("CSTestDB")))
            {
                var result = context.ExecuteScalar<int>("SP_CREATE_USUARIO",
                 new
                 {
                     usuario.ApellidoMaterno,
                     usuario.ApellidoPaterno,
                     FechaCreacion = DateTime.Now,
                     usuario.Curp,
                     usuario.Nombre,
                     usuario.Salario,
                     usuario.Telefono,
                     usuario.IdUsuario
                 },
                 commandType: System.Data.CommandType.StoredProcedure);

                return result == 0 ? usuario : null;
            }
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario? Update(Usuario usuario)
        {
            if (usuario == null)
            {
                return usuario;
            }

            using (var context = new SqlConnection(_configuration.GetConnectionString("CSTestDB")))
            {
                var result = context.ExecuteScalar<int>("SP_UPDATE_USUARIO",
                 new
                 {
                     usuario.ApellidoMaterno,
                     usuario.ApellidoPaterno,
                     FechaActualizacion = DateTime.Now,
                     usuario.Curp,
                     usuario.Nombre,
                     usuario.Salario,
                     usuario.Telefono,
                     usuario.IdUsuario
                 },
                 commandType: System.Data.CommandType.StoredProcedure);

                return result == 0 ? usuario : null;
            }
        }
    }
}
