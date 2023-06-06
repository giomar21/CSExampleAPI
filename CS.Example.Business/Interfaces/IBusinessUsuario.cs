using CS.Example.Common;
using CS.Example.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Business.Interfaces
{
    public interface IBusinessUsuario
    {
        OperationResult<UsuarioRootModel> Get(int initRow, int finishRow, string? word);

        OperationResult<UsuarioModel?> Post(UsuarioModel usuario);

        OperationResult<UsuarioModel?> Update(UsuarioModel usuario);

        OperationResult Delete(Guid idUsuario);
    }
}
