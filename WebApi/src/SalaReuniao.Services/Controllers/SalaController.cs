using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.ViewModel;

namespace SalaReuniao.Services.Controllers
{
    [Route("api/[controller]")]
    public class SalaController : Controller
    {

        [Authorize("Bearer")]
        [HttpGet]
        [Route("obtertodos")]
        public ActionResult<IEnumerable<SalaViewModel>> Get([FromServices]ISalaAppService salaAppService)
        {
            return salaAppService.ObterTodas().ToList();
        }

        [Authorize("Bearer")]
        [HttpGet]
        [HttpGet("obterPorId/{id}")]
        public ActionResult<SalaViewModel> Get([FromServices]ISalaAppService salaAppService, string id)
        {
            return salaAppService.ObterPorId(Guid.Parse(id));
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("adicionar")]
        public object Post([FromServices]ISalaAppService salaAppService, 
            [FromBody] SalaViewModel salaViewModel)
        {
            return salaAppService.Adicionar(salaViewModel);
        }

        [Authorize("Bearer")]
        [HttpPut]
        [Route("alterar")]
        public object Put([FromServices]ISalaAppService salaAppService, 
            [FromBody] SalaViewModel salaViewModel)
        {
            salaAppService.Editar(salaViewModel);
            return new
            {
                errors = false,
                message = "Cadastro efetuado com sucesso."
            };
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("remover")]
        public object Delete([FromServices]ISalaAppService salaAppService,
            [FromBody] SalaViewModel salaViewModel)
        {
            salaAppService.Excluir(salaViewModel);
            return new
            {
                errors = false,
                message = "Cadastro efetuado com sucesso."
            };
        }
    }
}