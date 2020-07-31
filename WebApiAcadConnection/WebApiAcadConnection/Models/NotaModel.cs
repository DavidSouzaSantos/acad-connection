using System;
using System.Collections.Generic;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class NotaModel
    {
        private NotaDAO notaDAO;

        public NotaModel()
        {
            notaDAO = new NotaDAO();
        }

        public List<NotaDTO> ConsultarPorAvaliacaoAluno(int pCodigoAvaliacao, int pCodigoAluno)
        {
            try
            {
                List<NotaDTO> nota = notaDAO.ConsultarPorAvaliacaoAluno(pCodigoAvaliacao, pCodigoAluno);

                if (nota == null || nota.Count <= 0)
                    throw new Exception("Nenhuma avaliação foi encontrado");

                return nota;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NotaDTO Cadastrar(NotaDTO nota)
        {
            try
            {
                nota.Codigo = notaDAO.Cadastrar(nota);

                if (nota.Codigo == null || nota.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar nota");

                return nota;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NotaDTO Atualizar(NotaDTO nota)
        {
            try
            {
                if (!notaDAO.Atualizar(nota))
                    throw new Exception("Erro ao alterar nota");

                return nota;
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
                if (!notaDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir nota");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}