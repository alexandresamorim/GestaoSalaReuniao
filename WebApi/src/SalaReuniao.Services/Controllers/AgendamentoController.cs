using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.ViewModel;

namespace SalaReuniao.Services.Controllers
{
    [Route("api/[controller]")]
    public class AgendamentoController : Controller
    {
        [Authorize("Bearer")]
        [HttpGet]
        [Route("obterPorData/{salaGuid}/{data}")]
        public ActionResult<IEnumerable<SalaAgendamentoViewModel>> Get([FromServices]ISalaAgendamentoAppService salaAgendamentoAppService, Guid salaGuid, DateTime data)
        {
            return salaAgendamentoAppService.ObterPorData(salaGuid, data).ToList();
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("adicionar")]
        public object Post([FromServices]ISalaAgendamentoAppService salaAgendamentoAppService,
            [FromBody] SalaAgendamentoViewModel salaAgendamentoView)
        {
            var result = salaAgendamentoAppService.Adicionar(salaAgendamentoView);
            return result;
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("remover")]
        public object Remover([FromServices]ISalaAgendamentoAppService salaAgendamentoAppService,
            [FromBody] SalaAgendamentoViewModel salaAgendamentoView)
        {
            salaAgendamentoAppService.Excluir(salaAgendamentoView);
            return new
            {
                errors = false,
                message = "Cadastro efetuado com sucesso."
            };
        }
    }
}