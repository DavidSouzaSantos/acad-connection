using System;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Instituição
    ///</summary>
    public class InstituicaoModel
    {
        private InstituicaoDAO disciplinaDAO;

        ///<summary>
        ///Construtor InstituicaoModel
        ///</summary>
        public InstituicaoModel()
        {
            disciplinaDAO = new InstituicaoDAO();
        }

        ///<summary>
        ///Método para Consultar Instituição pelo Código
        ///</summary>
        ///<param name="pCodigo">Código do Endereço</param>
        public InstituicaoDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                InstituicaoDTO disciplinas = disciplinaDAO.ConsultarPorCodigo(pCodigo);

                if (disciplinas == null)
                    throw new Exception("Instituição não encontrado");

                return disciplinas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Instituição
        ///</summary>
        ///<param name="pInstituicao">Objeto do Instituição</param>
        public InstituicaoDTO Cadastrar(InstituicaoDTO pInstituicao)
        {
            try
            {
                pInstituicao.Codigo = disciplinaDAO.Cadastrar(pInstituicao);

                if (pInstituicao.Codigo == null || pInstituicao.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar instituição");

                return pInstituicao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Instituição
        ///</summary>
        ///<param name="pInstituicao">Objeto do Instituição</param>
        public InstituicaoDTO Alterar(InstituicaoDTO pInstituicao)
        {
            try
            {
                if (!disciplinaDAO.Alterar(pInstituicao))
                    throw new Exception("Erro ao alterar instituição");

                return pInstituicao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Instituição
        ///</summary>
        ///<param name="pCodigo">Objeto do Instituição</param>
        public int Excluir(int pCodigo)
        {
            try
            {
                if (!disciplinaDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir instituição");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}