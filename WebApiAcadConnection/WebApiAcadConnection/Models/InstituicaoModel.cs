using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class InstituicaoModel
    {
        private InstituicaoDAO disciplinaDAO;

        public InstituicaoModel()
        {
            disciplinaDAO = new InstituicaoDAO();
        }

        public InstituicaoDTO ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                InstituicaoDTO disciplinas = disciplinaDAO.ConsultarPorCodigo(pCodigoInstituicao);

                if (disciplinas == null)
                    throw new Exception("Instituição não encontrado");

                return disciplinas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InstituicaoDTO Cadastrar(InstituicaoDTO instituicao)
        {
            try
            {
                instituicao.Codigo = disciplinaDAO.Cadastrar(instituicao);

                if (instituicao.Codigo == null || instituicao.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar instituição");

                return instituicao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InstituicaoDTO Atualizar(InstituicaoDTO instituicao)
        {
            try
            {
                instituicao.Codigo = disciplinaDAO.Atualizar(instituicao);

                if (instituicao.Codigo == null || instituicao.Codigo.Value == 0)
                    throw new Exception("Erro ao alterar instituição");

                return instituicao;
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
                int codigo = disciplinaDAO.Excluir(pCodigo);

                if (codigo == 0)
                    throw new Exception("Erro ao excluir instituição");

                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}