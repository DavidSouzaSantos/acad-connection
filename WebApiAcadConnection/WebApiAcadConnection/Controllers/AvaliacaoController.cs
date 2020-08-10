using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// AvaliacaoController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Avaliacao")]
    public class AvaliacaoController : ApiController
    {
        AvaliacaoModel avaliacaoModel = new AvaliacaoModel();

        /// <summary>
        /// Consultar Avaliação pelo código
        /// </summary>
        /// <remarks>
        /// Consultar Avaliação pelo código
        /// </remarks>
        /// <param name="pCodigo">Código da Avaliação</param>
        /// <returns>Avaliação</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
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

        /// <summary>
        /// Cadastrar Avaliação
        /// </summary>
        /// <remarks>
        /// Cadastrar Avaliação
        /// </remarks>
        /// <param name="pAvaliacao">Objeto Avaliação</param>
        /// <returns>Avaliação Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
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

        /// <summary>
        /// Alterar Avaliação
        /// </summary>
        /// <remarks>
        /// Alterar Avaliação
        /// </remarks>
        /// <param name="pAvaliacao">Objeto Avaliação</param>
        /// <returns>Avaliação Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
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

        /// <summary>
        /// Excluir Avaliação
        /// </summary>
        /// <remarks>
        /// Excluir Avaliação
        /// </remarks>
        /// <param name="pCodigo">Código da Avaliação</param>
        /// <returns>Avaliação Excluída</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
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
