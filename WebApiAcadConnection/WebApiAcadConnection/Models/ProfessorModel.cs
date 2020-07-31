using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class ProfessorModel
    {
        private ProfessorDAO professorDAO;

        public ProfessorModel()
        {
            professorDAO = new ProfessorDAO();
        }

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

        public ProfessorDTO Cadastrar(ProfessorDTO professor)
        {
            try
            {
                professor.Codigo = professorDAO.Cadastrar(professor);

                if (professor.Codigo == null || professor.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar professor");

                return professor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProfessorDTO Atualizar(ProfessorDTO professor)
        {
            try
            {
                if (!professorDAO.Atualizar(professor))
                    throw new Exception("Erro ao alterar professor");

                return professor;
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