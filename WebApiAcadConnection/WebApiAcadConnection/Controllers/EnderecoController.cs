using System;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Endereco")]
    public class EnderecoController : ApiController
    {
        EnderecoModel enderecoModel = new EnderecoModel();

        [HttpGet]
        [Route("{pCodigo}")]
        public IHttpActionResult ConsultarEnderecoPorCodigo(int pCodigo)
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
