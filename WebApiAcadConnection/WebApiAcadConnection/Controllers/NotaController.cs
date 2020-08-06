﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Controllers
{
    [RoutePrefix("WebApiAcadConnection/Nota")]
    public class NotaController : ApiController
    {
        NotaModel notaModel = new NotaModel();

        [HttpGet]
        [Route("ConsultarPorAvaliacaoAluno/{pCodigoAvaliacao}/{pCodigoAvaliacao}")]
        public IHttpActionResult ConsultarPorAvaliacaoAluno(int pCodigoAvaliacao, int pCodigoAluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                List<NotaDTO> Notas = notaModel.ConsultarPorAvaliacaoAluno(pCodigoAvaliacao, pCodigoAluno);

                if (Notas == null)
                    return NotFound();

                return Ok(Notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IHttpActionResult Cadastrar(NotaDTO pNota)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pNota = notaModel.Cadastrar(pNota);
                return Ok(pNota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IHttpActionResult Alterar(NotaDTO pNota)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(m => m.Errors).ToString());

                pNota = notaModel.Alterar(pNota);
                return Ok(pNota);
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

                pCodigo = notaModel.Excluir(pCodigo);
                return Ok(pCodigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}