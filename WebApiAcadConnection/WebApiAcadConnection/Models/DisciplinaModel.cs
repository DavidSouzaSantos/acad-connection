using System;
using System.Collections.Generic;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Disciplina
    ///</summary>
    public class DisciplinaModel
    {
        private DisciplinaDAO disciplinaDAO;

        ///<summary>
        ///Construtor Disciplina
        ///</summary>
        public DisciplinaModel()
        {
            disciplinaDAO = new DisciplinaDAO();
        }

        ///<summary>
        ///Método para Consultar Disciplina pela Instituição
        ///</summary>
        ///<param name="pCodigoInstituicao">Código da Instituição</param>
        public List<DisciplinaDTO> ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                List<DisciplinaDTO> disciplinas = disciplinaDAO.ConsultarPorInstituicao(pCodigoInstituicao);

                if (disciplinas == null || disciplinas.Count <= 0)
                    throw new Exception("Nenhuma disciplina foi encontrado");

                return disciplinas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Disciplina
        ///</summary>
        ///<param name="pDisciplina">Objeto do Disciplina</param>
        public DisciplinaDTO Cadastrar(DisciplinaDTO pDisciplina)
        {
            try
            {
                pDisciplina.Codigo = disciplinaDAO.Cadastrar(pDisciplina);

                if (pDisciplina.Codigo == null || pDisciplina.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar disciplina");

                return pDisciplina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Disciplina
        ///</summary>
        ///<param name="pDisciplina">Objeto do Disciplina</param>
        public DisciplinaDTO Alterar(DisciplinaDTO pDisciplina)
        {
            try
            {
                if (!disciplinaDAO.Alterar(pDisciplina))
                    throw new Exception("Erro ao alterar disciplina");

                return pDisciplina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Disciplina
        ///</summary>
        ///<param name="pCodigo">Código do Disciplina</param>
        public int Excluir(int pCodigo)
        {
            try
            {
                if (!disciplinaDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir disciplina");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}