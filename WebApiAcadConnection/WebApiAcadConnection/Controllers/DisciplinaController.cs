using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// DisciplinaController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Disciplina")]
    public class DisciplinaController : ApiController
    {
        DisciplinaModel disciplinaModel = new DisciplinaModel();

        /// <summary>
        /// Consultar Disciplina pela Instituição
        /// </summary>
        /// <remarks>
        /// Consultar Disciplina pela Instituição
        /// </remarks>
        /// <param name="pCodigoInstituicao">Código da Intituição</param>
        /// <returns>Disciplinas da Instituição</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpGet]
        [Route("ConsultarPorInstituicao/{pCodigoInstituicao}")]
        public IHttpActionResult ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<DisciplinaDTO> disciplinas = disciplinaModel.ConsultarPorInstituicao(pCodigoInstituicao);

                if (disciplinas == null || disciplinas.Count <= 0)
                    return NotFound();

                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Disciplina
        /// </summary>
        /// <remarks>
        /// Cadastrar Disciplina
        /// </remarks>
        /// <param name="pDisciplina">Objeto Disciplina</param>
        /// <returns>Disciplina Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(DisciplinaDTO pDisciplina)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pDisciplina = disciplinaModel.Cadastrar(pDisciplina);
                return Ok(pDisciplina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Disciplina
        /// </summary>
        /// <remarks>
        /// Alterar Disciplina
        /// </remarks>
        /// <param name="pDisciplina">Objeto Disciplina</param>
        /// <returns>Disciplina Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(DisciplinaDTO pDisciplina)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pDisciplina = disciplinaModel.Alterar(pDisciplina);
                return Ok(pDisciplina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Disciplina
        /// </summary>
        /// <remarks>
        /// Excluir Disciplina
        /// </remarks>
        /// <param name="pCodigo">Código da Disciplina</param>
        /// <returns>Disciplina Excluída</returns>
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

                pCodigo = disciplinaModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
