using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class CursoModel
    {
        private CursoDAO cursoDAO;

        public CursoModel()
        {
            cursoDAO = new CursoDAO();
        }

        public List<CursoDTO> ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                List<CursoDTO> cursos = cursoDAO.ConsultarPorInstituicao(pCodigoInstituicao);

                if (cursos == null || cursos.Count <= 0)
                    throw new Exception("Nenhuma curso foi encontrado");

                return cursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CursoDTO Cadastrar(CursoDTO curso)
        {
            try
            {
                curso.Codigo = cursoDAO.Cadastrar(curso);

                if (curso.Codigo == null || curso.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar curso");

                return curso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CursoDTO Alterar(CursoDTO curso)
        {
            try
            {
                if (!cursoDAO.Alterar(curso))
                    throw new Exception("Erro ao alterar curso");

                return curso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Excluir(int pCodigo)
        {
            try
            {
                if(!cursoDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir curso");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}