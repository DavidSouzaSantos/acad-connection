using System;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// EnderecoController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Endereco")]
    public class EnderecoController : ApiController
    {
        EnderecoModel enderecoModel = new EnderecoModel();

        /// <summary>
        /// Consultar Endereço pelo código
        /// </summary>
        /// <remarks>
        /// Consultar Endereço pelo código
        /// </remarks>
        /// <param name="pCodigo">Código do Endereço</param>
        /// <returns>Endereço</returns>
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

                EnderecoDTO endereco = enderecoModel.ConsultarPorCodigo(pCodigo);

                if (endereco == null)
                    return NotFound();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Endereço
        /// </summary>
        /// <remarks>
        /// Cadastrar Endereço
        /// </remarks>
        /// <param name="pEndereco">Objeto Endereço</param>
        /// <returns>Endereço Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(EnderecoDTO pEndereco)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pEndereco = enderecoModel.Cadastrar(pEndereco);
                return Ok(pEndereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Endereço
        /// </summary>
        /// <remarks>
        /// Alterar Endereço
        /// </remarks>
        /// <param name="pEndereco">Objeto Endereço</param>
        /// <returns>Endereço Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(EnderecoDTO pEndereco)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pEndereco = enderecoModel.Alterar(pEndereco);
                return Ok(pEndereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Endereço
        /// </summary>
        /// <remarks>
        /// Excluir Endereço
        /// </remarks>
        /// <param name="pCodigo">Código do Endereço</param>
        /// <returns>Endereço Excluído</returns>
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

                pCodigo = enderecoModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
