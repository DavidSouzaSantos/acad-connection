using System;
using System.Collections.Generic;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Curso
    ///</summary>
    public class CursoModel
    {
        private CursoDAO cursoDAO;

        ///<summary>
        ///Construtor CursoModel
        ///</summary>
        public CursoModel()
        {
            cursoDAO = new CursoDAO();
        }

        ///<summary>
        ///Método para Consultar Cursos pela Instituição
        ///</summary>
        ///<param name="pCodigoInstituicao">Código da Instituição</param>
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

        ///<summary>
        ///Método para Cadastrar Curso
        ///</summary>
        ///<param name="pCurso">Objeto do Curso</param>
        public CursoDTO Cadastrar(CursoDTO pCurso)
        {
            try
            {
                pCurso.Codigo = cursoDAO.Cadastrar(pCurso);

                if (pCurso.Codigo == null || pCurso.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar curso");

                return pCurso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Curso
        ///</summary>
        ///<param name="pCurso">Objeto do Curso</param>
        public CursoDTO Alterar(CursoDTO pCurso)
        {
            try
            {
                if (!cursoDAO.Alterar(pCurso))
                    throw new Exception("Erro ao alterar curso");

                return pCurso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Curso
        ///</summary>
        ///<param name="pCodigo">Código do Curso</param>
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