﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [Authorize]
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
                    return BadRequest(ModelState);

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
                    return BadRequest(ModelState);

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
                    return BadRequest(ModelState);

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
