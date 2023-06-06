using CS.Example.Business.Interfaces;
using CS.Example.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.Example.API.Controllers
{
    /// <summary>
    /// Servicios para la gestión de Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IBusinessUsuario _businessUsuario;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessUsuario"></param>
        public UsuarioController(IBusinessUsuario businessUsuario)
        {
            _businessUsuario = businessUsuario;
        }

        /// <summary>
        /// Devuelve un objeto de tipo <see cref="UsuarioRootModel"/> con la lista de Usuarios en función al paginado y texto de búsqueda
        /// </summary>
        /// <param name="initRow"></param>
        /// <param name="finishRow"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<UsuarioRootModel> Get([FromQuery] int initRow, int finishRow, string? word)
        {
            var result = _businessUsuario.Get(initRow, finishRow, word);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuario)
        {
            var result = _businessUsuario.Post(usuario);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<UsuarioModel> Put([FromBody] UsuarioModel usuario)
        {
            var result = _businessUsuario.Update(usuario);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        /// <summary>
        /// Elimina (logicamente) un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<bool> Delete([FromQuery] Guid idUsuario)
        {
            var result = _businessUsuario.Delete(idUsuario);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok();
        }

    }
}
