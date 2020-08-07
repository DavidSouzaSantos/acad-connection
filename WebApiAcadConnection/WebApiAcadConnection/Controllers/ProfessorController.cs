using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [Authorize]
    [RoutePrefix("WebApiAcadConnection/Professor")]
    public class ProfessorController : ApiController
    {
        ProfessorModel professorModel = new ProfessorModel();

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
