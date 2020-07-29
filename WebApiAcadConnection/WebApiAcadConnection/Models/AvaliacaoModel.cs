using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class AvaliacaoModel
    {
        private AvaliacaoDAO avaliacaoDAO;

        public AvaliacaoModel()
        {
            avaliacaoDAO = new AvaliacaoDAO();
        }

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

        public AvaliacaoDTO Cadastrar(AvaliacaoDTO avaliacao)
        {
            try
            {
                avaliacao.Codigo = avaliacaoDAO.Cadastrar(avaliacao);

                if (avaliacao.Codigo == null || avaliacao.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar avaliação");

                return avaliacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AvaliacaoDTO Atualizar(AvaliacaoDTO avaliacao)
        {
            try
            {
                avaliacao.Codigo = avaliacaoDAO.Atualizar(avaliacao);

                if (avaliacao.Codigo == null || avaliacao.Codigo.Value == 0)
                    throw new Exception("Erro ao alterar avaliação");

                return avaliacao;
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
                int codigo = avaliacaoDAO.Excluir(pCodigo);

                if (codigo == 0)
                    throw new Exception("Erro ao excluir avaliação");

                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}