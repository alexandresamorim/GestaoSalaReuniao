using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Repository;

namespace SalaReuniao.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public void Adicionar(Usuario entity)
        {
            var sql = new StringBuilder();
            sql.AppendLine(
                "Insert Into Usuarios(UsuarioId, Email, Username, Nome, Sobrenome, Senha)");
            sql.AppendLine("Values(@UsuarioId, @Email, @Username, @Nome, @Sobrenome, @Senha)");
            var param = new DynamicParameters();
            param.Add("@UsuarioId", entity.UsuarioId);
            param.Add("@Email", entity.Email);
            param.Add("@Username", entity.Username);
            param.Add("@Nome", entity.Nome);
            param.Add("@Sobrenome", entity.Sobrenome);
            param.Add("@Senha", entity.Senha);

            using (var conn = Connection)
            {
                conn.Open();
                conn.Query(sql.ToString(), param);
                conn.Close();
            }
        }

        public void Alterar(Usuario entity)
        {
            var sql = new StringBuilder();
            sql.AppendLine("Update Usuarios Set");
            sql.AppendLine("Email = @Email,");
            sql.AppendLine("Username = @Username,");
            sql.AppendLine("Nome = @Nome,");
            sql.AppendLine("Sobrenome = @Sobrenome,");
            sql.AppendLine("Senha = @Senha");
            sql.AppendLine("Where UsuarioId = @UsuarioId");

            var param = new DynamicParameters();
            param.Add("@UsuarioId", entity.UsuarioId);
            param.Add("@Email", entity.Email);
            param.Add("@Username", entity.Username);
            param.Add("@Nome", entity.Nome);
            param.Add("@Sobrenome", entity.Sobrenome);
            param.Add("@Senha", entity.Senha);

            using (var conn = Connection)
            {
                conn.Open();
                conn.Query(sql.ToString(), param);
                conn.Close();
            }
        }

        public void Remover(Usuario entity)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Query("Delete From Usuarios Where UsuarioId = @UsuarioId", new { entity.UsuarioId });
                conn.Close();
            }
        }

        public Usuario GetById(Guid id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var usuario = conn.Query<Usuario>("Select * From Usuarios Where UsuarioId = @id", new { id }).FirstOrDefault();
                conn.Close();

                return usuario;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var usuario = conn.Query<Usuario>("Select * From Usuarios");
                conn.Close();

                return usuario;
            }
        }

        public Usuario ObterPorEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var usuario = conn.Query<Usuario>("Select * From Usuarios Where Email = @email", new { email }).FirstOrDefault();
                conn.Close();

                return usuario;
            }
        }
    }
}