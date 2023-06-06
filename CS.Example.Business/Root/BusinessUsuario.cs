using CS.Example.Business.Interfaces;
using CS.Example.Common.DTO;
using CS.Example.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Example.Data.Interfaces;
using CS.Example.Data.Model;

namespace CS.Example.Business.Root
{
    /// <summary>
    /// Capa de negocio para la gestión de Usuarios
    /// </summary>
    public class BusinessUsuario : IBusinessUsuario
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="usuarioService"></param>
        public BusinessUsuario(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        /// <summary>
        /// Eliminado lógico de un Usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public OperationResult Delete(Guid idUsuario)
        {
            var result = new OperationResult();

            try
            {
                var rDelete = this._usuarioService.Delete(idUsuario);
                if (!rDelete) return result.ToError("Sucedió un error al eliminar el usuario.");
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Error al eliminar usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Devuelve una lista de usuarios en función a los filtros de entrada
        /// </summary>
        /// <param name="initRow"></param>
        /// <param name="finishRow"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public OperationResult<UsuarioRootModel> Get(int initRow, int finishRow, string? word)
        {
            var result = new OperationResult<UsuarioRootModel>() { Data = new UsuarioRootModel() };

            var listUsuarios = new List<UsuarioModel>();

            try
            {
                #region Get Data

                var rUsuarios = this._usuarioService.Get(initRow, finishRow, word);

                if (rUsuarios == null)
                {
                    return result.ToError("No se encontraron usuarios.");
                }

                rUsuarios.ForEach(s => listUsuarios.Add(new UsuarioModel()
                {
                    Activo = s.Activo,
                    ApellidoMaterno = s.ApellidoMaterno,
                    ApellidoPaterno = s.ApellidoPaterno,
                    FechaActualizacion = s.FechaActualizacion,
                    FechaCreacion = s.FechaCreacion,
                    Curp = s.Curp,
                    Nombre = s.Nombre,
                    IdUsuario = s.IdUsuario,
                    Salario = s.Salario,
                    Telefono = s.Telefono
                }));

                result.Data.Usuarios = listUsuarios;

                #endregion

                #region Get Count

                var rCount = this._usuarioService.GetCount(word);
                result.Data.Count = rCount;

                #endregion

                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Error al obtener el listado de usuarios: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public OperationResult<UsuarioModel?> Post(UsuarioModel usuario)
        {
            var result = new OperationResult<UsuarioModel>();

            try
            {
                if (usuario == null) return result.ToError("No se ingresó el objeto Usuario.");

                var rCreate = this._usuarioService.Create(new Usuario()
                {
                    ApellidoMaterno = usuario.ApellidoMaterno,
                    ApellidoPaterno = usuario.ApellidoPaterno,
                    Curp = usuario.Curp,
                    Nombre = usuario.Nombre,
                    Salario = usuario.Salario,
                    Telefono = usuario.Telefono,
                    IdUsuario = usuario.IdUsuario
                });

                if (rCreate == null) return result.ToError("Sucedió un error al crear el Usuario.");

                result.Data = new UsuarioModel()
                {
                    ApellidoMaterno = rCreate.ApellidoMaterno,
                    ApellidoPaterno = rCreate.ApellidoPaterno,
                    FechaCreacion = rCreate.FechaCreacion,
                    FechaActualizacion = rCreate.FechaActualizacion,
                    Curp = rCreate.Curp,
                    Nombre = rCreate.Nombre,
                    Salario = rCreate.Salario,
                    Telefono = rCreate.Telefono,
                    IdUsuario = rCreate.IdUsuario
                };

                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Sucedió un error al crear el Usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public OperationResult<UsuarioModel?> Update(UsuarioModel usuario)
        {
            var result = new OperationResult<UsuarioModel>();

            try
            {
                if (usuario == null) return result.ToError("No se ingresó el objeto Usuario.");

                var rUpdate = this._usuarioService.Update(new Usuario()
                {
                    ApellidoMaterno = usuario.ApellidoMaterno,
                    ApellidoPaterno = usuario.ApellidoPaterno,
                    Curp = usuario.Curp,
                    Nombre = usuario.Nombre,
                    Salario = usuario.Salario,
                    Telefono = usuario.Telefono,
                    IdUsuario = usuario.IdUsuario
                });

                if (rUpdate == null) return result.ToError("Sucedió un error al actualizar el Usuario.");

                result.Data = new UsuarioModel()
                {
                    ApellidoMaterno = rUpdate.ApellidoMaterno,
                    ApellidoPaterno = rUpdate.ApellidoPaterno,
                    FechaCreacion = rUpdate.FechaCreacion,
                    FechaActualizacion = rUpdate.FechaActualizacion,
                    Curp = rUpdate.Curp,
                    Nombre = rUpdate.Nombre,
                    Salario = rUpdate.Salario,
                    Telefono = rUpdate.Telefono,
                    IdUsuario = rUpdate.IdUsuario
                };

                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Sucedió un error al actualizar el Usuario: {ex.Message}");
            }
        }
    }
}
