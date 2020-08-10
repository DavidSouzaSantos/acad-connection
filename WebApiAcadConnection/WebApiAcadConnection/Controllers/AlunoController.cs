using System;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// AlunoController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Aluno")]
    public class AlunoController : ApiController
    {
        AlunoModel alunoModel = new AlunoModel();

        /// <summary>
        /// Consultar Aluno pelo código
        /// </summary>
        /// <remarks>
        /// Consultar Aluno pelo código
        /// </remarks>
        /// <param name="pCodigo">Código Aluno</param>
        /// <returns>Aluno</returns>
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

                AlunoDTO aluno = alunoModel.ConsultarPorCodigo(pCodigo);

                if (aluno == null)
                    return NotFound();

                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Aluno
        /// </summary>
        /// <remarks>
        /// Cadastrar Aluno
        /// </remarks>
        /// <param name="pAluno">Objeto Aluno</param>
        /// <returns>Aluno Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(AlunoDTO pAluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pAluno = alunoModel.Cadastrar(pAluno);
                return Ok(pAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Aluno
        /// </summary>
        /// <remarks>
        /// Alterar Aluno
        /// </remarks>
        /// <param name="pAluno">Objeto Aluno</param>
        /// <returns>Aluno Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(AlunoDTO pAluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pAluno = alunoModel.Alterar(pAluno);
                return Ok(pAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Aluno
        /// </summary>
        /// <remarks>
        /// Excluir Aluno
        /// </remarks>
        /// <param name="pCodigo">Código Aluno</param>
        /// <returns>Aluno Excluída</returns>
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

                pCodigo = alunoModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
