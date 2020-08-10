using System;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// InstituicaoController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Instituicao")]
    public class InstituicaoController : ApiController
    {
        InstituicaoModel disciplinaModel = new InstituicaoModel();

        /// <summary>
        /// Consultar Instituição pelo código
        /// </summary>
        /// <remarks>
        /// Consultar Intituição pelo código
        /// </remarks>
        /// <param name="pCodigo">Código da Intituição</param>
        /// <returns>Intituição</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpGet]
        [Route("{pCodigo}")]
        public IHttpActionResult ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                InstituicaoDTO instituicao = disciplinaModel.ConsultarPorCodigo(pCodigo);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Instituição
        /// </summary>
        /// <remarks>
        /// Cadastrar Instituição
        /// </remarks>
        /// <param name="pInstituicao">Objeto Instituição</param>
        /// <returns>Instituição Cadastrada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(InstituicaoDTO pInstituicao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pInstituicao = disciplinaModel.Cadastrar(pInstituicao);
                return Ok(pInstituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Instituição
        /// </summary>
        /// <remarks>
        /// Alterar Instituição
        /// </remarks>
        /// <param name="pInstituicao">Objeto Instituição</param>
        /// <returns>Instituição Alterada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(InstituicaoDTO pInstituicao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pInstituicao = disciplinaModel.Alterar(pInstituicao);
                return Ok(pInstituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Instituição
        /// </summary>
        /// <remarks>
        /// Excluir Instituição
        /// </remarks>
        /// <param name="pCodigo">Código da Instituição</param>
        /// <returns>Instituição Excluída</returns>
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
