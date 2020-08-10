using System;
using System.Collections.Generic;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Nota
    ///</summary>
    public class NotaModel
    {
        private NotaDAO notaDAO;

        ///<summary>
        ///Construtor NotaDAO
        ///</summary>
        public NotaModel()
        {
            notaDAO = new NotaDAO();
        }

        ///<summary>
        ///Método para Consultar Nota pela Avaliação e Aluno
        ///</summary>
        ///<param name="pCodigoAvaliacao">Código da Avaliação</param>
        ///<param name="pCodigoAluno">Código do Aluno</param>
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

        ///<summary>
        ///Método para Cadastrar Nota
        ///</summary>
        ///<param name="pNota">Objeto da Nota</param>
        public NotaDTO Cadastrar(NotaDTO pNota)
        {
            try
            {
                pNota.Codigo = notaDAO.Cadastrar(pNota);

                if (pNota.Codigo == null || pNota.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar nota");

                return pNota;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Nota
        ///</summary>
        ///<param name="pNota">Objeto da Nota</param>
        public NotaDTO Alterar(NotaDTO pNota)
        {
            try
            {
                if (!notaDAO.Alterar(pNota))
                    throw new Exception("Erro ao alterar nota");

                return pNota;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Nota
        ///</summary>
        ///<param name="pCodigo">Código da Nota</param>
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