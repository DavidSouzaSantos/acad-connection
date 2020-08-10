using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Avaliação
    ///</summary>
    public class AvaliacaoModel
    {
        private AvaliacaoDAO avaliacaoDAO;

        ///<summary>
        ///Construtor AvaliacaoModel
        ///</summary>
        public AvaliacaoModel()
        {
            avaliacaoDAO = new AvaliacaoDAO();
        }

        ///<summary>
        ///Método para Consultar Avaliações pelo Curso
        ///</summary>
        ///<param name="pCodigoCurso">Código do Curso</param>mo
        public List<AvaliacaoDTO> ConsultarPorCurso(int pCodigoCurso)
        {
            try
            {
                List<AvaliacaoDTO> avaliacao = avaliacaoDAO.ConsultarPorCurso(pCodigoCurso);

                if (avaliacao == null || avaliacao.Count <= 0)
                    throw new Exception("Nenhuma avaliação foi encontrado");

                return avaliacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Avaliação
        ///</summary>
        ///<param name="pAvaliacao">Objeto da Avaliação</param>
        public AvaliacaoDTO Cadastrar(AvaliacaoDTO pAvaliacao)
        {
            try
            {
                pAvaliacao.Codigo = avaliacaoDAO.Cadastrar(pAvaliacao);

                if (pAvaliacao.Codigo == null || pAvaliacao.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar avaliação");

                return pAvaliacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Avaliação
        ///</summary>
        ///<param name="pAvaliacao">Objeto da Avaliação</param>
        public AvaliacaoDTO Alterar(AvaliacaoDTO pAvaliacao)
        {
            try
            {
                if (!avaliacaoDAO.Alterar(pAvaliacao))
                    throw new Exception("Erro ao alterar avaliação");

                return pAvaliacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Avaliação
        ///</summary>
        ///<param name="pCodigo">Código da Avaliação</param>
        public int Excluir(int pCodigo)
        {
            try
            {
                if (!avaliacaoDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir avaliação");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}