using System;
using System.Web.Http;
using System.Web.Routing;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;


namespace WebApiAcadConnection.Controllers
{
    [RoutePrefix("WebApiAcadConnection/Usuario")]
    public class UsuarioController : ApiController
    {
        UsuarioModel usuarioModel = new UsuarioModel();

        [HttpGet]
        [Route("{pCodigo}")]
        public IHttpActionResult ConsultarUsuarioPorCodigo(int pCodigo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                UsuarioDTO usuario = usuarioModel.ConsultarPorCodigo(pCodigo);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

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
                return InternalServerError(ex);
            }
        }

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
                return InternalServerError(ex);
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

                pCodigo = usuarioModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
