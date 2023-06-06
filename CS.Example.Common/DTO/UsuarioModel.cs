using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common.DTO
{
    /// <summary>
    /// Modelo con propiedades de un Usuario
    /// </summary>
    public class UsuarioModel
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno
        /// </summary>
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido materno
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Salario
        /// </summary>
        public decimal? Salario { get; set; }

        /// <summary>
        /// CURP del usuario
        /// </summary>
        public string Curp { get; set; }

        /// <summary>
        /// Teléfono
        /// </summary>
        public string? Telefono { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de actualización
        /// </summary>
        public DateTime? FechaActualizacion { get; set; }

        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Devuelve el nombre completo
        /// </summary>
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
            }
        }
    }
}
