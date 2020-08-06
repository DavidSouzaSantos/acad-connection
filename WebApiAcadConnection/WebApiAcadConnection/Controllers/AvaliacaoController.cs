using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [RoutePrefix("WebApiAcadConnection/Avaliacao")]
    public class AvaliacaoController : ApiController
    {
        AvaliacaoModel avaliacaoModel = new AvaliacaoModel();

        [HttpGet]
        [Route("{pCodigo}")]
        public IHttpActionResult ConsultarPorCurso(int pCodigo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<AvaliacaoDTO> Avaliacoes = avaliacaoModel.ConsultarPorCurso(pCodigo);

                if (Avaliacoes == null)
                    return NotFound();

                return Ok(Avaliacoes);
            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(AvaliacaoDTO pAvaliacao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pAvaliacao = avaliacaoModel.Cadastrar(pAvaliacao);
                return Ok(pAvaliacao);
            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(AvaliacaoDTO pAvaliacao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pAvaliacao = avaliacaoModel.Alterar(pAvaliacao);
                return Ok(pAvaliacao);
            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{pCodigo}/Excluir")]
        public IHttpActionResult Excluir(int pCodigo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pCodigo = avaliacaoModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
