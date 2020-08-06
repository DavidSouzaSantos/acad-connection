using System;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [RoutePrefix("WebApiAcadConnection/Instituicao")]
    public class InstituicaoController : ApiController
    {
        InstituicaoModel disciplinaModel = new InstituicaoModel();

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
