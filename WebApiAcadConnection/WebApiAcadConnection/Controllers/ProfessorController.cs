using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// ProfessorController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Professor")]
    public class ProfessorController : ApiController
    {
        ProfessorModel professorModel = new ProfessorModel();

        /// <summary>
        /// Consultar Professores pelo Instituição
        /// </summary>
        /// <remarks>
        /// Consultar Professores pelo Instituição
        /// </remarks>
        /// <param name="pCodigoInstituicao">Código da Intituição</param>
        /// <returns>Professores da Instituição</returns>
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

                List<ProfessorDTO> professores = professorModel.ConsultarPorInstituicao(pCodigoInstituicao);

                if (professores == null)
                    return NotFound();

                return Ok(professores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Professor
        /// </summary>
        /// <remarks>
        /// Cadastrar Professor
        /// </remarks>
        /// <param name="pProfessor">Objeto Professor</param>
        /// <returns>Professor Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(ProfessorDTO pProfessor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pProfessor = professorModel.Cadastrar(pProfessor);
                return Ok(pProfessor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Professor
        /// </summary>
        /// <remarks>
        /// Alterar Professor
        /// </remarks>
        /// <param name="pProfessor">Objeto Professor</param>
        /// <returns>Professor Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(ProfessorDTO pProfessor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pProfessor = professorModel.Alterar(pProfessor);
                return Ok(pProfessor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Professor
        /// </summary>
        /// <remarks>
        /// Excluir Professor
        /// </remarks>
        /// <param name="pCodigo">Código do Professor</param>
        /// <returns>Professor Excluído</returns>
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
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pCodigo = professorModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
