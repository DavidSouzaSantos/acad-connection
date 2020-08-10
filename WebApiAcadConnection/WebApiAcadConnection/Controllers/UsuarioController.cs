using System;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Enums;
using WebApiAcadConnection.Models;


namespace WebApiAcadConnection.Controllers
{
    /// <summary>
    /// UsuarioController
    /// </summary>
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Usuario")]
    public class UsuarioController : ApiController
    {
        UsuarioModel usuarioModel = new UsuarioModel();

        /// <summary>
        /// Consultar Usuário pelo Código
        /// </summary>
        /// <remarks>
        /// Consultar Usuário pelo Código
        /// </remarks>
        /// <param name="pCodigo">Código do Usuário</param>
        /// <returns>Usuário</returns>
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

                UsuarioDTO usuario = usuarioModel.ConsultarPorCodigo(pCodigo);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Usuário
        /// </summary>
        /// <remarks>
        /// Cadastrar Usuário
        /// </remarks>
        /// <param name="pUsuario">Objeto Usuário</param>
        /// <returns>Usuário Cadastrado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(UsuarioDTO pUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pUsuario = usuarioModel.Cadastrar(pUsuario);
                return Ok(pUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar Usuário
        /// </summary>
        /// <remarks>
        /// Alterar Usuário
        /// </remarks>
        /// <param name="pUsuario">Objeto Usuário</param>
        /// <returns>Usuário Alterado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="400">Erro</response>
        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(UsuarioDTO pUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                pUsuario = usuarioModel.Alterar(pUsuario);
                return Ok(pUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir Usuário
        /// </summary>
        /// <remarks>
        /// Excluir Usuário
        /// </remarks>
        /// <param name="pCodigo">Código do Usuário</param>
        /// <returns>Usuário Excluído</returns>
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

                pCodigo = usuarioModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
