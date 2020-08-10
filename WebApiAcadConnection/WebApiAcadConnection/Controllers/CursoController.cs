using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// CursoController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Curso")]
    public class CursoController : ApiController
    {
        CursoModel CursoModel = new CursoModel();

        /// <summary>
        /// Consultar Curso pela Instituição
        /// </summary>
        /// <remarks>
        /// Consultar Curso pela Instituição
        /// </remarks>
        /// <param name="pCodigoInstituicao">Código da Intituição</param>
        /// <returns>Cursos da Instituição</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpGet]
        [Route("ConsultarPorInstituicao/{pCodigo}")]
        public IHttpActionResult ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<CursoDTO> cursos = CursoModel.ConsultarPorInstituicao(pCodigoInstituicao);

                if (cursos == null)
                    return NotFound();

                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Curso
        /// </summary>
        /// <remarks>
        /// Cadastrar Curso
        /// </remarks>
        /// <param name="pCurso">Objeto Curso</param>
        /// <returns>Curso Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(CursoDTO pCurso)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pCurso = CursoModel.Cadastrar(pCurso);
                return Ok(pCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Curso
        /// </summary>
        /// <remarks>
        /// Alterar Curso
        /// </remarks>
        /// <param name="pCurso">Objeto Curso</param>
        /// <returns>Curso Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(CursoDTO pCurso)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pCurso = CursoModel.Alterar(pCurso);
                return Ok(pCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Curso
        /// </summary>
        /// <remarks>
        /// Excluir Curso
        /// </remarks>
        /// <param name="pCodigo">Código do Curso</param>
        /// <returns>Curso Excluído</returns>
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

                pCodigo = CursoModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
