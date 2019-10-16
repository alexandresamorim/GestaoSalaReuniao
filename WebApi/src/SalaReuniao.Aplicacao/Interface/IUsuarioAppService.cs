using System;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;

namespace SalaReuniao.Aplicacao.Interface
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel ObterPorId(Guid usuarioId);
        UsuarioViewModel ObterPorEmail(string email);
        ValidationAppResult Registar(UsuarioViewModel usuarioView);
        void Alterar(UsuarioViewModel usuarioView);
        void Excluir(UsuarioViewModel usuarioView);
    }
}