using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Repository;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ValidationResult Adicionar(Usuario entity)
        {
            var resultadoValidacao = new ValidationResult();
            if (!entity.IsValid())
            {
                resultadoValidacao.AdicionarErro(entity.ResultadoValidacao);
                return resultadoValidacao;
            }
            _usuarioRepository.Adicionar(entity);
            return resultadoValidacao;

        }

        public void Alterar(Usuario entity)
        {
            _usuarioRepository.Alterar(entity);
        }

        public void Remover(Usuario entity)
        {
            _usuarioRepository.Remover(entity);
        }

        public Usuario GetById(Guid id)
        {
            return _usuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario ObterPorEmail(string email)
        {
            return _usuarioRepository.ObterPorEmail(email);
        }
    }
}