using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Professor
    ///</summary>
    public class ProfessorModel
    {
        private ProfessorDAO professorDAO;

        ///<summary>
        ///Construtor ProfessorModel
        ///</summary>
        public ProfessorModel()
        {
            professorDAO = new ProfessorDAO();
        }

        ///<summary>
        ///Método para Consultar Professor pela Instituição
        ///</summary>
        ///<param name="pCodigoInstituicao">Código da Instituição</param>
        public List<ProfessorDTO> ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                List<ProfessorDTO> professor = professorDAO.ConsultarPorInstituicao(pCodigoInstituicao);

                if (professor == null || professor.Count <= 0)
                    throw new Exception("Nenhuma professor foi encontrado");

                return professor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Professor
        ///</summary>
        ///<param name="pProfessor">Objeto do Professor</param>
        public ProfessorDTO Cadastrar(ProfessorDTO pProfessor)
        {
            try
            {
                pProfessor.Codigo = professorDAO.Cadastrar(pProfessor);

                if (pProfessor.Codigo == null || pProfessor.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar professor");

                return pProfessor;
            }
            catch (Exception ex)
            {
                throw ex;  
            }
        }

        ///<summary>
        ///Método para Alterar Professor
        ///</summary>
        ///<param name="pProfessor">Objeto do Professor</param>
        public ProfessorDTO Alterar(ProfessorDTO pProfessor)
        {
            try
            {
                if (!professorDAO.Alterar(pProfessor))
                    throw new Exception("Erro ao alterar professor");

                return pProfessor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Professor
        ///</summary>
        ///<param name="pCodigo">Código do Professor</param>
        public int Excluir(int pCodigo)
        {
            try
            {
                if (!professorDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir professor");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}