using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Repository;

namespace SalaReuniao.Infra.Data.Repository
{
    public class SalaRepository : RepositoryBase, ISalaRepository
    {
        public void Adicionar(Sala entity)
        {
            var sql = new StringBuilder();
            sql.AppendLine(
                "Insert Into Salas(SalaId, Situacao, Descricao)");
            sql.AppendLine("Values(@SalaId, @Situacao, @Descricao)");
            var param = new DynamicParameters();
            param.Add("@SalaId", entity.SalaId);
            param.Add("@Situacao", entity.Situacao);
            param.Add("@Descricao", entity.Descricao);
  
            using (var conn = Connection)
            {
                conn.Open();
                conn.Query(sql.ToString(), param);
                conn.Close();
            }
        }

        public void Alterar(Sala entity)
        {
            var sql = new StringBuilder();
            sql.AppendLine("Update Salas Set");
            sql.AppendLine("Situacao = @Situacao,");
            sql.AppendLine("Descricao = @Descricao");
            sql.AppendLine("Where SalaId = @SalaId");

            var param = new DynamicParameters();
            param.Add("@SalaId", entity.SalaId);
            param.Add("@Situacao", entity.Situacao);
            param.Add("@Descricao", entity.Descricao);

            using (var conn = Connection)
            {
                conn.Open();
                conn.Query(sql.ToString(), param);
                conn.Close();
            }
        }

        public void Remover(Sala entity)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Query("Delete From Salas Where SalaId = @SalaId", new { entity.SalaId});
                conn.Close();
            }
        }

        public Sala GetById(Guid id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var sala = conn.Query<Sala>("Select * From Salas Where SalaId = @id", new { id }).FirstOrDefault();
                conn.Close();

                return sala;
            }
        }

        public IEnumerable<Sala> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var salas = conn.Query<Sala>("Select * From Salas");
                conn.Close();

                return salas;
            }
        }

        public IEnumerable<Sala> GetByDescricao(string descricao)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var salas = conn.Query<Sala>("Select * From Salas Where Descricao Like @descricao", new { descricao });
                conn.Close();

                return salas;
            }
        }
    }
}