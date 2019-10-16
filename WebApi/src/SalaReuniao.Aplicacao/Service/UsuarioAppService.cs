using System;
using AutoMapper;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Service;

namespace SalaReuniao.Aplicacao.Service
{
    public class UsuarioAppService :BaseAppService, IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IMapper mapper, IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public UsuarioViewModel ObterPorId(Guid usuarioId)
        {
            return _mapper.Map<UsuarioViewModel>(_usuarioService.GetById(usuarioId));
        }

        public UsuarioViewModel ObterPorEmail(string email)
        {
            return _mapper.Map<UsuarioViewModel>(_usuarioService.ObterPorEmail(email));
        }

        public ValidationAppResult Registar(UsuarioViewModel usuarioView)
        {
            var usuario = _mapper.Map<Usuario>(usuarioView);
            
            var result = _usuarioService.Adicionar(usuario);
            if (!result.IsValid)
                return DomainToApplicationResult(result);


            return DomainToApplicationResult(result);
        }

        public void Alterar(UsuarioViewModel usuarioView)
        {
            var usuario = _mapper.Map<Usuario>(usuarioView);
            _usuarioService.Alterar(usuario);
        }

        public void Excluir(UsuarioViewModel usuarioView)
        {
            var usuario = _mapper.Map<Usuario>(usuarioView);
            _usuarioService.Remover(usuario);
        }
    }
}