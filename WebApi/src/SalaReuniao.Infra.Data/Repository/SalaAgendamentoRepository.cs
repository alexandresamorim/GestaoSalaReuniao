using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Repository;

namespace SalaReuniao.Infra.Data.Repository
{
    public class SalaAgendamentoRepository : RepositoryBase, ISalaAgendamentoRepository
    {
        public void Adicionar(SalaAgendamento entity)
        {
            var sql = new StringBuilder();
            sql.AppendLine(
                "Insert Into SalaAgendamentos(SalaAgendamentoId, SalaId, UsuarioId, Descricao, Data, HoraInicio, HoraFinal)");
            sql.AppendLine("Values(@SalaAgendamentoId, @SalaId, @UsuarioId, @Descricao, @Data, @HoraInicio, @HoraFinal)");
            var param = new DynamicParameters();
            param.Add("@SalaAgendamentoId", entity.SalaAgendamentoId);
            param.Add("@SalaId", entity.SalaId);
            param.Add("@UsuarioId", entity.UsuarioId);
            param.Add("@Descricao", entity.Descricao);
            param.Add("@Data", entity.Data);
            param.Add("@HoraInicio", entity.Data.AddHours(entity.HoraInicio.TimeOfDay.Hours).AddMinutes(entity.HoraInicio.TimeOfDay.Minutes));
            param.Add("@HoraFinal", entity.Data.AddHours(entity.HoraFinal.TimeOfDay.Hours).AddMinutes(entity.HoraFinal.TimeOfDay.Minutes));

            using (var conn = Connection)
            {
                conn.Open();
                conn.Query(sql.ToString(), param);
                conn.Close();
            }
        }

        public void Alterar(SalaAgendamento entity)
        {
            var sql = new StringBuilder();
            sql.AppendLine("Update SalaAgendamentos Set");
            sql.AppendLine("SalaId = @SalaId,");
            sql.AppendLine("UsuarioId = @UsuarioId,");
            sql.AppendLine("Descricao = @Descricao,");
            sql.AppendLine("Data = @Data,");
            sql.AppendLine("HoraInicio = @HoraInicio,");
            sql.AppendLine("HoraFinal = @HoraFinal");
            sql.AppendLine("Where SalaAgendamentoId = @SalaAgendamentoId");

            var param = new DynamicParameters();
            param.Add("@SalaAgendamentoId", entity.SalaAgendamentoId);
            param.Add("@SalaId", entity.SalaId);
            param.Add("@UsuarioId", entity.UsuarioId);
            param.Add("@Descricao", entity.Descricao);
            param.Add("@Data", entity.Data.Date);
            param.Add("@HoraInicio", entity.HoraInicio);
            param.Add("@HoraFinal", entity.HoraFinal);

            using (var conn = Connection)
            {
                conn.Open();
                conn.Query(sql.ToString(), param);
                conn.Close();
            }
        }

        public void Remover(SalaAgendamento entity)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Query("Delete From SalaAgendamentos Where SalaAgendamentoId = @SalaAgendamentoId", new { entity.SalaAgendamentoId });
                conn.Close();
            }
        }

        public SalaAgendamento GetById(Guid id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var agendamento = conn.Query<SalaAgendamento>("Select * From SalaAgendamentos Where SalaAgendamentoId = @id", new { id }).FirstOrDefault();
                conn.Close();

                return agendamento;
            }
        }

        public IEnumerable<SalaAgendamento> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var agendamentos = conn.Query<SalaAgendamento>("Select * From SalaAgendamentos");
                conn.Close();

                return agendamentos;
            }
        }

        public IEnumerable<SalaAgendamento> ObterPorData(Guid salaId, DateTime data)
        {

            var sql = "Select * From SalaAgendamentos Inner Join Usuarios On SalaAgendamentos.UsuarioId = Usuarios.UsuarioId Where SalaId  = @salaId And Data = @data";
            using (var conn = Connection)
            {
                conn.Open();
                var agendamentos = conn.Query<SalaAgendamento, Usuario, SalaAgendamento>(sql,
                    (a, u) =>
                    {
                        a.Usuario = u;
                        return a;
                    }, new { salaId, data }, splitOn: "SalaAgendamentoId, UsuarioId");
                conn.Close();

                return agendamentos;
            }
        }

        public IEnumerable<SalaAgendamento> ObterPorIntervalo(Guid salaId, DateTime dataHoraInicio, DateTime datahoraFinal)
        {
            var sql = "Select * From SalaAgendamentos " +
                      "Inner Join Usuarios On SalaAgendamentos.UsuarioId = Usuarios.UsuarioId " +
                      "Where SalaId  = @salaId " +
                      "And (HoraInicio Between @dataHoraInicio And @datahoraFinal Or HoraFinal Between  @dataHoraInicio And @datahoraFinal)";

            var param = new DynamicParameters();
            param.Add("@salaId", salaId);
            param.Add("@dataHoraInicio", dataHoraInicio);
            param.Add("@datahoraFinal", datahoraFinal);


            using (var conn = Connection)
            {
                conn.Open();
                var agendamentos = conn.Query<SalaAgendamento, Usuario, SalaAgendamento>(sql,
                    (a, u) =>
                    {
                        a.Usuario = u;
                        return a;
                    }, param, splitOn: "SalaAgendamentoId, UsuarioId");
                conn.Close();

                return agendamentos;
            }
        }
    }
}