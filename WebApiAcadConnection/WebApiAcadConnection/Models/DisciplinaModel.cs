using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class DisciplinaModel
    {
        private DisciplinaDAO disciplinaDAO;

        public DisciplinaModel()
        {
            disciplinaDAO = new DisciplinaDAO();
        }

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

        public DisciplinaDTO Cadastrar(DisciplinaDTO disciplina)
        {
            try
            {
                disciplina.Codigo = disciplinaDAO.Cadastrar(disciplina);

                if (disciplina.Codigo == null || disciplina.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar disciplina");

                return disciplina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DisciplinaDTO Alterar(DisciplinaDTO disciplina)
        {
            try
            {
                if (!disciplinaDAO.Alterar(disciplina))
                    throw new Exception("Erro ao alterar disciplina");

                return disciplina;
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