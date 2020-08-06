using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [RoutePrefix("WebApiAcadConnection/Disciplina")]
    public class DisciplinaController : ApiController
    {
        DisciplinaModel disciplinaModel = new DisciplinaModel();

        [HttpGet]
        [Route("ConsultarPorInstituicao/{pCodigoInstituicao}")]
        public IHttpActionResult ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                List<DisciplinaDTO> disciplinas = disciplinaModel.ConsultarPorInstituicao(pCodigoInstituicao);

                if (disciplinas == null || disciplinas.Count <= 0)
                    return NotFound();

                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(DisciplinaDTO pDisciplina)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pDisciplina = disciplinaModel.Cadastrar(pDisciplina);
                return Ok(pDisciplina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(DisciplinaDTO pDisciplina)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pDisciplina = disciplinaModel.Alterar(pDisciplina);
                return Ok(pDisciplina);
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
