using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [RoutePrefix("WebApiAcadConnection/Curso")]
    public class CursoController : ApiController
    {
        CursoModel CursoModel = new CursoModel();

        [HttpGet]
        [Route("ConsultarPorInstituicao/{pCodigo}")]
        public IHttpActionResult ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                List<CursoDTO> cursos = CursoModel.ConsultarPorInstituicao(pCodigoInstituicao);

                if (cursos == null)
                    return NotFound();

                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(CursoDTO pCurso)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pCurso = CursoModel.Cadastrar(pCurso);
                return Ok(pCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(CursoDTO pCurso)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pCurso = CursoModel.Alterar(pCurso);
                return Ok(pCurso);
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

                pCodigo = CursoModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
