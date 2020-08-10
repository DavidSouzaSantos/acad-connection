using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// NotaController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Nota")]
    public class NotaController : ApiController
    {
        NotaModel notaModel = new NotaModel();

        /// <summary>
        /// Consultar Notas pelo código
        /// </summary>
        /// <remarks>
        /// Consultar Notas pelo código
        /// </remarks>
        /// <param name="pCodigoAvaliacao">Código da Avaliação</param>
        /// <param name="pCodigoAluno">Código do Aluno</param>
        /// <returns>Notas</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpGet]
        [Route("ConsultarPorAvaliacaoAluno/{pCodigoAvaliacao}/{pCodigoAluno}")]
        public IHttpActionResult ConsultarPorAvaliacaoAluno(int pCodigoAvaliacao, int pCodigoAluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<NotaDTO> Notas = notaModel.ConsultarPorAvaliacaoAluno(pCodigoAvaliacao, pCodigoAluno);

                if (Notas == null)
                    return NotFound();

                return Ok(Notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Nota
        /// </summary>
        /// <remarks>
        /// Cadastrar Nota
        /// </remarks>
        /// <param name="pNota">Objeto Nota</param>
        /// <returns>Nota Cadastrada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(NotaDTO pNota)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pNota = notaModel.Cadastrar(pNota);
                return Ok(pNota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Nota
        /// </summary>
        /// <remarks>
        /// Alterar Nota
        /// </remarks>
        /// <param name="pNota">Objeto Nota</param>
        /// <returns>Nota Alterada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(NotaDTO pNota)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pNota = notaModel.Alterar(pNota);
                return Ok(pNota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Nota Endereço
        /// </summary>
        /// <remarks>
        /// Nota Endereço
        /// </remarks>
        /// <param name="pCodigo">Código da Nota</param>
        /// <returns>Nota Excluída</returns>
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

                pCodigo = notaModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
